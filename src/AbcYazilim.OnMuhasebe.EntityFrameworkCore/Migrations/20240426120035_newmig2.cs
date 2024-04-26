using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbcYazilim.OnMuhasebe.Migrations
{
    /// <inheritdoc />
    public partial class newmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MakbuzHareket_AppBankaHesaplar_BankaHesapId",
                table: "MakbuzHareket");

            migrationBuilder.DropForeignKey(
                name: "FK_MakbuzHareket_AppBankaSubeler_CekBankaSubeId",
                table: "MakbuzHareket");

            migrationBuilder.DropForeignKey(
                name: "FK_MakbuzHareket_AppBankalar_CekBankaId",
                table: "MakbuzHareket");

            migrationBuilder.DropForeignKey(
                name: "FK_MakbuzHareket_AppKasalar_KasaId",
                table: "MakbuzHareket");

            migrationBuilder.DropForeignKey(
                name: "FK_MakbuzHareket_AppMakbuzlar_MakbuzId",
                table: "MakbuzHareket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MakbuzHareket",
                table: "MakbuzHareket");

            migrationBuilder.RenameTable(
                name: "MakbuzHareket",
                newName: "AppMakbuzHareketler");

            migrationBuilder.RenameIndex(
                name: "IX_MakbuzHareket_MakbuzId",
                table: "AppMakbuzHareketler",
                newName: "IX_AppMakbuzHareketler_MakbuzId");

            migrationBuilder.RenameIndex(
                name: "IX_MakbuzHareket_KasaId",
                table: "AppMakbuzHareketler",
                newName: "IX_AppMakbuzHareketler_KasaId");

            migrationBuilder.RenameIndex(
                name: "IX_MakbuzHareket_CekBankaSubeId",
                table: "AppMakbuzHareketler",
                newName: "IX_AppMakbuzHareketler_CekBankaSubeId");

            migrationBuilder.RenameIndex(
                name: "IX_MakbuzHareket_CekBankaId",
                table: "AppMakbuzHareketler",
                newName: "IX_AppMakbuzHareketler_CekBankaId");

            migrationBuilder.RenameIndex(
                name: "IX_MakbuzHareket_BankaHesapId",
                table: "AppMakbuzHareketler",
                newName: "IX_AppMakbuzHareketler_BankaHesapId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Vade",
                table: "AppMakbuzHareketler",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tutar",
                table: "AppMakbuzHareketler",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TakipNo",
                table: "AppMakbuzHareketler",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "OdemeTuru",
                table: "AppMakbuzHareketler",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "MakbuzId",
                table: "AppMakbuzHareketler",
                type: "UniqueIdentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "KendiBelgemiz",
                table: "AppMakbuzHareketler",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "KasaId",
                table: "AppMakbuzHareketler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ciranta",
                table: "AppMakbuzHareketler",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CekHesapNo",
                table: "AppMakbuzHareketler",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CekBankaSubeId",
                table: "AppMakbuzHareketler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CekBankaId",
                table: "AppMakbuzHareketler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BelgeNo",
                table: "AppMakbuzHareketler",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "BelgeDurumu",
                table: "AppMakbuzHareketler",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "BankaHesapId",
                table: "AppMakbuzHareketler",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AsilBorclu",
                table: "AppMakbuzHareketler",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "AppMakbuzHareketler",
                type: "VarChar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMakbuzHareketler",
                table: "AppMakbuzHareketler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppMakbuzHareketler_TakipNo",
                table: "AppMakbuzHareketler",
                column: "TakipNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankaHesaplar_BankaHesapId",
                table: "AppMakbuzHareketler",
                column: "BankaHesapId",
                principalTable: "AppBankaHesaplar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankaSubeler_CekBankaSubeId",
                table: "AppMakbuzHareketler",
                column: "CekBankaSubeId",
                principalTable: "AppBankaSubeler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankalar_CekBankaId",
                table: "AppMakbuzHareketler",
                column: "CekBankaId",
                principalTable: "AppBankalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMakbuzHareketler_AppKasalar_KasaId",
                table: "AppMakbuzHareketler",
                column: "KasaId",
                principalTable: "AppKasalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMakbuzHareketler_AppMakbuzlar_MakbuzId",
                table: "AppMakbuzHareketler",
                column: "MakbuzId",
                principalTable: "AppMakbuzlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankaHesaplar_BankaHesapId",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankaSubeler_CekBankaSubeId",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMakbuzHareketler_AppBankalar_CekBankaId",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMakbuzHareketler_AppKasalar_KasaId",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMakbuzHareketler_AppMakbuzlar_MakbuzId",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMakbuzHareketler",
                table: "AppMakbuzHareketler");

            migrationBuilder.DropIndex(
                name: "IX_AppMakbuzHareketler_TakipNo",
                table: "AppMakbuzHareketler");

            migrationBuilder.RenameTable(
                name: "AppMakbuzHareketler",
                newName: "MakbuzHareket");

            migrationBuilder.RenameIndex(
                name: "IX_AppMakbuzHareketler_MakbuzId",
                table: "MakbuzHareket",
                newName: "IX_MakbuzHareket_MakbuzId");

            migrationBuilder.RenameIndex(
                name: "IX_AppMakbuzHareketler_KasaId",
                table: "MakbuzHareket",
                newName: "IX_MakbuzHareket_KasaId");

            migrationBuilder.RenameIndex(
                name: "IX_AppMakbuzHareketler_CekBankaSubeId",
                table: "MakbuzHareket",
                newName: "IX_MakbuzHareket_CekBankaSubeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppMakbuzHareketler_CekBankaId",
                table: "MakbuzHareket",
                newName: "IX_MakbuzHareket_CekBankaId");

            migrationBuilder.RenameIndex(
                name: "IX_AppMakbuzHareketler_BankaHesapId",
                table: "MakbuzHareket",
                newName: "IX_MakbuzHareket_BankaHesapId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Vade",
                table: "MakbuzHareket",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tutar",
                table: "MakbuzHareket",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<string>(
                name: "TakipNo",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "OdemeTuru",
                table: "MakbuzHareket",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<Guid>(
                name: "MakbuzId",
                table: "MakbuzHareket",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "KendiBelgemiz",
                table: "MakbuzHareket",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "KasaId",
                table: "MakbuzHareket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ciranta",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CekHesapNo",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "CekBankaSubeId",
                table: "MakbuzHareket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CekBankaId",
                table: "MakbuzHareket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BelgeNo",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "BelgeDurumu",
                table: "MakbuzHareket",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<Guid>(
                name: "BankaHesapId",
                table: "MakbuzHareket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AsilBorclu",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "MakbuzHareket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MakbuzHareket",
                table: "MakbuzHareket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakbuzHareket_AppBankaHesaplar_BankaHesapId",
                table: "MakbuzHareket",
                column: "BankaHesapId",
                principalTable: "AppBankaHesaplar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakbuzHareket_AppBankaSubeler_CekBankaSubeId",
                table: "MakbuzHareket",
                column: "CekBankaSubeId",
                principalTable: "AppBankaSubeler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakbuzHareket_AppBankalar_CekBankaId",
                table: "MakbuzHareket",
                column: "CekBankaId",
                principalTable: "AppBankalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakbuzHareket_AppKasalar_KasaId",
                table: "MakbuzHareket",
                column: "KasaId",
                principalTable: "AppKasalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MakbuzHareket_AppMakbuzlar_MakbuzId",
                table: "MakbuzHareket",
                column: "MakbuzId",
                principalTable: "AppMakbuzlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
