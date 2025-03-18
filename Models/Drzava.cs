using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImenikApp.Models {
    public class Drzava {
    public int DrzavaId { get; set; }
    public  required string NazivDrzava { get; set; }
    public  ICollection<Grad>? Gradovi { get; set; }
}

}
