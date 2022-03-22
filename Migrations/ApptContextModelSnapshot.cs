﻿// <auto-generated />
using LaytonTemple.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaytonTemple.Migrations
{
    [DbContext(typeof(ApptContext))]
    partial class ApptContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("LaytonTemple.Models.AvailableTimes", b =>
                {
                    b.Property<string>("TimeSlot")
                        .HasColumnType("TEXT");

                    b.HasKey("TimeSlot");

                    b.ToTable("AvailableTimes");
                });

            modelBuilder.Entity("LaytonTemple.Models.GroupInfo", b =>
                {
                    b.Property<string>("groupName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeSlot")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("groupSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("groupName");

                    b.HasIndex("TimeSlot");

                    b.ToTable("GroupInfo");
                });

            modelBuilder.Entity("LaytonTemple.Models.ViewModels.GroupView", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TimeSlot")
                        .HasColumnType("TEXT");

                    b.Property<string>("groupinfogroupName")
                        .HasColumnType("TEXT");

                    b.HasKey("GroupID");

                    b.HasIndex("TimeSlot");

                    b.HasIndex("groupinfogroupName");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("LaytonTemple.Models.GroupInfo", b =>
                {
                    b.HasOne("LaytonTemple.Models.AvailableTimes", "timeslot")
                        .WithMany()
                        .HasForeignKey("TimeSlot");
                });

            modelBuilder.Entity("LaytonTemple.Models.ViewModels.GroupView", b =>
                {
                    b.HasOne("LaytonTemple.Models.AvailableTimes", "timeslot")
                        .WithMany()
                        .HasForeignKey("TimeSlot");

                    b.HasOne("LaytonTemple.Models.GroupInfo", "groupinfo")
                        .WithMany()
                        .HasForeignKey("groupinfogroupName");
                });
#pragma warning restore 612, 618
        }
    }
}
