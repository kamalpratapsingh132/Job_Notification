using Job_Notification.Data;
using Job_Notification.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext context;
  
        private UserManager<IdentityUserCreate> userManager;
        private SignInManager<IdentityUserCreate> signInManager;
        public UserController(UserManager<IdentityUserCreate> _usermanager, SignInManager<IdentityUserCreate> _signInManager, ApplicationDBContext _Context)
        {
            userManager = _usermanager;
            signInManager = _signInManager;
            context = _Context;
        }



        public IActionResult profile(string ID)
        {
            if (ID!=null)
            { 
                    var user = context.Users.Where(x => x.Email == ID).FirstOrDefault();                     
                    return View(user);
                }
                else
                {
                    return RedirectToAction("clientlogin", "client");

                }
            
         
        }



        public IActionResult Usertable ()
        {
            var use = context.Users.ToList();
            return View(use);
        }


        //public IActionResult CreateUser()
        //{
        //    return View();
        //}

        //public IActionResult CreateUser( User model)

        //{
        //    var emp = new IdentityUserCreate();
        //    context.Users.Add(emp);
        //    context.SaveChanges();
        //    return RedirectToAction("Usertable");


        //}

        //public IActionResult CreateEmployee([FromBody] Employee obj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new JsonResult("input field can't be empty");
        //    }
        //    dbcontext.Employees.Add(obj);
        //    int status = dbcontext.SaveChanges();
        //    //if (!Equals(status, 0))
        //    //{
        //    //    ViewData["sms"] = "Your Create page.";
        //    //    return Ok(new JsonResult(obj));
        //    //}
        //    //else
        //    //{
        //    //    ViewData["sms"] = "Item not Created.";
        //    //    return BadRequest(new JsonResult(obj));
        //    //}
        //    return new JsonResult(obj);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User model)
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
                    return new JsonResult(model);
                }
                else
                {
                    foreach (var er in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, er.Description);
                    }
                    return new JsonResult(model);
                }
            }
            else
            {
                return new JsonResult("input field can't be empty");
            }
        }

        public ActionResult CreateEdit(int? id)
        {
            User model = new User();
            //model.IsActive = true;
            if (id.HasValue)
            {
                //var emp = _context.User.Where(e => e.Id == id);
            }
            return PartialView("_CreateEdit", model);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateEdit(User model)
        {
            //validate user  
            if (!ModelState.IsValid)
            {


                return PartialView("_CreateEdit", model);
            }

            else
            {
                //_context.User.Add(model);
                //_context.SaveChanges();
                return RedirectToAction("index");

            }
            //save user into database   

        }


        public IActionResult Delete(int id)
        {
            //var emp = context.User.SingleOrDefault(e => e.ID == id);

            //if (emp != null)
            //{
            //    context.User.Remove(emp);
            //    context.SaveChanges();
            //    TempData["error"] = "Employee deleted !";
            //    return RedirectToAction("Usertable");
            //}
            //else
            //{
            //    TempData["error"] = "Employee Not Found !..";
            //    return RedirectToAction("Usertable");
            //}
            return View();
        }
    }
}
