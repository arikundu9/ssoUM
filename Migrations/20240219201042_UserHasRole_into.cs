using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ssoUM.Migrations
{
	/// <inheritdoc />
	public partial class UserHasRole_into : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "user_t_role_fk",
				table: "user");

			migrationBuilder.DropIndex(
				name: "IX_user_rid",
				table: "user");

			migrationBuilder.DropColumn(
				name: "rid",
				table: "user");

			migrationBuilder.AlterColumn<string>(
				name: "app_name",
				table: "app",
				type: "character(30)",
				fixedLength: true,
				maxLength: 30,
				nullable: false,
				defaultValueSql: "''::bpchar",
				oldClrType: typeof(string),
				oldType: "character(30)",
				oldFixedLength: true,
				oldMaxLength: 30);

			migrationBuilder.CreateTable(
				name: "user_has_role",
				columns: table => new
				{
					mapping_id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					uid = table.Column<long>(type: "bigint", nullable: false),
					rid = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("user_has_role_pk", x => x.mapping_id);
					table.ForeignKey(
						name: "user_has_role_role_fk",
						column: x => x.rid,
						principalTable: "role",
						principalColumn: "rid");
					table.ForeignKey(
						name: "user_has_role_user_fk",
						column: x => x.uid,
						principalTable: "user",
						principalColumn: "uid");
				});

			migrationBuilder.CreateIndex(
				name: "IX_user_has_role_rid",
				table: "user_has_role",
				column: "rid");

			migrationBuilder.CreateIndex(
				name: "IX_user_has_role_uid",
				table: "user_has_role",
				column: "uid");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "user_has_role");

			migrationBuilder.AddColumn<long>(
				name: "rid",
				table: "user",
				type: "bigint",
				nullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "app_name",
				table: "app",
				type: "character(30)",
				fixedLength: true,
				maxLength: 30,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "character(30)",
				oldFixedLength: true,
				oldMaxLength: 30,
				oldDefaultValueSql: "''::bpchar");

			migrationBuilder.CreateIndex(
				name: "IX_user_rid",
				table: "user",
				column: "rid");

			migrationBuilder.AddForeignKey(
				name: "user_t_role_fk",
				table: "user",
				column: "rid",
				principalTable: "role",
				principalColumn: "rid");
		}
	}
}
