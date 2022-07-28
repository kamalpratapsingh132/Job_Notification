using Job_Notification.Models;
using Microsoft.AspNetCore.Mvc;
using Job_Notification.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDBContext context;

        public AdminController(ApplicationDBContext _Context)
        {
            context = _Context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult Datatable()
        {
            var jobs = context.Add_Jobs.ToList();
            return View(jobs);
        }


        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]

        public IActionResult Create(Add_jobs model)

        {        
            context.Add_Jobs.Add(model);
            context.SaveChanges();
            return RedirectToAction("show_Data");

        }

        public IActionResult Delete(int id)
        {
            var emp = context.Add_Jobs.SingleOrDefault(e => e.ID == id);

            if (emp != null)
            {
                context.Add_Jobs.Remove(emp);
                context.SaveChanges();
                TempData["error"] = "Employee deleted !";
                return RedirectToAction("Datatable");
            }
            else
            {
                TempData["error"] = "Employee Not Found !..";
                return RedirectToAction("Datatable");
            }

        }




    }
}
