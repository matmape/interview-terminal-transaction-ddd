using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewQuestion.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TerminalTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionReference = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    GeoLocation = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ResponseCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    TmsAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Surcharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalTransactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalTransactions");
        }
    }
}
