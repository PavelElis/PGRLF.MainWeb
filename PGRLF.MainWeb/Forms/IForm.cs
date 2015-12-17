using System;

namespace PGRLF.MainWeb.Forms
{
    internal interface IForm
    {
        object Load(string xmlString);
        string Save();
        byte[] SavePDF();
        string SaveXML();
        void Process();
        string ApplicantEmail { get; }
        Guid? Identifikator { get; }
        DateTime? DatumPodani { get; }    
    }
}