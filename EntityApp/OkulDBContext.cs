using EntityApp;
using Microsoft.EntityFrameworkCore;

namespace DersAnaProje
{
    public class OkulDBContext: DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DEDUSTTER4151;Initial Catalog= OkulDbEF;Integrated Security = True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o=>o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).IsRequired();
        }
    }
}


//Fluent Api