using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagazzi.AccesoDatos.Migrations
{
    public partial class migrationcret2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run = table.Column<string>(type: "varchar(13)", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(20)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(80)", nullable: false),
                    TipoTrabajadorId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabajador_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajador_TipoTrabajador_TipoTrabajadorId",
                        column: x => x.TipoTrabajadorId,
                        principalTable: "TipoTrabajador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_EstadoId",
                table: "Trabajador",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_TipoTrabajadorId",
                table: "Trabajador",
                column: "TipoTrabajadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajador");
        }
    }
}
