using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInsurancReques02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRequestCoverage_InsuranceCharges_InsuranceRequestId",
                table: "InsuranceRequestCoverage");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRequestCoverage_InsuranceCoverages_InsuranceCoverageId",
                table: "InsuranceRequestCoverage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceRequestCoverage",
                table: "InsuranceRequestCoverage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceCharges",
                table: "InsuranceCharges");

            migrationBuilder.RenameTable(
                name: "InsuranceRequestCoverage",
                newName: "InsuranceRequestCoverages");

            migrationBuilder.RenameTable(
                name: "InsuranceCharges",
                newName: "InsuranceRequests");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceRequestCoverage_InsuranceRequestId",
                table: "InsuranceRequestCoverages",
                newName: "IX_InsuranceRequestCoverages_InsuranceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceRequestCoverage_InsuranceCoverageId",
                table: "InsuranceRequestCoverages",
                newName: "IX_InsuranceRequestCoverages_InsuranceCoverageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceRequestCoverages",
                table: "InsuranceRequestCoverages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceRequests",
                table: "InsuranceRequests",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRequestCoverages_InsuranceCoverages_InsuranceCoverageId",
                table: "InsuranceRequestCoverages",
                column: "InsuranceCoverageId",
                principalTable: "InsuranceCoverages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRequestCoverages_InsuranceRequests_InsuranceRequestId",
                table: "InsuranceRequestCoverages",
                column: "InsuranceRequestId",
                principalTable: "InsuranceRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRequestCoverages_InsuranceCoverages_InsuranceCoverageId",
                table: "InsuranceRequestCoverages");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRequestCoverages_InsuranceRequests_InsuranceRequestId",
                table: "InsuranceRequestCoverages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceRequests",
                table: "InsuranceRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceRequestCoverages",
                table: "InsuranceRequestCoverages");

            migrationBuilder.RenameTable(
                name: "InsuranceRequests",
                newName: "InsuranceCharges");

            migrationBuilder.RenameTable(
                name: "InsuranceRequestCoverages",
                newName: "InsuranceRequestCoverage");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceRequestCoverages_InsuranceRequestId",
                table: "InsuranceRequestCoverage",
                newName: "IX_InsuranceRequestCoverage_InsuranceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceRequestCoverages_InsuranceCoverageId",
                table: "InsuranceRequestCoverage",
                newName: "IX_InsuranceRequestCoverage_InsuranceCoverageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceCharges",
                table: "InsuranceCharges",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceRequestCoverage",
                table: "InsuranceRequestCoverage",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRequestCoverage_InsuranceCharges_InsuranceRequestId",
                table: "InsuranceRequestCoverage",
                column: "InsuranceRequestId",
                principalTable: "InsuranceCharges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRequestCoverage_InsuranceCoverages_InsuranceCoverageId",
                table: "InsuranceRequestCoverage",
                column: "InsuranceCoverageId",
                principalTable: "InsuranceCoverages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
