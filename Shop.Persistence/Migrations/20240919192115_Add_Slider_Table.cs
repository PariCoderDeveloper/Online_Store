using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Slider_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Category_Category_ParentCategoryId",
            //            column: x => x.ParentCategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Display = table.Column<bool>(type: "bit", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<int>(type: "int", nullable: false),
            //        Inventory = table.Column<int>(type: "int", nullable: false),
            //        Displayed = table.Column<bool>(type: "bit", nullable: false),
            //        CategoryId = table.Column<long>(type: "bigint", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Products_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserInRole",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<long>(type: "bigint", nullable: false),
            //        RoleId = table.Column<long>(type: "bigint", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserInRole", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserInRole_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserInRole_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductFeature",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<long>(type: "bigint", nullable: false),
            //        DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductFeature", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductFeature_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductImage",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<long>(type: "bigint", nullable: false),
            //        Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsRemoved = table.Column<bool>(type: "bit", nullable: false),
            //        RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductImage", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductImage_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
            //    values: new object[,]
            //    {
            //        { 1L, new DateTime(2024, 9, 19, 22, 51, 13, 635, DateTimeKind.Local).AddTicks(4811), false, "Admin", null, null },
            //        { 2L, new DateTime(2024, 9, 19, 22, 51, 13, 635, DateTimeKind.Local).AddTicks(4889), false, "Operator", null, null },
            //        { 3L, new DateTime(2024, 9, 19, 22, 51, 13, 635, DateTimeKind.Local).AddTicks(4918), false, "Customer", null, null }
            //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Category_ParentCategoryId",
        //        table: "Category",
        //        column: "ParentCategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductFeature_ProductId",
        //        table: "ProductFeature",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductImage_ProductId",
        //        table: "ProductImage",
        //        column: "ProductId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Products_CategoryId",
        //        table: "Products",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserInRole_RoleId",
        //        table: "UserInRole",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserInRole_UserId",
        //        table: "UserInRole",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Email",
        //        table: "Users",
        //        column: "Email",
        //        unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeature");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "UserInRole");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
