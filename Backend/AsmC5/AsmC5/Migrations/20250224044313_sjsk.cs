﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsmC5.Migrations
{
    /// <inheritdoc />
    public partial class sjsk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Combos_ComboID1",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ComboID1",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ComboID1",
                table: "CartItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComboID1",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ComboID1",
                table: "CartItems",
                column: "ComboID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Combos_ComboID1",
                table: "CartItems",
                column: "ComboID1",
                principalTable: "Combos",
                principalColumn: "ComboID");
        }
    }
}
