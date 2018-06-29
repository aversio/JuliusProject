using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models; 

namespace MVC_CodeFirst_Login.Controllers {
    [Produces("application/json")]
    [Route("api/practioner")]
    public class GPRestService : Controller {

        private OurDbContext _context;
     
        public GPRestService(OurDbContext context) {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public void AddGeneralPractioner([FromBody] GeneralPractioner generalPractioner) {
            _context.Add(generalPractioner);                   
        }

        [HttpGet("{id}")]
        public IQueryable<GeneralPractioner> GetGeneralPractioner(string id)
        {
            int Pid = Convert.ToInt32(id);
            var generalPractioner = from gp in _context.GeneralPractioner
                          where gp.UserId == Pid
                          select gp;
            return generalPractioner;
        }

        [HttpGet("all")]
        public IEnumerable<GeneralPractioner> GetAllGP() {
            return _context.GeneralPractioner.ToList();
        }
    }
}