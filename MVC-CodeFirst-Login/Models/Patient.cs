using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models {
    public class Patient
    {
        [Key]         
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Voer uw voornaam in")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Voer uw achternaam in")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Voer uw email in")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Voer uw gebruikersnaam in")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Voer uw wachtwoord in")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
          
        [Compare("Password", ErrorMessage ="Wachtwoord moet overeenkomen")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }
    }
}
