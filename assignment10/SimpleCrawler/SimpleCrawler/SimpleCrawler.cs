using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    internal class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            myCrawler.Crawl();//开始爬行
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (count <= 10)
            {
                List<string> currentUrls = new List<string>();

                foreach (string url in urls.Keys) //找到还没有下载过的链接
                {
                    if ((bool)urls[url]) continue;
                    currentUrls.Add(url);
                }

                if (currentUrls.Count == 0) break;

                //设置最大并行度为 3
                Parallel.ForEach(currentUrls, new ParallelOptions { MaxDegreeOfParallelism = 3 }, current =>
                {
                    Console.WriteLine("爬行" + current + "页面!");
                    string html = DownLoad(current); // 下载
                    urls[current] = true;
                    count++;
                    Parse(html);//解析,并加入新的链接
                });
            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
