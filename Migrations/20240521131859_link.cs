using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3API.Migrations
{
    /// <inheritdoc />
    public partial class link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropTable(
                name: "PersonalLinks");

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.AlterColumn<string>(
                name: "LinkSite",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalInterestLinks",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
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
                table: "Links",
                columns: new[] { "LinkID", "LinkSite" },
                values: new object[] { 1, "https://magnusandfriends.se/sv/den-kompletta-surf-guiden/?gad_source=1&gclid=Cj0KCQjwjLGyBhCYARIsAPqTz18D50Ic8DNB1AC5G4p9x7sPzTO-06fC7Xs3faEYufv1PEYx2y0ez-gaAn4VEALw_wcB" });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID", "PersonInterestsID" },
                values: new object[] { 1, 2, 0 });

            migrationBuilder.InsertData(
                table: "PersonalInterestLinks",
                columns: new[] { "InterestID", "LinkID", "PersonID", "PersonalLinkID" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 1, 1, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInterestLinks_InterestID",
                table: "PersonalInterestLinks",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInterestLinks_LinkID",
                table: "PersonalInterestLinks",
                column: "LinkID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInterestLinks");

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestID", "PersonID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.AlterColumn<string>(
                name: "LinkSite",
                table: "Links",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InterestLinks",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false),
                    LinkID = table.Column<int>(type: "int", nullable: false),
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
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    LinkID = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestID", "PersonID", "PersonInterestsID" },
                values: new object[] { 3, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_LinkID",
                table: "InterestLinks",
                column: "LinkID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLinks_LinkID",
                table: "PersonalLinks",
                column: "LinkID");
        }
    }
}
