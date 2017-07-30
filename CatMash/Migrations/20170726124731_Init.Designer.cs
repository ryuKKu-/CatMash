using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CatMash.Data;

namespace CatMash.Migrations
{
    [DbContext(typeof(CatMashContext))]
    [Migration("20170726124731_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Score");

                    b.Property<int>("Wins");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("CatMash.Data.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("OpponentId")
                        .IsRequired();

                    b.Property<string>("PlayerId")
                        .IsRequired();

                    b.Property<bool>("Result");

                    b.Property<int>("Score");

                    b.HasKey("HistoryId");

                    b.HasIndex("OpponentId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("CatMash.Data.History", b =>
                {
                    b.HasOne("CatMash.Data.Cat", "Opponent")
                        .WithMany("HistoriesAway")
                        .HasForeignKey("OpponentId");

                    b.HasOne("CatMash.Data.Cat", "Player")
                        .WithMany("Histories")
                        .HasForeignKey("PlayerId");
                });
        }
    }
}
