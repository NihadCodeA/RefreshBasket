using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPanelCRUD.Migrations
{
    public partial class UpdateBookTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
