using blog_app.Entity;

namespace blog_app.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        void CreateComment(Comment comment);
    }
}