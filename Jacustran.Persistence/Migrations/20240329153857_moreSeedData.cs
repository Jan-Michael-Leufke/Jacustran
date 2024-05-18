using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class moreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Discriminator", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Population" },
                values: new object[] { new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ojiro is mostly a mountainous area and prides itself as the homeland of Wagyu cattle.", "Town", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ojiro", 2200 });

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Rating", "TownId" },
                values: new object[] { new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A place to take a relaxing hot bath.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ojiron-Onsen", 0, new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spots",
                keyColumn: "Id",
                keyValue: new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"));

            migrationBuilder.DeleteData(
                table: "Town",
                keyColumn: "Id",
                keyValue: new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4"));
        }
    }
}
