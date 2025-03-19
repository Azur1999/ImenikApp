using ImenikApp.Models;

namespace ImenikApp.DTO {

    // kada nam dodje http post zahtjev moramo mu vratiti id novog objekta i starost 
    public class OsobaPostResponseDTO {
        public int? OsobaId { get; set; }
        public int? Starost {get; set;} 
    }
}