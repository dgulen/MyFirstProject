using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using TestConsoleApp.Core;

namespace TestConsoleApp.Business
{
    class City
    {
        /// <summary>
        /// get requested city as string from user
        /// </summary>
        /// <returns>requested city</returns>
        public static string GetString()
        {

            Console.WriteLine("Enter a city to see the weather information: ");

            var userInput = Console.ReadLine();

            return userInput;
        }

        /// <summary>
        /// prints weather information retrived from api for any city
        /// </summary>
        /// <param name="city">city</param>
        public static void PrintWeather(String city)
        {
            string BingMapsKey = "82661c8e6e01ee9cde9679ed5629d783";

            try
            {

                string locationsRequest = CreateRequest(city, BingMapsKey);

                var JsonResponse = GetResponse(locationsRequest);

                Console.WriteLine();
                Console.WriteLine("{0} city weather: ", city);

                CityInfo cityInfo = new JavaScriptSerializer().Deserialize<CityInfo>(JsonResponse);
                /* 
                 * JavaScriptSerializer oJS = new JavaScriptSerializer();
                 *  CityInfo cityInfo = new CityInfo();
                 *  cityInfo = oJS.Deserialize<CityInfo>(JsonResponse);
                 */
                var cityWeather = cityInfo.weather[0];
     
                Console.WriteLine("id: {0} ", cityWeather.id);
                Console.WriteLine("main: {0} ", cityWeather.main);
                Console.WriteLine("description: {0}", cityWeather.description);
                Console.WriteLine("icon: {0}  ", cityWeather.icon);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }

        /// <summary>
        /// get info from given url
        /// </summary>
        /// <param name="url">weather api url</param>
        /// <returns>weather information in json</returns>
        public static string GetResponse(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }

                throw;

            }
        }
       
        /// <summary>
        /// create url with requested parameters
        /// </summary>
        /// <param name="queryString">city</param>
        /// <param name="BingMapsKey">key</param>
        /// <returns>url</returns>
        public static string CreateRequest(string queryString, string BingMapsKey)
        {

            string UrlRequest = "http://api.openweathermap.org/data/2.5/weather?q=" +
                                           queryString +
                                           "&ApiKey=" + BingMapsKey;

            return (UrlRequest);
        }
    }
}
