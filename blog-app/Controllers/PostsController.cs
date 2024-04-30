using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using blog_app.Entity;
using blog_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace blog_app.Controllers
{
    public class PostsController:Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
       
        public PostsController(IPostRepository postRepository,ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
           
        }
        public async Task<IActionResult> Index(string tag)
        {
            var claims =User.Claims;

            var posts = _postRepository.Posts;
            if(!string.IsNullOrEmpty(tag))
            {
                posts= posts.Where(x=>x.Tags.Any(t=>t.Url==tag));

            }
            return View(new PostsViewModel{Posts = await posts.ToListAsync()});
        }
         public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository
                        .Posts
                        .Include(x => x.Tags)
                        .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(p => p.Url == url));
        }
        [HttpPost]
        public JsonResult AddComment(int PostId,string UserName,string CommentText,string Url)
        {
            var entity = new Comment
            {
                PostId = PostId,
                CommentText = CommentText,
                PublishedOn = DateTime.Now,
                User = new User
                {
                    UserName = UserName,
                    Image = "avatar.jpg"
                }
            };
            _commentRepository.CreateComment(entity);
            return Json(new {
                UserName,
                CommentText,
                entity.PublishedOn,
                entity.User.Image
            });           
        }


    }
}