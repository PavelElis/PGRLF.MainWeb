using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using PGRLF.MainWeb.Forms.Validation;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    [Serializable]
    public class RTest_ViewModel : AbstractForm
    {
        public RTest_ViewModel()
        {
            PojistovnyHospodarskaZvirata = new List<Pojistovna>();
            PojistovnyOstatniPlodiny = new List<Pojistovna>();
            PojistovnySpecialniPlodiny = new List<Pojistovna>();
            zadatel = new fo();
            
        }

        [Display(GroupName = "TypPodprogramu", Name = "Typ podprogramu")]
        public string TypPodprogramu { get; set; }
        public HttpPostedFileBase[] files { get; set; }


        #region header
        // ReSharper disable InconsistentNaming
        [Display(GroupName = "typyPojisteni", Name = "Pojištění plodin speciálních")]
        public bool PojisteniPlodinSpecialnich { get; set; }

        [Display(GroupName = "typyPojisteni", Name = "Pojištění plodin ostatních")]
        public bool PojisteniPlodinOstatnich { get; set; }

        [Display(GroupName = "typyPojisteni", Name = "Pojištění hospodářských zvířat")]
        public bool PojisteniHospodarskychZvirat { get; set; }

        #endregion



        public fo zadatel { get; set; }



        #region pojistovny

        [DataType("Pojistovny")]
        public List<Pojistovna> PojistovnySpecialniPlodiny { get; set; }

        [DataType("Pojistovny")]
        public List<Pojistovna> PojistovnyOstatniPlodiny { get; set; }

        [DataType("Pojistovny")]
        public List<Pojistovna> PojistovnyHospodarskaZvirata { get; set; }

        #endregion

        #region cestne prohlaseni

        [MustBeTrue(ErrorMessage = "Čestné prohlášení")]
        public bool CestneProhlaseni { get; set; }

        [Display(GroupName = "cesnteProhlaseni", Name = "")]
        public string CPNazev { get; set; }

        [Display(GroupName = "cesnteProhlaseni", Name = "IČ/RČ")]
        public string CPICRC { get; set; }

        [MustBeTrue(ErrorMessage = "Splnění podmínek")]
        public bool SplneniPodminek { get; set; }

        #endregion

        #region pouceni

        [MustBeTrue(ErrorMessage = "Souhlas s poskytnutím osobních údajů")]
        public bool Souhlas { get; set; }

        #endregion

        // ReSharper restore InconsistentNaming

        public override string ApplicantEmail
        {
            get
            {
                return zadatel.IsPravnickaOsoba ? zadatel.SSEmail : zadatel.TPEmail;
            }
        }

        public override byte[] SavePDF()
        {
            var form = new PDFform(HttpContext.Current.Server.MapPath("~/Content/FormTemplates/RTest.pdf"));

            MemoryStream ms = new MemoryStream();
            Dictionary<string, string> formValues = new Dictionary<string, string>();
            formValues.Add(
                "PojisteniPlodinSpecialnich",
                PojisteniPlodinSpecialnich ? "       XX" : "XX");
            formValues.Add(
                "RadioButtonList",
                PojisteniPlodinSpecialnich ? "1" : "0");
            formValues.Add(
                "PojisteniPlodinOstatnich",
                PojisteniPlodinOstatnich ? "       XX" : "XX");
            formValues.Add(
                "PoistenieHospodarskychZvirat",
                PojisteniHospodarskychZvirat ? "       XX" : "XX");
            formValues.Add("FORodneCislo", zadatel.FORodneCislo != null ? zadatel.FORodneCislo.Replace("/", "") : String.Empty);
            formValues.Add(
                "FODatumNarozeni",
                zadatel.FODatumNarozeni != null ? zadatel.FODatumNarozeni.Value.ToString("ddMMyyyy") : String.Empty);
            formValues.Add("FOIC", zadatel.FOIC ?? String.Empty);
            formValues.Add("FODIC", zadatel.FODIC ?? String.Empty);
            formValues.Add("FOTitulPredMenom", zadatel.FOTitulPredMenom ?? String.Empty);
            formValues.Add("FOPrijmeni", zadatel.FOPrijmeni ?? String.Empty);
            formValues.Add("FOTitulZaMenom", zadatel.FOTitulZaMenom ?? String.Empty);
            formValues.Add("FOJmeno", zadatel.FOJmeno ?? String.Empty);
            formValues.Add("TPUlice", zadatel.TPUlice ?? String.Empty);
            formValues.Add("TPCisloPopisne", zadatel.TPCisloPopisne ?? String.Empty);
            formValues.Add("TPPSC", zadatel.TPPSC != null ? zadatel.TPPSC.Replace(" ", "") : String.Empty);
            formValues.Add("TPCisloOrientacni", zadatel.TPCisloOrientacni ?? String.Empty);
            formValues.Add("TPObec", zadatel.TPObec ?? String.Empty);
            formValues.Add("TPKraj", zadatel.TPKraj ?? String.Empty);
            formValues.Add(
                "MPMistoPodnikani",
                !String.IsNullOrEmpty(zadatel.MPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        zadatel.MPUlice,
                        zadatel.MPCisloPopisne,
                        zadatel.MPCisloOrientacni,
                        zadatel.MPPSC,
                        zadatel.MPObec,
                        zadatel.MPKraj)
                    : String.Empty);
            formValues.Add("TPTelefon1", zadatel.TPTelefon1 ?? String.Empty);
            formValues.Add("TPTelefon2", zadatel.TPTelefon2 ?? String.Empty);
            formValues.Add("TPFax", zadatel.TPFax ?? String.Empty);
            formValues.Add("TPEmail", zadatel.TPEmail ?? String.Empty);
            formValues.Add("POObchodniJmeno", zadatel.POObchodneJmeno ?? String.Empty);
            formValues.Add("POIC", zadatel.POIC ?? String.Empty);
            formValues.Add("PODIC", zadatel.PODIC ?? String.Empty);
            var zodpovedneosoby = "";
            if (!String.IsNullOrEmpty(zadatel.ZO1Jmeno))
            {
                zodpovedneosoby += String.Format("{0}{1} {2}{3} - {4}", string.IsNullOrEmpty(zadatel.ZO1TitulPredJmenem) ? "" : zadatel.ZO1TitulPredJmenem + " ", zadatel.ZO1Jmeno, zadatel.ZO1Prijmeni, string.IsNullOrEmpty(zadatel.ZO1TitulZaJmenem) ? "" : " " + zadatel.ZO1TitulZaJmenem, zadatel.ZO1Funkce);
            }
            if (!String.IsNullOrEmpty(zadatel.ZO2Jmeno))
            {
                zodpovedneosoby += String.Format(", {0}{1} {2}{3} - {4}", string.IsNullOrEmpty(zadatel.ZO2TitulPredJmenem) ? "" : zadatel.ZO2TitulPredJmenem + " ", zadatel.ZO2Jmeno, zadatel.ZO2Prijmeni, string.IsNullOrEmpty(zadatel.ZO2TitulZaJmenem) ? "" : " " + zadatel.ZO2TitulZaJmenem, zadatel.ZO2Funkce);
            }
            if (!String.IsNullOrEmpty(zadatel.ZO3Jmeno))
            {
                zodpovedneosoby += String.Format(", {0}{1} {2}{3} - {4}", string.IsNullOrEmpty(zadatel.ZO3TitulPredJmenem) ? "" : zadatel.ZO3TitulPredJmenem + " ", zadatel.ZO3Jmeno, zadatel.ZO3Prijmeni, string.IsNullOrEmpty(zadatel.ZO3TitulZaJmenem) ? "" : " " + zadatel.ZO3TitulZaJmenem, zadatel.ZO3Funkce);
            }

            formValues.Add("POZodpovedneOsoby", zodpovedneosoby);
            formValues.Add("POSidloSpolocnosti", zadatel.SSSidloSpolecnosti ?? String.Empty);
            formValues.Add("SSUlice", zadatel.SSUlice ?? String.Empty);
            formValues.Add("SSCisloPopisne", zadatel.SSCisloPopisne ?? String.Empty);
            formValues.Add("SSPSC", zadatel.SSPSC != null ? zadatel.SSPSC.Replace(" ", "") : String.Empty);
            formValues.Add("SSCisloOrientacni", zadatel.SSCisloOrientacni ?? String.Empty);
            formValues.Add("SSObec", zadatel.SSObec ?? String.Empty);
            formValues.Add("SSKraj", zadatel.SSKraj ?? String.Empty);
            formValues.Add("SSTelefon1", zadatel.SSTelefon1 ?? String.Empty);
            formValues.Add("SSTelefon2", zadatel.SSTelefon2 ?? String.Empty);
            formValues.Add("SSFax", zadatel.SSFax ?? String.Empty);
            formValues.Add("SSEmail", zadatel.SSEmail ?? String.Empty);
            formValues.Add("ZapisDoObchodnihoRejstriku", zadatel.ZapisDoObchodnihoRejstriku ?? String.Empty);
            formValues.Add("Vydal", zadatel.Vydal ?? String.Empty);
            formValues.Add("DatumZapisu", zadatel.DatumZapisu != null ? zadatel.DatumZapisu.Value.ToString("dd.MM.yyyy") : String.Empty);
            formValues.Add("EvidenceDoObchodnihoRejstriku", zadatel.EvidenceDoObchodnihoRejstriku ?? String.Empty);
            formValues.Add(
                "DatumVydaniOsvedceni",
                zadatel.DatumVydaniOsvedceni != null
                    ? zadatel.DatumVydaniOsvedceni.Value.ToString("dd.MM.yyyy")
                    : String.Empty);
            formValues.Add("UkonceniCinnosti", zadatel.UkonceniCinnosti ? "       XX" : "XX");
            formValues.Add(
                "DatumUkonceni",
                zadatel.DatumUkonceni != null ? zadatel.DatumUkonceni.Value.ToString("MM yyyy") : String.Empty);
            formValues.Add("ProdejPodniku", zadatel.ProdejPodniku ? "       XX" : "XX");
            formValues.Add("DatumProdeje", zadatel.DatumProdeje != null ? zadatel.DatumProdeje.Value.ToString("MM yyyy") : String.Empty);
            formValues.Add("BankovniSpojeni", zadatel.BankovniSpojeni ?? String.Empty);
            formValues.Add("CisloUctu", zadatel.CisloUctu ?? String.Empty);
            formValues.Add("KodBanky", zadatel.KodBanky ?? String.Empty);
            string pojistovny = "";
            if (PojistovnySpecialniPlodiny.Count > 0)
            {
                pojistovny += "Pojištění plodin speciálních\n";
                foreach (var pojistovna in PojistovnySpecialniPlodiny)
                {
                    pojistovny += String.Format(
                        "{0} - {1} - {2} Kč\n",
                        pojistovna.Nazev,
                        pojistovna.CisloZmluvy,
                        pojistovna.Castka);
                }

                pojistovny += "\n\n";
            }
            if (PojistovnyOstatniPlodiny.Count > 0)
            {
                pojistovny += "Pojištění plodin ostatních\n";
                foreach (var pojistovna in PojistovnyOstatniPlodiny)
                {
                    pojistovny += String.Format(
                        "{0} - {1} - {2} Kč\n",
                        pojistovna.Nazev,
                        pojistovna.CisloZmluvy,
                        pojistovna.Castka);
                }

                pojistovny += "\n\n";
            }
            if (PojistovnyHospodarskaZvirata.Count > 0)
            {
                pojistovny += "Pojištění hospodárských zvířat\n";
                foreach (var pojistovna in PojistovnyHospodarskaZvirata)
                {
                    pojistovny += String.Format(
                        "{0} - {1} - {2} Kč\n",
                        pojistovna.Nazev,
                        pojistovna.CisloZmluvy,
                        pojistovna.Castka);
                }
            }
            formValues.Add("Pojistovny", pojistovny);

            formValues.Add("CPNazev", CPNazev ?? String.Empty);
            formValues.Add("CPICRC", CPICRC ?? String.Empty);


            form.FillForm(formValues, ms);
            form.CloseForm();
            return ms.ToArray();
        }

        public override void Process()
        {
            if (!PojisteniHospodarskychZvirat)
            {
                PojistovnyHospodarskaZvirata = new List<Pojistovna>();
            }
            if (!PojisteniPlodinOstatnich)
            {
                PojistovnyOstatniPlodiny = new List<Pojistovna>();
            }
            if (!PojisteniPlodinSpecialnich)
            {
                PojistovnySpecialniPlodiny = new List<Pojistovna>();
            }

            #region fopo

            if (zadatel.IsPravnickaOsoba)
            {
                zadatel.FORodneCislo = null;
                zadatel.FODatumNarozeni = null;
                zadatel.FOIC = null;
                zadatel.FODIC = null;
                zadatel.FOTitulPredMenom = null;
                zadatel.FOTitulZaMenom = null;
                zadatel.FOJmeno = null;
                zadatel.FOPrijmeni = null;
                zadatel.TPUlice = null;
                zadatel.TPCisloPopisne = null;
                zadatel.TPPSC = null;
                zadatel.TPCisloOrientacni = null;
                zadatel.TPObec = null;
                zadatel.TPKraj = null;

                zadatel.TPTelefon1 = null;
                zadatel.TPTelefon2 = null;
                zadatel.TPFax = null;
                zadatel.TPEmail = null;

                zadatel.MPUlice = null;
                zadatel.MPCisloPopisne = null;
                zadatel.MPPSC = null;
                zadatel.MPCisloOrientacni = null;

                zadatel.MPObec = null;
                zadatel.MPKraj = null;

                if (zadatel.JeMistoPodnikaniStejnePo)
                {
                    zadatel.MPUlicePo = zadatel.SSUlice;
                    zadatel.MPCisloPopisnePo = zadatel.SSCisloPopisne;
                    zadatel.MPPSCPo = zadatel.SSPSC;
                    zadatel.MPCisloOrientacniPo = zadatel.SSCisloOrientacni;
                    zadatel.MPObecPo = zadatel.SSObec;
                    zadatel.MPKrajPo = zadatel.SSKraj;
                }
            }
            else
            {
                zadatel.POObchodneJmeno = null;

                zadatel.POIC = null;

                zadatel.PODIC = null;

                zadatel.POTypPO = null;


                zadatel.ZO1Jmeno = null;

                zadatel.ZO1Prijmeni = null;
                zadatel.ZO1Funkce = null;

                zadatel.ZO2Jmeno = null;
                zadatel.ZO2Prijmeni = null;
                zadatel.ZO2Funkce = null;

                zadatel.ZO3Jmeno = null;
                zadatel.ZO3Prijmeni = null;
                zadatel.ZO3Funkce = null;


                zadatel.SSUlice = null;
                zadatel.SSCisloPopisne = null;
                zadatel.SSPSC = null;
                zadatel.SSCisloOrientacni = null;

                zadatel.SSObec = null;
                zadatel.SSKraj = null;

                zadatel.SSTelefon1 = null;
                zadatel.SSTelefon2 = null;
                zadatel.SSFax = null;
                zadatel.SSEmail = null;

                zadatel.MPUlicePo = null;
                zadatel.MPCisloPopisnePo = null;
                zadatel.MPPSCPo = null;
                zadatel.MPCisloOrientacniPo = null;
                zadatel.MPObecPo = null;
                zadatel.MPKrajPo = null;

                if (zadatel.JeMistoPodnikaniStejneFo)
                {
                    zadatel.MPUlice = zadatel.TPUlice;
                    zadatel.MPCisloPopisne = zadatel.TPCisloPopisne;
                    zadatel.MPPSC = zadatel.TPPSC;
                    zadatel.MPCisloOrientacni = zadatel.TPCisloOrientacni;
                    zadatel.MPObec = zadatel.TPObec;
                    zadatel.MPKraj = zadatel.TPKraj;
                }
            }

            #endregion

            if (Identifikator == null || Identifikator == Guid.Empty)
            {
                Identifikator = Guid.NewGuid();
            }
            if (!zadatel.ProdejPodniku)
            {
                zadatel.DatumProdeje = null;
            }
            if (!zadatel.UkonceniCinnosti)
            {
                zadatel.DatumUkonceni = null;
            }
            DatumPodani = DateTime.Now;
        }
    }
}