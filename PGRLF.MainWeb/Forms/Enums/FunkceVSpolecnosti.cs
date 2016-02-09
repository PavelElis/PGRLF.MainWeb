using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum FunkceVSpolecnosti
    {
        [Display(Name = "Předseda představenstva")]
        PredsedaPredstavenstva,
        [Display(Name = "Místopředseda představenstva")]
        MistopredsedaPredstavenstva,
        [Display(Name = "Člen představenstva")]
        ClenPredstavenstva,
        [Display(Name = "Jednatel")]
        Jednatel,
        [Display(Name = "Komplementář")]
        Komplementar,
        [Display(Name = "Společník")]
        Spolecnik,
        [Display(Name = "Likvidátor")]
        Likvidator,
        [Display(Name = "Prokurista")]
        Prokurista,
        [Display(Name = "Správce konkurzní podstaty")]
        SpravceKonkurzniPodstaty,
        [Display(Name = "Insolvenční správce")]
        InsolvencniSpravce,
        [Display(Name = "Na základě plné moci")]
        NaZakladePlneMoci,
        [Display(Name = "Vyrovnací správce")]
        VyrovnavaciSpravce
    }
}