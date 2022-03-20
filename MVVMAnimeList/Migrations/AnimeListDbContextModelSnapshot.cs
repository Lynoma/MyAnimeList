﻿// <auto-generated />
using MVVMAnimeList.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVVMAnimeList.Migrations
{
    [DbContext(typeof(AnimeListDbContext))]
    partial class AnimeListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("tag_id");

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

                    b.HasKey("mal_id");

                    b.ToTable("TrelloItems");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TrelloItemTagDTO", b =>
                {
                    b.Property<int>("trelloItem_tag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("tagDtotag_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("trelloItemDtomal_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("trelloItem_tag_id");

                    b.HasIndex("tagDtotag_id");

                    b.HasIndex("trelloItemDtomal_id");

                    b.ToTable("TrelloItemTags");
                });

            modelBuilder.Entity("MVVMAnimeList.DTOs.TrelloItemTagDTO", b =>
                {
                    b.HasOne("MVVMAnimeList.DTOs.TagDTO", "tagDto")
                        .WithMany()
                        .HasForeignKey("tagDtotag_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVVMAnimeList.DTOs.TrelloItemDTO", "trelloItemDto")
                        .WithMany()
                        .HasForeignKey("trelloItemDtomal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tagDto");

                    b.Navigation("trelloItemDto");
                });
#pragma warning restore 612, 618
        }
    }
}
