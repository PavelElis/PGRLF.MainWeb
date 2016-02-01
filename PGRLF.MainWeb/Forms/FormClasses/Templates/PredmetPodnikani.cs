using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class PredmetPodnikani
    {
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof (FormResources), ErrorMessageResourceName = "PredmetPodnikani__Zadejte_činnost_vykonávanou_při_podnikání")]
        [Display(ResourceType = typeof (FormResources), Name = "PodporaZemedelec_RokZahajeniCinnosti")]
        [UIHint("Year")]
        public string RokZahajeniCinnosti { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "PodporaZemedelec_UdajJePovinny")]
        [Display(ResourceType = typeof(FormResources), Name = "PodporaZemedelec_Cinnost")]
        public string Cinnost { get; set; }
    }
}