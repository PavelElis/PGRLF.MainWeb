using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class PohledavkyZavazky
    {

        public PohledavkyZavazky()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "PohledavkyAktualni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PohledavkyAktualni")]
        public int PohledavkyAktualni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PohledavkyLonske")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PohledavkyLonske")]
        public int PohledavkyLonske { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PohledavkyPredlonske")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PohledavkyPredlonske")]
        public int PohledavkyPredlonske { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ZavazkyAktualni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ZavazkyAktualni")]
        public int ZavazkyAktualni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ZavazkyLonske")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ZavazkyLonske")]
        public int ZavazkyLonske { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ZavazkyPredlonske")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ZavazkyPredlonske")]
        public int ZavazkyPredlonske { get; set; }


    }
}