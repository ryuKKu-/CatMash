using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMash.Migrations
{
    public partial class Rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Cats_OpponentId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Cats_PlayerId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_OpponentId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_PlayerId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "OpponentId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Histories",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Cats",
                newName: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "CatId",
                table: "Histories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Histories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatAId = table.Column<string>(nullable: true),
                    CatBId = table.Column<string>(nullable: true),
                    RatingA = table.Column<int>(nullable: false),
                    RatingB = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Cats_CatAId",
                        column: x => x.CatAId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Cats_CatBId",
                        column: x => x.CatBId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_CatId",
                table: "Histories",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_MatchId",
                table: "Histories",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CatAId",
                table: "Matches",
                column: "CatAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CatBId",
                table: "Matches",
                column: "CatBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Cats_CatId",
                table: "Histories",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Matches_MatchId",
                table: "Histories",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Cats_CatId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Matches_MatchId",
                table: "Histories");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Histories_CatId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_MatchId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Histories",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Cats",
                newName: "Score");

            migrationBuilder.AddColumn<string>(
                name: "OpponentId",
                table: "Histories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Histories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "Histories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_OpponentId",
                table: "Histories",
                column: "OpponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PlayerId",
                table: "Histories",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Cats_OpponentId",
                table: "Histories",
                column: "OpponentId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Cats_PlayerId",
                table: "Histories",
                column: "PlayerId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
