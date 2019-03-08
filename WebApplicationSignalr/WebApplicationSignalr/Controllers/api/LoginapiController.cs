using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebApplicationSignalr.App_Start.Service;
using WebApplicationSignalr.Models;

namespace WebApplicationSignalr.Controllers.api
{
    public class LoginapiController : ApiController
    {
      
        [HttpPost]
        public HttpResponseMessage login(loginView loginmember)
        {


            rse90536Entities busdriver = new rse90536Entities();
            if (!ModelState.IsValid)
            {
                var message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, message);
            }

            string ValidateStr = new loginService().loginCheck(loginmember.account, loginmember.password/*,loginmember.busnumbr*/);
            if (ValidateStr.Equals(""))
            {
                string enTicket = new loginService().GetEnTicket(loginmember.account);
                CookieHeaderValue cookie = new CookieHeaderValue("DriverNumber", enTicket);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                var res = Request.CreateResponse(HttpStatusCode.OK, enTicket);
                res.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                Console.WriteLine("Test!");
                

                return res;

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ValidateStr);
            }

        }

        [HttpGet]
        public HttpResponseMessage getuserinfo()
        {
            if(User.Identity.IsAuthenticated)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [HttpPost]
        public HttpResponseMessage getDriverbn(BusAcView account)
        {
           int Drivebn = new GetDriverService().getbn(account.account);
          if(Drivebn.Equals(0))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                return    Request.CreateResponse(HttpStatusCode.OK,Drivebn.ToString());
            }
        }
        //public HttpResponseMessage getbusId(TicketView Ticket)
        //{
        //    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookies.Value)
        //}
    }
}