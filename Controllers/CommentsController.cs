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
    public class CommentsController
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
            return Ok(status = "success", message = "success", data = Comments);
        }

        [HttpPost]
        public IActionResult AddComment(CommentRequest Comments){
            var commentsAdd = new CommentRequest(){
                Id = 4,
                Content = Comments.Content,
                Status = Comments.Status,
                Create_Time = DateTime.Now,
                Author_Id = 2,
                Email = Comments.Email,
                Url = Comments.Url,
                Post_Id = 3
            };
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

        // [HttpPatch("{id}")]
        // public IActionResult PatchAuthor(CommentRequest Authors){
        //     return Ok(Comments.Append(i => i.Id == Authors.Id));
        // }

    }
}