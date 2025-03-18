using ImenikApp.Models;

namespace ImenikApp.DTO {
    public class OsobaDTO {
        public int? OsobaId { get; set; }
        public required string Ime { get; set; }
        public required string Prezime { get; set; }
        public required string BrojTelefona { get; set; }
        public required  PolEnum Pol { get; set; }
        public required  string Email { get; set; }
        public required int GradId { get; set; }
        public string? NazivGrad { get; set; } 
        public required int DrzavaId { get; set; }
        public string? NazivDrzava { get; set; } 
        public required DateTime DatumRodjenja { get; set; }
        public int? Starost {get; set;} 

    }
}
