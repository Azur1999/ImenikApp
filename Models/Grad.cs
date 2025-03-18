namespace ImenikApp.Models {
    public class Grad {
        public int GradId { get; set; } // istraziti private
        public required string NazivGrad { get; init; }
        public int DrzavaId { get; set; }
        public required Drzava Drzava { get; set; }
    }
}
