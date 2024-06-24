﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT_Auth.Data;

#nullable disable

namespace TT_Auth.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624112654_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.ApprovalRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("LeaveRequestId");

                    b.ToTable("ApprovalRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApproverId = 2,
                            Comment = "Enjoy your vacation!",
                            LeaveRequestId = 1,
                            Status = "Approved"
                        },
                        new
                        {
                            Id = 2,
                            ApproverId = 1,
                            Comment = "Get well soon!",
                            LeaveRequestId = 2,
                            Status = "Pending"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("OutOfOfficeBalance")
                        .HasColumnType("real");

                    b.Property<int?>("PeoplePartnerId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdivision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserInfoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PeoplePartnerId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserInfoId")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            OutOfOfficeBalance = 5f,
                            Photo = "photo_url_3",
                            Position = "Analyst",
                            RoleId = 2,
                            Status = "Active",
                            Subdivision = "Marketing",
                            UserInfoId = "2"
                        },
                        new
                        {
                            Id = 1,
                            OutOfOfficeBalance = 10f,
                            Photo = "photo_url_1",
                            Position = "Developer",
                            RoleId = 2,
                            Status = "Active",
                            Subdivision = "IT",
                            UserInfoId = "1"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.LeaveRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbsenceReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbsenceReason = "Vacation",
                            Comment = "Annual vacation",
                            EmployeeId = 1,
                            EndDate = new DateTime(2024, 7, 4, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6500),
                            StartDate = new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6452),
                            Status = "New"
                        },
                        new
                        {
                            Id = 2,
                            AbsenceReason = "Medical",
                            Comment = "Medical leave",
                            EmployeeId = 2,
                            EndDate = new DateTime(2024, 6, 29, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6507),
                            StartDate = new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6506),
                            Status = "New"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionName = "Read"
                        },
                        new
                        {
                            Id = 2,
                            PermissionName = "Write"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Project A description",
                            EndDate = new DateTime(2024, 12, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6516),
                            ProjectManagerId = 1,
                            ProjectType = "Internal",
                            StartDate = new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6515),
                            Status = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Project B description",
                            EndDate = new DateTime(2024, 9, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6525),
                            ProjectManagerId = 2,
                            ProjectType = "External",
                            StartDate = new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6524),
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrator role with full permissions",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Regular user role with limited permissions",
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8be6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
                            Email = "alex.smith@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            PasswordHash = "AQAAAAEAACcQAAAAEIJJR3+K7G9QXmJH5Nl5G5RZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==",
                            PhoneNumber = "1231231234",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ABSJ6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
                            TwoFactorEnabled = false,
                            UserName = "alex.smith"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
                            Email = "john.doe@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            PasswordHash = "AQAAAAEAACcQAAAAEBaKxU/EG+u0C5pW/VsH1jRZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "JBSY6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
                            TwoFactorEnabled = false,
                            UserName = "john.doe"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT_Auth.Models.Entity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT_Auth.Models.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.ApprovalRequest", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.Employee", "Approver")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TT_Auth.Models.Entity.LeaveRequests", "LeaveRequest")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("LeaveRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("LeaveRequest");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Employee", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.Employee", "PeoplePartner")
                        .WithMany("PeoplePartners")
                        .HasForeignKey("PeoplePartnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TT_Auth.Models.Entity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT_Auth.Models.Entity.UserInfo", "UserInfo")
                        .WithOne("Employee")
                        .HasForeignKey("TT_Auth.Models.Entity.Employee", "UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeoplePartner");

                    b.Navigation("Role");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.LeaveRequests", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Project", b =>
                {
                    b.HasOne("TT_Auth.Models.Entity.Employee", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.Employee", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("LeaveRequests");

                    b.Navigation("PeoplePartners");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.LeaveRequests", b =>
                {
                    b.Navigation("ApprovalRequests");
                });

            modelBuilder.Entity("TT_Auth.Models.Entity.UserInfo", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
