using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class DeMinimisPodpora
    {
        public string Index { get; set; }

        //[Display(ResourceType = typeof(FormResources), Name = "DeMinimisDatumPoskytnuti")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_ProdejPodnikuDatum")]
        //[Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ProdejPodnikuDatum")]
        public DateTime? DatumPoskytnuti { get; set; }

        public string Poskytovatel { get; set; }

        public string Castka { get; set; }
    }
}