using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing;

namespace Wypok
{
    public class Connect
    {
        public static string GetFullNickname(string mirek)
        {
            string fullNick = "";

            using (var streamReader = new StreamReader(GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                var innerText = doc.DocumentNode.Descendants("span").Select(x => x.InnerText).Take(4).ToList();
                Parallel.ForEach(innerText, line =>
                {
                    if (string.Equals(mirek, line, StringComparison.OrdinalIgnoreCase))
                    {
                        fullNick = line;
                    }
                });
            

            }
            return fullNick;

        }
        public static string PobierzAvatar(string mirek)
        {
            string link = "";
            try
            {

                using (var streamReader = new StreamReader(GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);
                   
                    var imgs = doc.DocumentNode.SelectNodes("//img");
                    var urls = doc.DocumentNode.Descendants("img")
                                 .Select(e => e.GetAttributeValue("src", null))
                                 .Where(s => !String.IsNullOrEmpty(s));
              
                    Parallel.ForEach(urls, item =>
                    {
                        if (item.Contains(mirek))
                        {
                            Console.WriteLine(item);
                            link = item;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                link= "http://www.bezpiecznykot.pl/wp-content/uploads/2015/12/kot-150x150.jpg";
            }
            return link;
        }
    

        
        public static List<string> PobierzTagi(string mirek)
        {
            List<string> tagi = new List<string>();
            try
            {
                using (var streamReader = new StreamReader(GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))

                {
                    var result = streamReader.ReadToEnd();
                
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);
                    var innerText = doc.DocumentNode.Descendants("a").Select(x => x.InnerText).ToList();
                    foreach (var item in innerText)
                    {
                        if (item.Contains("#") && item.Contains("("))
                        {
                           
                            tagi.Add(item.Split(' ').First());
                        }
                    }
                }
            }
            catch (Exception ex)
            {         
                throw;
            }

            return tagi;

        }
        public static string WypiszTagi(string mirek)
        {
            return String.Join("\r\n", PobierzTagi(mirek));
        }

        public static int CommonTags(string mirek1, string mirek2)
        {
            var x = 0;
            var tag1 = PobierzTagi(mirek1);
            var tag2 = PobierzTagi(mirek2);

            Parallel.ForEach(tag1, item =>
            {
                Parallel.ForEach(tag2, tag =>
                {

                    if (item.Equals(tag))
                    {
                        x++;
                    }
                }
                    );

            }
                );
            return x;
        }

    }
}
