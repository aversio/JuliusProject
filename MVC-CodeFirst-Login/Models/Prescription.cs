using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient patient { get; set; }

        [ForeignKey("GeneralPractioner")]
        public int UserId { get; set; }
        public GeneralPractioner generalPractioner { get; set; }

        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public Medication medication { get; set; }


    }
}
