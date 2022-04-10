using CORE_FIRST_PRAJECT.DB_context;
using CORE_FIRST_PRAJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_FIRST_PRAJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<empmodel> mod = new List<empmodel>();
            chetucompanyContext ent = new chetucompanyContext();
            var res = ent.EmpDetails.ToList();
            foreach (var item in res)
            {
                mod.Add(new empmodel
                {
                   Id=item.Id,
                   Name=item.Name,
                   Email=item.Email,
                   Department=item.Department,
                   Contact=item.Contact,
                   City=item.City

                });

            }
           
            return View(mod);
        }
        [HttpGet]
        public IActionResult ADD_EMP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ADD_EMP(empmodel mod)
        {
            chetucompanyContext ent = new chetucompanyContext();
            EmpDetail tbl = new EmpDetail();
            tbl.Id = mod.Id;
            tbl.Name = mod.Name;
            tbl.Email = mod.Email;
            tbl.Department = mod.Department;
            tbl.Contact = mod.Contact;
            tbl.City = mod.City;
            if (mod.Id == 0)
            {


                ent.EmpDetails.Add(tbl);
                ent.SaveChanges();
            }
            else
            {
                ent.Entry(tbl).State =EntityState.Modified;
                ent.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Edit(int id)
        {
            empmodel mod = new empmodel();
            chetucompanyContext ent = new chetucompanyContext();
            var edt = ent.EmpDetails.Where(m => m.Id == id).First();
            mod.Id = edt.Id;
            mod.Name = edt.Name;
            mod.Email = edt.Email;
            mod.Department = edt.Department;
            mod.Contact = edt.Contact;
            mod.City = edt.City;
            return View("ADD_EMP", mod);


        }
        public IActionResult Delete(int id)
        {
            chetucompanyContext ent = new chetucompanyContext();
            var det = ent.EmpDetails.Where(m => m.Id == id).First();
            ent.EmpDetails.Remove(det);
            ent.SaveChanges();

            return RedirectToAction("Index");
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
    }
}
