using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nullabilityChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Town",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Town",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Spots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Spots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"),
                column: "Rating",
                value: "FiveStars");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "FourStars");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Colorful and with antique wooden structures", "ThreeStars" });

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "TwoStars");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Rating",
                value: "FourStars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Town",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Town",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Spots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Spots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                column: "Rating",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                columns: new[] { "Description", "Rating" },
                values: new object[] { "Colorful and with antique wooden structures ", "None" });

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
    }
}
