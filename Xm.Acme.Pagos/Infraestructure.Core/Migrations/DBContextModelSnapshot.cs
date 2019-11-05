﻿// <auto-generated />
using System;
using Infraestructure.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infraestructure.Entity.Entities.AgentCrossingsEntity", b =>
                {
                    b.Property<int>("AgentCrossingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agent");

                    b.Property<string>("Business");

                    b.Property<string>("Company");

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool?>("Crossed");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime?>("FinalValidity");

                    b.Property<bool?>("FullPaymentDebts");

                    b.Property<DateTime>("InitialValidity");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<int>("TypeCrossingId");

                    b.Property<int>("Value");

                    b.HasKey("AgentCrossingId");

                    b.HasIndex("TypeCrossingId");

                    b.ToTable("AgentCrossings","Crossing");
                });

            modelBuilder.Entity("Infraestructure.Entity.Entities.TypeCrossingsEntity", b =>
                {
                    b.Property<int>("TypeCrossingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("Enable");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name");

                    b.HasKey("TypeCrossingId");

                    b.ToTable("TypeCrossings","Crossing");
                });

            modelBuilder.Entity("Infraestructure.Entity.Entities.AgentCrossingsEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Entities.TypeCrossingsEntity", "TypeCrossingsEntity")
                        .WithMany("AgentCrossingsEntities")
                        .HasForeignKey("TypeCrossingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
