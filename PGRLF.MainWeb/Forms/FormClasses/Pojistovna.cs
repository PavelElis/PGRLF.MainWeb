using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    public class Pojistovna
    {
        [Display(GroupName = "pojistovna", Name = "Číslo pojistné smlouvy")]
        [Required(ErrorMessage = "Zadejte číslo pojistné smlouvy")]
        public string CisloZmluvy { get; set; }

        [Display(GroupName = "pojistovna", Name = "Pojišťovna")]
        [DataType("Pojistovna")]
        [Required(ErrorMessage = "Zadejte název pojišťovny")]
        public string Nazev { get; set; }

        [Display(GroupName = "pojistovna", Name = "Pojistné v Kč")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Zadejte pojistnou částku")]
        public string Castka { get; set; }
    }
}