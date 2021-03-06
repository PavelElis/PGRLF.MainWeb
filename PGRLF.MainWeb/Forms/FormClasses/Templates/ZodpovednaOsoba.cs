﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PGRLF.MainWeb.Forms.Enums;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class ZodpovednaOsoba
    {
        public string Index { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulPredJmenem")]
        public string TitulPredJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "KrestniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Jmeno")]
        public string Jmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Prijmeni")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Prijmeni")]
        public string Prijmeni { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TitulZaJmenem")]
        public string TitulZaJmenem { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Funkce")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Funkce")]
        public FunkceVSpolecnosti? FunkceVSpolecnosti { get; set; }

    }
}