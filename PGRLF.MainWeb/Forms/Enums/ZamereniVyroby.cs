using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum ZamereniVyroby
    {
        [Display(Name = "Rostlinná výroba")]
        Rostlinna,
        [Display(Name = "Živočišná výroba")]
        Zivocisna,
        [Display(Name = "Jiná")]
        Jina
    }
}