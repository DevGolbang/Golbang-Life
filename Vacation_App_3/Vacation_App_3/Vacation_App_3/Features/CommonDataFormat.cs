using Newtonsoft.Json;

namespace Vacation_App_3.Features
{
    public class CommonDataFormat
    {
        public WeatherDataFormat WeatherData { get; set; }
        public VirusInfo VirusDatas { get; set; }
    }
    public class WeatherDataFormat
    {

        [JsonProperty("response")]
        public Resp Response { get; set; }
   


    }
    public class VirusInfo
    {
        public string DeadCount { get; set; }
        public string DefectorCount { get; set; }
        public string CheckOutCount { get; set; }
    }
    public class Resp
    {
        
        [JsonProperty("body")]
        public Body ContentBody { get; set; }
    }
    public class Body
    {
        [JsonProperty("items")]
        public ItemList Itm_list { get; set; }
    }   
    public class ItemList
    {
        [JsonProperty("item")]
        public Item[] Items { get; set; }
    }
    public class Item
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("fcstValue")]
        public string Value { get; set; }
    }
}
