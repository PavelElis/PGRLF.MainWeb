using Foolproof;
using PGRLF.MainWeb.Forms.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class BankovniSpojeni
    {

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources), 
            Name = "PodporaZemedelec_CisloUctu")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_CisloUctu")]
        [RegularExpression(Helpers.AccountNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_CisloUctu")]
        public string CisloUctu { get; set; }

        [Display(GroupName = "spolecnaCast", ResourceType = typeof(FormResources),
            Name = "PodporaZemedelec_KodBankyVyberteBanku")]
        [DataType("Banka")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_KodBanky")]
        public string KodBanky { get; set; }
    }
}