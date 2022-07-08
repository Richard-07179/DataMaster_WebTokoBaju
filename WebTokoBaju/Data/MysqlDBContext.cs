using Microsoft.EntityFrameworkCore;

namespace WebTokoBaju.Data
{
    public class MysqlDBContext : DbContext
    {
        public MysqlDBContext(DbContextOptions<MysqlDBContext> options) : base(options)
        {

        }

        public DbSet<Baju> Bajus { get; set; }
        public DbSet<Merk> Merks { get; set; }
        public DbSet<JenisBaju> JenisBajus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map entities to tables  
            modelBuilder.Entity<Merk>().ToTable("merk");
            modelBuilder.Entity<Baju>().ToTable("baju");
            modelBuilder.Entity<JenisBaju>().ToTable("jenis_baju");


            // Configure Primary Keys  
            modelBuilder.Entity<Baju>().HasKey(b => b.IdBaju);
            modelBuilder.Entity<Merk>().HasKey(m => m.IdMerk);
            modelBuilder.Entity<JenisBaju>().HasKey(jb => jb.IdJenisBaju);

            // Configure columns
            modelBuilder.Entity<Merk>().Property(m => m.IdMerk).HasColumnType("int").HasColumnName("id_merk");
            modelBuilder.Entity<Merk>().Property(m => m.NamaMerk).HasColumnType("varchar(100)").HasColumnName("nama_merk");

            modelBuilder.Entity<JenisBaju>().Property(jb => jb.IdJenisBaju).HasColumnType("int").HasColumnName("id_jenis_baju");
            modelBuilder.Entity<JenisBaju>().Property(jb => jb.NamaJenisBaju).HasColumnType("varchar(100)").HasColumnName("nama_jenis_baju");

            modelBuilder.Entity<Baju>().Property(b => b.IdBaju).HasColumnType("int").HasColumnName("id_baju");
            modelBuilder.Entity<Baju>().Property(b => b.NamaBaju).HasColumnType("varchar(100)").HasColumnName("nama_baju");
            modelBuilder.Entity<Baju>().Property(b => b.Harga).HasColumnType("double").HasColumnName("harga");
            modelBuilder.Entity<Baju>().Property(b => b.PathGambarBaju).IsRequired(false).HasColumnType("varchar(1000)").HasColumnName("path_gambar_baju");
        }
    }
}
