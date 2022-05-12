using DataAccess.Interfaces;
using Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TitleRepositoy : ITitleRepository
    {
        public List<TitleAndContent> DataExtraction()
        {

            List<string> linkList = new List<string>();
            HtmlDocument doc1 = new HtmlDocument();
         
            string mainUrl = "https://www.wired.com/";

            var client = new WebClient() { Encoding = Encoding.UTF8 };



            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = client.DownloadString(mainUrl + "most-recent/");
            doc1.LoadHtml(response);
           

            List<TitleAndContent> titleList = new List<TitleAndContent>();

            titleList.Add(new TitleAndContent { TitleId = 1, TitleName = doc1.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[1]/div[2]/a/h3").InnerText, Content = GetTitleAndContents(1) });

            titleList.Add(new TitleAndContent { TitleId = 2, TitleName = doc1.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[2]/div[2]/a/h3").InnerText, Content = GetTitleAndContents(2) });
            titleList.Add(new TitleAndContent { TitleId = 3, TitleName = doc1.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[3]/div[2]/a/h3").InnerText, Content = GetTitleAndContents(3) });
            titleList.Add(new TitleAndContent { TitleId = 4, TitleName = doc1.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[5]/div[2]/a/h3").InnerText, Content = GetTitleAndContents(4) });
            titleList.Add(new TitleAndContent
            {
                TitleId = 5,
                TitleName = doc1.DocumentNode.SelectSingleNode("//*[@id='main-content']/div[1]/div[1]/div/div/section[2]/div[1]/div[1]/div/div/div[1]/div[2]/a/h3").InnerText,
                Content = GetTitleAndContents(5)
            });



            return titleList;
        }      
        public string GetContentLink(int id)
        {
            string anaLink = "https://www.wired.com";
            string link = "https://www.wired.com/most-recent/";
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var path = "";
            var secilenHtml = "";
            if (id == 1)
            {
                secilenHtml = "//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[1]/div[2]/a";
                path = htmlDocument.DocumentNode.SelectSingleNode(secilenHtml).Attributes["href"].Value;

            }
            if (id == 2)
            {
                secilenHtml = "//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[2]/div[2]/a";
                path = htmlDocument.DocumentNode.SelectSingleNode(secilenHtml).Attributes["href"].Value;

            }
            if (id == 3)
            {
                secilenHtml = "//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[3]/div[2]/a";
                path = htmlDocument.DocumentNode.SelectSingleNode(secilenHtml).Attributes["href"].Value;

            }
            if (id == 4)
            {
                secilenHtml = "//*[@id='main-content']/div[1]/div[1]/div/div/section[1]/div[1]/div[1]/div/div/div[5]/div[2]/a";
                path = htmlDocument.DocumentNode.SelectSingleNode(secilenHtml).Attributes["href"].Value;

            }
            if (id == 5)
            {

                secilenHtml = "//*[@id='main-content']/div[1]/div[1]/div/div/section[2]/div[1]/div[1]/div/div/div[1]/div[2]/a";
                path = htmlDocument.DocumentNode.SelectSingleNode(secilenHtml).Attributes["href"].Value;


            }
            return anaLink + path;
        }
        public string GetTitleAndContents(int id)

        {
            //Burası linkini veridğim makalenin p etiketlerini dönüyor.
            string link = GetContentLink(id);
            Uri url3 = new Uri(link);
            WebClient client = new WebClient { Encoding = Encoding.UTF8 };           
            string html = client.DownloadString(url3);
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var secilenHtml = "";
            HtmlNodeCollection secilenHtmlList;

            List<string> secilenHtmlGrup = new();
            StringBuilder stringBuilder = new StringBuilder();

            secilenHtmlGrup.Add(secilenHtml = "//*[@id='main-content']/article/div[2]/div[3]/div[1]/div[1]/div/div");
            secilenHtmlGrup.Add(secilenHtml = "//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div/div/div/div[1]/div");
            secilenHtmlGrup.Add(secilenHtml = "//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div[1]/div/div");
            secilenHtmlGrup.Add(secilenHtml = "//*[@id='main-content']/article/div[2]/div[1]/div[1]/div/div[1]/div/div");

            foreach (var item in secilenHtmlGrup)
            {
                secilenHtmlList = htmlDocument.DocumentNode.SelectNodes(item);
                if (secilenHtmlList != null)
                {
                    foreach (var itemcik in secilenHtmlList)
                    {
                        if (itemcik.SelectNodes("p") != null)
                        {
                            foreach (var pler in itemcik.SelectNodes("p"))
                            {
                                stringBuilder.AppendLine(pler.InnerText);
                            }
                        }

                    }
                }

            }
           
            var sonuc = stringBuilder.ToString();
            return sonuc;

          

        }
    }
}
