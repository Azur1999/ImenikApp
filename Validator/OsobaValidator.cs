using FluentValidation;
using ImenikApp.Data;
using ImenikApp.DTO;
using ImenikApp.Models;
using Microsoft.EntityFrameworkCore;
namespace ImenikApp.Validacija {
public class OsobaPostRequestDTOValidator : AbstractValidator<OsobaPostRequestDTO> {
    private readonly ApplicationDbContext _context;

    public OsobaPostRequestDTOValidator(ApplicationDbContext context) {
        _context = context;

        RuleFor(o => o.Email)
            .MustAsync(async (email, cancellation) =>
                !await _context.Osobe.AnyAsync(o => o.Email == email))
            .WithMessage("Email već postoji.");

        RuleFor(o => o.BrojTelefona)
            .MustAsync(async (brojTelefona, cancellation) =>
                !await _context.Osobe.AnyAsync(o => o.BrojTelefona == brojTelefona))
            .WithMessage("Broj telefona već postoji.");
    }
}

}
