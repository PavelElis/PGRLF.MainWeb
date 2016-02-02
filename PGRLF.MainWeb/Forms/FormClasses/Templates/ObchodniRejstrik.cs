using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class ObchodniRejstrik
    {

        [Display(ResourceType = typeof(FormResources), Name = "ORZapis")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORZapis")]
        public string ORZapis { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ORVydal")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORVydal")]
        public string ORVydal { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ORDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_ORDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORDatum")]
        public DateTime? ORDatum { get; set; }

    }
}