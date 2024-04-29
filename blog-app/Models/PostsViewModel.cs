using blog_app.Entity;

namespace blog_app.Models
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; } = new();
        public List<Tag> Tags { get; set; }=new();
    }
    
}