using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PGRLF.MainWeb.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable
    {
        // for server side validation
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }

        // add data- to elements for client side validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule()
            {
                ValidationType = "mustbetrue",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };
            yield return modelClientValidationRule;
        }
    }
}