using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User newUser)
        {
            // Basic validation to assure that any property is null
            foreach (PropertyInfo prop in newUser.GetType().GetProperties())
            {
                if(prop.GetValue(newUser) is null)
                {
                    Dictionary<string, string> responseData = new Dictionary<string, string>()
                    { 
                        {prop.Name, $"{prop.Name} is required!"}
                    };
                    return BadRequest(new FailResponse(responseData));
                }
            }

            // TODO: Really save something in a DB
            // TODO: Log event

            return Created("", new SuccessResponse(newUser));
        }
    }
}
