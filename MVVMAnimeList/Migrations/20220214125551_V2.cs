using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVMAnimeList.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_TrelloItems_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems");

            migrationBuilder.DropIndex(
                name: "IX_TrelloItems_trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems");

            migrationBuilder.DropIndex(
                name: "IX_Tags_trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems");

            migrationBuilder.DropColumn(
                name: "trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "tag_id",
                table: "TrelloItemTags",
                newName: "trelloItemDtomal_id");

            migrationBuilder.RenameColumn(
                name: "mal_id",
                table: "TrelloItemTags",
                newName: "tagDtotag_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrelloItemTags_tagDtotag_id",
                table: "TrelloItemTags",
                column: "tagDtotag_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrelloItemTags_trelloItemDtomal_id",
                table: "TrelloItemTags",
                column: "trelloItemDtomal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrelloItemTags_Tags_tagDtotag_id",
                table: "TrelloItemTags",
                column: "tagDtotag_id",
                principalTable: "Tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrelloItemTags_TrelloItems_trelloItemDtomal_id",
                table: "TrelloItemTags",
                column: "trelloItemDtomal_id",
                principalTable: "TrelloItems",
                principalColumn: "mal_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrelloItemTags_Tags_tagDtotag_id",
                table: "TrelloItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_TrelloItemTags_TrelloItems_trelloItemDtomal_id",
                table: "TrelloItemTags");

            migrationBuilder.DropIndex(
                name: "IX_TrelloItemTags_tagDtotag_id",
                table: "TrelloItemTags");

            migrationBuilder.DropIndex(
                name: "IX_TrelloItemTags_trelloItemDtomal_id",
                table: "TrelloItemTags");

            migrationBuilder.RenameColumn(
                name: "trelloItemDtomal_id",
                table: "TrelloItemTags",
                newName: "tag_id");

            migrationBuilder.RenameColumn(
                name: "tagDtotag_id",
                table: "TrelloItemTags",
                newName: "mal_id");

            migrationBuilder.AddColumn<int>(
                name: "trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrelloItems_trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems",
                column: "trelloItemTagDTOtrelloItem_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags",
                column: "trelloItemTagDTOtrelloItem_tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                table: "Tags",
                column: "trelloItemTagDTOtrelloItem_tag_id",
                principalTable: "TrelloItemTags",
                principalColumn: "trelloItem_tag_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrelloItems_TrelloItemTags_trelloItemTagDTOtrelloItem_tag_id",
                table: "TrelloItems",
                column: "trelloItemTagDTOtrelloItem_tag_id",
                principalTable: "TrelloItemTags",
                principalColumn: "trelloItem_tag_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
