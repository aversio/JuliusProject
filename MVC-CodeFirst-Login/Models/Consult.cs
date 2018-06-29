using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Consult
    {
        [Key]
        public int ConsultId { get; set; }

        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("Diagnosis")]
        public int DiagnosisId { get; set; }
        public Diagnosis diagnosis { get; set; }
    }
}
