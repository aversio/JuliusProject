using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Diagnosis
    {
        //d
        [Key]
        public int DiagnosisId { get; set; }

        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public int DSId { get; set; }

        public int HypotheseId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient patient { get; set; }

        [ForeignKey("GeneralPractioner")]
        public int UserId { get; set; }
        public GeneralPractioner generalPractioner { get; set; }
    }
}
