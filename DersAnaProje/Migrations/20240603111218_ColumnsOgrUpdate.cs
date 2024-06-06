using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersAnaProje.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsOgrUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ogrenciler",
                table: "Ogrenciler");

            migrationBuilder.RenameTable(
                name: "Ogrenciler",
                newName: "tblOgrenciler");

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "tblOgrenciler",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "tblOgrenciler",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler",
                column: "Ogrenciid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler");

            migrationBuilder.RenameTable(
                name: "tblOgrenciler",
                newName: "Ogrenciler");

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ogrenciler",
                table: "Ogrenciler",
                column: "Ogrenciid");
        }
    }
}
