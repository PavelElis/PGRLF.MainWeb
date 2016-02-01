using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using PGRLF.MainWeb.Forms.Validation;
using PGRLF.MainWeb.Forms.FormClasses.Templates;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    [Serializable]
    public class PojisteniLesy_ViewModel : AbstractForm
    {
        public PojisteniLesy_ViewModel()
        {
            FyzickaOsoba = new FyzickaOsoba();
            PravnickaOsoba = new PravnickaOsoba();
            Kontakt = new Kontakt();
            BankovniSpojeni = new BankovniSpojeni();
        }

        public bool JePravnickaOsoba { get; set; }

        public bool JeSvazekObci { get; set; }

        public FyzickaOsoba FyzickaOsoba { get; set; }
        public PravnickaOsoba PravnickaOsoba { get; set; }
        public SvazekObci SvazekObci { get; set; }
        public Kontakt Kontakt { get; set; }
        public BankovniSpojeni BankovniSpojeni { get; set; }
        public ObchodniRejstrik ObchodniRejstrik { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ProdejPodniku")]
        public bool ProdejPodniku { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ProdejPodnikuDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_ProdejPodnikuDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ProdejPodnikuDatum")]
        public DateTime? ProdejPodnikuDatum { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "UkonceniCinnosti")]
        public bool UkonceniCinnosti { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "UkonceniCinnostiDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_UkonceniCinnostiDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_UkonceniCinnostiDatum")]
        public DateTime? UkonceniCinnostiDatum { get; set; }



        [MustBeTrue(ErrorMessage = "Musí být zaškrtnuto")]
        public bool CestneProhlaseni { get; set; }
        
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMJmeno { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMAdresa { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMIC { get; set; }
        
        #region DM1
        [MustBeTrueIfFieldHasValue("DM1HospodarskyRok", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM1KalendarniRok { get; set; }
        [MustBeTrueIfFieldHasValue("DM1KalendarniRok", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM1HospodarskyRok { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public DateTime? DM1HRZacatek { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        [Required(ErrorMessage = "Musí být vyplněno")]
        public DateTime? DM1HRKonec { get; set; }

        #endregion

        #region DM2

        [MustBeTrueIfFieldHasValue("DM2NeniPropojen", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM2NeniPropojen { get; set; }
        [MustBeTrueIfFieldHasValue("DM2JePropojen", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM2JePropojen { get; set; }

        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2Jmeno1 { get; set; }
        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2Adresa1 { get; set; }
        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2IC1 { get; set; }

        public string DM2Jmeno2 { get; set; }
        public string DM2Adresa2 { get; set; }
        public string DM2IC2 { get; set; }

        public string DM2Jmeno3 { get; set; }
        public string DM2Adresa3 { get; set; }
        public string DM2IC3 { get; set; }

        #endregion

        #region DM3

        [MustBeTrueIfFieldHasValue("DM3VzniklSpojenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3NevzniklSpojenim { get; set; }
        [MustBeTrueIfFieldHasValue("DM3NevzniklSpojenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3VzniklSpojenim { get; set; }
        //public bool DM3PrevzalJmeni { get; set; }

        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3Jmeno1 { get; set; }
        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3Adresa1 { get; set; }
        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3IC1 { get; set; }

        public string DM3Jmeno2 { get; set; }
        public string DM3Adresa2 { get; set; }
        public string DM3IC2 { get; set; }

        public string DM3Jmeno3 { get; set; }
        public string DM3Adresa3 { get; set; }
        public string DM3IC3 { get; set; }

        [MustBeTrueIfFieldHasValue("DM3NeniCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3JeCentralniRegistr { get; set; }
        [MustBeTrueIfFieldHasValue("DM3JeCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3NeniCentralniRegistr { get; set; }

        #endregion

        #region DM4

        [MustBeTrueIfFieldHasValue("DM4VzniklRozelenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4NevzniklRozdelenim { get; set; }
        [MustBeTrueIfFieldHasValue("DM4NevzniklRozdelenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4VzniklRozelenim { get; set; }

        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM41Jmeno { get; set; }
        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM41Adresa { get; set; }
        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM41IC { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti1 { get; set; }
        public string DM42Poskytovatel1 { get; set; }
        public string DM42Castka1 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti2 { get; set; }
        public string DM42Poskytovatel2 {get; set; }
        public string DM42Castka2 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti3 { get; set; }
        public string DM42Poskytovatel3 { get; set; }
        public string DM42Castka3 { get; set; }

        [MustBeTrueIfFieldHasValue("DM4NeniCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4JeCentralniRegistr { get; set; }
        [MustBeTrueIfFieldHasValue("DM4JeCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4NeniCentralniRegistr { get; set; }

        #endregion

        [MustBeTrue(ErrorMessage = "Musí být zaškrtnuto")]
        public bool DMCestneProhlaseni { get; set; }

        [MustBeTrue(ErrorMessage = "Musí být zaškrtnuto")]
        public bool SouhlasSeZpracovanim { get; set; }

        public override string ApplicantEmail
        {
            get
            {
                return Kontakt.Email;
            }
        }


        public override void Process()
        {
            if (Identifikator == null || Identifikator == Guid.Empty)
            {
                Identifikator = Guid.NewGuid();
            }
            if (!ProdejPodniku)
            {
                ProdejPodnikuDatum = null;
            }
            if (!UkonceniCinnosti)
            {
                UkonceniCinnostiDatum = null;
            }
            DatumPodani = DateTime.Now;
        }



        public override byte[] SavePDF()
        {
            var form = new PDFform(HttpContext.Current.Server.MapPath("~/Content/FormTemplates/ProgramZemedelec2015.pdf"));
            MemoryStream ms = new MemoryStream();
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            /*formValues.Add("FORodneCislo", (FyzickaOsoba.RodneCislo ?? "").Replace("/", ""));
            formValues.Add("FODatumNarozeni", FyzickaOsoba.DatumNarozeni != null ? FyzickaOsoba.DatumNarozeni.Value.ToString("ddMMyyyy") : "");
            formValues.Add("FOIC", FyzickaOsoba.IC ?? "");
            formValues.Add("FODIC", FyzickaOsoba.DIC ?? "");
            formValues.Add("FOTitulPredJmenem", FyzickaOsoba.TitulPredJmenem ?? "");
            formValues.Add("FOPrijmeni", FyzickaOsoba.Prijmeni ?? "");
            formValues.Add("FOTitulZaJmenem", FyzickaOsoba.TitulZaJmenem ?? "");
            formValues.Add("FOJmeno", FyzickaOsoba.Jmeno ?? "");
            formValues.Add("TPUlice", FyzickaOsoba.TrvalyPobyt.Ulice ?? "");
            formValues.Add("TPCisloPopisne", FyzickaOsoba.TrvalyPobyt.CisloPopisne ?? "");
            formValues.Add("TPPSC", FyzickaOsoba.TrvalyPobyt.PSC ?? "");
            formValues.Add("TPCisloOrientacni", FyzickaOsoba.TrvalyPobyt.CisloOrientacni ?? "");
            formValues.Add("TPObec", FyzickaOsoba.TrvalyPobyt.Obec ?? "");
            formValues.Add("MistoPodnikani", !String.IsNullOrEmpty(FyzickaOsoba.MistoPodnikani.PSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        FyzickaOsoba.MistoPodnikani.Ulice,
                        FyzickaOsoba.MistoPodnikani.CisloPopisne,
                        FyzickaOsoba.MistoPodnikani.CisloOrientacni,
                        FyzickaOsoba.MistoPodnikani.PSC,
                        FyzickaOsoba.MistoPodnikani.Obec,
                        FyzickaOsoba.MistoPodnikani.Kraj)
                    : "");
            formValues.Add("TPTelefon1", TPTelefon1 ?? "");
            formValues.Add("TPTelefon2", TPTelefon2 ?? "");
            formValues.Add("TPFax", TPFax ?? "");
            formValues.Add("TPEmail", TPEmail ?? "");

            formValues.Add("POObchodneJmeno", POObchodneJmeno ?? "");
            formValues.Add("POIC", POIC ?? "");
            formValues.Add("PODIC", PODIC ?? "");
            var zodpovedneosoby = "";
            if (!String.IsNullOrEmpty(ZO1Jmeno))
            {
                zodpovedneosoby += String.Format("{0}{1} {2}{3} - {4}", string.IsNullOrEmpty(ZO1TitulPredJmenem) ? "" : ZO1TitulPredJmenem + " ", ZO1Jmeno, ZO1Prijmeni, string.IsNullOrEmpty(ZO1TitulZaJmenem) ? "" : " " + ZO1TitulZaJmenem, ZO1Funkce);
            }
            if (!String.IsNullOrEmpty(ZO2Jmeno))
            {
                zodpovedneosoby += String.Format(", {0}{1} {2}{3} - {4}", string.IsNullOrEmpty(ZO2TitulPredJmenem) ? "" : ZO2TitulPredJmenem + " ", ZO2Jmeno, ZO2Prijmeni, string.IsNullOrEmpty(ZO2TitulZaJmenem) ? "" : " " + ZO2TitulZaJmenem, ZO2Funkce);
            }
            if (!String.IsNullOrEmpty(ZO3Jmeno))
            {
                zodpovedneosoby += String.Format(", {0}{1} {2}{3} - {4}", string.IsNullOrEmpty(ZO3TitulPredJmenem) ? "" : ZO3TitulPredJmenem + " ", ZO3Jmeno, ZO3Prijmeni, string.IsNullOrEmpty(ZO3TitulZaJmenem) ? "" : " " + ZO3TitulZaJmenem, ZO3Funkce);
            }

            formValues.Add("POZodpovedneOsoby", zodpovedneosoby);
            formValues.Add("POSidloSpolecnosti", SSSidloSpolecnosti);
            formValues.Add("POMistoPodnikani", !String.IsNullOrEmpty(POMPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        POMPUlice,
                        POMPCisloPopisne,
                        POMPCisloOrientacni,
                        POMPPSC,
                        POMPObec,
                        POMPKraj)
                    : "");
            if (POPocetSpolecniku != 0)
                formValues.Add("POPocetSpolecniku", POPocetSpolecniku.ToString("D"));
            if (POZakladniKapital != 0)
                formValues.Add("POZakladniKapital", POZakladniKapital.ToString("D"));

            formValues.Add("SSUlice", SSUlice ?? "");
            formValues.Add("SSPSC", SSPSC ?? "");
            formValues.Add("SSCisloPopisne", SSCisloPopisne ?? "");
            formValues.Add("SSCisloOrientacni", SSCisloOrientacni ?? "");
            formValues.Add("SSObec", SSObec ?? "");
            formValues.Add("SSTelefon1", SSTelefon1 ?? "");
            formValues.Add("SSTelefon2", SSTelefon2 ?? "");
            formValues.Add("SSFax", SSFax ?? "");
            formValues.Add("SSEmail", SSEmail ?? "");

            formValues.Add("DatumVydaniOsvedceni", DatumVydaniOsvedceni != null ? DatumVydaniOsvedceni.Value.ToString("dd.MM.yyyy") : "" ?? "");
            formValues.Add("UkonceniCinnosti", UkonceniCinnosti ? "1" : "0");
            formValues.Add("ProdejPodniku", ProdejPodniku ? "1" : "0");
            formValues.Add("DatumUkonceni", DatumUkonceni != null ? DatumUkonceni.Value.ToString("MM yyyy") : "");
            formValues.Add("DatumProdeje", DatumProdeje != null ? DatumProdeje.Value.ToString("MM yyyy") : "");
            formValues.Add("CisloUctu", CisloUctu ?? "");
            formValues.Add("KodBanky", KodBanky ?? "");

            if (PredmetyPodnikani.Count > 0)
            {
                formValues.Add("SCPredmetPodnikani1", PredmetyPodnikani[0].Cinnost ?? "");
                formValues.Add("SCRokZahajeni1", PredmetyPodnikani[0].RokZahajeniCinnosti ?? "");
            }
            if (PredmetyPodnikani.Count > 1)
            {
                formValues.Add("SCPredmetPodnikani2", PredmetyPodnikani[1].Cinnost ?? "");
                formValues.Add("SCRokZahajeni2", PredmetyPodnikani[1].RokZahajeniCinnosti ?? "");
            }
            if (PredmetyPodnikani.Count > 2)
            {
                formValues.Add("SCPredmetPodnikani3", PredmetyPodnikani[2].Cinnost ?? "");
                formValues.Add("SCRokZahajeni3", PredmetyPodnikani[2].RokZahajeniCinnosti ?? "");
            }
            if (PredmetyPodnikani.Count > 3)
            {
                formValues.Add("SCPredmetPodnikani4", PredmetyPodnikani[3].Cinnost ?? "");
                formValues.Add("SCRokZahajeni4", PredmetyPodnikani[3].RokZahajeniCinnosti ?? "");
            }

            if (RostlinnaVyroba)
                formValues.Add("rostlinnaVyroba", "On");
            if (ZivocisnaVyroba)
                formValues.Add("zivocisnaVyroba", "On");
            if (JinaVyroba)
                formValues.Add("jinaVyroba", "On");

            formValues.Add("skot", skot.ToString());
            formValues.Add("plemSkot", plemSkot.ToString());
            formValues.Add("ovce", ovce.ToString());
            formValues.Add("plemOvce", plemOvce.ToString());
            formValues.Add("kozy", kozy.ToString());
            formValues.Add("plemKozy", plemKozy.ToString());

            formValues.Add("StrukturaChovanychZvirat", StrukturaChovanychZvirat ?? "");
            formValues.Add("StrukturaPestovanychPlodin", StrukturaPestovanychPlodin ?? "");
            formValues.Add("VyrobaOkenADveri", StrukturaJinaVyroba ?? "");

            formValues.Add("CP1", CP1);
            formValues.Add("CP2", CP2);
            formValues.Add("CP31", CP31 ? "1" : "0");
            formValues.Add("CP32", CP32 ? "1" : "0");

            formValues.Add("CestneProhlaseni", CestneProhlaseni ? "Yes" : "0");
            formValues.Add("SouhlasSeSpracovanim", Souhlas ? "Yes" : "0");

            formValues.Add("EvidenceZemedelskehoPodnikatele", EvidenceDoObchodnihoRejstriku ?? "");

            form.FillForm(formValues, ms);*/
            form.CloseForm();

            //return ZemedelecOld();
            return ms.ToArray();
        }
    }
}