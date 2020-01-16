using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Yeet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 15, 15, 3, 8, 445, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 15, 15, 3, 8, 434, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentQuantity", "DeletedAt", "Description", "ModifiedAt", "ProductName" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 1, 15, 15, 3, 8, 446, DateTimeKind.Local).AddTicks(3006), 10, null, "Modern US riffle with 5.56 rounds.", null, "AR-15" },
                    { 1, new DateTime(2020, 1, 15, 15, 3, 8, 446, DateTimeKind.Local).AddTicks(3101), 8, null, "Moder 9mm pistol with selectable modes.", null, "Glock20" },
                    { 2, new DateTime(2020, 1, 15, 15, 3, 8, 446, DateTimeKind.Local).AddTicks(3112), 1, null, "Russian rifle using a rare 9.39mm round restricted for use", null, "ASVAL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 11, 14, 20, 3, 801, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 11, 14, 20, 3, 793, DateTimeKind.Local).AddTicks(4112));
        }
    }
}
