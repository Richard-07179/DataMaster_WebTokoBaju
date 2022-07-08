using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTokoBaju.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "jenis_baju",
                columns: table => new
                {
                    id_jenis_baju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_jenis_baju = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jenis_baju", x => x.id_jenis_baju);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "merk",
                columns: table => new
                {
                    id_merk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_merk = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merk", x => x.id_merk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "baju",
                columns: table => new
                {
                    id_baju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_baju = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    harga = table.Column<double>(type: "double", nullable: false),
                    id_merk = table.Column<int>(type: "int", nullable: false),
                    id_jenis_baju = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baju", x => x.id_baju);
                    table.ForeignKey(
                        name: "FK_baju_jenis_baju_id_jenis_baju",
                        column: x => x.id_jenis_baju,
                        principalTable: "jenis_baju",
                        principalColumn: "id_jenis_baju",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_baju_merk_id_merk",
                        column: x => x.id_merk,
                        principalTable: "merk",
                        principalColumn: "id_merk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_baju_id_jenis_baju",
                table: "baju",
                column: "id_jenis_baju");

            migrationBuilder.CreateIndex(
                name: "IX_baju_id_merk",
                table: "baju",
                column: "id_merk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baju");

            migrationBuilder.DropTable(
                name: "jenis_baju");

            migrationBuilder.DropTable(
                name: "merk");
        }
    }
}
