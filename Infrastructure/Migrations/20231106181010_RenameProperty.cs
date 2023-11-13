using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_AccountId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_ClientID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Reservations",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AccountId",
                table: "Reservations",
                newName: "IX_Reservations_AccountID");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountID",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accounts_AccountID",
                table: "Reservations",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accounts_AccountID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Reservations",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AccountID",
                table: "Reservations",
                newName: "IX_Reservations_AccountId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accounts_AccountId",
                table: "Reservations",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_ClientID",
                table: "Reservations",
                column: "ClientID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
