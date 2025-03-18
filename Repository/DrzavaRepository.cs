using ImenikApp.Models;
using Microsoft.EntityFrameworkCore;
using ImenikApp.Data;

namespace ImenikApp.Repositories {
    public class DrzavaRepository : IDrzavaRepository {
        private readonly ApplicationDbContext _context;

        public DrzavaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Drzava>> GetAllDrzaveAsync() {
            return await _context.Drzave.ToListAsync();
        }

        public async Task<Drzava?> GetDrzavaByIdAsync(int id)  {
            return await _context.Drzave.FirstOrDefaultAsync(d => d.DrzavaId == id);
        }

        public async Task AddDrzavaAsync(Drzava drzava) {
            await _context.Drzave.AddAsync(drzava);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDrzavaAsync(Drzava drzava) {
            _context.Drzave.Update(drzava);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDrzavaAsync(int id) {
            var drzava = await _context.Drzave.FirstOrDefaultAsync(d => d.DrzavaId == id);
            if (drzava != null)
            {
                _context.Drzave.Remove(drzava);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Grad>> GetGradoviByDrzava(int DrzavaId) {
        
             return await _context.Gradovi
                .Where(grad => grad.DrzavaId == DrzavaId)
                .ToListAsync();
        }

    }
}
