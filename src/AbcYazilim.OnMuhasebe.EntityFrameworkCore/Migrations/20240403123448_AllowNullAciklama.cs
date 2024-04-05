using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbcYazilim.OnMuhasebe.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullAciklama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "AppOzelKodlar",
                type: "VarChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "OzelKod2Id",
                table: "AppHizmetler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OzelKod1Id",
                table: "AppHizmetler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "AppOzelKodlar",
                type: "VarChar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OzelKod2Id",
                table: "AppHizmetler",
                type: "UniqueIdentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OzelKod1Id",
                table: "AppHizmetler",
                type: "UniqueIdentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);
        }
    }
}
