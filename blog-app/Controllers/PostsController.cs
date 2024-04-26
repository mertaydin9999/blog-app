using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
namespace blog_app.Controllers
{
    public class PostsController:Controller
    {
        private IPostRepository _repository;
        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Posts.ToList());
        }

    }
}