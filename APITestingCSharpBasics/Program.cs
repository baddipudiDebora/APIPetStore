using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APITestingCSharpBasics
{
    internal class Program
    {
        static string baseURL = ConfigurationManager.AppSettings["applicationBaseURL"];
        static  HttpWebRequest myHttpWebRequest;
        static string requestURL;
        Uri myUri;
        static void Main(string[] args)
        {
            testGETPetbyID("1");
        }

        public static void testGETPetbyID(string petID)
        {            
           formAPIRequestURL(petID);
           formHttpRequestObject();
           sendAPIRequest();
        }


        // 1. form the request url
        public static void formAPIRequestURL(string petID)
        {     
            requestURL = string.Format("{0}{1}{2}", baseURL, "pet/", petID);
            Console.WriteLine(requestURL);
            Thread.Sleep(2000);
        }

        // 2. Create a 'HttpWebRequest' object for the specified url.
        public static HttpWebRequest formHttpRequestObject()
        {
           try
            {     
                Uri myUri = new Uri(requestURL);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                return myHttpWebRequest;
            }
            catch (Exception ex)
            {
                return myHttpWebRequest;
            }
           
        }

        // 3. Send the request and wait for response.
        public static void sendAPIRequest()
        {
            try
            {               
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)formHttpRequestObject().GetResponse();
                Console.WriteLine(myHttpWebResponse.StatusCode);
                Thread.Sleep(1000);
                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(3000);
            }

        }
    }
}
