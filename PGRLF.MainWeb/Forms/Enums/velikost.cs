using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum Velikost
    {
        [Display(Name = "Malý")]
        Maly,
        [Display(Name = "Střední")]
        Stredni,
        [Display(Name = "Velký")]
        Velky
    }
}