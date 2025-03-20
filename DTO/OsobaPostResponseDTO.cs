using ImenikApp.Models;

namespace ImenikApp.DTO {

    // kada nam dodje http post zahtjev moramo mu vratiti id novog objekta i starost 
    public class OsobaPostResponseDTO {
        public required int OsobaId { get; set; }
        public required int Starost {get; set;} 
        public string? NazivGrad { get; set; } 
        // public required int DrzavaId { get; set; }
        public string? NazivDrzava { get; set; } 

    }
}