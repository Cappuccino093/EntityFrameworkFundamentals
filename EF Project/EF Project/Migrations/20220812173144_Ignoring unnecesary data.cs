using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfProject.Migrations;

/// <inheritdoc />
public partial class Ignoringunnecesarydata : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropForeignKey(
			name: "FK_Tasks_Categories_CategoryId",
			table: "Tasks");

		_ = migrationBuilder.DropIndex(
			name: "IX_Tasks_CategoryId",
			table: "Tasks");

		_ = migrationBuilder.DeleteData(
			table: "Tasks",
			keyColumn: "Id",
			keyValue: new Guid("4ec00255-a535-4681-a3a2-6b531d7dfeaa"));

		_ = migrationBuilder.DeleteData(
			table: "Tasks",
			keyColumn: "Id",
			keyValue: new Guid("5d2ac5a7-067b-46c0-9ae3-970da83eb9cb"));

		_ = migrationBuilder.DeleteData(
			table: "Categories",
			keyColumn: "Id",
			keyValue: new Guid("34171682-a1aa-4677-8bb9-1c8fc391d324"));

		_ = migrationBuilder.DeleteData(
			table: "Categories",
			keyColumn: "Id",
			keyValue: new Guid("fb2abee8-4434-4880-8d1a-90e3256df891"));

		_ = migrationBuilder.InsertData(
			table: "Categories",
			columns: new[] { "Id", "Description", "Name", "Weight" },
			values: new object[,]
			{
					{ new Guid("2b8c0bc2-7a2f-49cb-9a0a-66bb407fb17f"), null, "To-Do", null },
					{ new Guid("8b51488e-c03c-4ea3-b4d2-438f5c01afd1"), null, "Personal", null }
			});

		_ = migrationBuilder.InsertData(
			table: "Tasks",
			columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Priority", "Title" },
			values: new object[,]
			{
					{ new Guid("05f36d64-cf7b-4a51-a38f-4352231abc1b"), new Guid("8b51488e-c03c-4ea3-b4d2-438f5c01afd1"), new DateTime(2022, 8, 12, 11, 31, 44, 56, DateTimeKind.Local).AddTicks(7361), null, 0, "See Movie" },
					{ new Guid("10e7cd7f-e084-4c07-a111-4edab31e494a"), new Guid("2b8c0bc2-7a2f-49cb-9a0a-66bb407fb17f"), new DateTime(2022, 8, 12, 11, 31, 44, 56, DateTimeKind.Local).AddTicks(7349), null, 2, "Bills" }
			});
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DeleteData(
			table: "Categories",
			keyColumn: "Id",
			keyValue: new Guid("2b8c0bc2-7a2f-49cb-9a0a-66bb407fb17f"));

		_ = migrationBuilder.DeleteData(
			table: "Categories",
			keyColumn: "Id",
			keyValue: new Guid("8b51488e-c03c-4ea3-b4d2-438f5c01afd1"));

		_ = migrationBuilder.DeleteData(
			table: "Tasks",
			keyColumn: "Id",
			keyValue: new Guid("05f36d64-cf7b-4a51-a38f-4352231abc1b"));

		_ = migrationBuilder.DeleteData(
			table: "Tasks",
			keyColumn: "Id",
			keyValue: new Guid("10e7cd7f-e084-4c07-a111-4edab31e494a"));

		_ = migrationBuilder.InsertData(
			table: "Categories",
			columns: new[] { "Id", "Description", "Name", "Weight" },
			values: new object[,]
			{
					{ new Guid("34171682-a1aa-4677-8bb9-1c8fc391d324"), null, "Personal", null },
					{ new Guid("fb2abee8-4434-4880-8d1a-90e3256df891"), null, "To-Do", null }
			});

		_ = migrationBuilder.InsertData(
			table: "Tasks",
			columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Priority", "Title" },
			values: new object[,]
			{
					{ new Guid("4ec00255-a535-4681-a3a2-6b531d7dfeaa"), new Guid("34171682-a1aa-4677-8bb9-1c8fc391d324"), new DateTime(2022, 8, 11, 19, 43, 9, 974, DateTimeKind.Local).AddTicks(3966), null, 0, "See Movie" },
					{ new Guid("5d2ac5a7-067b-46c0-9ae3-970da83eb9cb"), new Guid("fb2abee8-4434-4880-8d1a-90e3256df891"), new DateTime(2022, 8, 11, 19, 43, 9, 974, DateTimeKind.Local).AddTicks(3951), null, 2, "Bills" }
			});

		_ = migrationBuilder.CreateIndex(
			name: "IX_Tasks_CategoryId",
			table: "Tasks",
			column: "CategoryId");

		_ = migrationBuilder.AddForeignKey(
			name: "FK_Tasks_Categories_CategoryId",
			table: "Tasks",
			column: "CategoryId",
			principalTable: "Categories",
			principalColumn: "Id",
			onDelete: ReferentialAction.Cascade);
	}
}
