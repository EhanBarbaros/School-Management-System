using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityApp.Migrations
{
    /// <inheritdoc />
    public partial class DersTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dersad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Derskod = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.Dersid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDersler");
        }
    }
}
