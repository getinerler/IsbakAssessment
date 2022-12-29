using Microsoft.EntityFrameworkCore.Migrations;

namespace IsbakAssessment.Migrations
{
    public partial class ChangeRateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeRate",
                table: "CryptoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeRate",
                table: "CryptoItems");
        }
    }
}
