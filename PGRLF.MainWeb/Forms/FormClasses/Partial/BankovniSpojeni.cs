using PGRLF.MainWeb.Forms.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class BankovniSpojeni
    {
        [Display(GroupName = "bankovniSpojeni", ResourceType = typeof(FormResources), Name = "CisloUctu")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloUctu")]
        [RegularExpression(Helpers.AccountNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_CisloUctu")]
        public string CisloUctu { get; set; }

        [Display(GroupName = "bankovniSpojeni", ResourceType = typeof(FormResources), Name = "KodBanky")]
        [DataType("Banka")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_KodBanky")]
        public string KodBanky { get; set; }
    }
}