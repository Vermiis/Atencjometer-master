using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing;
using AtjWinForms;
using Wypok;

namespace AtjWinForms
{
    class ConnectToMirko 
    {
        public static string GetFullNickname(string mirek)
        {
            string fullNick = "";
            
            

            using (var streamReader = new StreamReader(Wypok.GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))
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

                using (var streamReader = new StreamReader(Wypok.GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);
                    //  var innerText = doc.DocumentNode.Descendants("img").Select(x => x.InnerText).ToList();
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
                throw;
            }
            return link;
        }
        public static Image UstawAvek(string mirek)
        {
            System.Drawing.Image avek;
            var request = WebRequest.Create(PobierzAvatar(GetFullNickname(mirek)));
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                avek = System.Drawing.Image.FromStream(stream);
            }
            return avek;
        }
        //to lepsze 
        public static List<string> PobierzTagi(string mirek)
        {
            List<string> tagi = new List<string>();
            try
            {
                using (var streamReader = new StreamReader(Wypok.GetResponses.GetResponseFromWypok(mirek).GetResponseStream()))

                {
                    var result = streamReader.ReadToEnd();
                    // Console.WriteLine(result);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);
                    var innerText = doc.DocumentNode.Descendants("a").Select(x => x.InnerText).ToList();
                    foreach (var item in innerText)
                    {
                        if (item.Contains("#") && item.Contains("("))
                        {
                            //Console.WriteLine(item);
                            //tagi.Add(item);
                            tagi.Add(item.Split(' ').First());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //obsluga 404 do naruchania
                Console.WriteLine(ex.ToString());
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
