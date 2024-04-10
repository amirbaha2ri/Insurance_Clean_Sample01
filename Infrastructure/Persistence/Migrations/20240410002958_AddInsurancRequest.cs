using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInsurancRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fund",
                table: "InsuranceCharges",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "InsuranceCharges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InsuranceRequestCoverage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceCoverageId = table.Column<int>(type: "int", nullable: false),
                    InsuranceRequestId = table.Column<int>(type: "int", nullable: false),
                    GuID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestCoverage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverage_InsuranceCharges_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceCharges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverage_InsuranceCoverages_InsuranceCoverageId",
                        column: x => x.InsuranceCoverageId,
                        principalTable: "InsuranceCoverages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverage_InsuranceCoverageId",
                table: "InsuranceRequestCoverage",
                column: "InsuranceCoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverage_InsuranceRequestId",
                table: "InsuranceRequestCoverage",
                column: "InsuranceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequestCoverage");

            migrationBuilder.DropColumn(
                name: "Fund",
                table: "InsuranceCharges");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "InsuranceCharges");
        }
    }
}
