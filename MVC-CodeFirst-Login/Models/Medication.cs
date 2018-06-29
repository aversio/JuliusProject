using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
