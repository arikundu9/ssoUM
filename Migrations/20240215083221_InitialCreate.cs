using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ssoUM.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "keys",
				columns: table => new
				{
					kid = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					type = table.Column<short>(type: "smallint", nullable: false),
					private_key = table.Column<string>(type: "character varying", nullable: false),
					public_key = table.Column<string>(type: "character varying", nullable: true),
					algo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("keys_pk", x => x.kid);
				});

			migrationBuilder.CreateTable(
				name: "jwt",
				columns: table => new
				{
					jid = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					description = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
					kid = table.Column<long>(type: "bigint", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("jwt_pk", x => x.jid);
					table.ForeignKey(
						name: "jwt_fk",
						column: x => x.kid,
						principalTable: "keys",
						principalColumn: "kid",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "app",
				columns: table => new
				{
					aid = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					redirecturl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
					jid = table.Column<long>(type: "bigint", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("app_pk", x => x.aid);
					table.ForeignKey(
						name: "app_fk",
						column: x => x.jid,
						principalTable: "jwt",
						principalColumn: "jid",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "role",
				columns: table => new
				{
					rid = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					r_pid = table.Column<long>(type: "bigint", nullable: true),
					role_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
					aid = table.Column<long>(type: "bigint", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("role_pk", x => x.rid);
					table.ForeignKey(
						name: "role_fk",
						column: x => x.r_pid,
						principalTable: "role",
						principalColumn: "rid");
					table.ForeignKey(
						name: "role_t_app_fk",
						column: x => x.aid,
						principalTable: "app",
						principalColumn: "aid",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "user",
				columns: table => new
				{
					uid = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					aid = table.Column<long>(type: "bigint", nullable: false),
					rid = table.Column<long>(type: "bigint", nullable: true),
					username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
					password_hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
					password_salt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("user_pk", x => x.uid);
					table.ForeignKey(
						name: "user_fk",
						column: x => x.aid,
						principalTable: "app",
						principalColumn: "aid",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "user_t_role_fk",
						column: x => x.rid,
						principalTable: "role",
						principalColumn: "rid");
				});

			migrationBuilder.CreateIndex(
				name: "IX_app_jid",
				table: "app",
				column: "jid");

			migrationBuilder.CreateIndex(
				name: "IX_jwt_kid",
				table: "jwt",
				column: "kid");

			migrationBuilder.CreateIndex(
				name: "IX_role_aid",
				table: "role",
				column: "aid");

			migrationBuilder.CreateIndex(
				name: "IX_role_r_pid",
				table: "role",
				column: "r_pid");

			migrationBuilder.CreateIndex(
				name: "IX_user_aid",
				table: "user",
				column: "aid");

			migrationBuilder.CreateIndex(
				name: "IX_user_rid",
				table: "user",
				column: "rid");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "user");

			migrationBuilder.DropTable(
				name: "role");

			migrationBuilder.DropTable(
				name: "app");

			migrationBuilder.DropTable(
				name: "jwt");

			migrationBuilder.DropTable(
				name: "keys");
		}
	}
}
