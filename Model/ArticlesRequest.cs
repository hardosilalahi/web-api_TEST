using System;
namespace web_test_api.Model
{
    public class AuthorRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
    }
    
    public class PostsRequest{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool Status { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        public int Author_Id { get; set; }
    }

    public class CommentRequest{
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime Create_Time { get; set; }
        public int Author_Id { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int Post_Id { get; set; }

    }
}