using PGRLF.MainWeb.Forms.Enums;
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
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_PocetSpolecniku")]
        public int PocetSpolecniku { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "ZakladniKapital")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_ZakladniKapital")]
        public int ZakladniKapital { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO1TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string ZO1Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string ZO1Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO1TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Funkce")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO1Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO2TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        public string ZO2Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        public string ZO2Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO2TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO2Funkce { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string ZO3TitulPredJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        public string ZO3Jmeno { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Prijmeni")]
        public string ZO3Prijmeni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string ZO3TitulZaJmenem { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Funkce")]
        [DataType("FunkceVSpolecnosti")]
        public string ZO3Funkce { get; set; }

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