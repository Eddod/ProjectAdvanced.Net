using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAdvanced.Net.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblEmployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PersonalNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "TblProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProjects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TblTimereports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    WorkHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTimereports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTimereports_TblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TblEmployees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblTimereports_TblProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TblProjects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblEmployees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, "Edwin", "Westerberg", "941201293" },
                    { 2, "Test", "Testsson", "82314284" },
                    { 3, "Prov", "Provsson", "137583589" },
                    { 4, "Pröv", "Prövsson", "8491284824" },
                    { 5, "Sara", "Karlsson", "853948392" }
                });

            migrationBuilder.InsertData(
                table: "TblProjects",
                columns: new[] { "ProjectId", "ProjectDescription" },
                values: new object[,]
                {
                    { 1, "Projekt1" },
                    { 2, "Projekt2" }
                });

            migrationBuilder.InsertData(
                table: "TblTimereports",
                columns: new[] { "Id", "EmployeeId", "ProjectId", "Week", "WorkHours" },
                values: new object[,]
                {
                    { 3, 3, 1, 3, 50 },
                    { 4, 5, 1, 4, 40 },
                    { 6, 2, 1, 4, 40 },
                    { 1, 5, 2, 1, 40 },
                    { 2, 4, 2, 2, 40 },
                    { 5, 4, 2, 5, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblTimereports_EmployeeId",
                table: "TblTimereports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblTimereports_ProjectId",
                table: "TblTimereports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblTimereports");

            migrationBuilder.DropTable(
                name: "TblEmployees");

            migrationBuilder.DropTable(
                name: "TblProjects");
        }
    }
}
