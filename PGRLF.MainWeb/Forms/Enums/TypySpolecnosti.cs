using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class TypySpolecnosti
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var typySpolecnosti = new string[]
            {
                "Akciová společnost",
                "Společnost s ručením omezeným",
                "Komanditní společnost",
                "Veřejná obchodní společnost",
                "Družstvo",
            };
            var returnList = new List<SelectListItem>();

            foreach (var ts in typySpolecnosti)
            {
                returnList.Add(new SelectListItem() {Text = ts, Value = ts});
            }
            return returnList;
        }
    }
}