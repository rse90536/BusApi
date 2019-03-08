using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationSignalr.App_Start.Service;
using WebApplicationSignalr.Models;

namespace WebApplicationSignalr.Controllers.api
{
    public class SignalRBusapiController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage BusPost(BusNumView loginmember)
        {
            int BusNum = new GetDriverService().findBn(loginmember.busnum);
            if (BusNum != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, BusNum);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "無此車牌");
            }
        }


      
        [HttpPost]
        public HttpResponseMessage testrequset(CaridView comeCarid)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<serverhub>();
            hubContext.Clients.User(comeCarid.comeCarid)/*在這找司機*/
                .sendMessage(comeCarid.stopid,comeCarid.goback);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage GoUp(GoUpView comeCarid)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<serverhub>();
            hubContext.Clients.User(comeCarid.comeCarid)/*在這找司機*/
                .sendMessage(comeCarid.stopid,comeCarid.goback,comeCarid.up);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage downstop(gobackView comeCarid)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<serverhub>();
            hubContext.Clients.User(comeCarid.comeCarid)/*在這找司機*/
                .sendMessage(comeCarid.stopid);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
