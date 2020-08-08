using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealershipRepository.Ef.Migrations
{
    public partial class FixedCarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Cars_ClientId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CarId",
                table: "Contracts",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Cars_CarId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CarId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Cars_ClientId",
                table: "Contracts",
                column: "ClientId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
