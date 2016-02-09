using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class VymeraPudy
    {

        public VymeraPudy()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "PudaCelkova")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PudaCelkova")]
        public string PudaCelkova { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PudaVlastni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PudaVlastni")]
        public string PudaVlastni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PudaCizi")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PudaCizi")]
        public string PudaCizi { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PudaNakup")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PudaNakup")]
        public string PudaNakup { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KupniCena")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_KupniCena")]
        public string KupniCena { get; set; }



    }
}