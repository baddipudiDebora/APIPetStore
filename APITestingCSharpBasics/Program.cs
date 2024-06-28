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
        static void Main(string[] args)
        {
           sendValidAPIRequest("1");
      //     sendInvalidAPIRequest("100");
        }

        public static void sendValidAPIRequest(string petID)
        {
            string baseURL = ConfigurationManager.AppSettings["applicationBaseURL"];
            string requestURL = string.Format("{0}{1}{2}", baseURL, "pet/", petID);
            Console.WriteLine(requestURL);
            Thread.Sleep(3000);
            // 1. Create a 'HttpWebRequest' object for the specified url.
            Uri myUri = new Uri(requestURL);

            // Create a 'HttpWebRequest' object for the specified url.
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);

            try
            {
                // Send the request and wait for response.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
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
        public static void sendInvalidAPIRequest(string petID)
        {
            string requestURL = "https://petstore.swagger.io/v2/pet/"+petID;
            // 1. Create a 'HttpWebRequest' object for the specified url.
            Uri myUri = new Uri(requestURL);

            // Create a 'HttpWebRequest' object for the specified url.
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);

            try
            {
                // Send the request and wait for response.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
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
