using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using PGRLF.MainWeb.Forms.Validation;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    public class fo
    {
        public bool IsPravnickaOsoba { get; set; }
        
        #region Fyzicka osoba

        [RegularExpression("(\\d)(\\d)(\\d)(\\d)(\\d)(\\d)(\\/)(\\d)(\\d)(\\d)(\\d)?",
            ErrorMessage = "Zadejte rodné číslo dddddd/ddd anebo dddddd/dddd")]
        [DisplayFormat(NullDisplayText = "------/--", ConvertEmptyStringToNull = true)]
        [Display(GroupName = "fyzickaOsoba", Name = "Rodné číslo")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte rodné číslo žadatele")]
        public string FORodneCislo { get; set; }

        [RegularExpression("(\\d)(\\d)(\\d)(\\d)(\\d)(\\d)(\\/)(\\d)(\\d)(\\d)(\\d)?",
            ErrorMessage = "Zadejte rodné číslo dddddd/ddd anebo dddddd/dddd")]
        [DisplayFormat(NullDisplayText = "------/--", ConvertEmptyStringToNull = true)]
        [Display(GroupName = "fyzickaOsoba", Name = "Rodné číslo")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte rodné číslo žadatele")]
        public string XFORodneCislo { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Datum narození")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte datum narození žadatele")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FODatumNarozeni { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "IČ")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte IČ žadatele - fyzické osoby")]
        public string FOIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "DIČ")]
        public string FODIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Titul před jménem")]
        public string FOTitulPredMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Titul za jménem")]
        public string FOTitulZaMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Jméno")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte křestní jméno žadatele")]
        public string FOJmeno { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Příjmení")]
        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte příjmení žadatele")]
        public string FOPrijmeni { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage = "Zadejte název ulice trvalého bydliště žadatele")]*/
        [Display(GroupName = "fyzickaOsoba", Name = "Ulice")]
        public string TPUlice { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage = "Zadejte číslo popisné (uváděné v katastru nemovitostí) trvalého bydliště žadatele")]
        [Display(GroupName = "fyzickaOsoba", Name = "Popisné číslo")]
        public string TPCisloPopisne { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage = "Zadejte poštovní směrovací číslo trvalého bydliště žadatele")]
        [Display(GroupName = "fyzickaOsoba", Name = "PSČ")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string TPPSC { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage = "Zadejte číslo orientační trvalého bydliště žadatele")]*/
        [Display(GroupName = "fyzickaOsoba", Name = "Orientační číslo")]
        public string TPCisloOrientacni { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage = "Zadejte název obce (včetně místní části) trvalého bydliště žadatele")]
        [Display(GroupName = "fyzickaOsoba", Name = "Obec")]
        public string TPObec { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Vyberte kraj trvalého bydliště žadatele")]
        [Display(GroupName = "fyzickaOsoba", Name = "Kraj")]
        [DataType("Kraj")]
        public string TPKraj { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false, ErrorMessage = "Zadejte příjmení žadatele")]
        [Display(GroupName = "fyzickaOsoba", Name = "Telefon 1")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPTelefon1 { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Telefon 2")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPTelefon2 { get; set; }

        [Display(GroupName = "fyzickaOsoba", Name = "Fax")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string TPFax { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", false,
            ErrorMessage =
                "Zadejte kontaktní e-mail žadatele. Zadávejte prosím živou a prověřenou e-mailovou adresu pro primární komunikaci s PGRLF"
            )]
        [Display(GroupName = "fyzickaOsoba", Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string TPEmail { get; set; }

        [Display(GroupName = "mistoPodnikani", Name = "Stejné jako \"Adresa trvalého pobytu\"")]
        public bool JeMistoPodnikaniStejneFo { get; set; }

        [Display(GroupName = "mistoPodnikani", Name = "Ulice")]
        public string MPUlice { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte popisné číslo")]
        [Display(GroupName = "mistoPodnikani", Name = "Popisné číslo")]
        public string MPCisloPopisne { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte PSČ")]
        [Display(GroupName = "mistoPodnikani", Name = "PSČ")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string MPPSC { get; set; }

        [Display(GroupName = "mistoPodnikani", Name = "Orientační číslo")]
        public string MPCisloOrientacni { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte obec")]
        [Display(GroupName = "mistoPodnikani", Name = "Obec")]
        public string MPObec { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejneFo" }, new object[] { false, false }, ErrorMessage = "Zadejte kraj")]
        [Display(GroupName = "mistoPodnikani", Name = "Kraj")]
        [DataType("Kraj")]
        public string MPKraj { get; set; }

        // Pravnicka osoba

        [Display(GroupName = "mistoPodnikani", Name = "Stejné jako \"Sídlo společnosti\"")]
        public bool JeMistoPodnikaniStejnePo { get; set; }

        [Display(GroupName = "mistoPodnikani", Name = "Ulice")]
        public string MPUlicePo { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte popisné číslo")]
        [Display(GroupName = "mistoPodnikani", Name = "Popisné číslo")]
        public string MPCisloPopisnePo { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte PSČ")]
        [Display(GroupName = "mistoPodnikani", Name = "PSČ")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string MPPSCPo { get; set; }

        [Display(GroupName = "mistoPodnikani", Name = "Orientační číslo")]
        public string MPCisloOrientacniPo { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte obec")]
        [Display(GroupName = "mistoPodnikani", Name = "Obec")]
        public string MPObecPo { get; set; }

        [RequiredIfFieldsHaveValueAttribute(new[] { "IsPravnickaOsoba", "JeMistoPodnikaniStejnePo" }, new object[] { true, false }, ErrorMessage = "Zadejte kraj")]
        [Display(GroupName = "mistoPodnikani", Name = "Kraj")]
        [DataType("Kraj")]
        public string MPKrajPo { get; set; }

        #endregion

        #region Pravnicka osoba

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte obchodní jméno právnické osoby žadatele")]
        [Display(GroupName = "pravnickaOsoba", Name = "Obchodní jméno")]
        public string POObchodneJmeno { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte IČ žadatele - právnické osoby")]
        [Display(GroupName = "pravnickaOsoba", Name = "IČ")]
        public string POIC { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte DIČ žadatele - právnické osoby")]
        [Display(GroupName = "pravnickaOsoba", Name = "DIČ")]
        public string PODIC { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Typ společnosti")]
        [DataType("TypSpolecnosti")]
        public string POTypPO { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO1TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO1TitulZaJmenem { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte jméno odpovědného zástupce právnické osoby")]
        [Display(GroupName = "pravnickaOsoba", Name = "Jméno")]
        public string ZO1Jmeno { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte příjmení odpovědného zástupce právnické osoby")]
        [Display(GroupName = "pravnickaOsoba", Name = "Příjmení")]
        public string ZO1Prijmeni { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Vyberte funkci odpovědného zástupce právnické osoby")]
        [Display(GroupName = "pravnickaOsoba", Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO1Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO2TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO2TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Jméno")]
        public string ZO2Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Příjmení")]
        public string ZO2Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO2Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul před jménem")]
        public string ZO3TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Titul za jménem")]
        public string ZO3TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Jméno")]
        public string ZO3Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Příjmení")]
        public string ZO3Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO3Funkce { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte název sídla společnosti")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Sídlo společnosti")]
        public string SSSidloSpolecnosti { get; set; }

        //[RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte název ulice sídla právnické osoby")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Ulice")]
        public string SSUlice { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte číslo popisné (uváděné v katastru nemovitostí) sídla právnické osoby")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Popisné číslo")]
        public string SSCisloPopisne { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte poštovní směrovací číslo sídla právnické osoby")]
        [Display(GroupName = "sidloSpolecnosti", Name = "PSČ")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zadejte PSČ ve formátu xxxxx")]
        public string SSPSC { get; set; }

        /*[RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte číslo orientační sídla právnické osoby")]*/
        [Display(GroupName = "sidloSpolecnosti", Name = "Orientační číslo")]
        public string SSCisloOrientacni { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte název obce (včetně místní části) sídla právnické osoby")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Obec")]
        public string SSObec { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage = "Zadejte kraj")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Kraj")]
        [DataType("Kraj")]
        public string SSKraj { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte kontaktní telefonní číslo žadatele")]
        [Display(GroupName = "sidloSpolecnosti", Name = "Telefon 1")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string SSTelefon1 { get; set; }

        [Display(GroupName = "sidloSpolecnosti", Name = "Telefon 2")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string SSTelefon2 { get; set; }

        [Display(GroupName = "sidloSpolecnosti", Name = "Fax")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky")]
        public string SSFax { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true,
            ErrorMessage =
                "Zadejte kontaktní e-mail žadatele. Zadávejte prosím živou a prověřenou e-mailovou adresu pro primární komunikaci s PGRLF"
            )]
        [Display(GroupName = "sidloSpolecnosti", Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string SSEmail { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte Spisovou značku z výpisu z obchodního rejstříku")]
        [Display(GroupName = "spisovaZnacka", Name = "Zápis do obchodního rejstříku")]
        public string ZapisDoObchodnihoRejstriku { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte soud, u kterého je právnická osoba vedena")]
        [Display(GroupName = "spisovaZnacka", Name = "Vydal")]
        public string Vydal { get; set; }

        [RequiredIfFieldHasValue("IsPravnickaOsoba", true, ErrorMessage = "Zadejte datum zápisu právnické osoby do obchodního rejstříku")]
        [Display(GroupName = "spisovaZnacka", Name = "Datum zápisu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumZapisu { get; set; }

        #endregion

        #region spolocna cast

        [Required(ErrorMessage = "Zadejte evidenci zemědělského podnikatele")]
        [Display(GroupName = "spolecnaCast", Name = "Evidence zemědělského podnikatele u")]
        public string EvidenceDoObchodnihoRejstriku { get; set; }

        [Required(ErrorMessage = "Zadejte datum vydání osvědčení zemědělského podnikatele")]
        [Display(GroupName = "spolecnaCast",
            Name = "Datum vydání osvědčení o zápisu do evidence zemědělského podnikatele")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumVydaniOsvedceni { get; set; }


        [Display(GroupName = "spolecnaCast", Name = "Plánuji ukončit zemědělskou činnost")]
        public bool UkonceniCinnosti { get; set; }

        [RequiredIfFieldHasValue("UkonceniCinnosti", true,
            ErrorMessage = "Zadejte měsíc a rok, ve kterém plánujete ukončit zemědělskou činnost")]
        [Display(GroupName = "spolecnaCast", Name = "Datum ukončení")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumUkonceni { get; set; }

        [Display(GroupName = "spolecnaCast", Name = "Plánuji prodat podnik")]
        public bool ProdejPodniku { get; set; }

        [RequiredIfFieldHasValue("ProdejPodniku", true,
            ErrorMessage = "Zadejte měsíc a rok, ve kterém plánujete prodat zemědělský podnik")]
        [Display(GroupName = "spolecnaCast", Name = "Datum prodeje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumProdeje { get; set; }

        [Required(ErrorMessage = "Zadejte název banky bankovního spojení žadatele")]
        [Display(GroupName = "spolecnaCast", Name = "Bankovní spojení (název, adresa)")]
        public string BankovniSpojeni { get; set; }

        [Required(ErrorMessage = "Zadejte číslo bankovního účtu žadatele")]
        [Display(GroupName = "spolecnaCast", Name = "Číslo účtu")]
        [RegularExpression(Helpers.AccountNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_Povolené_znaky_Cislo_Uctu")]
        public string CisloUctu { get; set; }

        [Display(GroupName = "spolecnaCast", Name = "Kód banky (Vyberte banku)")]
        [DataType("Banka")]
        public string KodBanky { get; set; }


        public bool ZadamPodporu { get; set; }

        #endregion

    }
}
