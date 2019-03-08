using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationSignalr.Controllers.api
{


    public class testapiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage testrequset(string test)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<serverhub>();
            hubContext.Clients.User("617-U8")
                .sendMessage("tttt",test);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
