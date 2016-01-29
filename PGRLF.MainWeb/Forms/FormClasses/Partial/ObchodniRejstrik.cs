using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class ObchodniRejstrik
    {

        [Display(GroupName = "obchodniRejstrik", ResourceType = typeof(FormResources), Name = "ORZapis")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORZapis")]
        public string ORZapis { get; set; }

        [Display(GroupName = "obchodniRejstrik", ResourceType = typeof(FormResources), Name = "ORVydal")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORVydal")]
        public string ORVydal { get; set; }

        [Display(GroupName = "obchodniRejstrik", ResourceType = typeof(FormResources), Name = "ORDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_ORDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ORDatum")]
        public DateTime? ORDatum { get; set; }

    }
}