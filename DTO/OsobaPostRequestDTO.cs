using System.ComponentModel.DataAnnotations;
using ImenikApp.Models;

namespace ImenikApp.DTO{
    public class OsobaPostRequestDTO {
         //public int OsobaId { get; set; }
        [StringLength(50)]
        public required string Ime { get; set; }
        [StringLength(50)]
        public required string Prezime { get; set; }
        [RegularExpression(@"^\d{3}/\d{3}-\d{3}$")]
        public required string BrojTelefona { get; set; }
        public required  PolEnum Pol { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required int GradId {get; set;}
        public required int DrzavaId {get; set;}
        
        public required DateOnly DatumRodjenja { get; set; }
    }

}