using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class Evidence
    {

        public Evidence()
        {

        }

        [Display(ResourceType = typeof(FormResources), Name = "EvidenceU")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_EvidenceU")]
        public string EvidenceU { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DatumVydaniEvidence")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DatumVydaniEvidence")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DatumVydaniEvidence")]
        public DateTime? DatumVydaniEvidence { get; set; }

    }
}