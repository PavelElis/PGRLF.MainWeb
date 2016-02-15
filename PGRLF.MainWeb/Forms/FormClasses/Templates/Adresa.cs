using System.ComponentModel.DataAnnotations;
using PGRLF.MainWeb.Forms.Enums;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class Adresa
    {

        public Adresa()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "Ulice")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Ulice")]
        public string Ulice { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string CisloPopisne { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string CisloOrientacni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Obec")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string Obec { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("\\d{5}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_PSC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string PSC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public Kraj? Kraj { get; set; }
    }
}