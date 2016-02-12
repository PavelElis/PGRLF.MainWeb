using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTextSharp.text;
using PGRLF.MainWeb.Forms.Enums;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class PravnickaOsoba
    {
        public PravnickaOsoba()
        {
            SidloSpolecnosti = new Adresa();
            MistoPodnikani = new Adresa();
            ZodpovednaOsobaList = new List<ZodpovednaOsoba>() { new ZodpovednaOsoba()};
        }

        //Obecné údaje

        [Display(ResourceType = typeof(FormResources), Name = "ObchodniJmeno")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ObchodniJmeno")]
        public string ObchodniJmeno { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "TypSpolecnosti")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_TypSpolecnosti")]
        public TypSpolecnosti? TypPO { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "IC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_IC")]
        [RegularExpression("\\d{8}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_IC")]
        public string IC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "DIC")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_DIC")]
        [RegularExpression("\\w{2}\\d{8,10}", ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Chyba_DIC")]
        public string DIC { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "PocetSpolecniku")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_PocetSpolecniku")]
        public int? PocetSpolecniku { get; set; }

        [Display(ResourceType = typeof(FormResources), Name = "ZakladniKapital")]
        [Required(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_ZakladniKapital")]
        public int? ZakladniKapital { get; set; }

        public List<ZodpovednaOsoba> ZodpovednaOsobaList { get; set; }

        public Adresa SidloSpolecnosti { get; set; }

        public bool POJeMistoPodnikaniStejne { get; set; }

        public Adresa MistoPodnikani { get; set; }

        public void AddZodpovednaOsoba()
        {
            ZodpovednaOsobaList.Add(new ZodpovednaOsoba());
        }

        public void RemoveZodpovednaOsoba(int index)
        {
            ZodpovednaOsobaList.RemoveAt(index);
        }

    }
}