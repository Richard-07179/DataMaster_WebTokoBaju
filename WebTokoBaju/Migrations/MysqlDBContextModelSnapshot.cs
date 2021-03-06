// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTokoBaju.Data;

#nullable disable

namespace WebTokoBaju.Migrations
{
    [DbContext(typeof(MysqlDBContext))]
    partial class MysqlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebTokoBaju.Data.Baju", b =>
                {
                    b.Property<int>("IdBaju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_baju");

                    b.Property<double>("Harga")
                        .HasColumnType("double")
                        .HasColumnName("harga");

                    b.Property<string>("NamaBaju")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama_baju");

                    b.Property<int>("id_jenis_baju")
                        .HasColumnType("int");

                    b.Property<int>("id_merk")
                        .HasColumnType("int");

                    b.HasKey("IdBaju");

                    b.HasIndex("id_jenis_baju");

                    b.HasIndex("id_merk");

                    b.ToTable("baju", (string)null);
                });

            modelBuilder.Entity("WebTokoBaju.Data.JenisBaju", b =>
                {
                    b.Property<int>("IdJenisBaju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_jenis_baju");

                    b.Property<string>("NamaJenisBaju")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama_jenis_baju");

                    b.HasKey("IdJenisBaju");

                    b.ToTable("jenis_baju", (string)null);
                });

            modelBuilder.Entity("WebTokoBaju.Data.Merk", b =>
                {
                    b.Property<int>("IdMerk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_merk");

                    b.Property<string>("NamaMerk")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama_merk");

                    b.HasKey("IdMerk");

                    b.ToTable("merk", (string)null);
                });

            modelBuilder.Entity("WebTokoBaju.Data.Baju", b =>
                {
                    b.HasOne("WebTokoBaju.Data.JenisBaju", "MyJenisBaju")
                        .WithMany("Bajus")
                        .HasForeignKey("id_jenis_baju")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebTokoBaju.Data.Merk", "MyMerk")
                        .WithMany("Bajus")
                        .HasForeignKey("id_merk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyJenisBaju");

                    b.Navigation("MyMerk");
                });

            modelBuilder.Entity("WebTokoBaju.Data.JenisBaju", b =>
                {
                    b.Navigation("Bajus");
                });

            modelBuilder.Entity("WebTokoBaju.Data.Merk", b =>
                {
                    b.Navigation("Bajus");
                });
#pragma warning restore 612, 618
        }
    }
}
