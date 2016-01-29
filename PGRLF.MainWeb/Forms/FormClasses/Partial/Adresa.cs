using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class Adresa
    {

        public Adresa()
        {
            Ulice = null;
            CisloPopisne = null;
            CisloOrientacni = null;
            Obec = null;
            PSC = null;
            Kraj = null;
        }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "Ulice")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Ulice")]
        public string Ulice { get; set; }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "CisloPopisne")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_CisloPopisne")]
        public string CisloPopisne { get; set; }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "CisloOrientacni")]
        public string CisloOrientacni { get; set; }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "Obec")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Obec")]
        public string Obec { get; set; }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "PSC")]
        [DisplayFormat(DataFormatString = "{0:### ##}", ApplyFormatInEditMode = true)]
        [RegularExpression("[0-9]{5}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_PSC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PSC")]
        public string PSC { get; set; }

        [Display(GroupName = "adresa", ResourceType = typeof(FormResources), Name = "Kraj")]
        [DataType("Kraj")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Kraj")]
        public string Kraj { get; set; }
    }
}