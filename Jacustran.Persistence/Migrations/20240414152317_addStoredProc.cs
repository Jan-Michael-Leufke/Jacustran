using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace Jacustran.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addStoredProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[CitiesWithSpotsRatingLowerThan]
                    @lowerThanRating INT
                AS
                BEGIN
                    SELECT distinct town.* 
                    FROM Town
                    LEFT JOIN Spots ON Spots.TownId = Town.Id
                    WHERE Spots.Rating < @lowerThanRating AND Discriminator = 'City' AND Spots.Rating < @lowerThanRating
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[CitiesWithSpotsRatingLowerThan]");
        }
    }
}
