using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace PGRLF.MainWeb.Forms.Enums
{
    public enum PravniForma
    {
        [Display(ResourceType = typeof(FormResources), Name = "FyzickaOsoba")]
        FyzickaOsoba,

        [Display(ResourceType = typeof(FormResources), Name = "PravnickaOsoba")]
        PravnickaOsoba,

        [Display(ResourceType = typeof(FormResources), Name = "SvazekObci")]
        SvazekObci
    }
}