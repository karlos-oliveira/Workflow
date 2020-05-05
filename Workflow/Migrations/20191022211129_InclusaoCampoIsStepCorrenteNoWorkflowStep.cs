using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class InclusaoCampoIsStepCorrenteNoWorkflowStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStepCorrente",
                table: "WorkflowStep",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStepCorrente",
                table: "WorkflowStep");
        }
    }
}
