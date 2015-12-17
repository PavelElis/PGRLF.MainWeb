using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class FunkceVSpolecnosti
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var typySpolecnosti = new string[]
            {
                "Předseda představenstva",
                "Místopředseda představenstva",
                "Člen představenstva",
                "Jednatel",
                "Komplementář",
                "Společník",
                "Likvidátor",
                "Prokurista",
                "Správce konkurzní podstaty",
                "Insolvenční správce",
                "Na základě plné moci",
                "Vyrovnací správce"
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