using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [FirstName], [LastName], [Picture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'3323606f-acd6-4491-8fef-939106f3c978', N'Admin', N'admin', NULL, N'admin@test.com', N'ADMIN@TEST.COM', N'admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAIAAYagAAAAEMdBzJx1Bg/1j3hbcZ7jEMmJbMoVmhZMRwOnOMsMU6LzxVZAMWK5bYD43Z3G/mymgQ==', N'4HTNGR5Z4X4JPW56EI5MRUZQDXVNEB4W', N'a3f5f059-64df-475c-9db0-9afdff548307', NULL, 0, 0, NULL, 1, 0)");

            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = '3323606f-acd6-4491-8fef-939106f3c978'");

        }
    }
}
