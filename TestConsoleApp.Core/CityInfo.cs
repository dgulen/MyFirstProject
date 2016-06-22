using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// store weather information of a city
/// </summary>

namespace TestConsoleApp.Core
{

    public class CityInfo
    {
        
        //[JsonProperty(PropertyName = "weather")]
        public List<Weather> weather { get; set; }
    }
}
