using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using PGRLF.AzureStorageProvider;

namespace PGRLF.MainWeb.Security
{
    /*[AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
       AllowMultiple = true)]*/

    public class DigestAuthorizationAttribute : ActionFilterAttribute
    {
        private const string _Realm = "MyRealm";
        private readonly Storage azureStorage = new Storage();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authorizationHeader = filterContext.RequestContext.HttpContext.Request.Headers["Authorization"];
            if (authorizationHeader != null && authorizationHeader.StartsWith("Digest"))
            {
                var authString = authorizationHeader.Substring(7);
                var elements = authString.Split(',');
                var settings = new Dictionary<string, string>();
                foreach (var element in elements)
                {
                    var s = element.Split(new char[] {'='}, 2);
                    var key = s[0].Trim(new char[] {' ', '\"'});
                    var value = s[1].Trim(new char[] {' ', '\"'});
                    settings.Add(key, value);
                }

                // provided username
                var username = settings["username"].ToString();

                if (username == azureStorage.AdminUser)
                {
                    // password you are expecting
                    var password = azureStorage.AdminPassword;

                    var userAuthString = _GetMd5HashBinHex(String.Format("{0}:{1}:{2}", username, _Realm, password));
                    var locationAuthString =
                        _GetMd5HashBinHex(
                            String.Format(
                                "{0}:{1}",
                                filterContext.RequestContext.HttpContext.Request.HttpMethod,
                                settings["uri"]));

                    var finalAuthString =
                        _GetMd5HashBinHex(
                            String.Format(
                                "{0}:{1}:{2}:{3}:{4}:{5}",
                                new object[]
                                {
                                    userAuthString, settings["nonce"], settings["nc"],
                                    settings["cnonce"], settings["qop"], locationAuthString
                                }));
                    var providedAuthString = (string) settings["response"];

                    if (finalAuthString == providedAuthString)
                    {
                        // user is good to go!
                        base.OnActionExecuting(filterContext);
                        return;
                    }
                }
            }

            if (!filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var stringBuilder = new StringBuilder("Digest");
                stringBuilder.Append(string.Format(" realm=\"{0}\"", _Realm));
                stringBuilder.Append(", nonce=\"");
                stringBuilder.Append(_GetCurrentNonce());
                stringBuilder.Append("\"");
                stringBuilder.Append(", opaque=\"0000000000000000\"");
                stringBuilder.Append(", stale=");
                stringBuilder.Append("false");
                stringBuilder.Append(", algorithm=MD5");
                stringBuilder.Append(", qop=\"auth\"");
                filterContext.HttpContext.Response.AppendHeader("WWW-Authenticate", stringBuilder.ToString());
                filterContext.HttpContext.Response.StatusCode = 401;
                return;
            }
        }

        private static string _GetCurrentNonce()
        {
            var nonceTime = DateTime.Now + TimeSpan.FromMinutes(1);
            var expireStr = nonceTime.ToString("G");
            var enc = new ASCIIEncoding();
            var expireBytes = enc.GetBytes(expireStr);
            var nonce = Convert.ToBase64String(expireBytes);
            // nonce can't end in '=', so trim them from the end
            nonce = nonce.TrimEnd(new Char[] {'='});
            return nonce;
        }

        private static string _GetMd5HashBinHex(string val)
        {
            var bs = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(val));
            var authStr = "";
            for (var i = 0; i < 16; i++)
            {
                authStr = String.Concat(authStr, String.Format("{0:x02}", bs[i]));
            }
            return authStr;
        }
    }
}