using System;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using agi = HtmlAgilityPack;

namespace weatherAsyncTest
{
    
    class Program
    {

    
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            sw.Start();
            string html = wc.DownloadString("http://ncov.mohw.go.kr/index_main.jsp");
            agi.HtmlDocument doc = new agi.HtmlDocument();
           
            doc.LoadHtml(html);
           
            agi.HtmlNodeCollection nodeCollect = doc.DocumentNode.SelectNodes("//div[@class=\"co_cur\"]//li");
            sw.Stop();
            //foreach (agi.HtmlNode node in nodeCollect)
            //{
            //    spanText.Add(node.SelectSingleNode("a").InnerText);
            //}
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(nodeCollect[i].SelectSingleNode("a").InnerText);
            }
            
            Console.WriteLine(sw.ElapsedMilliseconds);
            


        }
    }
}
