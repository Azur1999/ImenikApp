using Microsoft.EntityFrameworkCore;
using ImenikApp.Models;

namespace ImenikApp.Data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Drzava> Drzave { get; set; }
    public DbSet<Grad> Gradovi { get; set; }
    public DbSet<Osoba> Osobe { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Drzava>(entity =>
        {
            entity.ToTable("Drzava");

            entity.HasKey(d => d.DrzavaId);

            entity.Property(d => d.NazivDrzava)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(d => d.Gradovi)
                .WithOne(g => g.Drzava)
                .HasForeignKey(g => g.DrzavaId);

            entity.HasData(
                new { DrzavaId = 1, NazivDrzava = "Bosna i Hercegovina" },
                new { DrzavaId = 2, NazivDrzava = "Hrvatska" },
                new { DrzavaId = 3, NazivDrzava = "Srbija" },
                new { DrzavaId = 4, NazivDrzava = "Spanija" },
                new { DrzavaId = 5, NazivDrzava = "Njemacka" }
            
        
            );
        });

        
        modelBuilder.Entity<Grad>(entity =>
        {
            entity.ToTable("Grad");

            entity.HasKey(g => g.GradId);

            entity.Property(g => g.NazivGrad)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(g => g.DrzavaId)
                .IsRequired();
            

            entity.HasOne(g => g.Drzava)
                .WithMany(d => d.Gradovi)
                .HasForeignKey(g => g.DrzavaId)
                .OnDelete(DeleteBehavior.Restrict); 

            entity.HasData(
                new { GradId = 1, NazivGrad = "Sarajevo", DrzavaId = 1 },
                new { GradId = 2, NazivGrad = "Tuzla", DrzavaId = 1 },
                new { GradId = 3, NazivGrad = "Banja Luka", DrzavaId = 1 },
                new { GradId = 4, NazivGrad = "Mostar", DrzavaId = 1 },
                new { GradId = 5, NazivGrad = "Sarajevo", DrzavaId = 1 },
                new { GradId = 6, NazivGrad = "Zagreb", DrzavaId = 2 },
                new { GradId = 7, NazivGrad = "Split", DrzavaId = 2 },
                new { GradId = 8, NazivGrad = "Rijeka", DrzavaId = 2 },
                new { GradId = 9, NazivGrad = "Beograd", DrzavaId = 3 },
                new { GradId = 10, NazivGrad = "Nis", DrzavaId = 3 },
                new { GradId = 11, NazivGrad = "Novi Sad", DrzavaId = 3 },
                new { GradId = 12, NazivGrad = "Madrid", DrzavaId = 4 },
                new { GradId = 13, NazivGrad = "Barcelona", DrzavaId = 4 },
                new { GradId = 14, NazivGrad = "Minhen", DrzavaId = 5 },
                new { GradId = 15, NazivGrad = "Berlin", DrzavaId = 5 },
                new { GradId = 16, NazivGrad = "Frankfurt", DrzavaId = 5 }
            );
        });    
        
    }
}

}
