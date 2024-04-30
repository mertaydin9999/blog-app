using blog_app.Entity;

namespace blog_app.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts {get;}
        void CreatePost (Post post);
        void EditPost (Post post);
    }
}