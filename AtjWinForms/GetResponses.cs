using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AtjWinForms
{
    class GetResponses
    {
        public static HttpWebResponse GetResponseFromWypok(string mirek)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://wykop.pl/ludzie/" + mirek);
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (Exception e)
            {

                throw;
            }


        }
    }
}
