using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class InclusaoCampoIdConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "Workflow",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "Usuario",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "Step",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "GrupoAprovador",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "GrupoAprovador");
        }
    }
}
