using System;
using System.Configuration;
using System.Security;
using Microsoft.Exchange.WebServices.Data;

namespace PGRLF.MainWeb.Forms.Exchange
{
    public interface IUserData
    {
        ExchangeVersion Version { get; }
        string EmailAddress { get; }
        SecureString Password { get; }
        Uri AutodiscoverUrl { get; set; }
    }

    public class UserData : IUserData
    {
        private static UserData userData;


        public ExchangeVersion Version
        {
            get { return ExchangeVersion.Exchange2010_SP1; }
        }

        public string EmailAddress { get; private set; }

        public SecureString Password { get; private set; }

        public Uri AutodiscoverUrl { get; set; }

        public static IUserData GetUserData()
        {
            if (userData == null)
            {
                userData = new UserData()
                {
                    AutodiscoverUrl = new Uri(ConfigurationManager.AppSettings["ExchangeAutodiscoverUrl"].ToString()),
                    EmailAddress = ConfigurationManager.AppSettings["ExchangeMailBox"].ToString(),
                    Password = new SecureString()
                };

                string pass = ConfigurationManager.AppSettings["ExchangePassword"].ToString();
                foreach (var ch in pass)
                {
                    userData.Password.AppendChar(ch);
                }
                userData.Password.MakeReadOnly();
            }
            return userData;
        }
    }
}