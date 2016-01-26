using PGRLF.MainWeb.Forms.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class ZodpovednaOsoba
    {
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string POZOTitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Jmeno")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string POZOJmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string POZOPrijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string POZOTitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "FunkceZodpovedneOsoby")]
        [DataType("FunkceVSpolecnosti")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_FunkceZodpovedneOsoby")]
        public string POZOFunkce { get; set; }
    }
}