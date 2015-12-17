using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.Attributes;
using CaptchaMvc.HtmlHelpers;
using PGRLF.AzureStorageProvider;
using PGRLF.MainWeb.Forms;

namespace PGRLF.MainWeb.Controllers
{
    public class FormController<T> : Controller where T : class, new()
    {
        private readonly Storage azureStorage = new Storage();
        public Guid FormID;
        public string FormName;
        public string ViewName;
        //
        // GET: /Form/
        public ActionResult Show()
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            var viewModel = new T();
            return View(ViewName, viewModel);
        }

        [HttpPost]
        public ActionResult Validate(T viewModel)
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            
            ((IForm) viewModel).Process();
            ModelState.Clear();
            TryValidateModel(viewModel);
            ViewBag.IsValidationSuccessful = ModelState.IsValid;
            return View(ViewName, viewModel);
        }

        [HttpPost]
        public ActionResult Submit(T viewModel, HttpPostedFileBase[] files)
        {

            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            var form = ((IForm) viewModel);
            form.Process();
            ModelState.Clear();
            TryValidateModel(viewModel);

            bool valid = this.IsCaptchaValid("Kontrolní kód je nesprávný");

            try
            {
                /*Lopp for multiple files*/
                foreach (HttpPostedFileBase file in files)
                {
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), filename);
                    file.SaveAs(path);
                    /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                }

            }
            catch
            {

            }

            if (ModelState.IsValid)
            {
                FormSender.SendFormData(
                Server.MapPath("~/App_Data/uploads"),
                files,
                FormName,
                form.SavePDF(),
                Encoding.UTF8.GetBytes(form.SaveXML()));


                FormSender.SendConfirmationEmail(
                    form.ApplicantEmail,
                    (Guid)form.Identifikator,
                    (DateTime)form.DatumPodani);

                try
                {
                    /*Lopp for multiple files*/
                    foreach (HttpPostedFileBase file in files)
                    {
                        /*Geting the file name*/
                        string filename = System.IO.Path.GetFileName(file.FileName);
                        /*Saving the file in server folder*/
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), filename);
                        System.IO.File.Delete(path);
                        /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                    }

                }
                catch
                {

                }
                return View("Sent", viewModel);
            }

            else
            {
                return View(ViewName, viewModel);
            }

        }

        [HttpPost]
        public FileResult Save(T viewModel)
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            var form = (IForm) viewModel;
            form.Process();

            FileResult result = new FileContentResult(Encoding.UTF8.GetBytes(form.Save()), "text/xml")
            {
                FileDownloadName = FormName + ".xml"
            };

            return result;
        }

        [HttpPost]
        public FileResult PdfPreview(T viewModel)
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            var model = ((IForm) viewModel);
            model.Process();

            FileResult result = new FileContentResult(model.SavePDF(), "application/pdf")
            {
                FileDownloadName = FormName + ".pdf"
            };

            return result;
        }

        public ActionResult Load()
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;

            return View("Load");
        }

        [HttpPost]
        public ActionResult Load(HttpPostedFileBase file)
        {
            ViewBag.FormID = FormID.ToString();
            ViewBag.FormName = FormName;
            try
            {
                // Verify that the user selected a file
                var viewModel = new T();
                if (file != null && file.ContentLength > 0)
                {
                    viewModel = ((IForm) viewModel).Load(new StreamReader(file.InputStream).ReadToEnd()) as T;
                }
                ((IForm) viewModel).Process();
                // redirect back to the index action to show the form once again
                return View(ViewName, viewModel);
            }
            catch
            {
                ViewBag.InvalidFile = true;
                return View("Load");
            }
        }

        /*[CaptchaMvc.Attributes.CaptchaVerify("Captcha is not valid")]
        [HttpPost]
        public ActionResult MathCaptcha(string empty)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Message: captcha is valid.";
                return View("Load");
            }

            TempData["ErrorMessage"] = "Error: captcha is not valid.";
            return View("Load");
        }*/
    }
}