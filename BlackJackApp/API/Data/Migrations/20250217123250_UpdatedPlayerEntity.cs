using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BlackJackPlayers",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "BlackJackPlayers",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BlackJackPlayers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "BlackJackPlayers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1)
            );

            migrationBuilder.AddColumn<string>(
                name: "GameTag",
                table: "BlackJackPlayers",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    isMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    BlackJackPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_BlackJackPlayers_BlackJackPlayerId",
                        column: x => x.BlackJackPlayerId,
                        principalTable: "BlackJackPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BlackJackPlayerId",
                table: "Photos",
                column: "BlackJackPlayerId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Photos");

            migrationBuilder.DropColumn(name: "City", table: "BlackJackPlayers");

            migrationBuilder.DropColumn(name: "Country", table: "BlackJackPlayers");

            migrationBuilder.DropColumn(name: "Created", table: "BlackJackPlayers");

            migrationBuilder.DropColumn(name: "DateOfBirth", table: "BlackJackPlayers");

            migrationBuilder.DropColumn(name: "GameTag", table: "BlackJackPlayers");
        }
    }
}
