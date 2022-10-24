using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewQuestion.Infrastructure.Migrations
{
    public partial class Agent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
              

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "TerminalTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminalTransactions_AgentId",
                table: "TerminalTransactions",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalTransactions_Agents_AgentId",
                table: "TerminalTransactions",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerminalTransactions_Agents_AgentId",
                table: "TerminalTransactions");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_TerminalTransactions_AgentId",
                table: "TerminalTransactions");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "TerminalTransactions"); 
        }
    }
}
