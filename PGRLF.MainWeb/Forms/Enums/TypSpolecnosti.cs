using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum TypSpolecnosti
    {
        [Display(Name = "Akciová společnost")]
        AkciovaSpolecnost,
        [Display(Name = "Společnost s ručením omezeným")]
        SpolecnostSRucenimOmezenym,
        [Display(Name = "Komanditní společnost")]
        KomanditniSpolecnost,
        [Display(Name = "Veřejná obchodní společnost")]
        VerejnaObchodniSpolecnost,
        [Display(Name = "Družstvo")]
        Druzstvo
    }
}