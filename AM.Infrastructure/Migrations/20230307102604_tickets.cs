using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    FlightFk = table.Column<int>(type: "int", nullable: false),
                    PassengerFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Siege = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.FlightFk, x.PassengerFk });
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerFk",
                table: "Tickets",
                column: "PassengerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPassportNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => new { x.FlightsFlightId, x.PassengersPassportNumber });
                    table.ForeignKey(
                        name: "FK_reservations_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Passengers_PassengersPassportNumber",
                        column: x => x.PassengersPassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_PassengersPassportNumber",
                table: "reservations",
                column: "PassengersPassportNumber");
        }
    }
}
