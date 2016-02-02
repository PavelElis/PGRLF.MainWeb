using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class PlanovaneUkonceni
    {
        [Display(ResourceType = typeof(FormResources), Name = "ProdejPodniku")]
        public bool ProdejPodniku { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ProdejPodnikuDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_ProdejPodnikuDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ProdejPodnikuDatum")]
        public DateTime? ProdejPodnikuDatum { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "UkonceniCinnosti")]
        public bool UkonceniCinnosti { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "UkonceniCinnostiDatum")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_UkonceniCinnostiDatum")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_UkonceniCinnostiDatum")]
        public DateTime? UkonceniCinnostiDatum { get; set; }
    }
}