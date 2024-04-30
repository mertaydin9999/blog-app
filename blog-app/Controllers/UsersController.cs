using System.Security.Claims;
using blog_app.Data.Abstract;
using blog_app.Data.Concrete.EfCore;
using blog_app.Entity;
using blog_app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace blog_app.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserRepository _userRepository;
       public UsersController(IUserRepository userRepository)
       {
            _userRepository = userRepository;
       }
       public IActionResult Login()
       {
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Posts");
            }
            return View();
       }
       public async Task<IActionResult> Logout()
       {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
       }
       [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
       {
        if(ModelState.IsValid)
        {
            var isUser = _userRepository.Users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);
            if(isUser != null)
            {
                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier,isUser.UserId.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name,isUser.UserName  ?? ""));
                userClaims.Add(new Claim(ClaimTypes.GivenName,isUser.Name  ?? ""));

                if(isUser.Email== "mert@gmail.com")
                {
                    userClaims.Add(new Claim(ClaimTypes.Role,"admin"));
                }
                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties );
                return RedirectToAction("Index","Posts");
            }
            else
            {
                ModelState.AddModelError("","Kullanici adi veya sifre yanlis");
            }
        }
        
        return View(model);
       }
    }
}