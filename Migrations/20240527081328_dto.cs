using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class dto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropTable(
                name: "LinkPerson");
        }
    }
}
