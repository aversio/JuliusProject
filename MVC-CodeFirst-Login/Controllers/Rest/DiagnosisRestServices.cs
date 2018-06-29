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
    [Route("api/diagnosis")]
    public class DiagnosisRestService : Controller
    {

        private OurDbContext _context;

        public DiagnosisRestService(OurDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public void AddDiagnosis([FromBody] Diagnosis diagnosis)
        {
            _context.Add(diagnosis);
        }

        [HttpGet("{id}")]
        public IQueryable<Diagnosis> GetDiagnosis(string id)
        {
            int Pid = Convert.ToInt32(id);
            var diagnosis = from d in _context.Diagnosis
                          where d.DiagnosisId == Pid
                          select d;
            return diagnosis;
        }

        [HttpGet("all")]
        public IEnumerable<Diagnosis> GetAllGP()
        {
            return _context.Diagnosis.ToList();
        }

    }
}