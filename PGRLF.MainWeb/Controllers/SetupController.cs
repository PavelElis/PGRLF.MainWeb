using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using PGRLF.AzureStorageProvider;
using PGRLF.AzureStorageProvider.TableEntities;
using PGRLF.MainWeb.Security;
using Telerik.Web.Mvc;

namespace PGRLF.MainWeb.Controllers
{
    public class CultureAwareActionAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // That's for displaying in the UI, the model binder doesn't use it
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");

            // That's the important one for the model binder
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs-CZ");
        }
    }

    public class SetupController : Controller
    {
        private readonly Storage azureStorage = new Storage();
        //
        // GET: /Setup/
        [DigestAuthorization]
        public ActionResult Index()
        {
            return RedirectToAction("FormList");
        }


        [DigestAuthorization]
        public ActionResult FormList()
        {
            return View();
        }

        #region GridActions

        [GridAction]
        public ActionResult _SelectAjaxEditing()
        {
            return View(new GridModel(azureStorage.GetAllForms()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _SaveAjaxEditing(string id)
        {
            var form = azureStorage.GetForm(new Guid(id));

            TryUpdateModel(form);
            azureStorage.InsertOrUpdateForm(form);

            return View(new GridModel(azureStorage.GetAllForms()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [CultureAwareAction]
        [GridAction]
        public ActionResult _InsertAjaxEditing()
        {
            //Create a new instance of the EditableProduct class.
            Form form = new Form();
            //Perform model binding (fill the product properties and validate it).
            if (TryUpdateModel(form))
            {
                //The model is valid - insert the product.
                azureStorage.InsertOrUpdateForm(form);
            }
            //Rebind the grid
            return View(new GridModel(azureStorage.GetAllForms()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _DeleteAjaxEditing(string id)
        {
            //Find a customer with ProductID equal to the id action parameter
            azureStorage.DeleteForm(new Guid(id));

            //Rebind the grid
            return View(new GridModel(azureStorage.GetAllForms()));
        }

        #endregion
    }
}