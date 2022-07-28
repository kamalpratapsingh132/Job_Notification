using Job_Notification.Data;
using Job_Notification.Models;
using Job_Notification.Models.LoginViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<IdentityUserCreate> userManager;
        private SignInManager<IdentityUserCreate> signInManager;
        private readonly ApplicationDBContext context;
        public HomeController(ILogger<HomeController> logger , UserManager<IdentityUserCreate> _usermanager, SignInManager<IdentityUserCreate> _signInManager, ApplicationDBContext _Context)
        {
            _logger = logger;
            userManager = _usermanager;
            signInManager = _signInManager;
            context = _Context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.SingleOrDefault(e => e.UserName == model.email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(model.email, model.password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Details");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid User");
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {

                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUserCreate()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PasswordHash = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    Gender = model.Gender
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.message = "user created Sucessfully !";
                    return View();
                }
                else
                {
                    foreach (var er in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, er.Description);
                    }
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //public async Task<IActionResult> SignOut()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("Index");
        //}

    }
}
