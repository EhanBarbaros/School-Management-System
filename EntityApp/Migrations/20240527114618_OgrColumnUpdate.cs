using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityApp.Migrations
{
    /// <inheritdoc />
    public partial class OgrColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrenciler",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Numara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciler", x => x.Ogrenciid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciler");
        }
    }
}
