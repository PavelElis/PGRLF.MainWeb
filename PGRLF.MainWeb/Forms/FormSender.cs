using System;
using System.Configuration;
using System.Globalization;
using Microsoft.Exchange.WebServices.Data;
using PGRLF.AzureStorageProvider.TableEntities;
using PGRLF.MainWeb.Forms.Exchange;
using System.Web;


namespace PGRLF.MainWeb.Forms
{
    public static class FormSender
    {
        private static readonly IUserData onlineUserData = UserData.GetUserData();
        private static readonly ExchangeService service = Service.ConnectToService(onlineUserData, null);       

        public static void SendConfirmationEmail(string address, Guid formId, DateTime fileDate)
        {
            var message = new EmailMessage(service)
            {
                Subject = EmailResources.ConfirmationMailHeader,
                Body = String.Format(EmailResources.ConfirmationMailBody, fileDate.ToString(CultureInfo.GetCultureInfo("cs-Cz")), formId)
            };
            message.ToRecipients.Add(address);           

            message.Send();
        }

        public static void SendFormData(string ServerPath,HttpPostedFileBase[] files, string fileName, byte[] pdfArray, byte[] xmlArray)
        {
            var message = new EmailMessage(service)
            {
                Subject = fileName, 
                Body = fileName
            };
            message.ToRecipients.Add(ConfigurationManager.AppSettings["TargetMailBox"]);
            message.Attachments.AddFileAttachment(fileName + ".pdf", pdfArray);
            message.Attachments.AddFileAttachment(fileName + ".xml", xmlArray);

            try
            {
                /*Lopp for multiple files*/
                foreach (HttpPostedFileBase file in files)
                {
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    var path = System.IO.Path.Combine(ServerPath, filename);
                    message.Attachments.AddFileAttachment(path);
                    /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                }


            }
            catch
            {

            }

            message.Send();
        }

        public static void SendMailTest()
        {
            EmailMessage message = new EmailMessage(service);
            message.Subject = "integration testts";
            message.Body = "fkytfoyufoyfy";
            message.ToRecipients.Add(ConfigurationManager.AppSettings["TargetMailBox"]);


            message.Send();
        }
    }
}