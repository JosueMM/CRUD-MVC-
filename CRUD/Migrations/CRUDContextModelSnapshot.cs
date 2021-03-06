﻿// <auto-generated />
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CRUD.Migrations
{
    [DbContext(typeof(CRUDContext))]
    partial class CRUDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("CRUD.Models.CarModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeId");

                    b.Property<int>("cylinders");

                    b.Property<string>("model");

                    b.Property<int>("year");

                    b.HasKey("id");

                    b.HasIndex("MakeId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CRUD.Models.MakeModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("CRUD.Models.CarModel", b =>
                {
                    b.HasOne("CRUD.Models.MakeModel", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
