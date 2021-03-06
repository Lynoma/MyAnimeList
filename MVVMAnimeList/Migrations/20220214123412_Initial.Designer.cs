// <auto-generated />
using MVVMAnimeList.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVVMAnimeList.Migrations
{
    [DbContext(typeof(AnimeListDbContext))]
    [Migration("20220214123412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("MVVMAnimeList.DTOs.TagDTO", b =>
                {
                    b.Property<int>("tag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("trelloItemTagDTOtrelloItem_tag_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("tag_id");

                    b.HasIndex("trelloItemTagDTOtrelloItem_tag_id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TrelloItemDTO", b =>
                {
                    b.Property<int>("mal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("id_list")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.Property<int>("trelloItemTagDTOtrelloItem_tag_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("mal_id");

                    b.HasIndex("trelloItemTagDTOtrelloItem_tag_id");

                    b.ToTable("TrelloItems");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TrelloItemTagDTO", b =>
                {
                    b.Property<int>("trelloItem_tag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("mal_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tag_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("trelloItem_tag_id");

                    b.ToTable("TrelloItemTags");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TagDTO", b =>
                {
                    b.HasOne("MVVMAnimeList.DTOs.TrelloItemTagDTO", "trelloItemTagDTO")
                        .WithMany()
                        .HasForeignKey("trelloItemTagDTOtrelloItem_tag_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trelloItemTagDTO");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TrelloItemDTO", b =>
                {
                    b.HasOne("MVVMAnimeList.DTOs.TrelloItemTagDTO", "trelloItemTagDTO")
                        .WithMany()
                        .HasForeignKey("trelloItemTagDTOtrelloItem_tag_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trelloItemTagDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
