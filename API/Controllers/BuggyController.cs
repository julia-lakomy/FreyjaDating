using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";

            //for testing server errors only
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var x = _context.Users.Find(-1);

            if(x == null) return NotFound();

            return Ok(x);
            //for testing server errors only
            //404 not fount method
        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var x = _context.Users.Find(-1);

            var errorToReturn = x.ToString();

            return errorToReturn;
            //for testing server errors only
            //returns server error to client aplikaction
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request");
            //for testing server errors only
            //returns bad request
        }
    }
}