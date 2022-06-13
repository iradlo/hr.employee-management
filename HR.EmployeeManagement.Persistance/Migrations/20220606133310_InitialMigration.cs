using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.EmployeeManagement.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Description", "TeamName" },
                values: new object[,]
                {
                    { 2, "Team for designing UI", "User interface team" },
                    { 1, "Team for database", "Database team" },
                    { 3, "Team for architecture and infrastructure", "Infrastructure team" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", "administrator", "admin" },
                    { 2, "igor", "user", "igor" },
                    { 3, "test", "user", "test" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "City", "Email", "LastName", "Name", "Phone", "TeamId" },
                values: new object[,]
                {
                    { 102, "Washington boulevar 3", "Washington", "ron123@ms.com", "Joe", "Mike", "13332", 2 },
                    { 103, "Washington boulevar 3", "Washington", "mike@ms.com", "Scot", "Ron", "13333332", 2 },
                    { 104, "Washington boulevar 3", "Washington", "don.jonson@hr.com", "Michael", "Dean", "24343", 2 },
                    { 100, "Street Red 1", "Atlanta", "jac@cd.com", "Doe", "John", "12312", 1 },
                    { 101, "Redmong street 123", "Texas", "dean@yaho.com", "Jonson", "Don", "13332", 1 },
                    { 105, "La boulevar 3", "Los Angeles", "john.doe@hr.com", "Jackson", "Jack", "24343", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
