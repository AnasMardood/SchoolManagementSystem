using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdvisorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_Advisor_AdvisorID",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvisorSemesters_Advisor_AdvisorId",
                table: "AdvisorSemesters");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Advisor_AdvisorID",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Advisor_AdvisorID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Advisor_AdvisorID",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Advisor_AdvisorID",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advisor",
                table: "Advisor");

            migrationBuilder.RenameTable(
                name: "Advisor",
                newName: "Advisors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advisors",
                table: "Advisors",
                column: "AdvisorID");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_Advisors_AdvisorID",
                table: "AcademicCalendars",
                column: "AdvisorID",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvisorSemesters_Advisors_AdvisorId",
                table: "AdvisorSemesters",
                column: "AdvisorId",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Advisors_AdvisorID",
                table: "Announcements",
                column: "AdvisorID",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Advisors_AdvisorID",
                table: "Attendances",
                column: "AdvisorID",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Advisors_AdvisorID",
                table: "Materials",
                column: "AdvisorID",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Advisors_AdvisorID",
                table: "Message",
                column: "AdvisorID",
                principalTable: "Advisors",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicCalendars_Advisors_AdvisorID",
                table: "AcademicCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvisorSemesters_Advisors_AdvisorId",
                table: "AdvisorSemesters");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Advisors_AdvisorID",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Advisors_AdvisorID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Advisors_AdvisorID",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Advisors_AdvisorID",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advisors",
                table: "Advisors");

            migrationBuilder.RenameTable(
                name: "Advisors",
                newName: "Advisor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advisor",
                table: "Advisor",
                column: "AdvisorID");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicCalendars_Advisor_AdvisorID",
                table: "AcademicCalendars",
                column: "AdvisorID",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvisorSemesters_Advisor_AdvisorId",
                table: "AdvisorSemesters",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Advisor_AdvisorID",
                table: "Announcements",
                column: "AdvisorID",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Advisor_AdvisorID",
                table: "Attendances",
                column: "AdvisorID",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Advisor_AdvisorID",
                table: "Materials",
                column: "AdvisorID",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Advisor_AdvisorID",
                table: "Message",
                column: "AdvisorID",
                principalTable: "Advisor",
                principalColumn: "AdvisorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
