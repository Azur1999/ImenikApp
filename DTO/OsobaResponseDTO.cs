using System.ComponentModel.DataAnnotations;
using ImenikApp.Models;

namespace ImenikApp.DTO {
    public class OsobaResponseDTO {
        public int OsobaId { get; set; }
        [StringLength(50)]
        public required string Ime { get; set; }
        [StringLength(50)]
        public required string Prezime { get; set; }
        [RegularExpression(@"^\d{3}/\d{3}-\d{3}$")]
        public required string BrojTelefona { get; set; }
        public required  PolEnum Pol { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        //public required int GradId { get; set; }
        public string? NazivGrad { get; set; } 
        // public required int DrzavaId { get; set; }
        public string? NazivDrzava { get; set; } 
        public required DateOnly DatumRodjenja { get; set; }
        public int? Starost {get; set;} 
    // nazDrz i nazGrad je nullable jer kada frontend salje post ili put ovi nazivi nisu relevantni
    // objekti OsobaDTO mogu postojati i bez ovih naziva
    // sa frontenda nam se salju id grada i drzave na osnovu odabranog iz dropdown
    }
}
