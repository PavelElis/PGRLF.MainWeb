using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;

namespace PGRLF.MainWeb.Forms
{
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
            {
                items.Add(field.Key.ToString());
            }
            return items;
        }

        public void FillForm(
            Dictionary<string, string> items,
            Stream formStream)
        {
            PdfStamper pdfStamper = new PdfStamper(pdfReader, formStream);
            AcroFields pdfFormFields = pdfStamper.AcroFields;
            BaseFont arialBaseFont;
            string arialFontPath;
            try
            {
                arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
                arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }
            catch (IOException)
            {
                arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }

            pdfFormFields.AddSubstitutionFont(arialBaseFont);
            foreach (KeyValuePair<string, string> item in items)
            {
                pdfFormFields.SetFieldProperty(item.Key, "textfont", arialBaseFont, null);
                if (item.Value!=null) pdfFormFields.SetField(item.Key, item.Value);
            }
            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }

        public void CloseForm()
        {
            pdfReader.Close();
        }
    }
}