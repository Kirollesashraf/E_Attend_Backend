using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Attend.Migrations
{
    /// <inheritdoc />
    public partial class changeTitel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sheets",
                newName: "Titles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titles",
                table: "Sheets",
                newName: "Title");
        }
    }
}
