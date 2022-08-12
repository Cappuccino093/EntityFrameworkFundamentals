using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfProject.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.CreateTable(
			name: "Categories",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
				Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
			},
			constraints: table => table.PrimaryKey("PK_Categories", x => x.Id));

		_ = migrationBuilder.CreateTable(
			name: "Tasks",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
				Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Priority = table.Column<int>(type: "int", nullable: false),
				CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Tasks", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_Tasks_Categories_CategoryId",
					column: x => x.CategoryId,
					principalTable: "Categories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateIndex(
			name: "IX_Tasks_CategoryId",
			table: "Tasks",
			column: "CategoryId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "Tasks");

		_ = migrationBuilder.DropTable(
			name: "Categories");
	}
}
