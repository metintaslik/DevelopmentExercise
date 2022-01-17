using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentExercise.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountDescription = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    RoleID = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    Percentage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    RoleID = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityCount = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    DiscountCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceTotalPrice = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "ID", "DiscountDescription", "Percentage", "RoleID", "Value" },
                values: new object[] { 1, "For an employee of the store, gets a 30% discount", true, 1, 0.3m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "ID", "DiscountDescription", "Percentage", "RoleID", "Value" },
                values: new object[] { 2, "For an affiliate of the store, gets a 10% discount", true, 2, 0.1m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "ID", "DiscountDescription", "Percentage", "RoleID", "Value" },
                values: new object[] { 3, "Customer for over 2 years, gets a 5% discount", true, 3, 0.5m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "ID", "DiscountDescription", "Percentage", "RoleID", "Value" },
                values: new object[] { 4, "For every $100 on the bill, there would be a $ 5 discount", false, null, 5m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Created", "Email", "FirstName", "LastName", "Role", "RoleID" },
                values: new object[] { 1, new DateTime(2017, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4613), "metinn.taslik@gmail.com", "Metin", "TASLIK", 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Created", "Email", "FirstName", "LastName", "Role", "RoleID" },
                values: new object[] { 2, new DateTime(2018, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4633), "metinn.taslik@outlook.com", "Metin", "TASLIK", 3, 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Created", "Email", "FirstName", "LastName", "Role", "RoleID" },
                values: new object[] { 3, new DateTime(2021, 7, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4636), "demo@demo.com", "Demo", "DEMO", 2, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Created", "Email", "FirstName", "LastName", "Role", "RoleID" },
                values: new object[] { 4, new DateTime(2022, 1, 9, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4643), "test@test.com", "Test", "TEST", 3, 3 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 1, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4962), 0.00m, 36778.74m, "HRWE6WTI", 1, 0m, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 2, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4968), 0.00m, 10980.00m, "750JB8JJ", 1, 0m, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 3, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4972), 0.00m, 950.00m, "KZ8VVPBX", 2, 0m, 3 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 4, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4977), 0.00m, 600.75m, "GFY1SSWF", 1, 0m, 4 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 5, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4981), 0.00m, 4999.00m, "391RNVTZ", 1, 0m, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 6, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4987), 0.00m, 17999.00m, "X2020IK0", 1, 0m, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Created", "DiscountCost", "OrderCost", "OrderNumber", "QuantityCount", "TotalCost", "UserID" },
                values: new object[] { 7, new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4991), 0.00m, 99.99m, "NDNRZ0L8", 1, 0m, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderID",
                table: "Invoices",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
