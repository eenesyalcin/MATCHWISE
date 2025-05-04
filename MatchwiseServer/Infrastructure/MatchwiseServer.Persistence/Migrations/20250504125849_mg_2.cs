using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchwiseServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Candidates");
        }
    }
}
