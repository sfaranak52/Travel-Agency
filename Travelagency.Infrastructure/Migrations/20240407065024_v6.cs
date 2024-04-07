using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelagency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayStatus",
                schema: "TravelAgency",
                table: "Pay",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayStatus",
                schema: "TravelAgency",
                table: "Pay");
        }
    }
}
