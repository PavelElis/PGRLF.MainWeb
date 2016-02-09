using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class ZamereniVyroby
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var vyroba = new string[]
            {
                "Rostlinná výroba",
                "Živočišná výroba",
                "Jiná",
            };
            var returnList = new List<SelectListItem>();

            foreach (var vel in vyroba)
            {
                returnList.Add(new SelectListItem() { Text = vel, Value = vel });
            }
            return returnList;
        }
    }
}