using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using web_test_api.Model;
using Bcrypt.Net;


namespace web_test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController
    {
        private static List<AuthorRequest> Authors = new List<AuthorRequest>(){
            new AuthorRequest(){
                Id = 1,
                Username = "spongbobbybola",
                Password = "berburuuburubur",
                Salt = $"{Bcrypt.HashPassword(Password)}",
                Email = "goofygoober@bottom.net",
                Profile = "Berburu Ubur-ubur"
            },
            new AuthorRequest(){
                Id = 2,
                Username = "petrikstar",
                Password = "batunisan",
                Salt = $"{Bcrypt.HashPassword(Password)}",
                Email = "goofymber@bottom.net",
                Profile = "Mengganggu Squidward"
            },
            new AuthorRequest(){
                Id = 3,
                Username = "squidwardtentakel",
                Password = "klarinetidola",
                Salt = Bcrypt.HashPassword(Password),
                Email = "belomgajian@bottom.net",
                Profile = "Hidup santai bermain klarinet"
            }
        };

        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(ILogger<ArticlesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAuthors(){
            return Ok(status = "success", message = "success", data = Authors);
        }

        [HttpPost]
        public IActionResult AddUser(AuthorRequest authorAdd){
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