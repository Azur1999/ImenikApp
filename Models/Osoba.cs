using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImenikApp.Models {
    public class Osoba {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OsobaId { get; set; } // ili Guuid
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string BrojTelefona { get; set; }
        public  required PolEnum Pol { get; set; }
        public required  string Email { get; set; }
        public required int GradId { get; set; } 
        public Grad? Grad { get; set; } 
        public  required int  DrzavaId { get; set; } 
        public  Drzava? Drzava { get; set; } 
        public required DateOnly DatumRodjenja { get; set; }
 
    }
}
