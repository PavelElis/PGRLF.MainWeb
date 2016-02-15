using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum Kraj
    {
        [Display(Name = "Hlavní město Praha")]
        HlavniMestoPraha,
        [Display(Name = "Středočeský kraj")]
        Stredocesky,
        [Display(Name = "Plzeňský kraj")]
        Plzensky,
        [Display(Name = "Jihočeský kraj")]
        Jihocesky,
        [Display(Name = "Ústecký kraj")]
        Ustecky,
        [Display(Name = "Karlovarský kraj")]
        Karlovarsky,
        [Display(Name = "Pardubický kraj")]
        Pardubicky,
        [Display(Name = "Královéhradecký kraj")]
        Kralovehradecky,
        [Display(Name = "Liberecký kraj")]
        Liberecky,
        [Display(Name = "Jihomoravský kraj")]
        Jihomoravsky,
        [Display(Name = "Vysočina")]
        Vysocina,
        [Display(Name = "Zlínský kraj")]
        Zlinsky,
        [Display(Name = "Olomoucký kraj")]
        Olomoucky,
        [Display(Name = "Moravskoslezský kraj")]
        Moravskoslezsky
    }
}