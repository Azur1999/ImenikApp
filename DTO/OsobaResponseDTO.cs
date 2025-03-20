using System.ComponentModel.DataAnnotations;
using ImenikApp.Models;

namespace ImenikApp.DTO {
    public class OsobaResponseDTO {
        public required int OsobaId { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string BrojTelefona { get; set; }
        public required  PolEnum Pol { get; set; }
        public required string Email { get; set; }
        //public required int GradId { get; set; }
        public required string NazivGrad { get; set; } 
        // public required int DrzavaId { get; set; }
        public required  string NazivDrzava { get; set; } 
        public required DateOnly DatumRodjenja { get; set; }
        public required int Starost {get; set;} 

    }
}
