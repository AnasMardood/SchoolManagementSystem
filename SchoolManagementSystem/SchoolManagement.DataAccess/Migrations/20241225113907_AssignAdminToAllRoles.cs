using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace SchoolManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[security].[UserRoles] (UserId, RoleId) SELECT '3323606f-acd6-4491-8fef-939106f3c978', Id FROM[security].[Roles]");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] where UserId ='3323606f-acd6-4491-8fef-939106f3c978'");
        }
    }
}
