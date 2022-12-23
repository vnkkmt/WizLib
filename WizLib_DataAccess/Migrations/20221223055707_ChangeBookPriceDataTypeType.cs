using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ChangeBookPriceDataTypeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Books",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
