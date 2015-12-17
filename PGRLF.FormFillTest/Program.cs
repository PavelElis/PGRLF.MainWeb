using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace PGRLF.FormFillTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new PDFform("C:\\ZoPPPGRLF.pdf");
            var Fields = form.GetListFieldNames();
        }
    }
    public class PDFform
    {
        public PdfReader pdfReader;

        public PDFform(string path)
        {
            pdfReader = new PdfReader(path);
        }

        public List<string> GetListFieldNames()
        {
            List<string> items = new List<string>();
            foreach (KeyValuePair<string, AcroFields.Item> field in pdfReader.AcroFields.Fields)
                items.Add(field.Key.ToString());
            return items;
        }

        public void FillForm(Dictionary<string, string> items, string NewFileUrl)
        {
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(NewFileUrl, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            foreach (KeyValuePair<string, string> item in items)
            {
                pdfFormFields.SetField(item.Key, item.Value);
            }
            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }
    }
}
