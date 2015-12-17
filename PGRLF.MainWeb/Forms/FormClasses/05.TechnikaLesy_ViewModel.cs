using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using PGRLF.MainWeb.Forms.Validation;
using PGRLF.MainWeb.Forms.FormClasses.SubClasses;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    [Serializable]
    public class TechnikaLesy_ViewModel : AbstractForm
    {
        public TechnikaLesy_ViewModel()
        {

        }

        public bool JePravnickaOsoba { get; set; }
        public bool JeSvazekObec { get; set; }

        public FyzickaOsoba fyzickaOsoba { get; set; }
        public PravnickaOsoba pravnickaOsoba { get; set; }
        public Kontakt kontakt { get; set; }

        public override string ApplicantEmail
        {
            get
            {
                return kontakt.Email;
            }
        }

        public override void Process()
        {
            if (JePravnickaOsoba)
            {
                fyzickaOsoba.nullovani();
                pravnickaOsoba.nastavMistoPodnikani();
            }
            else
            {
                pravnickaOsoba.nullovani();
                fyzickaOsoba.nastavMistoPodnikani();
            }

            if (Identifikator == null || Identifikator == Guid.Empty)
            {
                Identifikator = Guid.NewGuid();
            }
            DatumPodani = DateTime.Now;
        }

        public override byte[] SavePDF()
        {
            var form = new PDFform(HttpContext.Current.Server.MapPath("~/Content/FormTemplates/ProgramZemedelec2015.pdf"));
            MemoryStream ms = new MemoryStream();
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            formValues.Add("FORodneCislo", (fyzickaOsoba.FORodneCislo ?? "").Replace("/", ""));
            formValues.Add("FODatumNarozeni", fyzickaOsoba.FODatumNarozeni != null ? fyzickaOsoba.FODatumNarozeni.Value.ToString("ddMMyyyy") : "");
            formValues.Add("FOIC", fyzickaOsoba.FOIC ?? "");
            formValues.Add("FODIC", fyzickaOsoba.FODIC ?? "");
            formValues.Add("FOTitulPredJmenem", fyzickaOsoba.FOTitulPredMenom ?? "");
            formValues.Add("FOPrijmeni", fyzickaOsoba.FOPrijmeni ?? "");
            formValues.Add("FOTitulZaJmenem", fyzickaOsoba.FOTitulZaMenom ?? "");
            formValues.Add("FOJmeno", fyzickaOsoba.FOJmeno ?? "");
            formValues.Add("TPUlice", fyzickaOsoba.FOTPUlice ?? "");
            formValues.Add("TPCisloPopisne", fyzickaOsoba.FOTPCisloPopisne ?? "");
            formValues.Add("TPPSC", fyzickaOsoba.FOTPPSC ?? "");
            formValues.Add("TPCisloOrientacni", fyzickaOsoba.FOTPCisloOrientacni ?? "");
            formValues.Add("TPObec", fyzickaOsoba.FOTPObec ?? "");
            formValues.Add("MistoPodnikani", !String.IsNullOrEmpty(fyzickaOsoba.FOMPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        fyzickaOsoba.FOMPUlice,
                        fyzickaOsoba.FOMPCisloPopisne,
                        fyzickaOsoba.FOMPCisloOrientacni,
                        fyzickaOsoba.FOMPPSC,
                        fyzickaOsoba.FOMPObec,
                        fyzickaOsoba.FOMPKraj)
                    : "");
            formValues.Add("TPTelefon1", kontakt.Telefon1 ?? "");
            formValues.Add("TPTelefon2", kontakt.Telefon2 ?? "");
            formValues.Add("TPFax", kontakt.Fax ?? "");
            formValues.Add("TPEmail", kontakt.Email ?? "");

            formValues.Add("POObchodneJmeno", pravnickaOsoba.POObchodniJmeno ?? "");
            formValues.Add("POIC", pravnickaOsoba.POIC ?? "");
            formValues.Add("PODIC", pravnickaOsoba.PODIC ?? "");
            var zodpovedneosoby = "";
            foreach(ZodpovednaOsoba zodpovednaOsoba in pravnickaOsoba.POZodpovedneOsoby)
            {
                zodpovedneosoby += String.Format("{0}{1} {2}{3} - {4}", string.IsNullOrEmpty(zodpovednaOsoba.POZOTitulPredJmenem) ? "" : zodpovednaOsoba.POZOTitulPredJmenem + " ", zodpovednaOsoba.POZOJmeno, zodpovednaOsoba.POZOPrijmeni, string.IsNullOrEmpty(zodpovednaOsoba.POZOTitulZaJmenem) ? "" : " " + zodpovednaOsoba.POZOTitulZaJmenem, zodpovednaOsoba.POZOFunkce);
            }

            formValues.Add("POZodpovedneOsoby", zodpovedneosoby);
            formValues.Add("POMistoPodnikani", !String.IsNullOrEmpty(pravnickaOsoba.POMPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        pravnickaOsoba.POMPUlice,
                        pravnickaOsoba.POMPCisloPopisne,
                        pravnickaOsoba.POMPCisloOrientacni,
                        pravnickaOsoba.POMPPSC,
                        pravnickaOsoba.POMPObec,
                        pravnickaOsoba.POMPKraj)
                    : "");
            if (pravnickaOsoba.POPocetSpolecniku != 0)
                formValues.Add("POPocetSpolecniku", pravnickaOsoba.POPocetSpolecniku.ToString("D"));
            if (pravnickaOsoba.POZakladniKapital != 0)
                formValues.Add("POZakladniKapital", pravnickaOsoba.POZakladniKapital.ToString("D"));

            formValues.Add("SSUlice", pravnickaOsoba.POSSUlice ?? "");
            formValues.Add("SSPSC", pravnickaOsoba.POSSPSC ?? "");
            formValues.Add("SSCisloPopisne", pravnickaOsoba.POSSCisloPopisne ?? "");
            formValues.Add("SSCisloOrientacni", pravnickaOsoba.POSSCisloOrientacni ?? "");
            formValues.Add("SSObec", pravnickaOsoba.POSSObec ?? "");
            formValues.Add("SSTelefon1", kontakt.Telefon1 ?? "");
            formValues.Add("SSTelefon2", kontakt.Telefon2 ?? "");
            formValues.Add("SSFax", kontakt.Fax ?? "");
            formValues.Add("SSEmail", kontakt.Email ?? "");

            form.FillForm(formValues, ms);
            form.CloseForm();

            return ms.ToArray();
        }

    }
}