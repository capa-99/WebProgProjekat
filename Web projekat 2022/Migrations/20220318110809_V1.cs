using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozoriste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozoriste", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    PozID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sala_Pozoriste_PozID",
                        column: x => x.PozID,
                        principalTable: "Pozoriste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ogranicenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozID = table.Column<int>(type: "int", nullable: true),
                    Izvedba = table.Column<int>(type: "int", nullable: true),
                    SelectedInd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Predstava_Pozoriste_PozID",
                        column: x => x.PozID,
                        principalTable: "Pozoriste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Izvedba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vreme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Karte = table.Column<int>(type: "int", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvedba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Izvedba_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvedba_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_PredstavaID",
                table: "Izvedba",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_SalaID",
                table: "Izvedba",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_Izvedba",
                table: "Predstava",
                column: "Izvedba");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_PozID",
                table: "Predstava",
                column: "PozID");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_PozID",
                table: "Sala",
                column: "PozID");

            migrationBuilder.AddForeignKey(
                name: "FK_Predstava_Izvedba_Izvedba",
                table: "Predstava",
                column: "Izvedba",
                principalTable: "Izvedba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvedba_Predstava_PredstavaID",
                table: "Izvedba");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Izvedba");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Pozoriste");
        }
    }
}
