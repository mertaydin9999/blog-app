using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using blog_app.Entity;

namespace blog_app.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;
        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}