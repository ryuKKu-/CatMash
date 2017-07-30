using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CatMash.Data;

namespace CatMash.Migrations
{
    [DbContext(typeof(CatMashContext))]
    partial class CatMashContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CatMash.Data.Cat", b =>
                {
                    b.Property<string>("CatId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Looses");

                    b.Property<string>("Name");

                    b.Property<int>("Rating");

                    b.Property<int>("Wins");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("CatMash.Data.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CatId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("MatchId");

                    b.Property<int>("Rating");

                    b.HasKey("HistoryId");

                    b.HasIndex("CatId");

                    b.HasIndex("MatchId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("CatMash.Data.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CatAId");

                    b.Property<string>("CatBId");

                    b.Property<int>("RatingA");

                    b.Property<int>("RatingB");

                    b.Property<int>("Result");

                    b.HasKey("MatchId");

                    b.HasIndex("CatAId");

                    b.HasIndex("CatBId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("CatMash.Data.History", b =>
                {
                    b.HasOne("CatMash.Data.Cat", "Cat")
                        .WithMany("Histories")
                        .HasForeignKey("CatId");

                    b.HasOne("CatMash.Data.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CatMash.Data.Match", b =>
                {
                    b.HasOne("CatMash.Data.Cat", "CatA")
                        .WithMany()
                        .HasForeignKey("CatAId");

                    b.HasOne("CatMash.Data.Cat", "CatB")
                        .WithMany()
                        .HasForeignKey("CatBId");
                });
        }
    }
}
