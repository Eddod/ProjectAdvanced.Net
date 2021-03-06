// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAdvanced.Net.DbModels;

namespace ProjectAdvanced.Net.Migrations
{
    [DbContext(typeof(WebAppDbContext))]
    [Migration("20220406072024_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectModels.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("TblEmployees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Edwin",
                            LastName = "Westerberg",
                            PersonalNumber = "941201293"
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Test",
                            LastName = "Testsson",
                            PersonalNumber = "82314284"
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Prov",
                            LastName = "Provsson",
                            PersonalNumber = "137583589"
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Pröv",
                            LastName = "Prövsson",
                            PersonalNumber = "8491284824"
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Sara",
                            LastName = "Karlsson",
                            PersonalNumber = "853948392"
                        });
                });

            modelBuilder.Entity("ProjectModels.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("TblProjects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ProjectDescription = "Projekt1"
                        },
                        new
                        {
                            ProjectId = 2,
                            ProjectDescription = "Projekt2"
                        });
                });

            modelBuilder.Entity("ProjectModels.TimeReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<int>("WorkHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TblTimereports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 5,
                            ProjectId = 2,
                            Week = 1,
                            WorkHours = 40
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 4,
                            ProjectId = 2,
                            Week = 2,
                            WorkHours = 40
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 3,
                            ProjectId = 1,
                            Week = 3,
                            WorkHours = 50
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 5,
                            ProjectId = 1,
                            Week = 4,
                            WorkHours = 40
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 4,
                            ProjectId = 2,
                            Week = 5,
                            WorkHours = 60
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 2,
                            ProjectId = 1,
                            Week = 4,
                            WorkHours = 40
                        });
                });

            modelBuilder.Entity("ProjectModels.TimeReport", b =>
                {
                    b.HasOne("ProjectModels.Employee", "Employee")
                        .WithMany("TimeReport")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectModels.Project", "Project")
                        .WithMany("TimeReports")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
