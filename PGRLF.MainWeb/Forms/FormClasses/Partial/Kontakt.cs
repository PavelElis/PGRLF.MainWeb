using PGRLF.MainWeb.Forms.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Partial
{
    public class Kontakt
    {
        [Display(GroupName = "kontakt", ResourceType = typeof(FormResources), Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Email")]
        public string Email { get; set; }

        [Display(GroupName = "kontakt", ResourceType = typeof(FormResources), Name = "Telefon1")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_Telefon")]
        [Required(ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Nevyplneno_Telefon")]
        public string Telefon1 { get; set; }

        [Display(GroupName = "kontakt", ResourceType = typeof(FormResources), Name = "Telefon2")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_Telefon")]
        public string Telefon2 { get; set; }

        [Display(GroupName = "kontakt", ResourceType = typeof(FormResources), Name = "Fax")]
        [RegularExpression(Helpers.PhoneNumberFormat, ErrorMessageResourceType = typeof(FormResources),
            ErrorMessageResourceName = "Chyba_Telefon")]
        public string Fax { get; set; }
    }
}