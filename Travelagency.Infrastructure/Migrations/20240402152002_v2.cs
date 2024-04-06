using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelagency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "TravelAgency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "TravelAgency",
                newName: "Customer");
        }
    }
}
