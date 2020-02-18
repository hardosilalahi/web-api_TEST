using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using web_test_api.Model;
// using System.Dynamic;
// using Microsoft.AspNetCore.JsonPatch;
// using Bcrypt.Net;


namespace web_test_api.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorsController : ControllerBase
    {
        private static List<AuthorRequest> Authors = new List<AuthorRequest>(){
            new AuthorRequest(){
                Id = 1,
                Username = "spongbobbybola",
                Password = "berburuuburubur",
                Salt = "sdgfjkasgdfgwuygr",
                Email = "goofygoober@bottom.net",
                Profile = "Berburu Ubur-ubur"
            },
            new AuthorRequest(){
                Id = 2,
                Username = "petrikstar",
                Password = "batunisan",
                Salt = "ashfgkjshbgdgsbfhgbs",
                Email = "goofymber@bottom.net",
                Profile = "Mengganggu Squidward"
            },
            new AuthorRequest(){
                Id = 3,
                Username = "squidwardtentakel",
                Password = "klarinetidola",
                Salt = "sfgafhetjhethg",
                Email = "belomgajian@bottom.net",
                Profile = "Hidup santai bermain klarinet"
            }
        };

        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAuthors(){
            return Ok(new {status = "success", message = "success", data = Authors});
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorRequest authorAdd){
            Authors.Add(authorAdd);

            return Ok(Authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id){
            return Ok(Authors.Find(i => i.Id == id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            return Ok(Authors.RemoveAll(i => i.Id == id));
        }

        // [HttpPatch("{id}")]
        // public IActionResult PatchAuthor(AuthorRequest Authors){
        //     return Ok(Authors.Append(i => i.Id == Authors.Id));
        // }

    }
}