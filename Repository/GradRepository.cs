using ImenikApp.Models;
using Microsoft.EntityFrameworkCore;
using ImenikApp.Data;

namespace ImenikApp.Repositories
{
    public class GradRepository : IGradRepository
    {
        private readonly ApplicationDbContext _context;

        public GradRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grad>> GetAllGradAsync()
        {
            return await _context.Gradovi.ToListAsync();
        }

        // Dohvatanje grada po ID-u
        public async Task<Grad?> GetGradByIdAsync(int id)
        {
            return await _context.Gradovi.FirstOrDefaultAsync(g => g.GradId == id);
        }

        // Dodavanje novog grada
        public async Task AddGradAsync(Grad grad)
        {
            await _context.Gradovi.AddAsync(grad);
            await _context.SaveChangesAsync();
        }

        // Ažuriranje postojećeg grada
        public async Task UpdateGradAsync(Grad grad)
        {
            _context.Gradovi.Update(grad);
            await _context.SaveChangesAsync();
        }

        // Brisanje grada po ID-u
        public async Task DeleteGradAsync(int id)
        {
            var grad = await _context.Gradovi.FirstOrDefaultAsync(g => g.GradId == id);
            if (grad != null)
            {
                _context.Gradovi.Remove(grad);
                await _context.SaveChangesAsync();
            }
        }

        // Dohvatanje grada po imenu
        public async Task<Grad?> GetGradByNameAsync(string naziv)
        {
            return await _context.Gradovi.FirstOrDefaultAsync(g => g.NazivGrad.Equals(naziv, StringComparison.OrdinalIgnoreCase));
        }
    }
}
