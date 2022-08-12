using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.DataAccessLayer.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This website would feature an easily updatable shopping cart and other features to provide convenience to local shoppers.", "Website for shop" },
                    { 2, "Develop system for restaurant", "Restaurant System" }
                });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "Id", "ProjectEntityId", "ProjectId", "UserEntityId", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, null, 1 },
                    { 2, null, 1, null, 2 },
                    { 3, null, 1, null, 3 },
                    { 4, null, 2, null, 1 },
                    { 5, null, 2, null, 3 },
                    { 6, null, 2, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "tom@gmail.com", "Tom", "tomsuper" },
                    { 2, "bob@gmail.com", "Bob", "bobhere" },
                    { 3, "mary@gmail.com", "Mary", "mary1234" },
                    { 4, "suse@gmail.com", "Suse", "onesuse" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "AssignToId", "Date", "Description", "Estimate", "Name", "Priority", "ProjectId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 12, 10, 35, 10, 0, DateTimeKind.Unspecified), "Unable to connect to database from app", 20f, "Fix connection to DB", 2, 1, 2, 2 },
                    { 7, 1, new DateTime(2022, 8, 11, 10, 35, 10, 0, DateTimeKind.Unspecified), "The end user clicks the “Save” button, but their entered data isn’t saved", 8f, "Functional error", 3, 2, 1, 2 },
                    { 4, 2, new DateTime(2022, 8, 11, 10, 35, 10, 0, DateTimeKind.Unspecified), "Assigning a value to the wrong variable", 1f, "Wrong variable", 1, 1, 4, 2 },
                    { 2, 3, new DateTime(2022, 8, 10, 10, 35, 10, 0, DateTimeKind.Unspecified), "Login button doesn't allow users to login", 8f, "Button doesn't work", 3, 2, 1, 2 },
                    { 5, 3, new DateTime(2022, 8, 5, 10, 35, 10, 0, DateTimeKind.Unspecified), "Verify whether all the input fields are accepting appropriate inputs", 16f, "Check code", 1, 1, 1, 1 },
                    { 6, 3, new DateTime(2022, 8, 5, 10, 35, 10, 0, DateTimeKind.Unspecified), "Validate buttons for functionality", 16f, "Check code", 1, 1, 5, 1 },
                    { 3, 4, new DateTime(2022, 8, 10, 10, 35, 10, 0, DateTimeKind.Unspecified), "A search box not responding to a user’s query", 10f, "Bug in search box", 2, 2, 1, 2 },
                    { 8, 4, new DateTime(2022, 8, 12, 10, 35, 10, 0, DateTimeKind.Unspecified), "The calculation has a data type mismatch", 4f, "Calculation error", 2, 2, 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserProjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
