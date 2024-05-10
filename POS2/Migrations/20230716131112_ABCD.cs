using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS2.Migrations
{
    /// <inheritdoc />
    public partial class ABCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "menuitems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "menuitems");
        }
    }
}
