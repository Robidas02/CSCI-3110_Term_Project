﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI_3110_Term_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddedDexNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DexNumber",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DexNumber",
                table: "Pokemon");
        }
    }
}
