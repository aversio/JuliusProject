using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class DiagnosisStatus
    {
        [Key]
        public int DSId { get; set; }

        public string Name { get; set; }
    }
}
