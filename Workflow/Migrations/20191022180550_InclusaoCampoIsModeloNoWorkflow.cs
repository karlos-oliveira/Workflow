using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class InclusaoCampoIsModeloNoWorkflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsModelo",
                table: "Workflow",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsModelo",
                table: "Workflow");
        }
    }
}
