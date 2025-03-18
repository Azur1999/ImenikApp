using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImenikApp.Models
{
    public class Osoba
    {
        public int OsobaId { get; set; } // ili Guuid

        [Required]
        [StringLength(50)]
        public required string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public required string Prezime { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}/\d{3}-\d{3}$", ErrorMessage = "Broj telefona nije u ispravnom formatu.")]
        public required string BrojTelefona { get; set; }

        [Required]
        public  PolEnum Pol { get; set; }

        [Required]
        [EmailAddress]
        public required  string Email { get; set; }

        [Required]
        public required int GradId { get; set; } 
        public required  Grad Grad { get; set; } 

        [Required]
        public  int DrzavaId { get; set; } 
        public  required Drzava Drzava { get; set; } 

        [Required]
        public required DateTime DatumRodjenja { get; set; }
 
    }
}
