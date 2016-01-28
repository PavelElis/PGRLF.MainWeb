using Foolproof;
using PGRLF.MainWeb.Forms.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class FyzickaOsoba
    {

        //Osobní údaje

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string FOTitulPredMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string FOJmeno { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string FOPrijmeni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string FOTitulZaMenom { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "DatumNarozeni")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DatumNarozeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DatumNarozeni")]
        public DateTime? FODatumNarozeni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "RodneCislo")]
        [DisplayFormat(NullDisplayText = "------/--", ConvertEmptyStringToNull = true)]
        [RegularExpression("(\\d)(\\d)(\\d)(\\d)(\\d)(\\d)(\\/)(\\d)(\\d)(\\d)(\\d)?",
            ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_RodneCislo")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_RodneCislo")]
        public string FORodneCislo { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        public string FOIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DIC")]
        public string FODIC { get; set; }


        //Adresa trvalého pobytu

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Ulice")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Ulice")]
        public string FOTPUlice { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string FOTPCisloPopisne { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string FOTPCisloOrientacni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Obec")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string FOTPObec { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_PSC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string FOTPPSC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string FOTPKraj { get; set; }


        //Adresa místa podnikání

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "JeMistoPodnikaniStejneFo")]
        public bool FOJeMistoPodnikaniStejne { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Ulice")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Ulice")]
        public string FOMPUlice { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string FOMPCisloPopisne { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string FOMPCisloOrientacni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Obec")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string FOMPObec { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_PSC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string FOMPPSC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string FOMPKraj { get; set; }

        public void nullovani()
        {
            FOTitulPredMenom = null;
            FOJmeno = null;
            FOPrijmeni = null;
            FOTitulZaMenom = null;
            FODatumNarozeni = null;
            FORodneCislo = null;
            FOIC = null;
            FODIC = null;

            FOTPUlice = null;
            FOTPCisloPopisne = null;
            FOTPCisloOrientacni = null;
            FOTPObec = null;
            FOTPPSC = null;
            FOTPKraj = null;

            FOMPUlice = null;
            FOMPCisloPopisne = null;
            FOMPCisloOrientacni = null;
            FOMPObec = null;
            FOMPPSC = null;
            FOMPKraj = null;
        }

        public void nastavMistoPodnikani()
        {
            if (FOJeMistoPodnikaniStejne)
            {
                FOMPUlice = FOTPUlice;
                FOMPCisloPopisne = FOTPCisloPopisne;
                FOMPPSC = FOTPPSC;
                FOMPCisloOrientacni = FOTPCisloOrientacni;
                FOMPObec = FOTPObec;
                FOMPKraj = FOTPKraj;
            }
        }
    }
}