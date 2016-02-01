﻿using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class BankovniSpojeni
    {
        [Display(ResourceType = typeof(FormResources), Name = "CisloUctu")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloUctu")]
        [RegularExpression(Helpers.Helpers.AccountNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_CisloUctu")]
        public string CisloUctu { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KodBanky")]
        [DataType("Banka")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_KodBanky")]
        public string KodBanky { get; set; }
    }
}