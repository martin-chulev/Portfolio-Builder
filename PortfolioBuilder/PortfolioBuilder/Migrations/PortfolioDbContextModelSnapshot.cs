﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioBuilder.Data;

namespace PortfolioBuilder.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    partial class PortfolioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PortfolioBuilder.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DomainId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Domain", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geolocations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.ProjectSubskill", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubskillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.HasKey("ProjectId", "SubskillId");

                    b.HasIndex("SubskillId");

                    b.ToTable("ProjectSkills");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Resource", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SkillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubskillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SkillId");

                    b.HasIndex("SubskillId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Skill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubcategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Subcategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Subskill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Subskill");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Category", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Domain", null)
                        .WithMany("Categories")
                        .HasForeignKey("DomainId");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.ProjectSubskill", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Project", "Project")
                        .WithMany("InvolvedSkills")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioBuilder.Models.Subskill", "Subskill")
                        .WithMany("RelatedProjects")
                        .HasForeignKey("SubskillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Resource", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Project", null)
                        .WithMany("References")
                        .HasForeignKey("ProjectId");

                    b.HasOne("PortfolioBuilder.Models.Skill", null)
                        .WithMany("Resources")
                        .HasForeignKey("SkillId");

                    b.HasOne("PortfolioBuilder.Models.Subskill", null)
                        .WithMany("Resources")
                        .HasForeignKey("SubskillId");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Skill", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Subcategory", null)
                        .WithMany("Skills")
                        .HasForeignKey("SubcategoryId");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Subcategory", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Category", null)
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("PortfolioBuilder.Models.Subskill", b =>
                {
                    b.HasOne("PortfolioBuilder.Models.Skill", null)
                        .WithMany("Subskills")
                        .HasForeignKey("SkillId");
                });
#pragma warning restore 612, 618
        }
    }
}
