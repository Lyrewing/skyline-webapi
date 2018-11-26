﻿using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System.Collections.Generic;
using System;
using Polly.Registry;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private ITracer _tracer;
        private readonly IReadOnlyPolicyRegistry<string> _policyRegistry;
        public ValuesController(ITracer tracer,IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _policyRegistry = policyRegistry;
            _tracer = tracer;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}