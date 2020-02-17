using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_test_api.Model;

namespace web_test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        // private static readonly string[] users = new[]
        // {
        //     "rashif", "rishaf", "rashaf", "rushaf", "roshof"
        // };
        private static List<User> users = new List<User>(){
            new User(){Id=1, Name = "rashif", Username="lupabapak"},
            new User(){Id=2, Name = "rishaf", Username="lupamamak"}
        };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {status = "success", message = "success", data = users });
        }       

        [HttpGet("{id}")]
        public IActionResult GetByID(int id){
            return Ok(users.Find(i => i.Id == id));
        }

        [HttpPost]
        public IActionResult AddUser(UserRequest user){
            var userAdd = new User(){
                Id = 3,
                Username = user.Username,
                Name = user.Name
            };
            users.Add(userAdd);

            return Ok(users);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id){
            return Ok(users.RemoveAll(i => i.Id == id));
        }

        // [HttpPatch("{id}")]
        // public IActionResult PatchName(UserRequest user){
            // var namePatch = new User(){
            //     Id = id,
            //     Name = users.Name
            // };
            // users.Add(namePatch);

            // return Ok(users);
            // return Ok(users.Append(i => i.Id == Id, Name = users.Name));
        // }
    }
}