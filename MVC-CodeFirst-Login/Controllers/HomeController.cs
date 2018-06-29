using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models;

namespace MVC_CodeFirst_Login.Controllers
{
    public class HomeController : Controller
    {
        private OurDbContext _context;
        public HomeController(OurDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Patient.ToList());
        }

        public IActionResult Episode()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //public IActionResult Diagnosis() {
        //    return View(_context.Diagnosis.ToList());
        //}

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
     

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //IAction??
        public IActionResult GPRegister() {
            return View();
        }

        [HttpPost]
        public ActionResult GPRegister(GeneralPractioner generalPractioner) {
            if (ModelState.IsValid) {
                _context.GeneralPractioner.Add(generalPractioner);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.message = generalPractioner.FirstName + " " + generalPractioner.LastName + 
                    " is successful registered";
            } else
            {
                ViewBag.message = "register failed.";
            }
            return View();
        }

        public IActionResult PaRegister() {
            return View();
        }

        [HttpPost]
        public ActionResult PaRegister(Patient patient) {
            if (ModelState.IsValid) {
                _context.Patient.Add(patient);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.message = patient.FirstName + " " + patient.LastName +
                    " is successful registered";
            }
            else {
                ViewBag.message = "register failed.";
            }
            return View();
        }        

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Patient patient, GeneralPractioner generalPractioner)
        {
            var account = _context.Patient.Where(u => u.UserName == patient.UserName &&
            u.Password == patient.Password).FirstOrDefault();

            var account2 = _context.GeneralPractioner.Where(u => u.UserName == generalPractioner.UserName &&
            u.Password == generalPractioner.Password).FirstOrDefault();

            if (account != null)
            {
                HttpContext.Session.SetString("PatientId", account.PatientId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);
                return View("Welcome", patient);
            }
            else if (account2 != null) {
                HttpContext.Session.SetString("UserId", account2.UserId.ToString());
                HttpContext.Session.SetString("UserName", account2.UserName);
                return View("Welcome", generalPractioner);
            }
            else
            {
                ModelState.AddModelError("", "username or pass is wrong");
            }
            return View();
        }

        public ActionResult Welcome() {
            if(HttpContext.Session.GetString("UserId") != null) {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
