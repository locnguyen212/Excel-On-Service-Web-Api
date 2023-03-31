using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallCenter.Migrations
{
    /// <inheritdoc />
    public partial class addtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshToken", "RefreshTokenExpireTime", "ResetPasswordToken", "Token" },
                values: new object[] { "$2b$10$JPZ8dqGU.wC4npTsMALiauAPiIXi/8bx9Ot5pZOyHzD0P543xL9RC", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshToken", "RefreshTokenExpireTime", "ResetPasswordToken", "Token" },
                values: new object[] { "$2b$10$s9/NlUO73rVVre8rBc2XOelR36ctdliCsEefs2RFhh2bRcMOMy7QG", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "RefreshToken", "RefreshTokenExpireTime", "ResetPasswordToken", "Token" },
                values: new object[] { "$2b$10$pBZoX4bMFK.2JyFCFAlzsO74MM7RKVDY6E67haRC78gxEKMiq/dhu", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "RefreshToken", "RefreshTokenExpireTime", "ResetPasswordToken", "Token" },
                values: new object[] { "$2b$10$U1xzhcIOO3JB.t03tX1kIOXeiIh1otyf3Dihtea4NLqnFS0qfyyQ.", null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2b$10$WdSJuVJt9HAPbapmoiNgf.TuDYeawnedE2o/vodTPCxnS0Dh.wPeq");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2b$10$QjzVM9Pxb.GGCd.u9W3cOOeLNxRwrV0z8cgDbB62rNoxi2u4Z/E9O");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2b$10$iPCqcg7Pzes0Dz28tvsqq.ZGOS/Oy0jhSQVbBFNSTzhlmcQtwN6V.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2b$10$/Cjs5jSYkAklLCr6Of2CyeLek9FRXHLvgXfWFVEAzBcR5kF2RLqkG");
        }
    }
}
