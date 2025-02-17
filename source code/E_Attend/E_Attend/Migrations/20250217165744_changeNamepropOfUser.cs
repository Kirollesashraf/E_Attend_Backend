using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Attend.Migrations
{
    /// <inheritdoc />
    public partial class changeNamepropOfUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AppUsers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppUsers",
                newName: "FullName");
        }
    }
}
