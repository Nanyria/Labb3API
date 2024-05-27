using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class RecreateIntital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    InterestsDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkSite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

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
                    table.PrimaryKey("PK_InterestLinks", x => new { x.InterestID, x.LinkID });
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

            migrationBuilder.CreateTable(
                name: "PersonalLinks",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    PersonalLinkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLinks", x => new { x.PersonID, x.LinkID });
                    table.ForeignKey(
                        name: "FK_PersonalLinks_Links_LinkID",
                        column: x => x.LinkID,
                        principalTable: "Links",
                        principalColumn: "LinkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalLinks_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false),
                    PersonInterestsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.InterestID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "InterestTitle", "InterestsDescription" },
                values: new object[,]
                {
                    { 1, "Surfing", "Väldigt kul, vatten" },
                    { 2, "Matlagning", "Väldigt kul, ingredienser och grejer" },
                    { 3, "Datorspel", "Väldigt kul, dator" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Adam", "Andersson", 42552525.0 },
                    { 2, "Eva", "Johansson", 731234567.0 }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID", "PersonInterestsID" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 3, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_LinkID",
                table: "InterestLinks",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLinks_LinkID",
                table: "PersonalLinks",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropTable(
                name: "PersonalLinks");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
