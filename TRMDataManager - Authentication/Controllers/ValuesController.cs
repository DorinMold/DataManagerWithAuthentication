﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TRMDataManager___Authentication.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get() // ca sa putem trimite statusul inapoi
        //public IHttpActionResult Get() // daca folosim IHttpActionResult avem Ok() dar nu mai aven return 
                                         //type...se poate retrun orice
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            //return Ok(new string[] { "value1", "value2", userId });
            return new string[] { "value1", "value2", userId };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}