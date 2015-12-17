using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using iTextSharp.text;

namespace PGRLF.MainWeb.Forms.Validation
{
    public static class LabelExtensions
    {
        public static MvcHtmlString LabelWithAsterixFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes=null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            // Null reference should happen - if it happens something is very wrong with the model
            // ReSharper disable once AssignNullToNotNullAttribute
            var propertyInfo = metadata.ContainerType.GetProperty(metadata.PropertyName);

            bool isConditionalyRequired = propertyInfo.CustomAttributes.Any(x => x.AttributeType == typeof(RequiredIfFieldHasValueAttribute) || x.AttributeType == typeof(RequiredIfFieldsHaveValueAttribute));
            bool isRequired = propertyInfo.CustomAttributes.Any(x => x.AttributeType == typeof(RequiredAttribute));
            if (isRequired || isConditionalyRequired) labelText += " *";
            

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            TagBuilder span = new TagBuilder("span");
            span.SetInnerText(labelText);

            // assign <span> to <label> inner html
            tag.InnerHtml = span.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}