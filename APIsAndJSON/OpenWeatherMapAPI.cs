using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            //Grab appsettings file
            var apiKeyObj = File.ReadAllText("appsettings.json");

            //Get the api key from the appsettings file using the key "apiKey"
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

            //Ask the user for their zip code
            Console.Write("Enter ZIP: ");

            //Enter a zip code for which you want to retrieve the weather forecast
            var zip = Console.ReadLine();

            //Build the api url using the provide zip and api key
            var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            //Create HTTPClient - This is what actually makes our api call
            var client = new HttpClient();

            //api call - This will return a JSON obj formatted as a string
            var response = client.GetStringAsync(url).Result;

            //Parse the string as a json obj - this obj can be indexed like an array
            var weatherObj = JObject.Parse(response);

            //Print the info we need - use weather obj and index the properties needed
            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        }
    }
}
