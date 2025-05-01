using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI_3110_Term_Project.Migrations
{
    /// <inheritdoc />
    public partial class CleanedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsPokemon");

            migrationBuilder.DropTable(
                name: "PokemonTeams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsPokemon",
                columns: table => new
                {
                    HeldById = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPokemon", x => new { x.HeldById, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemsPokemon_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsPokemon_Pokemon_HeldById",
                        column: x => x.HeldById,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTeams",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTeams", x => new { x.PokemonId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_PokemonTeams_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTeams_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPokemon_ItemId",
                table: "ItemsPokemon",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_TeamsId",
                table: "PokemonTeams",
                column: "TeamsId");
        }
    }
}
