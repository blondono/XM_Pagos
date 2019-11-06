using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class UpdateTables : Migration
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
                    CrossingId = table.Column<int>(nullable: false),
                    Agent = table.Column<string>(nullable: true),
                    TypeCrossingsEntityTypeCrossingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCrossings", x => x.AgentCrossingId);
                    table.ForeignKey(
                        name: "FK_AgentCrossings_TypeCrossings_TypeCrossingsEntityTypeCrossingId",
                        column: x => x.TypeCrossingsEntityTypeCrossingId,
                        principalSchema: "Crossing",
                        principalTable: "TypeCrossings",
                        principalColumn: "TypeCrossingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCrossings_TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "TypeCrossingsEntityTypeCrossingId");
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
