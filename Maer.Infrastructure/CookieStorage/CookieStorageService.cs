using System;
using System.Collections.Generic;
using System.Web;

namespace Maer.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {
        public void Save(string name, string value, int expires, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Save(string name, string value, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            cookie.Value = value;
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Save(string name, string key, string value, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            cookie[key] = value;
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public string Retrieve(string name)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[name] != null)
            {
                return HttpContext.Current.Request.Cookies[name].Value;
            }

            return "";
        }


        public string Retrieve(string name, string key)
        {
            if (HttpContext.Current.Request.Cookies != null
                && HttpContext.Current.Request.Cookies[name] != null
                && HttpContext.Current.Request.Cookies[name][key] != null)
            {
                return HttpContext.Current.Request.Cookies[name][key].ToString();
            }

            return "";
        }

        public void Save(string name, IDictionary<string, string> values, string domain)
        {
            if (values == null || values.Count < 1)
            {
                return;
            }
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            foreach (string key in values.Keys)
            {
                cookie[key] = values[key];
            }
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Save(string name, IDictionary<string, string> values, int expires, string domain)
        {
            if (values == null || values.Count < 1)
            {
                return;
            }
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }
            foreach (string key in values.Keys)
            {
                cookie[key] = values[key];
            }
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Clear(string name, string domain)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
    }
}
