using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class AprimoramentoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BloqueiaAndamento",
                table: "Status",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloqueiaAndamento",
                table: "Status");
        }
    }
}
