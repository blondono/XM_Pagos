using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class CreateCrossingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentCrossings_TypeCrossings_TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings");

            migrationBuilder.DropIndex(
                name: "IX_AgentCrossings_TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings");

            migrationBuilder.DropColumn(
                name: "TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings");

            migrationBuilder.CreateTable(
                name: "Crossings",
                schema: "Crossing",
                columns: table => new
                {
                    CrossingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    CreationUser = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ModificationUser = table.Column<string>(nullable: true),
                    Business = table.Column<string>(nullable: true),
                    TypeCrossingId = table.Column<int>(nullable: false),
                    InitialValidity = table.Column<DateTime>(nullable: false),
                    FinalValidity = table.Column<DateTime>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Crossed = table.Column<bool>(nullable: true),
                    FullPaymentDebts = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crossings", x => x.CrossingId);
                    table.ForeignKey(
                        name: "FK_Crossings_TypeCrossings_TypeCrossingId",
                        column: x => x.TypeCrossingId,
                        principalSchema: "Crossing",
                        principalTable: "TypeCrossings",
                        principalColumn: "TypeCrossingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCrossings_CrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "CrossingId");

            migrationBuilder.CreateIndex(
                name: "IX_Crossings_TypeCrossingId",
                schema: "Crossing",
                table: "Crossings",
                column: "TypeCrossingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentCrossings_Crossings_CrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "CrossingId",
                principalSchema: "Crossing",
                principalTable: "Crossings",
                principalColumn: "CrossingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentCrossings_Crossings_CrossingId",
                schema: "Crossing",
                table: "AgentCrossings");

            migrationBuilder.DropTable(
                name: "Crossings",
                schema: "Crossing");

            migrationBuilder.DropIndex(
                name: "IX_AgentCrossings_CrossingId",
                schema: "Crossing",
                table: "AgentCrossings");

            migrationBuilder.AddColumn<int>(
                name: "TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentCrossings_TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "TypeCrossingsEntityTypeCrossingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentCrossings_TypeCrossings_TypeCrossingsEntityTypeCrossingId",
                schema: "Crossing",
                table: "AgentCrossings",
                column: "TypeCrossingsEntityTypeCrossingId",
                principalSchema: "Crossing",
                principalTable: "TypeCrossings",
                principalColumn: "TypeCrossingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
