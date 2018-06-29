using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MVC_CodeFirst_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Controllers
{
    public class ConsultController : Controller
    {
        private OurDbContext _context;
        public ConsultController(OurDbContext context)
        {
            _context = context;
        }

        public IActionResult Consult()
        {
            var consult = _context.Consult
                .Include(d => d.diagnosis).ToList();

            return View(_context.Consult.ToList());
        }

        // GET: Consult/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consult/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultId,Name,BeginDate,EndDate,DiagnosisId")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Consult));
            }
            return View(consult);
        }
    }
}
