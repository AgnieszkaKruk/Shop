using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    public partial class fixDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Product_productId",
                table: "ProductsInCart");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ProductsInCart",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCart_productId",
                table: "ProductsInCart",
                newName: "IX_ProductsInCart_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "ProductsInCart",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DefaultPrice",
                table: "Product",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Product_ProductId",
                table: "ProductsInCart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Product_ProductId",
                table: "ProductsInCart");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductsInCart",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCart_ProductId",
                table: "ProductsInCart",
                newName: "IX_ProductsInCart_productId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "ProductsInCart",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "ProductsInCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DefaultPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Product_productId",
                table: "ProductsInCart",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
