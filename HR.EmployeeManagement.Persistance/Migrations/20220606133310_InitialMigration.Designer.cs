// <auto-generated />
using HR.EmployeeManagement.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR.EmployeeManagement.Persistance.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    [Migration("20220606133310_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HR.EmployeeManagement.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("TeamId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 100,
                            Address = "Street Red 1",
                            City = "Atlanta",
                            Email = "jac@cd.com",
                            LastName = "Doe",
                            Name = "John",
                            Phone = "12312",
                            TeamId = 1
                        },
                        new
                        {
                            EmployeeId = 101,
                            Address = "Redmong street 123",
                            City = "Texas",
                            Email = "dean@yaho.com",
                            LastName = "Jonson",
                            Name = "Don",
                            Phone = "13332",
                            TeamId = 1
                        },
                        new
                        {
                            EmployeeId = 102,
                            Address = "Washington boulevar 3",
                            City = "Washington",
                            Email = "ron123@ms.com",
                            LastName = "Joe",
                            Name = "Mike",
                            Phone = "13332",
                            TeamId = 2
                        },
                        new
                        {
                            EmployeeId = 103,
                            Address = "Washington boulevar 3",
                            City = "Washington",
                            Email = "mike@ms.com",
                            LastName = "Scot",
                            Name = "Ron",
                            Phone = "13333332",
                            TeamId = 2
                        },
                        new
                        {
                            EmployeeId = 104,
                            Address = "Washington boulevar 3",
                            City = "Washington",
                            Email = "don.jonson@hr.com",
                            LastName = "Michael",
                            Name = "Dean",
                            Phone = "24343",
                            TeamId = 2
                        },
                        new
                        {
                            EmployeeId = 105,
                            Address = "La boulevar 3",
                            City = "Los Angeles",
                            Email = "john.doe@hr.com",
                            LastName = "Jackson",
                            Name = "Jack",
                            Phone = "24343",
                            TeamId = 3
                        });
                });

            modelBuilder.Entity("HR.EmployeeManagement.Domain.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 2,
                            Description = "Team for designing UI",
                            TeamName = "User interface team"
                        },
                        new
                        {
                            TeamId = 1,
                            Description = "Team for database",
                            TeamName = "Database team"
                        },
                        new
                        {
                            TeamId = 3,
                            Description = "Team for architecture and infrastructure",
                            TeamName = "Infrastructure team"
                        });
                });

            modelBuilder.Entity("HR.EmployeeManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            Role = "administrator",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "igor",
                            Role = "user",
                            UserName = "igor"
                        },
                        new
                        {
                            Id = 3,
                            Password = "test",
                            Role = "user",
                            UserName = "test"
                        });
                });

            modelBuilder.Entity("HR.EmployeeManagement.Domain.Entities.Employee", b =>
                {
                    b.HasOne("HR.EmployeeManagement.Domain.Entities.Team", "TeamData")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
