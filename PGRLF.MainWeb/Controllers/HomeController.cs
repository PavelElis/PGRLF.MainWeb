using System;
using System.Linq;
using System.Web.Mvc;
using PGRLF.AzureStorageProvider;
using PGRLF.MainWeb.Forms;

namespace PGRLF.MainWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly Storage azureStorage = new Storage();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var forms =
                azureStorage.GetAllForms()
                    .Where(x => x.ValidFrom <= DateTime.Now)
                    .Where(y => y.ValidTo >= DateTime.Now)
                    .ToList();
            return View(forms);
        }

        public ActionResult Test()
        {
            FormSender.SendMailTest();
            return View("Index");
        }
    }
}