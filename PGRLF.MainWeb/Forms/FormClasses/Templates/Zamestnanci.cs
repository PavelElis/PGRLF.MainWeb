using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class Zamestnanci
    {

        public Zamestnanci()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "VelikostPodniku")]
        [DataType("Velikosti")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_VelikostPodniku")]
        public string VelikostPodniku { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PocetZamestnancu")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PocetZamestnancu")]
        public uint PocetZamestnancu { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Obrat")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obrat")]
        public int Obrat { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "BilancniSuma")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_BilancniSuma")]
        public int BilancniSuma { get; set; }


    }
}