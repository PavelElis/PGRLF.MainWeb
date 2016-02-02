using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class FyzickaOsoba
    {

        public FyzickaOsoba()
        {
            TrvalyPobyt = new Adresa();
            MistoPodnikani = new Adresa();
        }

        //Osobní údaje

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string Prijmeni { get; set; }

        [Display( ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string TitulZaJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DatumNarozeni")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DatumNarozeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DatumNarozeni")]
        public DateTime? DatumNarozeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "RodneCislo")]
        [DisplayFormat(NullDisplayText = "------/--", ConvertEmptyStringToNull = true)]
        [RegularExpression("(\\d{6})(\\/)(\\d{3,4})",
            ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_RodneCislo")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_RodneCislo")]
        public string RodneCislo { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        [RegularExpression("\\d{8}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_IC")]
        public string IC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DIC")]
        [RegularExpression("\\w{2}\\d{8,10}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DIC")]
        public string DIC { get; set; }

        public Adresa TrvalyPobyt { get; set; }

        public bool FOJeMistoPodnikaniStejne { get; set; }

        public Adresa MistoPodnikani { get; set; }

    }
}