using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class ZemedelskaVyroba
    {
        [Display(ResourceType = typeof(FormResources), Name = "Vyroba")]
        [DataType("ZamereniVyroby")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Vyroba")]
        public string Vyroba { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "VyrobaJine")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_VyrobaJine")]
        public string VyrobaJine { get; set; }
    }
}