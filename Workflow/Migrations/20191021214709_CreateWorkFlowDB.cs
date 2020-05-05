using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class CreateWorkFlowDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoAprovador",
                columns: table => new
                {
                    IdGrupoAprovador = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAprovador", x => x.IdGrupoAprovador);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAprovadorUsuario",
                columns: table => new
                {
                    IdGrupoAprovadorUsuario = table.Column<Guid>(nullable: false),
                    IdGrupoAprovador = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAprovadorUsuario", x => x.IdGrupoAprovadorUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    IdStep = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdGrupoAprovador = table.Column<Guid>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.IdStep);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    IdWorkflow = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.IdWorkflow);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep",
                columns: table => new
                {
                    IdWorkflowStep = table.Column<Guid>(nullable: false),
                    IdWorkflow = table.Column<Guid>(nullable: false),
                    IdStep = table.Column<Guid>(nullable: false),
                    IdStepAnterior = table.Column<Guid>(nullable: false),
                    IdStepProximo = table.Column<Guid>(nullable: false),
                    IdStatus = table.Column<Guid>(nullable: false),
                    Ordem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep", x => x.IdWorkflowStep);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoAprovador");

            migrationBuilder.DropTable(
                name: "GrupoAprovadorUsuario");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "WorkflowStep");
        }
    }
}
