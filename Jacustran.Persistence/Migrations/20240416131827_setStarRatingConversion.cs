using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setStarRatingConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Spots",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"),
                column: "Rating",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating" ,
                value: "None");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "None");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Spots",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"),
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: 0);
        }
    }
}
