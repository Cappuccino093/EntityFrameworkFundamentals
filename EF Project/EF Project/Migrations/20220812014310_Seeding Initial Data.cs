using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfProject.Migrations;

/// <inheritdoc />
public partial class SeedingInitialData : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.AlterColumn<int>(
			name: "Priority",
			table: "Tasks",
			type: "int",
			nullable: true,
			oldClrType: typeof(int),
			oldType: "int");

		_ = migrationBuilder.AlterColumn<string>(
			name: "Description",
			table: "Tasks",
			type: "nvarchar(max)",
			nullable: true,
			oldClrType: typeof(string),
			oldType: "nvarchar(max)");

		_ = migrationBuilder.AlterColumn<int>(
			name: "Weight",
			table: "Categories",
			type: "int",
			nullable: true,
			oldClrType: typeof(int),
			oldType: "int");

		_ = migrationBuilder.AlterColumn<string>(
			name: "Description",
			table: "Categories",
			type: "nvarchar(max)",
			nullable: true,
			oldClrType: typeof(string),
			oldType: "nvarchar(max)");

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
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
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

		_ = migrationBuilder.AlterColumn<int>(
			name: "Priority",
			table: "Tasks",
			type: "int",
			nullable: false,
			defaultValue: 0,
			oldClrType: typeof(int),
			oldType: "int",
			oldNullable: true);

		_ = migrationBuilder.AlterColumn<string>(
			name: "Description",
			table: "Tasks",
			type: "nvarchar(max)",
			nullable: false,
			defaultValue: "",
			oldClrType: typeof(string),
			oldType: "nvarchar(max)",
			oldNullable: true);

		_ = migrationBuilder.AlterColumn<int>(
			name: "Weight",
			table: "Categories",
			type: "int",
			nullable: false,
			defaultValue: 0,
			oldClrType: typeof(int),
			oldType: "int",
			oldNullable: true);

		_ = migrationBuilder.AlterColumn<string>(
			name: "Description",
			table: "Categories",
			type: "nvarchar(max)",
			nullable: false,
			defaultValue: "",
			oldClrType: typeof(string),
			oldType: "nvarchar(max)",
			oldNullable: true);
	}
}
