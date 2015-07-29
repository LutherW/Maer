using System;
using System.Collections;
using System.Collections.Generic;

namespace Maer.Infrastructure.CookieStorage
{
    public interface ICookieStorageService
    {
        void Save(string name, string value, int expires, string domain);
        void Save(string name, string value, string domain);
        void Save(string name, string key, string value, string domain);
        void Save(string name, IDictionary<string, string> values, string domain);
        void Save(string name, IDictionary<string, string> values, int expires, string domain);
        string Retrieve(string name);
        string Retrieve(string name, string key);
        void Clear(string name, string domain);
    }
}
