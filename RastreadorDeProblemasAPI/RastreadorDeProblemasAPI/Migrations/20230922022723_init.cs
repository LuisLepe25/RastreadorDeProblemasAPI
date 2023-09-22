using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RastreadorDeProblemasAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProblemaEstatus",
                columns: table => new
                {
                    IdProblemaEstatus = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeveridadColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemaEstatus", x => x.IdProblemaEstatus);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Problema",
                columns: table => new
                {
                    idProblema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdProblemaEstatus = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioAsignado = table.Column<int>(type: "int", nullable: false),
                    IdentificadorAlumno = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problema", x => x.idProblema);
                    table.ForeignKey(
                        name: "FK_Problema_ProblemaEstatus",
                        column: x => x.IdProblemaEstatus,
                        principalTable: "ProblemaEstatus",
                        principalColumn: "IdProblemaEstatus");
                    table.ForeignKey(
                        name: "FK_Problema_Usuario",
                        column: x => x.IdUsuarioAsignado,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problema_IdProblemaEstatus",
                table: "Problema",
                column: "IdProblemaEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Problema_IdUsuarioAsignado",
                table: "Problema",
                column: "IdUsuarioAsignado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problema");

            migrationBuilder.DropTable(
                name: "ProblemaEstatus");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
