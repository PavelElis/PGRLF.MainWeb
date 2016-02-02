using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class SvazekObci
    {
        [Display(ResourceType = typeof(FormResources), Name = "NazevSvazkuObci")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_NazevSvazkuObci")]
        public string NazevSvazkuObci { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        [RegularExpression("\\d{8}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_IC")]
        public string IC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DIC")]
        [RegularExpression("\\w{2}\\d{8,10}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DIC")]
        public string DIC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string Prijmeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string TitulZaJmenem { get; set; }

        //Adresa svazku obce

        public Adresa SidloSvazkuObci { get; set; }
    }
}