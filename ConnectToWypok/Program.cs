using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace ConnectToWypok
{


    public class Program
    {
        public static HttpWebResponse GetResponseFromWypok(string mirek)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://wykop.pl/ludzie/" + mirek);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            return response;
            
           
        }
        public static string GetFullNickname(string mirek)
        {
            string fullNick = "";
            
            using (var streamReader = new StreamReader(GetResponseFromWypok(mirek).GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                var innerText = doc.DocumentNode.Descendants("span").Select(x => x.InnerText).Take(4).ToList();
                foreach (var item in innerText)
                {              
                   
                    if (string.Equals(mirek, item, StringComparison.OrdinalIgnoreCase))
                    {                      
                      fullNick = item;                     
                    }
                }
            }
            return fullNick;
        }
        //to jest z dupy, do wyjebania
        public static void WebRequestToWypok(string mirek)
        {

            string WEBSERVICE_URL = "http://wykop.pl/ludzie/" + mirek;
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    //post a name, val = md5 params

                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    //webRequest.Headers.Add("Authorization", "md5");
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //olej to motzno
        public static string PobierzAvatar(string mirek)
        {
            string link="";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://wykop.pl/ludzie/" + mirek);



                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    // Console.WriteLine(result);


                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);

                    //  var innerText = doc.DocumentNode.Descendants("img").Select(x => x.InnerText).ToList();
                    var imgs = doc.DocumentNode.SelectNodes("//img");
                    var urls = doc.DocumentNode.Descendants("img")
                                 .Select(e => e.GetAttributeValue("src", null))
                                 .Where(s => !String.IsNullOrEmpty(s));
                    foreach (var item in urls)
                    {
                       // Console.WriteLine(item);
                        if (item.Contains(mirek))
                        {
                            Console.WriteLine(item);
                            link = item;
                        }
                    }
                   
                }


            }
            catch (Exception ex)
            {
                //obsluga 404 do naruchania
                Console.WriteLine(ex.ToString());
            }
            #region

            #endregion
            return link;

        }
        //to lepsze
        public static List<string> PobierzTagi(string mirek)
        {
            List<string> tagi = new List<string>();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://wykop.pl/ludzie/" + mirek);



                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    // Console.WriteLine(result);


                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(result);

                    var innerText = doc.DocumentNode.Descendants("a").Select(x => x.InnerText).ToList();

                    foreach (var item in innerText)
                    {
                        if (item.Contains("#"))
                        {
                            //Console.WriteLine(item);


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
            #region

            #endregion
            return tagi;

        }

        public static double Atencja (string mirek1, string mirek2)
        {
            int atj = 0;

            foreach (var item in PobierzTagi(mirek1))
            {
                foreach (var x in PobierzTagi(mirek2))
                {
                    if ((x.Equals(item)))
                    {
                        atj++;
                    }
                }
            }
            
            return atj;
        }

        //        Index
        //Pobranie informacji o użytkowniku
        //Parametry metody	param1 - nazwa użytkownika
        //Parametry API	appkey – klucz aplikacji
        //Parametry POST	

        //header a0f1239cd149ec1c698810f84b2d420c
        public static double AtencjaPro(string mirek1, string mirek2)
        {

            return 1;
        }



        static void Main(string[] args)
        {

            //div class fix-tagline

            Console.WriteLine("Podaj nick");
            var nick = Console.ReadLine();
            // WebRequest(nick);
            //PobierzTagi(nick);

            Console.WriteLine("Podaj nick");
            var nick1 = Console.ReadLine();
            //PobierzTagi(nick1);


            //IEnumerable<string> differenceQuery =
            //  PobierzTagi(nick).Except(PobierzTagi(nick1));


            //Console.WriteLine("Rozniace was tagi: ");
            //foreach (string s in differenceQuery)
            //    Console.WriteLine(s);

            
            Console.WriteLine(GetFullNickname(nick));
            PobierzAvatar(GetFullNickname(nick));
            Console.WriteLine(Atencja(nick1, nick));



        }


    }
}
