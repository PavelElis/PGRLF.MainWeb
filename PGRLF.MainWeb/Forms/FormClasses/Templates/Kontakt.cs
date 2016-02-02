using System.ComponentModel.DataAnnotations;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class Kontakt
    {
        [Display(ResourceType = typeof(FormResources), Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Telefon1")]
        [RegularExpression("\\d{9}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_Telefon")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Telefon")]
        public int? Telefon1 { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Telefon2")]
        [RegularExpression("\\d{9}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_Telefon")]
        public int? Telefon2 { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "Fax")]
        [RegularExpression("\\d{9}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_Telefon")]
        public int? Fax { get; set; }
    }
}