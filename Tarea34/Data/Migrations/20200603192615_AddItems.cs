using Microsoft.EntityFrameworkCore.Migrations;

namespace tarea3prog3.Data.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ced",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellido1 = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    Ok = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ced", x => x.Cedula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ced");
        }
    }
}
