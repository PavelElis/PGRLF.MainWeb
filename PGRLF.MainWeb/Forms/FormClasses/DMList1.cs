using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    public class DMList1
    {
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof (FormResources), ErrorMessageResourceName = "PredmetPodnikani__Zadejte_činnost_vykonávanou_při_podnikání")]
        [Display(ResourceType = typeof (FormResources), Name = "DMList11")]
        [UIHint("Year")]
        public string DMList11 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_UdajJePovinny")]
        [Display(ResourceType = typeof(FormResources), Name = "DMList12")]
        public string DMList12 { get; set; }
    }
}