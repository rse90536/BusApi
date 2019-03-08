using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplicationSignalr.App_Start
{
    public class ggettimeService
    {
        //async  public  GetRequest(string url)
        //  {
        //      HttpClient client = new HttpClient();
        //      HttpResponseMessakge response = client.("http://163.17.135.161/bus/route/300");

        //  }


        public void gettime()
        {
           GetRequest("http://www.microsoft.com");

        }
        async static void  GetRequest(string url)
        {
           using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://163.17.135.161/bus/route/300"))
              {
                  using (HttpContent content = response.Content)
                   {
                        string mycontent = await content.ReadAsStringAsync();
                      Console.WriteLine(mycontent);
                    }
                }

            }
            
        }

    }
}