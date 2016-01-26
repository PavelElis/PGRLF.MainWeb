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
            POZodpovedneOsoby = new List<ZodpovednaOsoba>();
            POZodpovedneOsoby.Add(new ZodpovednaOsoba());
        }

        //Obecné údaje

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "ObchodniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_ObchodniJmeno")]
        public string POObchodniJmeno { get; set; }

        [Display(GroupName = "JePravnickaOsoba", ResourceType = typeof(FormResources), Name = "TypSpolecnosti")]
        [DataType("TypSpolecnosti")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_TypSpolecnosti")]
        public string POTypPO { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_IC")]
        public string POIC { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_DIC")]
        public string PODIC { get; set; }

        public List<ZodpovednaOsoba> POZodpovedneOsoby { get; set; }


        //Sídlo společnosti

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Ulice")]
        public string POSSUlice { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string POSSCisloPopisne { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string POSSCisloOrientacni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Obec")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string POSSObec { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_PSC")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", false, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string POSSPSC { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string POSSKraj { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PocetSpolecniku")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_PocetSpolecniku")]
        public int POPocetSpolecniku { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "ZakladniKapital")]
        [RequiredIfFieldHasValue("JePravnickaOsoba", true, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_ZakladniKapital")]
        public int POZakladniKapital { get; set; }


        // Adresa místa podnikání

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "JeMistoPodnikaniStejnePo")]
        public bool POJeMistoPodnikaniStejne { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Ulice")]
        public string POMPUlice { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [RequiredIfFieldsHaveValue(new[] { "JePravnickaOsoba", "POJeMistoPodnikaniStejne" }, new object[] { false, false },
            ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string POMPCisloPopisne { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string POMPCisloOrientacni { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Obec")]
        [RequiredIfFieldsHaveValue(new[] { "JePravnickaOsoba", "POJeMistoPodnikaniStejne" }, new object[] { false, false },
            ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string POMPObec { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_PSC")]
        [RequiredIfFieldsHaveValue(new[] { "JePravnickaOsoba", "POJeMistoPodnikaniStejne" }, new object[] { false, false },
            ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string POMPPSC { get; set; }

        [Display(GroupName = "fyzickaOsoba", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [RequiredIfFieldsHaveValue(new[] { "JePravnickaOsoba", "POJeMistoPodnikaniStejne" }, new object[] { false, false },
            ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string POMPKraj { get; set; }

        public void nullovani()
        {
            POObchodniJmeno = null;
            POTypPO = null;
            POIC = null;
            PODIC = null;

            POSSUlice = null;
            POSSCisloPopisne = null;
            POSSCisloOrientacni = null;
            POSSObec = null;
            POSSPSC = null;
            POSSKraj = null;

            POMPUlice = null;
            POMPCisloPopisne = null;
            POMPCisloOrientacni = null;
            POMPObec = null;
            POMPPSC = null;
            POMPKraj = null;
        }

        public void nastavMistoPodnikani()
        {
            if (POJeMistoPodnikaniStejne)
            {
                POMPUlice = POSSUlice;
                POMPCisloPopisne = POSSCisloPopisne;
                POMPCisloOrientacni = POSSCisloOrientacni;
                POMPObec = POSSObec;
                POMPPSC = POSSPSC;
                POMPKraj = POSSKraj;
            }
        }
    }
}