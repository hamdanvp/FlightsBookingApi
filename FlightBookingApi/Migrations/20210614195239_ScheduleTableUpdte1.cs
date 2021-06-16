using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBookingAPI.Migrations
{
    public partial class ScheduleTableUpdte1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstrumentUsed",
                table: "AirlineSchedules");

            migrationBuilder.RenameColumn(
                name: "SheduleDate",
                table: "AirlineSchedules",
                newName: "DepartureDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "AirlineSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "AirlineSchedules");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "AirlineSchedules",
                newName: "SheduleDate");

            migrationBuilder.AddColumn<string>(
                name: "InstrumentUsed",
                table: "AirlineSchedules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
