using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class SvazekObci
    {
        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "NazevSvazkuObci")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_NazevSvazkuObci")]
        public string SONazevSvazkuObci { get; set; }

        [Display(GroupName = "svazekObci", ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
           ErrorMessageResourceName = "Nevyplneno_IC")]
        public string SOIC { get; set; }

        [Display(GroupName = "svazekObci", ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_DIC")]
        public string SODIC { get; set; }

        //Adresa svazku obce

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Ulice")]
        public string SOUlice { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string SOCisloPopisne { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string SOCisloOrientacni { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Obec")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string POSSObec { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_PSC")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string POSSPSC { get; set; }

        [Display(GroupName = "pravnickaOsoba", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string POSSKraj { get; set; }
    }
}