using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class Pojistovny
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var zoznamPojistoven = new string[]
            {
                "Agra Pojišťovna",
                "Česká pojišťovna, a.s.",
                "ČSOB Pojišťovna, a.s.",
                "Pojišťovna Generali",
                "Hasičská vzájemná pojišťovna, a.s.",
                "Kooperativa pojišťovna, a.s.",
            };
            var returnList = new List<SelectListItem>();

            foreach (var pojistovna in zoznamPojistoven)
            {
                returnList.Add(new SelectListItem() {Text = pojistovna, Value = pojistovna});
            }
            return returnList;
        }
    }
}