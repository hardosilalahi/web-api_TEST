using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using web_test_api.Model;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
// using Bcrypt.Net;


namespace web_test_api.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private static List<PostsRequest> Posts = new List<PostsRequest>(){
            new PostsRequest(){
                Id = 1,
                Title = "Tes Sim Spongebob",
                Content = "Spongebob Gagal Tes",
                Tags = new List<string>{
                    "spongebob",
                    "mobil"
                },
                Status = true,
                Create_Time = DateTime.Now,
                Update_Time = DateTime.Now,
                Author_Id = 1
            },
            new PostsRequest(){
                Id = 2,
                Title = "Spongebob dibantu Petrik",
                Content = "Petrik Memandu Spongebob",
                Tags = new List<string>{
                    "mengendara",
                    "penipu"
                },
                Status = true,
                Create_Time = DateTime.Now,
                Update_Time = DateTime.Now,
                Author_Id = 1
            },
            new PostsRequest(){
                Id = 3,
                Title = "Spongebob Menipu",
                Content = "Spongebob Mengakui Kesalahan",
                Tags = new List<string>{
                    "petrik",
                    "radio"
                },
                Status = true,
                Create_Time = DateTime.Now,
                Update_Time = DateTime.Now,
                Author_Id = 2
            }
        };

        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPosts(){
            return Ok(new {status = "success", message = "success", data = Posts});
        }

        [HttpPost]
        public IActionResult AddUser(PostsRequest postsAdd){
            Posts.Add(postsAdd);

            return Ok(Posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id){
            return Ok(Posts.Find(i => i.Id == id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            return Ok(Posts.RemoveAll(i => i.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAuthor(int id, [FromBody]JsonPatchDocument<PostsRequest> patch){
            patch.ApplyTo(Posts.Find(i => i.Id == id));

            return Ok(Posts.Find(i => i.Id == id));
        }

    }
}