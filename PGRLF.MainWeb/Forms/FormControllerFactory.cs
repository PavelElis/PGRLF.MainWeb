using System;
using System.Web.Mvc;
using System.Web.Routing;
using PGRLF.AzureStorageProvider;
using PGRLF.MainWeb.Controllers;

namespace PGRLF.MainWeb.Forms
{
    public class FormControllerFactory : DefaultControllerFactory
    {
        private readonly Storage azureStorage = new Storage();

        protected override Type GetControllerType(
            RequestContext requestContext,
            string controllerName)
        {
            if (controllerName.ToLowerInvariant() == "Form".ToLowerInvariant())
            {
                //override for typed form controller with viewModel

                //var formId = new Guid(requestContext.RouteData.GetRequiredString("id"));
                //var form = azureStorage.GetForm(formId);
                var formTechName = requestContext.RouteData.GetRequiredString("techname");
                var form = azureStorage.GetForm(formTechName);

                var viewModelType = Type.GetType("PGRLF.MainWeb.Forms.FormClasses." + form.TechName);

                var controllerType = typeof (FormController<>);

                var returnType = controllerType.MakeGenericType(viewModelType);

                return returnType;
            }
            else
            {
                return base.GetControllerType(requestContext, controllerName);
            }
        }

        protected override IController GetControllerInstance(
            RequestContext requestContext,
            Type controllerType)
        {
            if (controllerType.IsGenericType)
            {
                if (controllerType.GetGenericTypeDefinition() == typeof (FormController<>))
                {
                    //var formId = new Guid(requestContext.RouteData.GetRequiredString("id"));
                    //var form = azureStorage.GetForm(formId);
                    var formTechName = requestContext.RouteData.GetRequiredString("techname");
                    var form = azureStorage.GetForm(formTechName);

                    var controller = (IController) Activator.CreateInstance(controllerType);
                    var viewNameField = controller.GetType().GetField("ViewName");
                    var formNameField = controller.GetType().GetField("FormName");
                    var formIdField = controller.GetType().GetField("FormID");


                    viewNameField.SetValue(controller, form.TechName);
                    formIdField.SetValue(controller, form.Id);
                    formNameField.SetValue(controller, form.Name);

                    return controller;
                }
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}