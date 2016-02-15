using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class DeMinimisOsoba
    {
        public string Index { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ObchodniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ObchodniJmeno")]
        public string Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        [RegularExpression("\\d{8}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_IC")]
        public string IC { get; set; }

        public Adresa Adresa { get; set; }
    }
}