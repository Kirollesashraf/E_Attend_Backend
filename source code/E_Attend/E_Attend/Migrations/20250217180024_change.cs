using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Attend.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titles",
                table: "Sheets",
                newName: "Titel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titel",
                table: "Sheets",
                newName: "Titles");
        }
    }
}
