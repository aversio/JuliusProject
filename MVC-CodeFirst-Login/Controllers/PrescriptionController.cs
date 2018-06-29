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
    public class PrescriptionController : Controller
    {
        private OurDbContext _context;
        public PrescriptionController(OurDbContext context) {
            _context = context;
        }

        //public IActionResult Prescription() {
        //    return View(_context.Prescriptions.ToList());
        //}

        public IActionResult Prescription() {
            var prescription = _context.Prescription
                .Include(pa => pa.patient)
                .Include(mn => mn.medication)
                .Include(gp => gp.generalPractioner).ToList();
                

            return View(prescription);
        }

        // GET: Diagnosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diagnosis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriscriptionId,Quantity,MedicationId,PatientId,UserId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Prescription));
            }
            return View(prescription);
        } 

    }
}
