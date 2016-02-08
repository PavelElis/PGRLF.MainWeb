using System.Collections.Generic;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Enums
{
    public static class Velikost
    {
        public static IEnumerable<SelectListItem> GetList()
        {
            var velikost = new string[]
            {
                "Malý",
                "Střední",
                "Velký",
            };
            var returnList = new List<SelectListItem>();

            foreach (var vel in velikost)
            {
                returnList.Add(new SelectListItem() { Text = vel, Value = vel });
            }
            return returnList;
        }
    }
}