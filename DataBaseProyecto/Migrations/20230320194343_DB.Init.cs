using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBaseProyecto.Migrations
{
    /// <inheritdoc />
    public partial class DBInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id_Nota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(type: "double", nullable: false),
                    Porcentaje = table.Column<double>(type: "double", nullable: false),
                    Actividad = table.Column<string>(type: "longtext", nullable: true),
                    Id_Materia = table.Column<int>(type: "int", nullable: false),
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id_Nota);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiante_Nota_Id_Estudiante",
                        column: x => x.Id_Estudiante,
                        principalTable: "Nota",
                        principalColumn: "Id_Nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id_Materia = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id_Materia);
                    table.ForeignKey(
                        name: "FK_Materia_Nota_Id_Materia",
                        column: x => x.Id_Materia,
                        principalTable: "Nota",
                        principalColumn: "Id_Nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
