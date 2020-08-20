﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SNGJOB;

namespace SNGJOB.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200817114753_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SNGJOB.Models.UserModels.Allie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid?>("as_allie_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("as_user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("as_allie_id");

                    b.HasIndex("as_user_id");

                    b.ToTable("allies");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("contactId")
                        .HasColumnName("cs_contact_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("cs_user_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("name")
                        .HasColumnName("cs_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("cs_user_id");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("us_id")
                        .HasColumnType("char(36)");

                    b.Property<long>("creationDate")
                        .HasColumnName("us_creation_date")
                        .HasColumnType("bigint");

                    b.Property<long>("deleteTimeout")
                        .HasColumnName("us_delete_timeout")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .HasColumnName("us_email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnName("us_password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("passwordToken")
                        .HasColumnName("us_password_token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phone")
                        .HasColumnName("us_phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("type")
                        .HasColumnName("us_type")
                        .HasColumnType("int");

                    b.Property<long>("updateDate")
                        .HasColumnName("us_update_date")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DateOfBirth")
                        .HasColumnName("ud_date_of_birth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("address")
                        .HasColumnName("ud_address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("city")
                        .HasColumnName("ud_city")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("country")
                        .HasColumnName("ud_country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("emails")
                        .HasColumnName("ud_emails")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("firstName")
                        .HasColumnName("ud_first_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("fullName")
                        .HasColumnName("ud_full_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte>("interests")
                        .HasColumnName("ud_interests")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("lastName")
                        .HasColumnName("ud_last_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("middleName")
                        .HasColumnName("ud_middle_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("photos")
                        .HasColumnName("ud_photos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("state")
                        .HasColumnName("ud_state")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ud_id")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("ud_id");

                    b.ToTable("user_details");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserEducation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnName("ue_address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnName("ue_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("type")
                        .HasColumnName("ue_type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ue_user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("ue_user_id");

                    b.ToTable("user_educations");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserEmployment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnName("uet_address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("area")
                        .HasColumnName("uet_area")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnName("uet_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phone")
                        .HasColumnName("uet_phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("uet_user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("uet_user_id");

                    b.ToTable("user_employments");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.Allie", b =>
                {
                    b.HasOne("SNGJOB.Models.UserModels.User", "allie")
                        .WithMany()
                        .HasForeignKey("as_allie_id");

                    b.HasOne("SNGJOB.Models.UserModels.User", "user")
                        .WithMany()
                        .HasForeignKey("as_user_id");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.Contact", b =>
                {
                    b.HasOne("SNGJOB.Models.UserModels.User", "user")
                        .WithMany()
                        .HasForeignKey("cs_user_id");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserDetail", b =>
                {
                    b.HasOne("SNGJOB.Models.UserModels.User", "user")
                        .WithMany()
                        .HasForeignKey("ud_id");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserEducation", b =>
                {
                    b.HasOne("SNGJOB.Models.UserModels.User", "user")
                        .WithMany()
                        .HasForeignKey("ue_user_id");
                });

            modelBuilder.Entity("SNGJOB.Models.UserModels.UserEmployment", b =>
                {
                    b.HasOne("SNGJOB.Models.UserModels.User", "user")
                        .WithMany()
                        .HasForeignKey("uet_user_id");
                });
#pragma warning restore 612, 618
        }
    }
}
