using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropTable(
                name: "LinkPerson");

            migrationBuilder.DropTable(
                name: "PersonalInterestLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests");

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "PersonID", "InterestID" });

            migrationBuilder.CreateTable(
                name: "InterestLinks",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false),
                    InterestLinkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinks", x => new { x.LinkID, x.InterestID });
                    table.ForeignKey(
                        name: "FK_InterestLinks_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLinks_Links_LinkID",
                        column: x => x.LinkID,
                        principalTable: "Links",
                        principalColumn: "LinkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InterestLinks",
                columns: new[] { "InterestID", "LinkID", "InterestLinkID" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkID", "LinkSite" },
                values: new object[] { 2, "https://www.lapoint.se/?gad_source=1&gclid=Cj0KCQjw3tCyBhDBARIsAEY0XNkNh8aYEYYJ5v36jgFFx0-Zr2-ZBaodHOYuDRXhyjkWp-uxJCTRI94aAoocEALw_wcB" });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID", "PersonInterestsID" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 1, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "InterestLinks",
                columns: new[] { "InterestID", "LinkID", "InterestLinkID" },
                values: new object[] { 1, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_InterestID",
                table: "InterestLinks",
                column: "InterestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests");

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID" });

            migrationBuilder.CreateTable(
                name: "InterestLink",
                columns: table => new
                {
                    InterestsInterestID = table.Column<int>(type: "int", nullable: false),
                    linksLinkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLink", x => new { x.InterestsInterestID, x.linksLinkID });
                    table.ForeignKey(
                        name: "FK_InterestLink_Interests_InterestsInterestID",
                        column: x => x.InterestsInterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLink_Links_linksLinkID",
                        column: x => x.linksLinkID,
                        principalTable: "Links",
                        principalColumn: "LinkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestPerson",
                columns: table => new
                {
                    InterestsInterestID = table.Column<int>(type: "int", nullable: false),
                    peoplePersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPerson", x => new { x.InterestsInterestID, x.peoplePersonID });
                    table.ForeignKey(
                        name: "FK_InterestPerson_Interests_InterestsInterestID",
                        column: x => x.InterestsInterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPerson_People_peoplePersonID",
                        column: x => x.peoplePersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPerson",
                columns: table => new
                {
                    LinksLinkID = table.Column<int>(type: "int", nullable: false),
                    PeoplePersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPerson", x => new { x.LinksLinkID, x.PeoplePersonID });
                    table.ForeignKey(
                        name: "FK_LinkPerson_Links_LinksLinkID",
                        column: x => x.LinksLinkID,
                        principalTable: "Links",
                        principalColumn: "LinkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPerson_People_PeoplePersonID",
                        column: x => x.PeoplePersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInterestLinks",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    LinkID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false),
                    PersonalLinkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInterestLinks", x => new { x.PersonID, x.LinkID, x.InterestID });
                    table.ForeignKey(
                        name: "FK_PersonalInterestLinks_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInterestLinks_Links_LinkID",
                        column: x => x.LinkID,
                        principalTable: "Links",
                        principalColumn: "LinkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInterestLinks_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID", "PersonInterestsID" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 2, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "PersonalInterestLinks",
                columns: new[] { "InterestID", "LinkID", "PersonID", "PersonalLinkID" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 1, 1, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLink_linksLinkID",
                table: "InterestLink",
                column: "linksLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_peoplePersonID",
                table: "InterestPerson",
                column: "peoplePersonID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPerson_PeoplePersonID",
                table: "LinkPerson",
                column: "PeoplePersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInterestLinks_InterestID",
                table: "PersonalInterestLinks",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInterestLinks_LinkID",
                table: "PersonalInterestLinks",
                column: "LinkID");
        }
    }
}
