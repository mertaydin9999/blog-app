using blog_app.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
namespace blog_app.Controllers
{
    public class PostsController:Controller
    {
        private readonly BlogContext _context;
        public PostsController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Posts.ToList());
        }

    }
}