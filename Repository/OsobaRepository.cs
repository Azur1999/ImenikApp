using ImenikApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImenikApp.Data;

namespace ImenikApp.Repository
{
    public class OsobaRepository : IOsobaRepository
    {
        private readonly ApplicationDbContext _context;

        public OsobaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Osoba>> GetAllOsobeAsync()
        {
            return await _context.Osobe
            .Include(o => o.Grad)    // Uključujemo pocvezan entitet Grad
            .Include(o => o.Drzava)  
            .ToListAsync(); 
        }

        public async Task<Osoba?> GetOsobaByIdAsync(int id)
        {
            return await _context.Osobe.FindAsync(id);
        }

        public async Task AddOsobaAsync(Osoba osoba)
        {
            await _context.Osobe.AddAsync(osoba);
            await _context.SaveChangesAsync();
        }

        

        public async Task UpdateOsobaAsync(Osoba osoba)
        {
            _context.Osobe.Update(osoba);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOsobaAsync(int id)
        {
            var osoba = await _context.Osobe.FindAsync(id);
            if (osoba != null)
            {
                _context.Osobe.Remove(osoba);
                await _context.SaveChangesAsync();
            }
        }
    }
}
