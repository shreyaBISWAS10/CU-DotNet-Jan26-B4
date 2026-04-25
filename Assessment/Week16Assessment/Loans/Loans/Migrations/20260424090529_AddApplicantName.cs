using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loans.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicantName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicantName",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantName",
                table: "LoanApplications");
        }
    }
}
