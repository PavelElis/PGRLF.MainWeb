using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PGRLF.MainWeb.Forms
{
    public abstract class AbstractForm : IForm
    {       
        object IForm.Load(string xmlString)
        {
            var x = new XmlSerializer(this.GetType());

            Stream s = new MemoryStream(Encoding.Unicode.GetBytes(xmlString));
            var item = x.Deserialize(s);

            return item;
        }

        string IForm.Save()
        {
            var x = new XmlSerializer(this.GetType());
            var ms = new MemoryStream();
            x.Serialize(ms, this);
            ms.Position = 0;
            var rd = new StreamReader(ms);
            return rd.ReadToEnd();
        }

        public abstract void Init();

        public abstract byte[] SavePDF();

        public virtual string SaveXML()
        {
            return ((IForm) this).Save();
        }

        public abstract void Process();

        public abstract string ApplicantEmail { get; }
        public Guid? Identifikator { get; set; }
        public DateTime? DatumPodani { get; set; }
    }
}