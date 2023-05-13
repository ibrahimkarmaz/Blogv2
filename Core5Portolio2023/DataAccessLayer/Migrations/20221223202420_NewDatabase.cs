using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationSectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationStartYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EducationStopYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EducationContinue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EducationContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationID);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceJobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceStartYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExperienceStopYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExperienceContinue = table.Column<bool>(type: "bit", nullable: false),
                    ExperienceContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                });

            migrationBuilder.CreateTable(
                name: "JobContents",
                columns: table => new
                {
                    JobContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobContentInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobContentArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobContents", x => x.JobContentID);
                });

            migrationBuilder.CreateTable(
                name: "Summarys",
                columns: table => new
                {
                    SummaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summarys", x => x.SummaryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "JobContents");

            migrationBuilder.DropTable(
                name: "Summarys");
        }
    }
}
