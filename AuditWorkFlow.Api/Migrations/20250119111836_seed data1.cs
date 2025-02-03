using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuditWorkFlow.Api.Migrations
{
    /// <inheritdoc />
    public partial class seeddata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CountryCode", "Email", "FirstName", "LastName", "PanNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("33bbc9f2-869d-47a7-8d90-d2b533b60f48"), "+91", "prad@gmail.com", "Pradeep", "Gandham", "testpan001", "9292929292" },
                    { new Guid("f51fdf1b-aee9-441f-9ed5-1877ac407cc9"), "+91", "prav@gmail.com", "Praveen", "Gandham", "testpan002", "898989898" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33bbc9f2-869d-47a7-8d90-d2b533b60f48"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f51fdf1b-aee9-441f-9ed5-1877ac407cc9"));
        }
    }
}
