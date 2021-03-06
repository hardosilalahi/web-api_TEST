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
    [Route("comments")]
    public class CommentsController : ControllerBase
    {
        private static List<CommentRequest> Comments = new List<CommentRequest>(){
            new CommentRequest(){
                Id = 1,
                Content = "Kok Bisa Spongebob gagal?",
                Status = true,
                Create_Time = DateTime.Now,
                Author_Id = 1,
                Email = "sendicik@bottom.net",
                Url = "www.tupai.id",
                Post_Id = 1
            },
            new CommentRequest(){
                Id = 2,
                Content = "Gimana bisa dibantu?",
                Status = false,
                Create_Time = DateTime.Now,
                Author_Id = 1,
                Email = "hidupleri@bottom.net",
                Url = "www.tampanberani.id",
                Post_Id = 2
            },
            new CommentRequest(){
                Id = 3,
                Content = "Akhirnya mengakui",
                Status = true,
                Create_Time = DateTime.Now,
                Author_Id = 2,
                Email = "mermedmen@bottom.net",
                Url = "www.kapalilang.id",
                Post_Id = 3
            }
        };

        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetComments(){
            return Ok(new {status = "success", message = "success", data = Comments});
        }

        [HttpPost]
        public IActionResult AddComment(CommentRequest commentsAdd){
            Comments.Add(commentsAdd);

            return Ok(Comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id){
            return Ok(Comments.Find(i => i.Id == id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            return Ok(Comments.RemoveAll(i => i.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAuthor(int id, [FromBody]JsonPatchDocument<CommentRequest> patch){
            patch.ApplyTo(Comments.Find(i => i.Id == id));

            return Ok(Comments.Find(i => i.Id == id));
        }

    }
}