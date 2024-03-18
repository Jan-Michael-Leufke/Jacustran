using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Rating", "TownId" },
                values: new object[] { new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colorful and with antique wooden structures ", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinkakuji Temple", 0, new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}
