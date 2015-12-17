using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class Kraje
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var zoznamKrajov = new string[]
            {
                "Hlavní město Praha",
                "Středočeský kraj",
                "Plzeňský kraj",
                "Jihočeský kraj",
                "Ústecký kraj",
                "Karlovarský kraj",
                "Pardubický kraj",
                "Královéhradecký kraj",
                "Liberecký kraj",
                "Jihomoravský kraj",
                "Vysočina",
                "Zlínský kraj",
                "Olomoucký kraj",
                "Moravskoslezský kraj",
            };
            var returnList = new List<SelectListItem>();

            foreach (var kraj in zoznamKrajov)
            {
                returnList.Add(new SelectListItem() {Text = kraj, Value = kraj});
            }
            return returnList;
        }
    }
}