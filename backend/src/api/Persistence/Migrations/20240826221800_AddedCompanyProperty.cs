using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Jobs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Jobs");
        }
    }
}
