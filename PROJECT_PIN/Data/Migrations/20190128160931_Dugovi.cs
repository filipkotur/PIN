using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJECT_PIN.Data.Migrations
{
    public partial class Dugovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dugovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Banka = table.Column<string>(nullable: true),
                    Iznos = table.Column<double>(nullable: false),
                    OIB = table.Column<string>(nullable: true),
                    DatumRođenja = table.Column<DateTime>(nullable: false),
                    AdresaStanovanja = table.Column<string>(nullable: true),
                    KontaktBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dugovi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dugovi");
        }
    }
}
