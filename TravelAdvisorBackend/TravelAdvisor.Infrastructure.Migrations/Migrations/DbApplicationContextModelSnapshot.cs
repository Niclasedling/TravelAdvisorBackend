﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAdvisor.Infrastructure.Migrations.Data;

namespace TravelAdvisor.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(DbApplicationContext))]
    partial class DbApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.Attraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attractions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("514fae50-43a7-4958-9abd-c549817b9414"),
                            Address = "Stockholm Södra",
                            City = "Stockholm",
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Stockholms södra station är en överbyggd järnvägsstation på Västra stambanan i stadsdelen Södermalm i centrala Stockholm. ",
                            Image = "",
                            Latitude = 45.0,
                            Longitude = 54.0,
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hamnen"
                        },
                        new
                        {
                            Id = new Guid("252e9eea-9f1e-4fe2-bbf2-bcc17d1df943"),
                            Address = "Berlin Norra",
                            City = "Berlin",
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Inräknat förorter har staden omkring 4,6 miljoner invånare och hela storstadsregionen 6,1 miljoner. ",
                            Image = "",
                            Latitude = 45.0,
                            Longitude = 54.0,
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Shopping Center"
                        },
                        new
                        {
                            Id = new Guid("e0044d7a-3b3b-4a10-b67c-d85b2181fbe9"),
                            Address = "Oslo Centrum",
                            City = "Oslo",
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Oslo, från 1624 till 1925 Kristiania, äldst Anslo/Ásló/Ósló, är Norges huvudstad och administrativt är Oslo kommun ett eget fylke, med drygt 690 000 invånare. ",
                            Image = "",
                            Latitude = 45.0,
                            Longitude = 54.0,
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Oslo Centrum"
                        },
                        new
                        {
                            Id = new Guid("9b6cd306-a29f-40f5-9ba6-25906164d849"),
                            Address = "Prag Centrum Norra",
                            City = "Prag",
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Prag är huvudstad och största stad i Tjeckien samt är belägen vid floden Moldau.",
                            Image = "",
                            Latitude = 45.0,
                            Longitude = 54.0,
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Prag Centrum Norra"
                        },
                        new
                        {
                            Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Address = "Rom Colosseum",
                            City = "Rom",
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Bygget som slutfördes av hans son Titus",
                            Image = "",
                            Latitude = 45.0,
                            Longitude = 54.0,
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rom Colosseum"
                        });
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CommentCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttractionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AttractionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.ThumbInteraction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasLiked")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("ThumbInteractions");
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d157d49-58ca-4760-9fe1-7917fb8189da"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Pontus.Bjornfot@outlook.com",
                            FirstName = "Pontus",
                            LastName = "Bjornfot",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "PB"
                        },
                        new
                        {
                            Id = new Guid("7a2dcb8d-2195-4b41-a4d0-875c6ebcf1e8"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Robin.Edin@gmail.com",
                            FirstName = "Robin",
                            LastName = "Robin",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "RR"
                        },
                        new
                        {
                            Id = new Guid("ab731f94-c0d5-4246-a4f6-8245c723d72c"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Alex.Stenberg@gmail.com",
                            FirstName = "Alex",
                            LastName = "Stenberg",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "AS"
                        },
                        new
                        {
                            Id = new Guid("ece1da1c-6263-47e7-c36a-08d8911e42f9"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Jens.Svensson@gmail.com",
                            FirstName = "Jens",
                            LastName = "Svensson",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "JS"
                        },
                        new
                        {
                            Id = new Guid("72898113-5015-44ed-9cc2-57382b5cd7f2"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Johan.Andersson@gmail.com",
                            FirstName = "Johan",
                            LastName = "Andersson",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "JA"
                        },
                        new
                        {
                            Id = new Guid("109b6e0a-a64a-4feb-f16c-e68926ab2658"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Mattias.Andersson@gmail.com",
                            FirstName = "Mattias",
                            LastName = "Andersson",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "MA"
                        },
                        new
                        {
                            Id = new Guid("4b3f3998-c612-4b5f-9994-887ba7496a21"),
                            Created = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Nicki.Edling@gmail.com",
                            FirstName = "Nicki",
                            LastName = "Edling",
                            Modified = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "????a??.?5?]z=?8w=.?s??>~N?Y",
                            UserName = "NE"
                        });
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.Comment", b =>
                {
                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.Review", b =>
                {
                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.Attraction", "Attraction")
                        .WithMany()
                        .HasForeignKey("AttractionId");

                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Attraction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAdvisor.Infrastructure.Migrations.Models.ThumbInteraction", b =>
                {
                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.HasOne("TravelAdvisor.Infrastructure.Migrations.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Review");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
