using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Town",
                table: "Town");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Location",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Location",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Location",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TownId",
                table: "Location",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Discriminator", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Rating", "TownId" },
                values: new object[,]
                {
                    { new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A place to take a relaxing hot bath.", "Spot", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ojiron-Onsen", "FiveStars", new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4") },
                    { new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It´s a train station but also much more than that.", "Spot", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Umeda", "FourStars", new Guid("ac338e7a-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colorful and with antique wooden structures", "Spot", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinkakuji Temple", "ThreeStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Neighbourhood with a certain melancholic feel.", "Spot", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyamazaki", "TwoStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ancient Temple with a stunning View over Kyoto.", "Spot", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiyomizu", "FourStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_TownId",
                table: "Location",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Location_TownId",
                table: "Location",
                column: "TownId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Location_TownId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_TownId",
                table: "Location");

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Town");

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Town",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Town",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Town",
                table: "Town",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TownId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spots_Town_TownId",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Spots",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Rating", "TownId" },
                values: new object[,]
                {
                    { new Guid("8374a227-d754-4feb-8acd-c4f9ff13fa34"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A place to take a relaxing hot bath.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ojiron-Onsen", "FiveStars", new Guid("ffd3d609-d754-4feb-8acd-c4f9ff13adf4") },
                    { new Guid("8374adda-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It´s a train station but also much more than that.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Umeda", "FourStars", new Guid("ac338e7a-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9287afff-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colorful and with antique wooden structures", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinkakuji Temple", "ThreeStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("9384adfa-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Neighbourhood with a certain melancholic feel.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oyamazaki", "TwoStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("af871625-d754-4feb-8acd-c4f9ff13ba96"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ancient Temple with a stunning View over Kyoto.", "https://dummyimage.com/600x400/eee/aaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiyomizu", "FourStars", new Guid("af1fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spots_TownId",
                table: "Spots",
                column: "TownId");
        }
    }
}
