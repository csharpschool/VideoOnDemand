using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VideoOnDemand.Data;

namespace VideoOnDemand.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170430091336_CreateTablesWithSeedData2")]
    partial class CreateTablesWithSeedData2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255);

                    b.Property<int>("InstructorId");

                    b.Property<string>("MarqueeImageUrl")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Download", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int>("ModuleId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Url")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.UserCourse", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("CourseId");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<int>("Duration");

                    b.Property<int>("ModuleId");

                    b.Property<int>("Position");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(1024);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Url")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("VideoOnDemand.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VideoOnDemand.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VideoOnDemand.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("VideoOnDemand.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Course", b =>
                {
                    b.HasOne("VideoOnDemand.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Download", b =>
                {
                    b.HasOne("VideoOnDemand.Entities.Module")
                        .WithMany("Downloads")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Module", b =>
                {
                    b.HasOne("VideoOnDemand.Entities.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.UserCourse", b =>
                {
                    b.HasOne("VideoOnDemand.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("VideoOnDemand.Entities.Video", b =>
                {
                    b.HasOne("VideoOnDemand.Entities.Module")
                        .WithMany("Videos")
                        .HasForeignKey("ModuleId");
                });
        }
    }
}
