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
        }

        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMJmeno { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMAdresa { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMIC { get; set; }

        #region DM1
        public DM1UcetniObdobi DM1UcetniObdobi { get; set; }

        [Required(ErrorMessage = "Musí být vyplněno")]
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public DateTime? DM1HRZacatek { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        [Required(ErrorMessage = "Musí být vyplněno")]
        public DateTime? DM1HRKonec { get; set; }

        #endregion

        #region DM2
        public DM2Propojeni DM2Propojeni { get; set; }

        public string DM2Jmeno1 { get; set; }
        public string DM2Adresa1 { get; set; }
        public string DM2IC1 { get; set; }

        public string DM2Jmeno2 { get; set; }
        public string DM2Adresa2 { get; set; }
        public string DM2IC2 { get; set; }

        public string DM2Jmeno3 { get; set; }
        public string DM2Adresa3 { get; set; }
        public string DM2IC3 { get; set; }

        #endregion

        #region DM3

        public DM3Spojeni DM3Spojeni { get; set; }

        public string DM3Jmeno1 { get; set; }
        public string DM3Adresa1 { get; set; }
        public string DM3IC1 { get; set; }

        public string DM3Jmeno2 { get; set; }
        public string DM3Adresa2 { get; set; }
        public string DM3IC2 { get; set; }

        public string DM3Jmeno3 { get; set; }
        public string DM3Adresa3 { get; set; }
        public string DM3IC3 { get; set; }

        public DMCentralniRegistr DM3CentralniRegistr { get; set; }

        #endregion

        #region DM4

        public DM4Rozdeleni DM4Rozdeleni { get; set; }

        public string DM41Jmeno { get; set; }
        public string DM41Adresa { get; set; }
        public string DM41IC { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti1 { get; set; }
        public string DM42Poskytovatel1 { get; set; }
        public string DM42Castka1 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti2 { get; set; }
        public string DM42Poskytovatel2 { get; set; }
        public string DM42Castka2 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public string DM42DatumPoskytnuti3 { get; set; }
        public string DM42Poskytovatel3 { get; set; }
        public string DM42Castka3 { get; set; }

        public DMCentralniRegistr DM4CentralniRegistr { get; set; }

        #endregion

        [MustBeTrue(ErrorMessageResourceType = typeof(FormResources), ErrorMessageResourceName = "Nevyplneno_Souhlas")]
        public bool DMCestneProhlaseni { get; set; }

    }
}