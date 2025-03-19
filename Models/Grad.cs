namespace ImenikApp.Models {
    public class Grad {
        public int GradId { get; set; } 
        public required string NazivGrad { get; init; }
        public required int DrzavaId { get; set; }
        public Drzava? Drzava { get; set; }
    }
}
