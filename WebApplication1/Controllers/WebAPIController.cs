﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class WebAPIController : ApiController
    {
        // GET: api/WebAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WebAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WebAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WebAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WebAPI/5
        public void Delete(int id)
        {
        }
    }
}
