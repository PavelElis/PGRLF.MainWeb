using PGRLF.MainWeb.Forms.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class PravnickaOsoba
    {
        public PravnickaOsoba()
        {
            ObchodniJmeno = null;
            TypPO = null;
            IC = null;
            DIC = null;
            PocetSpolecniku = 0;
            ZakladniKapital = 0;
        }

        //Obecné údaje

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "ObchodniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_ObchodniJmeno")]
        public string ObchodniJmeno { get; set; }

        [Display(GroupName = "JePravnickaOsoba", ResourceType = typeof(FormResources), Name = "TypSpolecnosti")]
        [DataType("TypSpolecnosti")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_TypSpolecnosti")]
        public string TypPO { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_IC")]
        public string IC { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_DIC")]
        public string DIC { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PocetSpolecniku")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_PocetSpolecniku")]
        public int PocetSpolecniku { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "ZakladniKapital")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_ZakladniKapital")]
        public int ZakladniKapital { get; set; }

        public Adresa SidloSpolecnosti { get; set; }

        public bool POJeMistoPodnikaniStejne { get; set; }

        public Adresa MistoPodnikani { get; set; }


        /*public void nastavMistoPodnikani()
        {
            if (POJeMistoPodnikaniStejne)
            {
                POMPUlice = POUlice;
                POMPCisloPopisne = POCisloPopisne;
                POMPCisloOrientacni = POCisloOrientacni;
                POMPObec = POObec;
                POMPPSC = POPSC;
                POMPKraj = POKraj;
            }
        }*/
    }
}