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
        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "Hello world!";
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User newUser)
        {
            try
            {
                // Check that both passwords are equal
                if(newUser.Password != newUser.ReEnteredPassword)
                {
                    Dictionary<string, string> responseData = new Dictionary<string, string>()
                    {
                        {"password", "Both passwords must be equal!"}
                    };
                    return BadRequest(new FailResponse(responseData));
                }

                // Basic validation to assure that any property is null
                foreach (PropertyInfo prop in newUser.GetType().GetProperties())
                {
                    if (prop.GetValue(newUser) is null)
                    {
                        Dictionary<string, string> responseData = new Dictionary<string, string>()
                        {
                            {prop.Name, $"{prop.Name} is required! {prop.GetValue(newUser)} was passed."}
                        };
                        return BadRequest(new FailResponse(responseData));
                    }
                }

                // TODO: Really save something in a DB
                // TODO: Log event

                return Created("", new SuccessResponse(newUser));
            }
            catch (Exception err)
            {
                // TODO: Log event
                return StatusCode(500, new ErrorResponse(err.Message));
            }
        }
    }
}
