﻿// <auto-generated />
using System;
using MeetingApp2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingApp2.Migrations
{
    [DbContext(typeof(MeetingApp2Context))]
    partial class MeetingApp2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingApp2.Models.Meeting", b =>
                {
                    b.Property<Guid>("MeetingsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MeetingType")
                        .HasColumnType("int");

                    b.Property<int?>("MeetingTypesMeetingTypeId")
                        .HasColumnType("int");

                    b.HasKey("MeetingsID");

                    b.HasIndex("MeetingTypesMeetingTypeId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("MeetingApp2.Models.MeetingItem", b =>
                {
                    b.Property<int>("MeetingItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeetingItemStatus")
                        .HasColumnType("int");

                    b.Property<int?>("MeetingItemStatusesMeetingItemStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("MeetingsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MeetingsID1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PersonResponsible")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingItemId");

                    b.HasIndex("MeetingItemStatusesMeetingItemStatusId");

                    b.HasIndex("MeetingsID1");

                    b.ToTable("MeetingItems");
                });

            modelBuilder.Entity("MeetingApp2.Models.MeetingItemStatus", b =>
                {
                    b.Property<int>("MeetingItemStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingItemStatusId");

                    b.ToTable("MeetingItemStatuses");
                });

            modelBuilder.Entity("MeetingApp2.Models.MeetingType", b =>
                {
                    b.Property<int>("MeetingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeetingTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingTypeId");

                    b.ToTable("MeetingTypes");
                });

            modelBuilder.Entity("MeetingApp2.Models.Meeting", b =>
                {
                    b.HasOne("MeetingApp2.Models.MeetingType", "MeetingTypes")
                        .WithMany()
                        .HasForeignKey("MeetingTypesMeetingTypeId");

                    b.Navigation("MeetingTypes");
                });

            modelBuilder.Entity("MeetingApp2.Models.MeetingItem", b =>
                {
                    b.HasOne("MeetingApp2.Models.MeetingItemStatus", "MeetingItemStatuses")
                        .WithMany()
                        .HasForeignKey("MeetingItemStatusesMeetingItemStatusId");

                    b.HasOne("MeetingApp2.Models.Meeting", "Meeting")
                        .WithMany("MeetingItems")
                        .HasForeignKey("MeetingsID1");

                    b.Navigation("Meeting");

                    b.Navigation("MeetingItemStatuses");
                });

            modelBuilder.Entity("MeetingApp2.Models.Meeting", b =>
                {
                    b.Navigation("MeetingItems");
                });
#pragma warning restore 612, 618
        }
    }
}
