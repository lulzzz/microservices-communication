﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        [HttpGet, Route("{upn}")]
        //todo check permissions: daemon, owner or admin
        public IActionResult GetClaims(string upn)
        {
            var theAppClaims = User.Identities.First().Claims.Where(x => x.Issuer == "theapp")
                .Select(x => new KeyValuePair<string, string>(x.Type, x.Value));
            return Ok(theAppClaims);
        }
    }
}