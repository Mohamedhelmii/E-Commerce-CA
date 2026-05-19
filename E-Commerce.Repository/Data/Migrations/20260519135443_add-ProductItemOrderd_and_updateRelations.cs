using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProductItemOrderd_and_updateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "OrderItems",
                newName: "ProductItemOrdered_ProductName");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "OrderItems",
                newName: "ProductItemOrdered_ProductId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "OrderItems",
                newName: "ProductItemOrdered_ImageUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductItemOrdered_ProductName",
                table: "OrderItems",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ProductItemOrdered_ProductId",
                table: "OrderItems",
                newName: "ProductItemId");

            migrationBuilder.RenameColumn(
                name: "ProductItemOrdered_ImageUrl",
                table: "OrderItems",
                newName: "PictureUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
