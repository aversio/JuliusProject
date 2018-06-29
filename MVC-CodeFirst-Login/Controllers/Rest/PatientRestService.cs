using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models;

namespace MVC_CodeFirst_Login.Controllers
{
    [Produces("application/json")]
    [Route("api/patient")]
    public class PatientRestService : Controller
    {

        private OurDbContext _context;

        public PatientRestService(OurDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public void AddPatient([FromBody] GeneralPractioner patient)
        {
            _context.Add(patient);
        }

        [HttpGet("{id}")]
        public IQueryable<Patient> GetPatient(string id)
        {
            int Pid = Convert.ToInt32(id);
            var patient = from p in _context.Patient
                          where p.PatientId == Pid
                          select p;
            return patient;
        }

        [HttpGet("all")]
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patient.ToList();
        }

    }
}