using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Joe_s_Pizza.Models;

namespace Joe_s_Pizza.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ViewBag.msg = "User created successfully.";
            }
            else
            {
                ViewBag.msg = "Failed to create user.";
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);
            if (result.Succeeded)
            {
                string uname = User.Identity.Name;

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.msg = "Failed to login.";
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            ViewBag.msg = "User logged out successfully";
            return View();
        }

    }
}