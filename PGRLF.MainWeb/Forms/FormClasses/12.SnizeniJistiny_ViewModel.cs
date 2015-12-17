using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using PGRLF.MainWeb.Forms.Validation;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    [Serializable]
    public class SnizeniJistiny_ViewModel : AbstractForm
    {
        public SnizeniJistiny_ViewModel()
        {
            PredmetyPodnikani = new List<PredmetPodnikani>();
        }

        #region Header

        public bool Povinne { get; set; }


        [RequiredIfFieldHasValue("Povinne", false, ErrorMessageResourceType = typeof(FormResources),
        ErrorMessageResourceName = "PodporaZemedelec_InvZamer")]
        [Display(GroupName = "typyPodprogramu", Name = "Typ podprogramu")]
        public string TypyPodprogramu { get; set; }

        [Display(GroupName = "header", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_NavyseniProMladehoZemedelce")]
        public bool NavyseniMladehoZemedelce { get; set; }

        #endregion

        #region Fyzicka osoba

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_DatumNarozeni")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteDatumNarozeniZadatele")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        // ReSharper disable InconsistentNaming
        public DateTime? FODatumNarozeni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Dic")]
        public string FODIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Ic")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteIcFyzickeOsoby")]
        public string FOIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_KrestniJmeno")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteKrestniJmeno")]
        public string FOJmeno { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Prijmeni")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_PrijmeniZadatele")]
        public string FOPrijmeni { get; set; }

        [RegularExpression("(\\d)(\\d)(\\d)(\\d)(\\d)(\\d)(\\/)(\\d)(\\d)(\\d)(\\d)?",
            ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteRodneCislo")]
        [DisplayFormat(NullDisplayText = "------/--", ConvertEmptyStringToNull = true)]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_RodneCislo"
            )]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteRodneCisloZadatele")]
        public string FORodneCislo { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_TitulPredJmenem")]
        public string FOTitulPredMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_TitulZaJmenem")]
        public string FOTitulZaMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Stejné jako \"Adresa trvalého pobytu\"")]
        public bool JeMistoPodnikaniStejneFo { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Ulice")]
        public string MPUlice { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte popisné číslo")]
        [Display(GroupName = "fyzickaOsoba", Name = "Popisné číslo")]
        public string MPCisloPopisne { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte PSČ")]
        [Display(GroupName = "fyzickaOsoba", Name = "PSČ")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string MPPSC { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Orientační číslo")]
        public string MPCisloOrientacni { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte obec")]
        [Display(GroupName = "fyzickaOsoba", Name = "Obec")]
        public string MPObec { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte kraj")]
        [Display(GroupName = "fyzickaOsoba", Name = "Kraj")]
        [DataType("Kraj")]
        public string MPKraj { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_OrientacniCisloBydliste")]*/
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_OrientacniCislo")]
        public string TPCisloOrientacni { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaSnizeniJistiny_ViewModel_PopisneCislo")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_PopisneCislo")]
        public string TPCisloPopisne { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName =
                "PodporaSnizeniJistiny_ViewModel_TPEmail_Zadejte_kontaktní_e_mail_žadatele_KontaktniEmail")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Email")]
        [DataType(DataType.EmailAddress)]
        public string TPEmail { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Fax")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
    ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPFax { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_KrajZadatele")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Kraj")]
        [DataType("Kraj")]
        public string TPKraj { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_NazevObce")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Obec")]
        public string TPObec { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_PscABydliste")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Psc")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string TPPSC { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Telefon1")]
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Telefon1")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPTelefon1 { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Telefon_2")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPTelefon2 { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName =
                "PodporaSnizeniJistiny_ViewModel_TPUlice_Zadejte_název_ulice_trvalého_bydliště_žadatele")]*/
        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Ulice")]
        public string TPUlice { get; set; }

        #endregion

        #region Pravnicka osoba

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_DicZadatelePravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Dic")]
        public string PODIC { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_IcZadatelePravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Ic")]
        public string POIC { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ObchodniJmenoPravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_ObchodniJmeno")]
        public string POObchodneJmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_TypSpolocnosti")]
        [DataType("TypSpolecnosti")]
        public string POTypPO { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte název sídla společnosti")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Sídlo společnosti")]
        public string SSSidloSpolecnosti { get; set; }*/

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_OrientaceCisloSidlaPravnickejOsoby")]*/
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_OrientacniCislo")]
        public string SSCisloOrientacni { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_PopisneCisloPravnickejOsoby")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_PopisneCislo")]
        public string SSCisloPopisne { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName =
                "PodporaSnizeniJistiny_ViewModel_TPEmail_Zadejte_kontaktní_e_mail_žadatele_KontaktniEmail")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Email")
        ]
        [DataType(DataType.EmailAddress)]
        public string SSEmail { get; set; }

        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Fax")]
        public string SSFax { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName =
                "PodporaSnizeniJistiny_ViewModel_Zadejte_kraj")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Kraj")]
        [DataType("Kraj")]
        public string SSKraj { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteNazovObcePravnickeOsoby")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Obec")]
        public string SSObec { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_PscSidlaPravnickaOsoba")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Psc")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string SSPSC { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteTelefonniCisloZadatele")]
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_Telefon1")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string SSTelefon1 { get; set; }

        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_Telefon_2")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string SSTelefon2 { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteNazevUliceSidlaPravnickaOsoba")]*/
        [Display(GroupName = "sidloSpolecnosti", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Ulice")]
        public string SSUlice { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_VyberteFunkciPravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO1Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO1TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO1TitulZaJmenem { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteJmenoZastupceOsoby")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Jmeno")]
        public string ZO1Jmeno { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejtePrijmeniZastupcePravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Prijmeni"
            )]
        public string ZO1Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO2Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO2TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO2TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Jmeno")]
        public string ZO2Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Prijmeni"
            )]
        public string ZO2Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO3Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO3TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO3TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Jmeno")]
        public string ZO3Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Prijmeni")]
        public string ZO3Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_ZapisDoObchodnihoRejstriku")]
        public string ZapisDoObchodnihoRejstriku { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Vydal")]
        public string Vydal { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Datum zápisu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumZapisu { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejtePrijmeniZastupcePravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_ZadejtePocetSpolocniku")]
        public int POPocetSpolecniku { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejtePrijmeniZastupcePravnickaOsoba")]
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_ZadejteZakladniKapital")]
        public int POZakladniKapital { get; set; }

        // Pravnicka Osoba Misto Podnikani

        [Display(GroupName = "mistoPodnikani", Name = "Stejné jako \"Sídlo společnosti\"")]
        public bool JeMistoPodnikaniStejnePo { get; set; }

        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_OrientacniCislo")]
        public string POMPCisloOrientacni { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte popisné číslo")]
        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_PopisneCislo")]
        public string POMPCisloPopisne { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte kraj")]
        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Kraj")]
        [DataType("Kraj")]
        public string POMPKraj { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte obec")]
        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Obec")]
        public string POMPObec { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte PSČ")]
        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Psc")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string POMPPSC { get; set; }

        [Display(GroupName = "mistoPodnikani", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Ulice")]
        public string POMPUlice { get; set; }

        #endregion

        #region Spolocna cast

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_PlatceDPH")]
        public bool PlatceDph { get; set; }

        [Display(GroupName = "spolecnaCast", Name = "Zápis do obchodního rejstříku č.")]
        public string ZapisDoOR { get; set; }

        [Display(GroupName = "spolecnaCast", Name = "Vydal")]
        public string VydalOR { get; set; }

        [Display(GroupName = "spolecnaCast", Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumOR { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_CisloBankovnihoUctu")]
        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources), Name = "PodporaZemedelec_CisloUctu")]
        [RegularExpression(Helpers.AccountNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky_Cislo_Uctu")]
        public string CisloUctu { get; set; }

        [RequiredIfFieldHasValue("ProdejPodniku", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadejteMesicARokProdeje")]
        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_Datum_prodeje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumProdeje { get; set; }

        [RequiredIfFieldHasValue("UkonceniCinnosti", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadajteMesicARokUkoncenia")]
        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_DatumUkonceni")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumUkonceni { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadajteDatumVydaniaOsvedcenia")]
        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_DatumVydaniOsvedceni")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumVydaniOsvedceni { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_ZadajteEvidenciZemedelskehoPodnikatele")]
        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_EvidenceZemedelskehoPodnikatele")]
        public string EvidenceDoObchodnihoRejstriku { get; set; }

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_KodBankyVyberteBanku")]
        [DataType("Banka")]
        public string KodBanky { get; set; }

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_PlanujiProdatPodnik")]
        public bool ProdejPodniku { get; set; }

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_PlanujuUkoncitZemedelskouCinnost")]
        public bool UkonceniCinnosti { get; set; }

        public bool ZadamPodporu { get; set; }

        #endregion
        
        #region Zaměření zemědělské výroby

        [Display(ResourceType = typeof(FormResources), Name = "PodporaZemedelec_RostlinnaVyroba")]
        public bool RostlinnaVyroba { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PodporaZemedelec_ZivocisnaVyroba")]
        public bool ZivocisnaVyroba { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PodporaZemedelec_JinaVyroba")]
        public bool JinaVyroba { get; set; }

        [RequiredIfFieldHasValue("RostlinnaVyroba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaSnizeniJistiny_ViewModel_StrukturaPestovanychPlodin_Popište_strukturu_pěstovaných_plodin")]
        [UIHint("Textarea")]
        public string StrukturaPestovanychPlodin { get; set; }

        [RequiredIfFieldHasValue("ZivocisnaVyroba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaSnizeniJistiny_ViewModel_StrukturaChovanychZvirat_Popište_strukturu_chovaných_zvířat")]
        [UIHint("Textarea")]
        public string StrukturaChovanychZvirat { get; set; }

        [RequiredIfFieldHasValue("JinaVyroba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_JeNutneZadatPopis")]
        [UIHint("Textarea")]
        public string StrukturaJinaVyroba { get; set; }

        [Display(GroupName = "PocetZvirat", Name = "skot")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int skot { get; set; }
        [Display(GroupName = "PocetZvirat", Name = "plemSkot")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int plemSkot { get; set; }
        [Display(GroupName = "PocetZvirat", Name = "ovce")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int ovce { get; set; }
        [Display(GroupName = "PocetZvirat", Name = "plemOvce")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int plemOvce { get; set; }
        [Display(GroupName = "PocetZvirat", Name = "kozy")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int kozy { get; set; }
        [Display(GroupName = "PocetZvirat", Name = "plemKozy")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Nesprávná hodnota")]
        public int plemKozy { get; set; }
        #endregion

        #region Cestne prohlaseni

        [Display(GroupName = "cestneProhlaseni", Name = "CP1")]
        [RequiredIfFieldHasValue("Povinne", false, ErrorMessageResourceType = typeof(FormResources),
        ErrorMessageResourceName = "VyberVariant")]
        public string CP1 { get; set; }

        [Display(GroupName = "cestneProhlaseni", Name = "CP2")]
        [RequiredIfFieldHasValue("Povinne", false, ErrorMessageResourceType = typeof(FormResources),
        ErrorMessageResourceName = "VyberVariant")]
        public string CP2 { get; set; }

        [Display(GroupName = "cestneProhlaseni", Name = "CP31")]
        [RequiredIfFieldHasValue("TypyPodprogramu", "Zvirata", ErrorMessageResourceType = typeof(FormResources),
        ErrorMessageResourceName = "VyberVariant")]
        public bool CP31 { get; set; }

        [Display(GroupName = "cestneProhlaseni", Name = "CP32")]
        [RequiredIfFieldHasValue("TypyPodprogramu", "Zvirata", ErrorMessageResourceType = typeof(FormResources),
        ErrorMessageResourceName = "VyberVariant")]
        public bool CP32 { get; set; }

        [MustBeTrue(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_CestneVyhlasenie")]
        public bool CestneProhlaseni { get; set; }

        #endregion

        #region Pouceni

        [MustBeTrue(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_SouhlasSPoskytnutimOsobnichUdaju")]
        public bool Souhlas { get; set; }

        #endregion
        // ReSharper restore InconsistentNaming

        public bool IsPravnickaOsoba { get; set; }

        public List<PredmetPodnikani> PredmetyPodnikani { get; set; }

        public override string ApplicantEmail
        {
            get
            {
                return IsPravnickaOsoba ? SSEmail : TPEmail;
            }
        }

        public override void Process()
        {
            #region fopo

            if (IsPravnickaOsoba)
            {
                FORodneCislo = null;
                FODatumNarozeni = null;
                FOIC = null;
                FODIC = null;
                FOTitulPredMenom = null;
                FOTitulZaMenom = null;
                FOJmeno = null;
                FOPrijmeni = null;
                TPUlice = null;
                TPCisloPopisne = null;
                TPPSC = null;
                TPCisloOrientacni = null;
                TPObec = null;
                TPKraj = null;

                TPTelefon1 = null;
                TPTelefon2 = null;
                TPFax = null;
                TPEmail = null;

                MPUlice = null;
                MPCisloPopisne = null;
                MPPSC = null;
                MPCisloOrientacni = null;

                MPObec = null;
                MPKraj = null;

                if (JeMistoPodnikaniStejnePo)
                {
                    POMPUlice = SSUlice;
                    POMPCisloPopisne = SSCisloPopisne;
                    POMPPSC = SSPSC;
                    POMPCisloOrientacni = SSCisloOrientacni;
                    POMPObec = SSObec;
                    POMPKraj = SSKraj;
                }
            }
            else
            {
                POObchodneJmeno = null;

                POIC = null;

                PODIC = null;

                POTypPO = null;


                ZO1Jmeno = null;

                ZO1Prijmeni = null;
                ZO1Funkce = null;

                ZO2Jmeno = null;
                ZO2Prijmeni = null;
                ZO2Funkce = null;

                ZO3Jmeno = null;
                ZO3Prijmeni = null;
                ZO3Funkce = null;


                SSUlice = null;
                SSCisloPopisne = null;
                SSPSC = null;
                SSCisloOrientacni = null;

                SSObec = null;
                SSKraj = null;

                SSTelefon1 = null;
                SSTelefon2 = null;
                SSFax = null;
                SSEmail = null;

                POMPUlice = null;
                POMPCisloPopisne = null;
                POMPPSC = null;
                POMPCisloOrientacni = null;
                POMPObec = null;
                POMPKraj = null;

                if (JeMistoPodnikaniStejneFo)
                {
                    MPUlice = TPUlice;
                    MPCisloPopisne = TPCisloPopisne;
                    MPPSC = TPPSC;
                    MPCisloOrientacni = TPCisloOrientacni;
                    MPObec = TPObec;
                    MPKraj = TPKraj;
                }
            }

            #endregion

            if (Identifikator == null || Identifikator == Guid.Empty)
            {
                Identifikator = Guid.NewGuid();
            }
            if (!ProdejPodniku)
            {
                DatumProdeje = null;
            }
            if (!UkonceniCinnosti)
            {
                DatumUkonceni = null;
            }
            DatumPodani = DateTime.Now;
        }



        public override byte[] SavePDF()
        {
            var form = new PDFform(HttpContext.Current.Server.MapPath("~/Content/FormTemplates/ProgramZemedelec2015.pdf"));
            MemoryStream ms = new MemoryStream();
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            formValues.Add("HETypPodprogramu", TypyPodprogramu);

            formValues.Add("HEPlatceDPH", PlatceDph ? "1" : "0");
            formValues.Add("HENavyseni", NavyseniMladehoZemedelce ? "1" : "0");

            formValues.Add("FORodneCislo", (FORodneCislo ?? "").Replace("/", ""));
            formValues.Add("FODatumNarozeni", FODatumNarozeni != null ? FODatumNarozeni.Value.ToString("ddMMyyyy") : "");
            formValues.Add("FOIC", FOIC ?? "");
            formValues.Add("FODIC", FODIC ?? "");
            formValues.Add("FOTitulPredJmenem", FOTitulPredMenom ?? "");
            formValues.Add("FOPrijmeni", FOPrijmeni ?? "");
            formValues.Add("FOTitulZaJmenem", FOTitulZaMenom ?? "");
            formValues.Add("FOJmeno", FOJmeno ?? "");
            formValues.Add("TPUlice", TPUlice ?? "");
            formValues.Add("TPCisloPopisne", TPCisloPopisne ?? "");
            formValues.Add("TPPSC", TPPSC ?? "");
            formValues.Add("TPCisloOrientacni", TPCisloOrientacni ?? "");
            formValues.Add("TPObec", TPObec ?? "");
            formValues.Add("MistoPodnikani", !String.IsNullOrEmpty(MPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        MPUlice,
                        MPCisloPopisne,
                        MPCisloOrientacni,
                        MPPSC,
                        MPObec,
                        MPKraj)
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
            /*formValues.Add("POSidloSpolecnosti", SSSidloSpolecnosti);*/
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

            form.FillForm(formValues, ms);
            form.CloseForm();

            //return ZemedelecOld();
            return ms.ToArray();
        }

        private byte[] ZemedelecOld()
        {
            var form = new PDFform(HttpContext.Current.Server.MapPath("~/Content/FormTemplates/ProgramZemedelec2015.pdf"));
            MemoryStream ms = new MemoryStream();
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            (FORodneCislo ?? "")
                .Replace("/", "")
                .WriteToSequentialFields(
                    "F[0].P1[0].fo_rc_{0}[0]",
                    formValues);
            (FODatumNarozeni != null ? FODatumNarozeni.Value.ToString("ddMMyyyy") : "")
                .WriteToSequentialFields(
                    "F[0].P1[0].fo_drc_{0}[0]",
                    formValues);
            formValues.Add("F[0].P1[0].fo_ico[0]", FOIC ?? "");
            formValues.Add("F[0].P1[0].fo_dic[0]", FODIC ?? "");
            formValues.Add("F[0].P1[0].fo_titul_1[0]", FOTitulPredMenom ?? "");
            formValues.Add("F[0].P1[0].fo_prijmeni[0]", FOPrijmeni ?? "");
            formValues.Add("F[0].P1[0].fo_titul_2[0]", FOTitulZaMenom ?? "");
            formValues.Add("F[0].P1[0].fo_jmeno[0]", FOJmeno ?? "");
            formValues.Add("F[0].P1[0].fo_ulice_nazev[0]", TPUlice ?? "");
            formValues.Add("F[0].P1[0].fo_ulice_cp[0]", TPCisloPopisne ?? "");

            TPPSC.WriteToSequentialFields("F[0].P1[0].fo_psc_{0}[0]", formValues);

            formValues.Add("F[0].P1[0].fo_ulice_co[0]", TPCisloOrientacni ?? "");
            formValues.Add("F[0].P1[0].fo_obec[0]", TPObec ?? "");
            formValues.Add("TPKraj", TPKraj ?? "");
            formValues.Add("TPSidloFirmy", "TPSidloFirmy");
            formValues.Add(
                "F[0].P1[0].fo_mistopodnikani[0]",
                !String.IsNullOrEmpty(MPPSC)
                    ? String.Format(
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        MPUlice,
                        MPCisloPopisne,
                        MPCisloOrientacni,
                        MPPSC,
                        MPObec,
                        MPKraj)
                    : "");

            formValues.Add("F[0].P1[0].fo_telelefon_1[0]", TPTelefon1 ?? "");
            formValues.Add("F[0].P1[0].fo_telelefon_2[0]", TPTelefon2 ?? "");
            formValues.Add("F[0].P1[0].fo_fax_1[0]", TPFax ?? "");
            formValues.Add("F[0].P1[0].fo_email[0]", TPEmail ?? "");

            formValues.Add("F[0].P2[0].po_obchodni_jmeno[0]", POObchodneJmeno ?? "");
            formValues.Add("F[0].P2[0].po_ico[0]", POIC ?? "");
            formValues.Add("F[0].P2[0].po_dic[0]", PODIC ?? "");
            var zodpovedneosoby = "";
            if (!String.IsNullOrEmpty(ZO1Jmeno))
            {
                zodpovedneosoby += String.Format("{0} {1} - {2}", ZO1Jmeno, ZO1Prijmeni, ZO1Funkce);
            }
            if (!String.IsNullOrEmpty(ZO2Jmeno))
            {
                zodpovedneosoby += String.Format(",{0} {1} - {2}", ZO2Jmeno, ZO2Prijmeni, ZO2Funkce);
            }
            if (!String.IsNullOrEmpty(ZO3Jmeno))
            {
                zodpovedneosoby += String.Format(",{0} {1} - {2}", ZO3Jmeno, ZO3Prijmeni, ZO3Funkce);
            }
            formValues.Add("F[0].P2[0].po_zastupci[0]", zodpovedneosoby);

            formValues.Add("F[0].P2[0].po_ulice_nazev[0]", "");
            formValues.Add("F[0].P2[0].fo_ulice_nazev[0]", SSUlice ?? "");
            formValues.Add("F[0].P2[0].fo_ulice_cp[0]", SSCisloPopisne ?? "");

            (SSPSC ?? "")
                .WriteToSequentialFields(
                    "F[0].P2[0].fo_psc_{0}[0]",
                    formValues);
            formValues.Add("F[0].P2[0].fo_ulice_co[0]", SSCisloOrientacni ?? "");
            formValues.Add("F[0].P2[0].fo_obec[0]", SSObec ?? "");
            formValues.Add("SSKraj", SSKraj ?? "");
            formValues.Add("F[0].P2[0].fo_telelefon_1[0]", SSTelefon1 ?? "");
            formValues.Add("F[0].P2[0].fo_telelefon_2[0]", SSTelefon2 ?? "");
            formValues.Add("F[0].P2[0].fo_fax_1[0]", SSFax ?? "");
            formValues.Add("F[0].P2[0].fo_email[0]", SSEmail ?? "");

            formValues.Add("ZapisDoObchodnihoRejstriku", ZapisDoObchodnihoRejstriku ?? "");
            formValues.Add("F[0].P2[0].po_zapis_doOR_vydal[0]", Vydal ?? "");
            formValues.Add("F[0].P2[0].po_zapis_doOR_datum[0]", DatumZapisu != null ? DatumZapisu.Value.ToString("dd.MM.yyyy") : "");
            formValues.Add("F[0].P2[0].po_zapis_doOR_cr[0]", EvidenceDoObchodnihoRejstriku ?? "");
            formValues.Add(
                "F[0].P2[0].po_zapis_doOR_datum[1]",
                DatumVydaniOsvedceni != null
                    ? DatumVydaniOsvedceni.Value.ToString("dd.MM.yyyy")
                    : "");
            formValues.Add("UkonceniCinnosti", UkonceniCinnosti ? "-----" : "       -------");
            formValues.Add(
                "DatumUkonceni",
                DatumUkonceni != null ? DatumUkonceni.Value.ToString("MM yyyy") : "");
            formValues.Add("ProdejPodniku", ProdejPodniku ? "-----" : "      -------");
            formValues.Add("DatumProdeje", DatumProdeje != null ? DatumProdeje.Value.ToString("MM yyyy") : "");
            formValues.Add("F[0].P2[0].po_banka_cu[0]", CisloUctu ?? "");
            formValues.Add("F[0].P2[0].po_banka_kod[0]", KodBanky ?? "");

            if (PredmetyPodnikani.Count > 0)
            {
                formValues.Add("F[0].P3[0].po_podnikani_predmet_1[0]", PredmetyPodnikani[0].Cinnost ?? "");
                formValues.Add("F[0].P3[0].po_podnikani_rok_1[0]", PredmetyPodnikani[0].RokZahajeniCinnosti.ToString());
            }
            if (PredmetyPodnikani.Count > 1)
            {
                formValues.Add("F[0].P3[0].po_podnikani_predmet_2[0]", PredmetyPodnikani[1].Cinnost ?? "");
                formValues.Add("F[0].P3[0].po_podnikani_rok_2[0]", PredmetyPodnikani[1].RokZahajeniCinnosti.ToString());
            }
            if (PredmetyPodnikani.Count > 2)
            {
                formValues.Add("F[0].P3[0].po_podnikani_predmet_3[0]", PredmetyPodnikani[2].Cinnost ?? "");
                formValues.Add("F[0].P3[0].po_podnikani_rok_3[0]", PredmetyPodnikani[2].RokZahajeniCinnosti.ToString());
            }
            if (PredmetyPodnikani.Count > 3)
            {
                formValues.Add("F[0].P3[0].po_podnikani_predmet_4[0]", PredmetyPodnikani[3].Cinnost ?? "");
                formValues.Add("F[0].P3[0].po_podnikani_rok_4[0]", PredmetyPodnikani[3].RokZahajeniCinnosti.ToString());
            }

            formValues.Add("struktura_zvirat", StrukturaChovanychZvirat ?? "");
            formValues.Add("struktura_plodin", StrukturaPestovanychPlodin ?? "");
            formValues.Add("F[0].P3[0].zamereni_vyroby[0]", StrukturaJinaVyroba ?? "");

            PlatceDph.ScratchYesNoAnswer("PlatceDphAno", "PlatceDphNe", formValues);
            NavyseniMladehoZemedelce.ScratchYesNoAnswer("NavyseniAno", "NavyseniNe", formValues);
            UkonceniCinnosti.ScratchYesNoAnswer("PlanujiUkoncitAno", "PlanujiUkoncitNe", formValues);
            ProdejPodniku.ScratchYesNoAnswer("PlanujiProdatAno", "PlanujiProdatNe", formValues);

            if (DatumUkonceni.HasValue)
            {
                DatumUkonceni.Value.Month.ToString()
                    .WriteToSequentialFields(
                        "ukonceni_mesic_{0:2}",
                        formValues);
                DatumUkonceni.Value.Year.ToString()
                    .WriteToSequentialFields(
                        "ukonceni_rok_{0}",
                        formValues);
            }

            if (DatumProdeje.HasValue)
            {
                DatumProdeje.Value.Month.ToString()
                    .WriteToSequentialFields(
                        "prodej_mesic_{0:2}",
                        formValues);
                DatumProdeje.Value.Year.ToString()
                    .WriteToSequentialFields(
                        "prodej_rok_{0}",
                        formValues);
            }

            if (RostlinnaVyroba)
                formValues.Add("rostlinnaVyroba", "1");
            if (ZivocisnaVyroba)
                formValues.Add("zivocisnaVyroba", "1");
            if (JinaVyroba)
                formValues.Add("jinaVyroba", "1");

            var jmenoZadatele = string.Format(
                "{0} {1}",
                IsPravnickaOsoba ? POObchodneJmeno : FOJmeno,
                IsPravnickaOsoba ? "" : FOPrijmeni);

            formValues.Add("F[0].P4[0].prohlaseni_zadatel[0]", jmenoZadatele);
            formValues.Add("F[0].#subform[5].prohlaseni_zadatel[0]", jmenoZadatele);

            (DateTime.Now.Day.ToString("D2") + DateTime.Now.Month.ToString("D2"))
                .WriteToSequentialFields(
                    "hlavickaDatum_{0}",
                    formValues);

            formValues.Add("cestneProhlaseni", CestneProhlaseni ? "1" : "0");
            formValues.Add("souhlasSeSpracovanim", Souhlas ? "1" : "0");

            form.FillForm(formValues, ms);
            form.CloseForm();
            return ms.ToArray();

            /*
 * Yet to add
            
[Display(GroupName = "header", Name = "Plátce DPH")]
public bool PlatceDph { get; set; }

[Display(GroupName = "header", Name = "Navýšení pro mladého zemědělce")]
public bool NavyseniMladehoZemedelce { get; set; }
 * 
 * All from Struktura chovu a vyroby
 */
        }
    }
}