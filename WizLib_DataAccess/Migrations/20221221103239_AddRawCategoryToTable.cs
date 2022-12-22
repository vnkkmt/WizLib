using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRawCategoryToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into tbl_Category values('Cat 1')");
            migrationBuilder.Sql("Insert into tbl_Category values('Cat 2')");
            migrationBuilder.Sql("Insert into tbl_Category values('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
