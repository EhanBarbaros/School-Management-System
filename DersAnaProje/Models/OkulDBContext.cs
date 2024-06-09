using DersAnaProje.Models.Relationships;
using Microsoft.EntityFrameworkCore;

namespace DersAnaProje.Models
{
    public class OkulDBContext : DbContext
    {
        public OkulDBContext(DbContextOptions<OkulDBContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).IsRequired();

            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(d => d.DersAd).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.Kredi).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.DersKodu).HasColumnType("varchar").HasMaxLength(10).IsRequired();


            modelBuilder.Entity<OgrenciDers>().ToTable("tblOgrenciDersler");
            modelBuilder.Entity<OgrenciDers>().HasKey(od => new { od.Ogrenciid, od.Dersid });
            modelBuilder.Entity<OgrenciDers>().HasOne(od => od.Ogrenci).WithMany(o => o.OgrenciDersler).HasForeignKey(od => od.Ogrenciid);
            modelBuilder.Entity<OgrenciDers>().HasOne(od => od.Ders).WithMany(d => d.OgrenciDersler).HasForeignKey(od => od.Dersid);
        }


    }
}
