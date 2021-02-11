﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TARSTestJosue.Data;

namespace TARSTestJosue.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TARSTestJosue.Models.Component", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DateBuy")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("DolarRealBuy")
                        .HasColumnType("numeric");

                    b.Property<string>("Extra")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("LastUpdated")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Product")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Requirement")
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Version")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tb_component");
                });

            modelBuilder.Entity("TARSTestJosue.Models.Item", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ComponentId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdated")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Store")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("URL")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("tb_item");
                });

            modelBuilder.Entity("TARSTestJosue.Models.Component", b =>
                {
                    b.OwnsOne("TARSTestJosue.Models.Status", "Status", b1 =>
                        {
                            b1.Property<int>("ComponentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<string>("Color")
                                .HasColumnType("text");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Status");

                            b1.HasKey("ComponentId");

                            b1.ToTable("tb_component");

                            b1.WithOwner()
                                .HasForeignKey("ComponentId");
                        });

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TARSTestJosue.Models.Item", b =>
                {
                    b.HasOne("TARSTestJosue.Models.Component", "Component")
                        .WithMany("Prices")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TARSTestJosue.Models.Price", "Price", b1 =>
                        {
                            b1.Property<int>("ItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)");

                            b1.HasKey("ItemId");

                            b1.ToTable("tb_item");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });

                    b.Navigation("Component");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("TARSTestJosue.Models.Component", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
