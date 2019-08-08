using Microsoft.EntityFrameworkCore.Migrations;

namespace XinRevolution.Entity.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Account);
                });

            migrationBuilder.CreateTable(
                name: "IssueRelativeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueRelativeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueRelativeLinks_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Account", "Address", "EMail", "Id", "Name", "Password", "Phone" },
                values: new object[] { "mike.chen", "尚未編輯", "tmal0909@gmail.com", 1, "陳彥翔", "12345678", "0916956546" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Account", "Address", "EMail", "Id", "Name", "Password", "Phone" },
                values: new object[] { "mike.huang", "尚未編輯", "ss5141318@gmail.com", 2, "黃瀚緯", "0933846966", "0933846966" });

            migrationBuilder.CreateIndex(
                name: "IX_IssueRelativeLinks_IssueId",
                table: "IssueRelativeLinks",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueRelativeLinks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
