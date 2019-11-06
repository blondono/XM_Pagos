using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class ProcessFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProcessFile");

            migrationBuilder.CreateTable(
                name: "EquivalenceColumn",
                schema: "ProcessFile",
                columns: table => new
                {
                    Origin = table.Column<string>(nullable: false),
                    Bank = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    EquivalenceColumn = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ColumnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquivalenceColumn", x => x.Origin);
                });

            migrationBuilder.CreateTable(
                name: "FileAdministrator",
                schema: "ProcessFile",
                columns: table => new
                {
                    BankFileAdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessCode = table.Column<string>(nullable: true),
                    BankCode = table.Column<string>(nullable: true),
                    HeadFileName = table.Column<string>(nullable: true),
                    DetailFileName = table.Column<string>(nullable: true),
                    ReadFolder = table.Column<string>(nullable: true),
                    StartLine = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAdministrator", x => x.BankFileAdminId);
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                schema: "ProcessFile",
                columns: table => new
                {
                    BankLoadFileDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessCode = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.BankLoadFileDataId);
                });

            migrationBuilder.CreateTable(
                name: "FileDataDetail",
                schema: "ProcessFile",
                columns: table => new
                {
                    BankLoadFileDataDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<string>(nullable: true),
                    TransactionName = table.Column<string>(nullable: true),
                    DebitValue = table.Column<int>(nullable: false),
                    CreditValue = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    DetailQuantity = table.Column<int>(nullable: false),
                    BankLoadFileDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDataDetail", x => x.BankLoadFileDataDetailId);
                    table.ForeignKey(
                        name: "FK_FileDataDetail_FileData_BankLoadFileDataId",
                        column: x => x.BankLoadFileDataId,
                        principalSchema: "ProcessFile",
                        principalTable: "FileData",
                        principalColumn: "BankLoadFileDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDataDetail_BankLoadFileDataId",
                schema: "ProcessFile",
                table: "FileDataDetail",
                column: "BankLoadFileDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquivalenceColumn",
                schema: "ProcessFile");

            migrationBuilder.DropTable(
                name: "FileAdministrator",
                schema: "ProcessFile");

            migrationBuilder.DropTable(
                name: "FileDataDetail",
                schema: "ProcessFile");

            migrationBuilder.DropTable(
                name: "FileData",
                schema: "ProcessFile");
        }
    }
}
