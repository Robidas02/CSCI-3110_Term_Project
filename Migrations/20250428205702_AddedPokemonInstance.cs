using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI_3110_Term_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddedPokemonInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonInstanceId",
                table: "Moves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PokemonInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonSpeciesId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    AbilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonInstance_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonInstance_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonInstance_Pokemon_PokemonSpeciesId",
                        column: x => x.PokemonSpeciesId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonInstance_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonInstanceId",
                table: "Moves",
                column: "PokemonInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonInstance_AbilityId",
                table: "PokemonInstance",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonInstance_ItemId",
                table: "PokemonInstance",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonInstance_PokemonSpeciesId",
                table: "PokemonInstance",
                column: "PokemonSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonInstance_TeamId",
                table: "PokemonInstance",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_PokemonInstance_PokemonInstanceId",
                table: "Moves",
                column: "PokemonInstanceId",
                principalTable: "PokemonInstance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_PokemonInstance_PokemonInstanceId",
                table: "Moves");

            migrationBuilder.DropTable(
                name: "PokemonInstance");

            migrationBuilder.DropIndex(
                name: "IX_Moves_PokemonInstanceId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "PokemonInstanceId",
                table: "Moves");
        }
    }
}
