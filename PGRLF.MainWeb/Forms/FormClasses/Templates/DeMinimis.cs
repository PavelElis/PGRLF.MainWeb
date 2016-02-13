using PGRLF.MainWeb.Forms.Enums;
using PGRLF.MainWeb.Forms.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGRLF.MainWeb.Forms.FormClasses.Templates
{
    public class DeMinimis
    {
        public DeMinimis()
        {
            DM1UcetniObdobi = DM1UcetniObdobi.KalendarniRok;
            DM2Propojeni = DM2Propojeni.NeniPropojen;
            DM3Spojeni = DM3Spojeni.NevzniklSpojenim;
            DM3CentralniRegistr = DMCentralniRegistr.NeniZohledneno;
            DM4Rozdeleni = DM4Rozdeleni.NevniklRozdelenim;
            DM4CentralniRegistr = DMCentralniRegistr.NeniZohledneno;
            DM2PropojeniList = new List<DeMinimisOsoba>();
            DM3SpojeniList = new List<DeMinimisOsoba>();
            DM4RozdeleniPodporaList = new List<DeMinimisPodpora>();
        }

        public void Init()
        {
            if (!DM2PropojeniList.Any())
            {
                DM2PropojeniList.Add(new DeMinimisOsoba());
            }
            if (!DM3SpojeniList.Any())
            {
                DM3SpojeniList.Add(new DeMinimisOsoba());
            }
            if (!DM4RozdeleniPodporaList.Any())
            {
                DM4RozdeleniPodporaList.Add(new DeMinimisPodpora());
            }
        }

        public DeMinimisOsoba DM0Osoba { get; set; }


        public DM1UcetniObdobi DM1UcetniObdobi { get; set; }

        [Required(ErrorMessage = "Musí být vyplněno")]
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public DateTime? DM1HRZacatek { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        [Required(ErrorMessage = "Musí být vyplněno")]
        public DateTime? DM1HRKonec { get; set; }


        public DM2Propojeni DM2Propojeni { get; set; }
        public List<DeMinimisOsoba> DM2PropojeniList { get; set; }
        

        public DM3Spojeni DM3Spojeni { get; set; }
        public List<DeMinimisOsoba> DM3SpojeniList { get; set; }
        public DMCentralniRegistr DM3CentralniRegistr { get; set; }


        public DM4Rozdeleni DM4Rozdeleni { get; set; }
        public DeMinimisOsoba DM4RozdeleniOsoba { get; set; }
        public List<DeMinimisPodpora> DM4RozdeleniPodporaList { get; set; }
        public DMCentralniRegistr DM4CentralniRegistr { get; set; }


        [MustBeTrue(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Souhlas")]
        public bool DMCestneProhlaseni { get; set; }

    }
}