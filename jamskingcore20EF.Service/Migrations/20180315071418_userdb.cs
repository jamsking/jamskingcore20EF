using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Service.Migrations
{
    public partial class userdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExtend",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtend", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExtend");
        }
    }
}
