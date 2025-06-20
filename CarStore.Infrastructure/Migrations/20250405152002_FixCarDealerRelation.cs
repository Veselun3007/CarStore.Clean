using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCarDealerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_dealers_car_id",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "car_id",
                table: "cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_cars_dealer_id",
                table: "cars",
                column: "dealer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_dealers_dealer_id",
                table: "cars",
                column: "dealer_id",
                principalTable: "dealers",
                principalColumn: "dealer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_dealers_dealer_id",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_dealer_id",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "car_id",
                table: "cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_dealers_car_id",
                table: "cars",
                column: "car_id",
                principalTable: "dealers",
                principalColumn: "dealer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
