/// <summary>
/// store parameters of weather data 
/// </summary>

namespace TestConsoleApp.Core
{
    public class Weather
    {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
