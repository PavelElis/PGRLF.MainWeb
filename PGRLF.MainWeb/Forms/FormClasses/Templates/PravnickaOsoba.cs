using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class PravnickaOsoba
    {
        public PravnickaOsoba()
        {
            SidloSpolecnosti = new Adresa();
            MistoPodnikani = new Adresa();
        }

        //Obecné údaje

        [Display(ResourceType = typeof(FormResources), Name = "ObchodniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ObchodniJmeno")]
        public string ObchodniJmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TypSpolecnosti")]
        [DataType("TypSpolecnosti")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_TypSpolecnosti")]
        public string TypPO { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        [RegularExpression("\\d{8}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_IC")]
        public string IC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DIC")]
        [RegularExpression("\\w{2}\\d{8,10}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DIC")]
        public string DIC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PocetSpolecniku")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PocetSpolecniku")]
        public int? PocetSpolecniku { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ZakladniKapital")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ZakladniKapital")]
        public int? ZakladniKapital { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO1TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string ZO1Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string ZO1Prijmeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO1TitulZaJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Funkce")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO1Funkce { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO2TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        public string ZO2Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        public string ZO2Prijmeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO2TitulZaJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO2Funkce { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO3TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        public string ZO3Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        public string ZO3Prijmeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO3TitulZaJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO3Funkce { get; set; }

        public Adresa SidloSpolecnosti { get; set; }

        public bool POJeMistoPodnikaniStejne { get; set; }

        public Adresa MistoPodnikani { get; set; }


    }
}