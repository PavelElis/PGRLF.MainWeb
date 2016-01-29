using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class SvazekObci
    {
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "NazevSvazkuObci")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_NazevSvazkuObci")]
        public string NazevSvazkuObci { get; set; }

        [Display(GroupName = "svazekObci", ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
           ErrorMessageResourceName = "Nevyplneno_IC")]
        public string IC { get; set; }

        [Display(GroupName = "svazekObci", ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_DIC")]
        public string DIC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string TitulPredJmenem { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string Jmeno { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string Prijmeni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string TitulZaJmenem { get; set; }

        //Adresa svazku obce

        public Adresa SidloSvazkuObci { get; set; }
    }
}