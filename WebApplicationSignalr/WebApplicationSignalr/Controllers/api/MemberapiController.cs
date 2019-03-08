using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationSignalr.Models;

namespace WebApplicationSignalr.Controllers.api
{
    public class MemberapiController : ApiController
    {
        public IEnumerable<member> Get()
        {
            using (rse90536Entities entites = new rse90536Entities())
            {
                return entites.member.ToList();
            }
        }
        public member Get(int id)
        {
            using(rse90536Entities entities = new rse90536Entities())
            {
                return entities.member.FirstOrDefault(e => e.id==id);            }
        }

    }
}
