using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using PGRLF.MainWeb.Forms.Validation;
using PGRLF.MainWeb.Forms.FormClasses.Partial;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    [Serializable]
    public class TechnikaLesy_ViewModel : AbstractForm
    {
        public TechnikaLesy_ViewModel()
        {
            FyzickaOsoba = new FyzickaOsoba();
            PravnickaOsoba = new PravnickaOsoba();
            Kontakt = new Kontakt();
            BankovniSpojeni = new BankovniSpojeni();
        }

        public bool JePravnickaOsoba { get; set; }

        public bool JeObec { get; set; }

        public FyzickaOsoba FyzickaOsoba { get; set; }
        public PravnickaOsoba PravnickaOsoba { get; set; }
        public Kontakt Kontakt { get; set; }
        public BankovniSpojeni BankovniSpojeni { get; set; }

        public override string ApplicantEmail
        {
            get
            {
                return Kontakt.Email;
            }
        }

        public override void Process()
        {
            if (JePravnickaOsoba)
            {
                FyzickaOsoba.nullovani();
                PravnickaOsoba.nastavMistoPodnikani();
            }
            else
            {
                PravnickaOsoba.nullovani();
                FyzickaOsoba.nastavMistoPodnikani();
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

            formValues.Add("FORodneCislo", (FyzickaOsoba.FORodneCislo ?? "").Replace("/", ""));
            formValues.Add("FODatumNarozeni", FyzickaOsoba.FODatumNarozeni != null ? FyzickaOsoba.FODatumNarozeni.Value.ToString("ddMMyyyy") : "");
            formValues.Add("FOIC", FyzickaOsoba.FOIC ?? "");
            formValues.Add("FODIC", FyzickaOsoba.FODIC ?? "");
            formValues.Add("FOTitulPredJmenem", FyzickaOsoba.FOTitulPredMenom ?? "");
            formValues.Add("FOPrijmeni", FyzickaOsoba.FOPrijmeni ?? "");
            formValues.Add("FOTitulZaJmenem", FyzickaOsoba.FOTitulZaMenom ?? "");
            formValues.Add("FOJmeno", FyzickaOsoba.FOJmeno ?? "");
            formValues.Add("TPUlice", FyzickaOsoba.FOTPUlice ?? "");
            formValues.Add("TPCisloPopisne", FyzickaOsoba.FOTPCisloPopisne ?? "");
            formValues.Add("TPPSC", FyzickaOsoba.FOTPPSC ?? "");
            formValues.Add("TPCisloOrientacni", FyzickaOsoba.FOTPCisloOrientacni ?? "");
            formValues.Add("TPObec", FyzickaOsoba.FOTPObec ?? "");
            formValues.Add("MistoPodnikani", !String.IsNullOrEmpty(FyzickaOsoba.FOMPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        FyzickaOsoba.FOMPUlice,
                        FyzickaOsoba.FOMPCisloPopisne,
                        FyzickaOsoba.FOMPCisloOrientacni,
                        FyzickaOsoba.FOMPPSC,
                        FyzickaOsoba.FOMPObec,
                        FyzickaOsoba.FOMPKraj)
                    : "");
            formValues.Add("TPTelefon1", Kontakt.Telefon1 ?? "");
            formValues.Add("TPTelefon2", Kontakt.Telefon2 ?? "");
            formValues.Add("TPFax", Kontakt.Fax ?? "");
            formValues.Add("TPEmail", Kontakt.Email ?? "");

            formValues.Add("POObchodneJmeno", PravnickaOsoba.POObchodniJmeno ?? "");
            formValues.Add("POIC", PravnickaOsoba.POIC ?? "");
            formValues.Add("PODIC", PravnickaOsoba.PODIC ?? "");
            var zodpovedneosoby = "";
            foreach(ZodpovednaOsoba zodpovednaOsoba in PravnickaOsoba.POZodpovedneOsoby)
            {
                zodpovedneosoby += String.Format("{0}{1} {2}{3} - {4}", string.IsNullOrEmpty(zodpovednaOsoba.POZOTitulPredJmenem) ? "" : zodpovednaOsoba.POZOTitulPredJmenem + " ", zodpovednaOsoba.POZOJmeno, zodpovednaOsoba.POZOPrijmeni, string.IsNullOrEmpty(zodpovednaOsoba.POZOTitulZaJmenem) ? "" : " " + zodpovednaOsoba.POZOTitulZaJmenem, zodpovednaOsoba.POZOFunkce);
            }

            formValues.Add("POZodpovedneOsoby", zodpovedneosoby);
            formValues.Add("POMistoPodnikani", !String.IsNullOrEmpty(PravnickaOsoba.POMPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        PravnickaOsoba.POMPUlice,
                        PravnickaOsoba.POMPCisloPopisne,
                        PravnickaOsoba.POMPCisloOrientacni,
                        PravnickaOsoba.POMPPSC,
                        PravnickaOsoba.POMPObec,
                        PravnickaOsoba.POMPKraj)
                    : "");
            if (PravnickaOsoba.POPocetSpolecniku != 0)
                formValues.Add("POPocetSpolecniku", PravnickaOsoba.POPocetSpolecniku.ToString("D"));
            if (PravnickaOsoba.POZakladniKapital != 0)
                formValues.Add("POZakladniKapital", PravnickaOsoba.POZakladniKapital.ToString("D"));

            formValues.Add("SSUlice", PravnickaOsoba.POSSUlice ?? "");
            formValues.Add("SSPSC", PravnickaOsoba.POSSPSC ?? "");
            formValues.Add("SSCisloPopisne", PravnickaOsoba.POSSCisloPopisne ?? "");
            formValues.Add("SSCisloOrientacni", PravnickaOsoba.POSSCisloOrientacni ?? "");
            formValues.Add("SSObec", PravnickaOsoba.POSSObec ?? "");
            formValues.Add("SSTelefon1", Kontakt.Telefon1 ?? "");
            formValues.Add("SSTelefon2", Kontakt.Telefon2 ?? "");
            formValues.Add("SSFax", Kontakt.Fax ?? "");
            formValues.Add("SSEmail", Kontakt.Email ?? "");

            form.FillForm(formValues, ms);
            form.CloseForm();

            return ms.ToArray();
        }

    }
}