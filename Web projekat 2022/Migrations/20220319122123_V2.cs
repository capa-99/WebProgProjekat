using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_backend.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PozoristeID",
                table: "Izvedba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_PozoristeID",
                table: "Izvedba",
                column: "PozoristeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvedba_Pozoriste_PozoristeID",
                table: "Izvedba",
                column: "PozoristeID",
                principalTable: "Pozoriste",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvedba_Pozoriste_PozoristeID",
                table: "Izvedba");

            migrationBuilder.DropIndex(
                name: "IX_Izvedba_PozoristeID",
                table: "Izvedba");

            migrationBuilder.DropColumn(
                name: "PozoristeID",
                table: "Izvedba");
        }
    }
}
