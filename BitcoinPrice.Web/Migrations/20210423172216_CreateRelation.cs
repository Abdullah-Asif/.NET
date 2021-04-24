using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoinPrice.Web.Migrations
{
    public partial class CreateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_EUR_EURId",
                table: "Bpi");

            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_GBP_GBPId",
                table: "Bpi");

            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_USD_USDId",
                table: "Bpi");

            migrationBuilder.AlterColumn<Guid>(
                name: "USDId",
                table: "Bpi",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GBPId",
                table: "Bpi",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EURId",
                table: "Bpi",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_EUR_EURId",
                table: "Bpi",
                column: "EURId",
                principalTable: "EUR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_GBP_GBPId",
                table: "Bpi",
                column: "GBPId",
                principalTable: "GBP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_USD_USDId",
                table: "Bpi",
                column: "USDId",
                principalTable: "USD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_EUR_EURId",
                table: "Bpi");

            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_GBP_GBPId",
                table: "Bpi");

            migrationBuilder.DropForeignKey(
                name: "FK_Bpi_USD_USDId",
                table: "Bpi");

            migrationBuilder.AlterColumn<Guid>(
                name: "USDId",
                table: "Bpi",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "GBPId",
                table: "Bpi",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EURId",
                table: "Bpi",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_EUR_EURId",
                table: "Bpi",
                column: "EURId",
                principalTable: "EUR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_GBP_GBPId",
                table: "Bpi",
                column: "GBPId",
                principalTable: "GBP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bpi_USD_USDId",
                table: "Bpi",
                column: "USDId",
                principalTable: "USD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
