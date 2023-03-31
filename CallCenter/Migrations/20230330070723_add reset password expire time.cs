using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallCenter.Migrations
{
    /// <inheritdoc />
    public partial class addresetpasswordexpiretime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshPasswordTime",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "RefreshPasswordTime" },
                values: new object[] { "$2b$10$rFCR/Q321W6Nj6JEVxblA.YyNPkxAsf.Y5ByG/XZq4kahMa1aNr3G", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "RefreshPasswordTime" },
                values: new object[] { "$2b$10$1eh4/x56INzB3ZJFb0XrdO0rf.3p2ESCVCWhXFuDTipdZykLgukqq", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "RefreshPasswordTime" },
                values: new object[] { "$2b$10$OnyDprrENQYkpUIMEucJte7NG3oTanfmryPrYpmbcIc7jAeNcd2Le", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "RefreshPasswordTime" },
                values: new object[] { "$2b$10$PON5TiIsP3jgbbodPfaBnOrJBsb7IroRrCPqRWrRn0geqDg446z4O", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshPasswordTime",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2b$10$JPZ8dqGU.wC4npTsMALiauAPiIXi/8bx9Ot5pZOyHzD0P543xL9RC");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2b$10$s9/NlUO73rVVre8rBc2XOelR36ctdliCsEefs2RFhh2bRcMOMy7QG");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2b$10$pBZoX4bMFK.2JyFCFAlzsO74MM7RKVDY6E67haRC78gxEKMiq/dhu");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2b$10$U1xzhcIOO3JB.t03tX1kIOXeiIh1otyf3Dihtea4NLqnFS0qfyyQ.");
        }
    }
}
