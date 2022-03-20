using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_backend.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvedba_Pozoriste_PozoristeID",
                table: "Izvedba");

            migrationBuilder.DropForeignKey(
                name: "FK_Predstava_Izvedba_Izvedba",
                table: "Predstava");

            migrationBuilder.DropIndex(
                name: "IX_Predstava_Izvedba",
                table: "Predstava");

            migrationBuilder.DropIndex(
                name: "IX_Izvedba_PozoristeID",
                table: "Izvedba");

            migrationBuilder.DropColumn(
                name: "Izvedba",
                table: "Predstava");

            migrationBuilder.DropColumn(
                name: "SelectedInd",
                table: "Predstava");

            migrationBuilder.DropColumn(
                name: "SelectedIndex",
                table: "Pozoriste");

            migrationBuilder.DropColumn(
                name: "PozoristeID",
                table: "Izvedba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Izvedba",
                table: "Predstava",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedInd",
                table: "Predstava",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedIndex",
                table: "Pozoriste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PozoristeID",
                table: "Izvedba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_Izvedba",
                table: "Predstava",
                column: "Izvedba");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Predstava_Izvedba_Izvedba",
                table: "Predstava",
                column: "Izvedba",
                principalTable: "Izvedba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
