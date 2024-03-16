using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SpotsDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Town",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Rating", "TownId" },
                values: new object[,]
                {
                    { new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It´s a train station but also much more than that.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Umeda", 0, new Guid("ac338e7a-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Neighbourhood with a certain melancholic feel.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyamazaki", 0, new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ancient Temple with a stunning View over Kyoto.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiyomizu", 0, new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Town",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
