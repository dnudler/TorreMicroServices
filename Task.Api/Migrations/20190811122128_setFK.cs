using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Api.Migrations
{
    public partial class setFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"ALTER TABLE dbo.Tasks ADD CONSTRAINT
	                        FK_Tasks_Users FOREIGN KEY
	                        (
	                        UserId
	                        ) REFERENCES dbo.Users
	                        (
	                        Id
	                        ) ON UPDATE  NO ACTION 
	                         ON DELETE  NO ACTION 
	                        ";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             var sql = "ALTER TABLE dbo.Tasks DROP CONSTRAINT FK_Tasks_Users";
             migrationBuilder.Sql(sql);
        }

    }
}
