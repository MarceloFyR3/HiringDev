using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiringDev.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuscaVideos",
                columns: table => new
                {
                    IdBuscaVideo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuscaGuid = table.Column<Guid>(nullable: false),
                    ImagemCapa = table.Column<string>(nullable: true),
                    TermoBusca = table.Column<string>(nullable: true),
                    DataBusca = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    VideoId = table.Column<string>(nullable: true),
                    CanalId = table.Column<string>(nullable: true),
                    CanalTitulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuscaVideos", x => x.IdBuscaVideo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuscaVideos");
        }
    }
}
