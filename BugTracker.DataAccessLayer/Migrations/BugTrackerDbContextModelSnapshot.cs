﻿// <auto-generated />
using System;
using BugTracker.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugTracker.DataAccessLayer.Migrations
{
    [DbContext(typeof(BugTrackerDbContext))]
    partial class BugTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.TaskEntity<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Estimate")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignToId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignToId = 1,
                            Date = new DateTime(2022, 7, 12, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "Unable to connect to database from app",
                            Estimate = 20f,
                            Name = "Fix connection to DB",
                            Priority = 2,
                            ProjectId = 1,
                            Status = 2,
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            AssignToId = 3,
                            Date = new DateTime(2022, 8, 10, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "Login button doesn't allow users to login",
                            Estimate = 8f,
                            Name = "Button doesn't work",
                            Priority = 3,
                            ProjectId = 2,
                            Status = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            AssignToId = 4,
                            Date = new DateTime(2022, 8, 10, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "A search box not responding to a user’s query",
                            Estimate = 10f,
                            Name = "Bug in search box",
                            Priority = 2,
                            ProjectId = 2,
                            Status = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            AssignToId = 2,
                            Date = new DateTime(2022, 8, 11, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "Assigning a value to the wrong variable",
                            Estimate = 1f,
                            Name = "Wrong variable",
                            Priority = 1,
                            ProjectId = 1,
                            Status = 4,
                            Type = 2
                        },
                        new
                        {
                            Id = 5,
                            AssignToId = 3,
                            Date = new DateTime(2022, 8, 5, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "Verify whether all the input fields are accepting appropriate inputs",
                            Estimate = 16f,
                            Name = "Check code",
                            Priority = 1,
                            ProjectId = 1,
                            Status = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            AssignToId = 3,
                            Date = new DateTime(2022, 8, 5, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "Validate buttons for functionality",
                            Estimate = 16f,
                            Name = "Check code",
                            Priority = 1,
                            ProjectId = 1,
                            Status = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 7,
                            AssignToId = 1,
                            Date = new DateTime(2022, 8, 11, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "The end user clicks the “Save” button, but their entered data isn’t saved",
                            Estimate = 8f,
                            Name = "Functional error",
                            Priority = 3,
                            ProjectId = 2,
                            Status = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            AssignToId = 4,
                            Date = new DateTime(2022, 8, 12, 10, 35, 10, 0, DateTimeKind.Unspecified),
                            Description = "The calculation has a data type mismatch",
                            Estimate = 4f,
                            Name = "Calculation error",
                            Priority = 2,
                            ProjectId = 2,
                            Status = 1,
                            Type = 2
                        });
                });

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.ProjectEntity<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This website would feature an easily updatable shopping cart and other features to provide convenience to local shoppers.",
                            Name = "Website for shop"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Develop system for restaurant",
                            Name = "Restaurant System"
                        });
                });

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.UserEntity<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tom@gmail.com",
                            Name = "Tom",
                            Password = "tomsuper"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@gmail.com",
                            Name = "Bob",
                            Password = "bobhere"
                        },
                        new
                        {
                            Id = 3,
                            Email = "mary@gmail.com",
                            Name = "Mary",
                            Password = "mary1234"
                        },
                        new
                        {
                            Id = 4,
                            Email = "suse@gmail.com",
                            Name = "Suse",
                            Password = "onesuse"
                        });
                });

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.UserProjectEntity<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProjectEntityId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("UserProjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProjectId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ProjectId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            ProjectId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            ProjectId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            ProjectId = 2,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.TaskEntity<int>", b =>
                {
                    b.HasOne("BugTracker.DataAccessLayer.Entities.UserEntity<int>", "AssignTo")
                        .WithMany()
                        .HasForeignKey("AssignToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.DataAccessLayer.Entities.ProjectEntity<int>", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignTo");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BugTracker.DataAccessLayer.Entities.UserProjectEntity<int>", b =>
                {
                    b.HasOne("BugTracker.DataAccessLayer.Entities.ProjectEntity<int>", "ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectEntityId");

                    b.HasOne("BugTracker.DataAccessLayer.Entities.UserEntity<int>", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId");

                    b.Navigation("ProjectEntity");

                    b.Navigation("UserEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
