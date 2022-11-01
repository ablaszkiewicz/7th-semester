using Microsoft.EntityFrameworkCore.Migrations;

namespace proj.Migrations
{
    public partial class AddQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ItemsOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsOrders",
                table: "ItemsOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemsOrders_ItemId",
                table: "ItemsOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemsOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsOrders",
                table: "ItemsOrders",
                columns: new[] { "ItemId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrders_OrderId",
                table: "ItemsOrders",
                column: "OrderId");
        }
    }
}
