using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses
{
    public enum DruhVyroby
    {
        [Description("Rostlinná výroba")]
        Rostlinna,

        [Description("Živočišná výroba")]
        Zivocisna,

        [Description("Jiná výroba")]
        Jine
    }
}