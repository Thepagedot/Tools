using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Thepagedot.Tools.Services
{
    public class HttpService : IHttpService
    {
        private static readonly Dictionary<string, CacheFile<string>> Cache = new Dictionary<string, CacheFile<string>>();
        private static CookieContainer Cookies = new CookieContainer();
        private static HttpClient HttpClient = new HttpClient();

        public async Task<string> GetStringAsync(string url, TimeSpan? cacheTime)
        {
            // Check if cached response is available
            if (cacheTime != null && Cache.ContainsKey(url))
            {
                var cacheFile = Cache[url];
                if (DateTime.Now.Subtract(cacheFile.TimeStamp) < cacheTime)
                {
                    return cacheFile.Value;
                }
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("If-Modified-Since", DateTime.UtcNow.ToString());
            var response = await HttpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }

    internal class CacheFile<T>
    {
        public DateTime TimeStamp { get; set; }
        public T Value { get; set; }

        public CacheFile(T value)
        {
            TimeStamp = DateTime.Now;
            Value = value;
        }
    }
}
