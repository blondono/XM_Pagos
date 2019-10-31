using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class CreateCrossingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Crossing");

            migrationBuilder.CreateTable(
                name: "TypeCrossings",
                schema: "Crossing",
                columns: table => new
                {
                    TypeCrossingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    CreationUser = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ModificationUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Enable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCrossings", x => x.TypeCrossingId);
                });

            migrationBuilder.CreateTable(
                name: "AgentCrossings",
                schema: "Crossing",
                columns: table => new
                {
                    AgentCrossingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    CreationUser = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ModificationUser = table.Column<string>(nullable: true),
                    Business = table.Column<string>(nullable: true),
                    Agent = table.Column<string>(nullable: true),
                    TypeCrossingId = table.Column<int>(nullable: false),
                    InitialValidity = table.Column<DateTime>(nullable: false),
                    FinalValidity = table.Column<DateTime>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Crossed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCrossings", x => x.AgentCrossingId);
                    table.ForeignKey(
                        name: "FK_AgentCrossings_TypeCrossings_TypeCrossingId",
                        column: x => x.TypeCrossingId,
                        principalSchema: "Crossing",
                        principalTable: "TypeCrossings",
                        principalColumn: "TypeCrossingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCrossings_TypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "TypeCrossingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentCrossings",
                schema: "Crossing");

            migrationBuilder.DropTable(
                name: "TypeCrossings",
                schema: "Crossing");
        }
    }
}
