using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum Pojistovna
    {
        [Display(Name = "Agra Pojišťovna")]
        AgraPojistovna,
        [Display(Name = "Česká pojišťovna, a.s.")]
        CeskaPojistovna,
        [Display(Name = "ČSOB Pojišťovna, a.s.")]
        CSOBPojistovna,
        [Display(Name = "Pojišťovna Generali")]
        PojistovnaGenerali,
        [Display(Name = "Hasičská vzájemná pojišťovna, a.s.")]
        HasicskaPojistovna,
        [Display(Name = "Kooperativa pojišťovna, a.s.")]
        KooperativaPojistovna
    }
}