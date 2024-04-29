using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using blog_app.Entity;
using blog_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace blog_app.Controllers
{
    public class UsersController:Controller
    {
       public UsersController()
       {
        
       }
       public IActionResult Login()
       {
        return View();
       }

    }
}