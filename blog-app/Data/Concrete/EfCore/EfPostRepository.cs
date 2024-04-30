using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using blog_app.Entity;

namespace blog_app.Data.Concrete
{
    public class EfPostRepository : IPostRepository
    {
        private BlogContext _context;
        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault( i => i.PostId == post.PostId);
            if(entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Url = post.Url;
                entity.IsActive = post.IsActive;
                entity.Content = post.Content;
                
                _context.SaveChanges();
            }
        }
    }
}