using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVMAnimeList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrelloItemTags",
                columns: table => new
                {
                    trelloItem_tag_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tag_id = table.Column<int>(type: "INTEGER", nullable: false),
                    mal_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrelloItemTags", x => x.trelloItem_tag_id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    color = table.Column<string>(type: "TEXT", nullable: false),
                    trelloItemTagDTOtrelloItem_tag_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_Tags_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                        column: x => x.trelloItemTagDTOtrelloItem_tag_id,
                        principalTable: "TrelloItemTags",
                        principalColumn: "trelloItem_tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrelloItems",
                columns: table => new
                {
                    mal_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    id_list = table.Column<int>(type: "INTEGER", nullable: false),
                    trelloItemTagDTOtrelloItem_tag_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrelloItems", x => x.mal_id);
                    table.ForeignKey(
                        name: "FK_TrelloItems_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                        column: x => x.trelloItemTagDTOtrelloItem_tag_id,
                        principalTable: "TrelloItemTags",
                        principalColumn: "trelloItem_tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags",
                column: "trelloItemTagDTOtrelloItem_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrelloItems_trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems",
                column: "trelloItemTagDTOtrelloItem_tag_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TrelloItems");

            migrationBuilder.DropTable(
                name: "TrelloItemTags");
        }
    }
}
