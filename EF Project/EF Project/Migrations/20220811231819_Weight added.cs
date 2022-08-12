using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfProject.Migrations;

/// <inheritdoc />
public partial class Weightadded : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.AddColumn<int>(
			name: "Weight",
			table: "Categories",
			type: "int",
			nullable: false,
			defaultValue: 0);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropColumn(
			name: "Weight",
			table: "Categories");
	}
}
