using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XinRevolution.Entity.Migrations
{
    public partial class Table_Blog_Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_IssueItems_Title",
                table: "IssueItems");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IssueItems_Title_ReleaseDate",
                table: "IssueItems",
                columns: new[] { "Title", "ReleaseDate" });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.UniqueConstraint("AK_Blogs_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.UniqueConstraint("AK_Tags_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceType = table.Column<short>(type: "smallint", nullable: false),
                    ReferenceContent = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => x.Id);
                    table.UniqueConstraint("AK_BlogTags_BlogId_TagId", x => new { x.BlogId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogTags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Enable", "Name" },
                values: new object[,]
                {
                    { 1, true, "Tag1" },
                    { 2, false, "Tag2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mike.Chen");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account", "Address", "Mail", "Name", "Password", "Phone" },
                values: new object[] { 2, "mike.huang", "temp address", "temp mail", "Mike.Huang", "12345678", "temp phone" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogId",
                table: "BlogPosts",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_IssueItems_Title_ReleaseDate",
                table: "IssueItems");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_IssueItems_Title",
                table: "IssueItems",
                column: "Title");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mike");
        }
    }
}
