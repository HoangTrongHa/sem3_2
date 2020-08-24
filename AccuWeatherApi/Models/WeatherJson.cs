using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccuWeatherApi.Models
{ public class Temerature
    {
        public string Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
    public class WeatherJson
    {
        public string DataTime { get; set; }
        public int EpochDateTime { get; set; }
        public string WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public string IsDaylight { get; set; }
        public Temerature Temerature { get; set; }
        public int PrecipitationProbability { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
    public async static Task<List<WeatherJson>> GetJson(string url)
    {
        var http = new HttpClient();
        var response = await http.GetAsync(url); // nhan data tu json
        var result = await response.Content.ReadAsStringAsync();
        var serializer = new DataContractJsonSerializer(typeof(List<WeatherEachDay>)); //dong bo 
        var ms = new MemoryStream(Encoding.UTF8.GetBytes(result)); // format de khong bi loi 
        var Value = serializer.ReadObject(dataSteam) as List<WeatherJson>; // Doc ra giu lieu data
        return Value;
    }
}
