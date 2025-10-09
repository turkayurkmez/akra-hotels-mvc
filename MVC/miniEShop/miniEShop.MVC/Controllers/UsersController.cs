using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using miniEShop.Application.Services;
using miniEShop.MVC.Models;
using System.Security.Claims;

namespace miniEShop.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserSevice userSevice;

        public UsersController(IUserSevice userSevice)
        {
            this.userSevice = userSevice;
        }

        public IActionResult Login(string? gidilecekUrl)
        {
            ViewBag.Url = gidilecekUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model, string? gidilecekUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userSevice.VerifyUser(model.UserName, model.Password);
                if (user != null)
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),


                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekUrl) && Url.IsLocalUrl(gidilecekUrl))
                    {
                        return Redirect(gidilecekUrl);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("loginFailed", "Kullanıcı veya şifre hatalı");

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
