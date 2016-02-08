using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class CZNACEdotazy
    {

        public CZNACEdotazy()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "CZNACE")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CZNACE")]
        public string CZNACE { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DobaPodnikani")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DobaPodnikani")]
        public int DobaPodnikani { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "UkonceneObdobi")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_UkonceneObdobi")]
        public string UkonceneObdobi { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "OdhadTrzeb")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_OdhadTrzeb")]
        public int OdhadTrzeb { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PrumernyPocetZamestnancu")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PrumernyPocetZamestnancu")]
        public int PrumernyPocetZamestnancu { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PodilNejvetsihoOdberatele")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PodilNejvetsihoOdberatele")]
        public int PodilNejvetsihoOdberatele { get; set; }
    }
}