using blog_app.Entity;

namespace blog_app.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User user);
    }
}