using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class UpdateAgentCrossingFullPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FullPaymentDebts",
                schema: "Crossing",
                table: "AgentCrossings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullPaymentDebts",
                schema: "Crossing",
                table: "AgentCrossings");
        }
    }
}
