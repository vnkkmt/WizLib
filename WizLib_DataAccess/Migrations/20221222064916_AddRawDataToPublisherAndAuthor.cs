using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRawDataToPublisherAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Authors([FirstName],[LastName],[BirthDate],[Location]) values('Author1','LastName1','09/23/2012','Location1') ");
            migrationBuilder.Sql("insert into Authors([FirstName],[LastName],[BirthDate],[Location]) values('Author2','LastName2','09/23/2012','Location2') ");
            migrationBuilder.Sql("insert into Authors([FirstName],[LastName],[BirthDate],[Location]) values('Author3','LastName3','09/23/2012','Location3') ");


            migrationBuilder.Sql("insert into Publishers([Name],[Location]) values('Publisher1','Pub_Location1')");
            migrationBuilder.Sql("insert into Publishers([Name],[Location]) values('Publisher2','Pub_Location2')");
            migrationBuilder.Sql("insert into Publishers([Name],[Location]) values('Publisher3','Pub_Location3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
