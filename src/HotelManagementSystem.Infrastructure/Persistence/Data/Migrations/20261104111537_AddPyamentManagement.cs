using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPyamentManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "ServiceUsages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsages_ReservationId1",
                table: "ServiceUsages",
                column: "ReservationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsages_Reservations_ReservationId1",
                table: "ServiceUsages",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsages_Reservations_ReservationId1",
                table: "ServiceUsages");

            migrationBuilder.DropIndex(
                name: "IX_ServiceUsages_ReservationId1",
                table: "ServiceUsages");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "ServiceUsages");
        }
    }
}
