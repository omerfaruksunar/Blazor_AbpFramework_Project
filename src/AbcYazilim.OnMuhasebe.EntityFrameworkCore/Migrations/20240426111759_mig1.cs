using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbcYazilim.OnMuhasebe.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BankaToplam",
                table: "AppMakbuzlar",
                type: "Money",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "BankaToplam",
                table: "AppMakbuzlar",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
