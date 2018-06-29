using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Hypothesis
    {
        [Key]
        public int HypothesisId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }
    }
}
