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
    public class DiagnosisController : Controller
    {
        private OurDbContext _context;
        public DiagnosisController(OurDbContext context) {
            _context = context;
        }

        public IActionResult Diagnosis()
        {
            var diagnosis = _context.Diagnosis
                .Include(pa => pa.patient)
                .Include(gp => gp.generalPractioner).ToList();

            return View(diagnosis);
        }

        // GET: Diagnosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diagnosis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiagnosisId,ConsultId,DSId,HypotheseId,Name,PatientId,UserId")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Diagnosis));
            }
            return View(diagnosis);
        }
    }
}
