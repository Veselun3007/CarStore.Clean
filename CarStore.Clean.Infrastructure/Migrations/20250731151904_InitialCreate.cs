using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Clean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dealers",
                columns: table => new
                {
                    dealer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    contact_email = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealers", x => x.dealer_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    user_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    maker = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    model = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    dealer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_cars_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "dealer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    sale_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sale_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    final_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.sale_id);
                    table.ForeignKey(
                        name: "FK_sales_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dealers",
                columns: new[] { "dealer_id", "contact_email", "name" },
                values: new object[,]
                {
                    { 1, "contact@cityauto.com", "City Auto" },
                    { 2, "sales@bestmotors.com", "Best Motors" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "user_name" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", "john@example.com", "johndoe" },
                    { "00000000-0000-0000-0000-000000000002", "jane@example.com", "janedoe" }
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "car_id", "dealer_id", "maker", "model", "price", "year" },
                values: new object[,]
                {
                    { 1, 1, "Toyota", "Camry", 22000m, 2020 },
                    { 2, 2, "Ford", "Focus", 18000m, 2019 }
                });

            migrationBuilder.InsertData(
                table: "sales",
                columns: new[] { "sale_id", "CarId", "final_price", "sale_date", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 21500m, new DateTime(2025, 1, 10, 17, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000002" },
                    { 2, 2, 17500m, new DateTime(2025, 2, 20, 15, 30, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_dealer_id",
                table: "cars",
                column: "dealer_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_CarId",
                table: "sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_user_id",
                table: "sales",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "dealers");
        }
    }
}
