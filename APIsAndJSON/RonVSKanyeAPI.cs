using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine($"Ron says:\n{GetSwansonQuote(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Kanye says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
            }
        }
        private static string GetSwansonQuote(HttpClient client)
        {
            var jText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var quote = JArray.Parse(jText).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

            return quote;
        }

        private static string GetKanyeQuote(HttpClient client) 
        {
            var jText = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jText).GetValue("quote").ToString();

            return quote;
        }
    }
}
