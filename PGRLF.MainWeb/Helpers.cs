using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using PGRLF.MainWeb.Forms;

namespace PGRLF.MainWeb
{
    public static class Helpers
    {
        public const string Strike = "-------";
        public const string PhoneNumberFormat = @"[+0123456789 ]+";
        public const string AccountNumberFormat = @"[0123456789/-]+";

        private static readonly SelectListItem[] emptyItem =
        {
            new SelectListItem()
            {
                Text = FormResources.Helpers_PrependEmptyItem__Text, 
                Value = ""
            },
        };

        public static string GetDescriptionFromEnumValue(this Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static void WriteToSequentialFields(
            this string input,
            string pattern,
            Dictionary<string, string> formValues,
            int startAt = 0,
            int endAt = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "";
            }
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("pattern must not be null or whitespace", "pattern");
            }
            for (int i = Math.Max(0, startAt); i < Math.Min(input.Length, endAt); i++)
            {
                formValues.Add(string.Format(pattern, i + 1), input[i].ToString());
            }
        }

        public static void ScratchYesNoAnswer(
            this bool input,
            string yesField,
            string noField,
            Dictionary<string, string> formValues)
        {
            formValues.Add(input ? noField : yesField, Strike);
        }

        public static IEnumerable<string> GetErrors(this ModelStateDictionary modelState)
        {
            return from ms in modelState
                   where ms.Value.Errors.Count > 0
                   select string.Format("{0}: ", ms.Key)
                          + ms.Value.Errors.Aggregate(
                              "",
                              (acc,
                                  model) => string.Format("{0}{1}\n", acc, model.ErrorMessage));
        }

        public static IEnumerable<SelectListItem> PrependEmptyItem(this IEnumerable<SelectListItem> source)
        {
            return emptyItem.Concat(source as List<SelectListItem> ?? source.ToList());
        }
    }
}