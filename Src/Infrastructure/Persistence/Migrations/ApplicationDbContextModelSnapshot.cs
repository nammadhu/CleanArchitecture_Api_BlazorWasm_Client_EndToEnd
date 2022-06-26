﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ToDoListDomain.Entities.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("Domain.ToDoListDomain.Entities.TodoItem", b =>
                {
                    b.OwnsOne("Domain.ToDoListDomain.ValueObjects.ColorValueObject", "Color", b1 =>
                        {
                            b1.Property<long>("TodoItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Color");

                            b1.HasKey("TodoItemId");

                            b1.ToTable("TodoItems");

                            b1.WithOwner()
                                .HasForeignKey("TodoItemId");
                        });

                    b.OwnsOne("Domain.ToDoListDomain.ValueObjects.DescriptionValueObject", "Description", b1 =>
                        {
                            b1.Property<long>("TodoItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("TodoItemId");

                            b1.ToTable("TodoItems");

                            b1.WithOwner()
                                .HasForeignKey("TodoItemId");
                        });

                    b.OwnsOne("Domain.ToDoListDomain.ValueObjects.TimeTodoValueObject", "TimeTodo", b1 =>
                        {
                            b1.Property<long>("TodoItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2")
                                .HasColumnName("TimeTodo");

                            b1.HasKey("TodoItemId");

                            b1.ToTable("TodoItems");

                            b1.WithOwner()
                                .HasForeignKey("TodoItemId");
                        });

                    b.OwnsOne("Domain.ToDoListDomain.ValueObjects.TitleValueObject", "Title", b1 =>
                        {
                            b1.Property<long>("TodoItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Title");

                            b1.HasKey("TodoItemId");

                            b1.ToTable("TodoItems");

                            b1.WithOwner()
                                .HasForeignKey("TodoItemId");
                        });

                    b.Navigation("Color");

                    b.Navigation("Description");

                    b.Navigation("TimeTodo");

                    b.Navigation("Title");
                });
#pragma warning restore 612, 618
        }
    }
}
