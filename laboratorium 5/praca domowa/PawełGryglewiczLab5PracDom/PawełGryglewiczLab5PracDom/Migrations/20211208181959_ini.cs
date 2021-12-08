using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PawełGryglewiczLab5PracDom.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PlatformsNumber = table.Column<int>(type: "int", nullable: false),
                    YearOfFound = table.Column<int>(type: "int", nullable: false),
                    HasTicketOffice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PowerType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    YearOfProduction = table.Column<int>(type: "int", nullable: false),
                    NumberOfCars = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    Weigth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailwayConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfDepartureId = table.Column<int>(type: "int", nullable: false),
                    TimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    TrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RailwayConnections_Stations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RailwayConnections_Stations_PlaceOfDepartureId",
                        column: x => x.PlaceOfDepartureId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RailwayConnections_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RailwayConnectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_RailwayConnections_RailwayConnectionId",
                        column: x => x.RailwayConnectionId,
                        principalTable: "RailwayConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_RailwayConnectionId",
                table: "Passengers",
                column: "RailwayConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayConnections_DestinationId",
                table: "RailwayConnections",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayConnections_PlaceOfDepartureId",
                table: "RailwayConnections",
                column: "PlaceOfDepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayConnections_TrainId",
                table: "RailwayConnections",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RailwayConnections");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
