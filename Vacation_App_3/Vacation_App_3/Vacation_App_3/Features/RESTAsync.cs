using System;
using System.Threading.Tasks;
using System.Diagnostics;
using Vacation_App_3.Features;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using agi = HtmlAgilityPack;
using System.Linq;

namespace Vacation_App_3

{
    public class RESTAsync
    {
       
        public RESTAsync()
        {
           
        }
        public async Task<CommonDataFormat> GetData()
        {
            string content = await GetReqAsync("http://ncov.mohw.go.kr/index_main.jsp");
            agi.HtmlDocument _doc = new agi.HtmlDocument();
            _doc.LoadHtml(content);
            agi.HtmlNodeCollection nodeCollect = _doc.DocumentNode.SelectNodes("//div[@class=\"co_cur\"]//li");

            CommonDataFormat common = new CommonDataFormat
            {
                VirusDatas = new VirusInfo()
                {
                    DefectorCount = nodeCollect[0].SelectSingleNode("a").InnerText,
                    CheckOutCount = nodeCollect[1].SelectSingleNode("a").InnerText,
                    DeadCount = nodeCollect[2].SelectSingleNode("a").InnerText
                },
                WeatherData = JsonConvert.DeserializeObject<WeatherDataFormat>(await GetReqAsync(string.Format(Consts.OpenWeatherAPIEndpoint, Consts.OpenWeatherAPIKey, Consts.YearAndDate)))

            };
            return common;
        }

        //private async Task<WeatherDataFormat> GetWeatherData()
        //{
        //    string content = await GetReqAsync(string.Format(Consts.OpenWeatherAPIEndpoint, Consts.OpenWeatherAPIKey, Consts.YearAndDate));
        //    return JsonConvert.DeserializeObject<WeatherDataFormat>(content);
        //}
        //private async Task<VirusInfo> GetVirusData()
        //{
        //    string content = await GetReqAsync("http://ncov.mohw.go.kr/index_main.jsp");
        //    agi.HtmlDocument _doc = new agi.HtmlDocument();
        //    _doc.LoadHtml(content);
        //    agi.HtmlNodeCollection nodeCollect = _doc.DocumentNode.SelectNodes("//div[@class=\"co_cur\"]//li");
        //    VirusInfo VirusDatas = new VirusInfo()
        //    {
        //        DefectorCount = nodeCollect[0].SelectSingleNode("a").InnerText,
        //        CheckOutCount = nodeCollect[1].SelectSingleNode("a").InnerText,
        //        DeadCount = nodeCollect[2].SelectSingleNode("a").InnerText
        //    };
        //    return VirusDatas;
        //}
        private async Task<string> GetReqAsync(string uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string content = "";
            try
            {
                if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(uri);
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return content;
        }
    }
}
