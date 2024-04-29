using blog_app.Entity;

namespace blog_app.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags {get;}
        void CreatePost (Tag tag);
    }
}