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

        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMJmeno { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMAdresa { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        public string DMIC { get; set; }

        #region DM1
        [MustBeTrueIfFieldHasValue("DM1HospodarskyRok", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM1KalendarniRok { get; set; }
        [MustBeTrueIfFieldHasValue("DM1KalendarniRok", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM1HospodarskyRok { get; set; }
        [Required(ErrorMessage = "Musí být vyplněno")]
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        public DateTime? DM1HRZacatek { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Chybný datum")]
        [Required(ErrorMessage = "Musí být vyplněno")]
        public DateTime? DM1HRKonec { get; set; }

        #endregion

        #region DM2

        [MustBeTrueIfFieldHasValue("DM2NeniPropojen", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM2NeniPropojen { get; set; }
        [MustBeTrueIfFieldHasValue("DM2JePropojen", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM2JePropojen { get; set; }

        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2Jmeno1 { get; set; }
        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2Adresa1 { get; set; }
        [RequiredIfFieldHasValue("DM2JePropojen", true, ErrorMessage = "Musí být vyplněno")]
        public string DM2IC1 { get; set; }

        public string DM2Jmeno2 { get; set; }
        public string DM2Adresa2 { get; set; }
        public string DM2IC2 { get; set; }

        public string DM2Jmeno3 { get; set; }
        public string DM2Adresa3 { get; set; }
        public string DM2IC3 { get; set; }

        #endregion

        #region DM3

        [MustBeTrueIfFieldHasValue("DM3VzniklSpojenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3NevzniklSpojenim { get; set; }
        [MustBeTrueIfFieldHasValue("DM3NevzniklSpojenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3VzniklSpojenim { get; set; }
        //public bool DM3PrevzalJmeni { get; set; }

        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3Jmeno1 { get; set; }
        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3Adresa1 { get; set; }
        [RequiredIfFieldHasValue("DM3VzniklSpojenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM3IC1 { get; set; }

        public string DM3Jmeno2 { get; set; }
        public string DM3Adresa2 { get; set; }
        public string DM3IC2 { get; set; }

        public string DM3Jmeno3 { get; set; }
        public string DM3Adresa3 { get; set; }
        public string DM3IC3 { get; set; }

        [MustBeTrueIfFieldHasValue("DM3NeniCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3JeCentralniRegistr { get; set; }
        [MustBeTrueIfFieldHasValue("DM3JeCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM3NeniCentralniRegistr { get; set; }

        #endregion

        #region DM4

        [MustBeTrueIfFieldHasValue("DM4VzniklRozelenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4NevzniklRozdelenim { get; set; }
        [MustBeTrueIfFieldHasValue("DM4NevzniklRozdelenim", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4VzniklRozelenim { get; set; }

        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM41Jmeno { get; set; }
        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
        public string DM41Adresa { get; set; }
        [RequiredIfFieldHasValue("DM4VzniklRozelenim", true, ErrorMessage = "Musí být vyplněno")]
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

        [MustBeTrueIfFieldHasValue("DM4NeniCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4JeCentralniRegistr { get; set; }
        [MustBeTrueIfFieldHasValue("DM4JeCentralniRegistr", false, ErrorMessage = "Musí být zvoleno")]
        public bool DM4NeniCentralniRegistr { get; set; }

        #endregion

        [MustBeTrue(ErrorMessage = "Musí být zaškrtnuto")]
        public bool DMCestneProhlaseni { get; set; }

    }
}