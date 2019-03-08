using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Script.Serialization;

namespace WebApplicationSignalr.Controllers.api
{
    public class busTimeapiController : ApiController
    {
        private void useHttpWebRequest_Get()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://163.17.135.161/bus/route/300");
            //request.Method = WebRequestMethods.Http.Get;
            //request.ContentType = "application/json";

            //using (var response = (HttpWebResponse)request.GetResponse())
            //{
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        using (var stream = response.GetResponseStream())
            //        using (var reader = new StreamReader(stream))
            //        {
            //            var temp = reader.ReadToEnd();

            //            //TODO:反序列化
            //            var serializer = new JavaScriptSerializer();
            //            var list = serializer.Deserialize<List<>>(temp);
            //            this.dataGridView1.DataSource = list;
            //            this.txtResponse.Text = temp;
            //        }
            //    }
            //    else
            //    {
            //        this.dataGridView1.DataSource = null;
            //    }
            }
        }
        //public void gettime()
        //{
        //    GetRequest("http://www.microsoft.com");

        //}
        //async public HttpResponseMessage GetRequest(string url)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessakge response = await client("http://163.17.135.161/bus/route/300"))
        //        {
        //            using (HttpContent content = response.Content)
        //            {
        //                string mycontent = content.ReadAsStringAsync();
        //                Console.WriteLine(mycontent);
        //            }
        //        }

        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }


