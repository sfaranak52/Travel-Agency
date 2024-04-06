using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelagency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CancelationType",
                schema: "TravelAgency",
                table: "Trip",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartTime",
                schema: "TravelAgency",
                table: "Trip",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "TravelAgency",
                table: "Trip",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                schema: "TravelAgency",
                table: "Trip",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                schema: "TravelAgency",
                table: "Trip",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "IsCancelType",
                schema: "TravelAgency",
                table: "Trip",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                schema: "TravelAgency",
                table: "Trip",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                schema: "TravelAgency",
                table: "Trip",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_InvoiceId",
                schema: "TravelAgency",
                table: "Trip",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Invoice_InvoiceId",
                schema: "TravelAgency",
                table: "Trip",
                column: "InvoiceId",
                principalSchema: "TravelAgency",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Invoice_InvoiceId",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_InvoiceId",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "CancelationType",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DepartTime",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Destination",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "IsCancelType",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Source",
                schema: "TravelAgency",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "TripType",
                schema: "TravelAgency",
                table: "Trip");
        }
    }
}
