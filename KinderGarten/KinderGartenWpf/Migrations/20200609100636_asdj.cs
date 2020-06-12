using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenWpf.Migrations
{
    public partial class asdj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 9, 13, 6, 35, 123, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AMWCno1OJJsNJbjOQwo2N6DwMY10CcfrxNniEsiqggBXdCAnzqiZGeQ4PHGuPsjQug==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 6, 9, 13, 3, 14, 113, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AOznAEjHgzTx+vrR7lGyRPcVzDmfDVpGxCa3XfaCmO3qI7f/aSeTvr3tD2gEp1clxQ==");
        }
    }
}
