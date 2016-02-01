using System.ComponentModel;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
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