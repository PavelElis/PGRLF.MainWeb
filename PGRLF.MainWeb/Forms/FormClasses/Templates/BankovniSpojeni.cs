using System.ComponentModel.DataAnnotations;
using PGRLF.MainWeb.Forms.Enums;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class BankovniSpojeni
    {
        [Display(ResourceType = typeof(FormResources), Name = "CisloUctu")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloUctu")]
        [RegularExpression("(\\d{1,6}\\-)?\\d{0,10}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_CisloUctu")]
        public string CisloUctu { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KodBanky")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_KodBanky")]
        public Banka? KodBanky { get; set; }
    }
}