using MainBoilerPlate.Models;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Contexts
{
    public class MainContext : IdentityDbContext<UserApp, RoleApp, Guid>
    {
        public DbSet<UserApp> Users { get; set; }
        public DbSet<RoleApp> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<StatusAccount> Statuses { get; set; }
        public DbSet<TypeSlot> TypeSlots { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public MainContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Les noms des tables dans la base de données
            builder.Entity<UserApp>().ToTable("Users");
            builder.Entity<RoleApp>().ToTable("Roles");
            builder.Entity<Gender>().ToTable("Genders");
            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<TypeSlot>().ToTable("TypeSlots");
            builder.Entity<Slot>().ToTable("Slots");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Booking>().ToTable("Bookings");
            builder.Entity<RefreshToken>().ToTable("RefreshTokens");

            // Entities  properties

            builder.Entity<UserApp>(e =>
            {
                e.HasKey(u => u.Id);
                e.Property(u => u.Id).IsRequired().HasMaxLength(64);
                e.Property(u => u.FirstName).IsRequired().HasMaxLength(64);
                e.Property(u => u.LastName).IsRequired().HasMaxLength(64);
                e.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone");
                e.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
                e.Property(a => a.UpdatedAt).IsRequired().HasColumnType("timestamp with time zone");

                e.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            builder.Entity<RoleApp>(r =>
            {
                r.HasKey(r => r.Id);
                r.Property(r => r.Id).IsRequired().HasMaxLength(64);
                r.Property(r => r.Name).IsRequired().HasMaxLength(64);
                r.Property(r => r.NormalizedName).IsRequired().HasMaxLength(64);
                r.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
                r.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");

                r.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            builder.Entity<RefreshToken>(r =>
            {
                r.HasKey(r => r.Id);
                r.Property(r => r.Id).IsRequired().HasMaxLength(64);
                r.Property(r => r.Token).IsRequired().HasMaxLength(256);
                r.Property(r => r.ExpirationDate)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone");
            });

            builder.Entity<Gender>(g =>
            {
                g.HasKey(g => g.Id);
                g.Property(g => g.Id).IsRequired().HasMaxLength(64);
                g.Property(g => g.Name).IsRequired().HasMaxLength(64);
                g.Property(g => g.Color).IsRequired().HasMaxLength(16);
                g.Property(g => g.Icon).HasMaxLength(256);
                g.Property(g => g.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                g.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
                g.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<StatusAccount>(g =>
            {
                g.HasKey(g => g.Id);
                g.Property(g => g.Id).IsRequired().HasMaxLength(64);
                g.Property(g => g.Name).IsRequired().HasMaxLength(64);
                g.Property(g => g.Color).IsRequired().HasMaxLength(16);
                g.Property(g => g.Icon).HasMaxLength(256);
                g.Property(g => g.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                g.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
                g.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<Address>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Id).IsRequired().HasMaxLength(64);
                a.Property(a => a.Street).IsRequired().HasMaxLength(128);
                a.Property(a => a.City).IsRequired().HasMaxLength(64);
                a.Property(a => a.State).IsRequired().HasMaxLength(64);
                a.Property(a => a.Country).IsRequired().HasMaxLength(64);
                a.Property(a => a.ZipCode).IsRequired().HasMaxLength(16);
                a.Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                a.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
                a.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
            });
            builder.Entity<Slot>(s =>
            {
                s.HasKey(a => a.Id);
                s.Property(a => a.Id).IsRequired().HasMaxLength(64);
                s.Property(a => a.DateFrom).IsRequired().HasColumnType("timestamp with time zone");
                s.Property(a => a.DateTo).IsRequired().HasColumnType("timestamp with time zone");
                s.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
                s.Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                s.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<TypeSlot>(s =>
            {
                s.HasKey(a => a.Id);
                s.Property(a => a.Id).IsRequired().HasMaxLength(64);
                s.Property(g => g.Name).IsRequired().HasMaxLength(64);
                s.Property(g => g.Color).IsRequired().HasMaxLength(16);
                s.Property(g => g.Icon).HasMaxLength(256);
                s.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
                s.Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                s.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<Booking>(b =>
            {
                b.HasKey(a => a.Id);
                b.Property(a => a.Id).IsRequired().HasMaxLength(64);
                b.Property(b => b.Title).IsRequired().HasMaxLength(128);
                b.Property(b => b.Description).IsRequired().HasColumnType("text").HasMaxLength(512);
                b.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
                b.Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                b.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<Order>(o =>
            {
                o.HasKey(a => a.Id);
                o.Property(a => a.Id).IsRequired().HasMaxLength(64);
                o.Property(a => a.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0);
                o.Property(a => a.ReductionAmount)
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0);
                o.Property(a => a.ReductionPercentage).HasDefaultValue(0);
                o.Property(a => a.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasDefaultValue(0);
                o.Property(a => a.UpdatedAt).HasColumnType("timestamp with time zone");
                o.Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                o.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            //relationships
            builder.Entity<UserApp>().HasMany(u => u.Adresses).WithOne(a => a.User);

            builder
                .Entity<UserApp>()
                .HasOne(u => u.Gender)
                .WithMany()
                .HasForeignKey(u => u.GenderId);

            builder
                .Entity<UserApp>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId);

            // User => RefreshToken
            builder
                .Entity<RefreshToken>()
                .HasOne(r => r.User)
                .WithOne()
                .HasForeignKey<RefreshToken>(a => a.UserId);

            builder
                .Entity<UserApp>()
                .HasMany(u => u.Adresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            // Slot => slotType
            builder.Entity<Slot>().HasOne(s => s.Type).WithMany().HasForeignKey(s => s.TypeId);

            // Booking => Order, Student, slot
            builder
                .Entity<Booking>()
                .HasOne(b => b.Order)
                .WithMany(o => o.Bookings)
                .HasForeignKey(b => b.OrderId);

            builder
                .Entity<Booking>()
                .HasOne(b => b.Student)
                .WithMany(u => u.BookingsForStudent)
                .HasForeignKey(b => b.StudentId);

            builder
                .Entity<Booking>()
                .HasOne(b => b.Slot)
                .WithOne()
                .HasForeignKey<Booking>(b => b.SlotId);

            // Order => Student
            builder
                .Entity<Order>()
                .HasOne(b => b.Student)
                .WithMany(u => u.OrdersForStudent)
                .HasForeignKey(b => b.StudentId);

            // Seed Roles
            List<RoleApp> roles = new()
            {
                new RoleApp
                {
                    Id = EnvironmentVariables.ROLE_SUPER_ADMIN,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = EnvironmentVariables.ROLE_ADMIN,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = EnvironmentVariables.ROLE_TEACHER,
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = EnvironmentVariables.ROLE_STUDENT,
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    CreatedAt = DateTime.UtcNow,
                },
            };
            builder.Entity<RoleApp>().HasData(roles);
            // Seed Genders
            List<Gender> genders = new()
            {
                new Gender
                {
                    Id = EnvironmentVariables.GENDER_FEMALE,
                    Name = "Female",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Gender
                {
                    Id = EnvironmentVariables.GENDER_MALE,
                    Name = "Male",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Gender
                {
                    Id = EnvironmentVariables.GENDER_OTHER,
                    Name = "Other",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<Gender>().HasData(genders);

            // seed statuses for account
            List<StatusAccount> statuses = new()
            {
                new StatusAccount
                {
                    Id = EnvironmentVariables.STATUS_PENDING,
                    Name = "Pending",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new StatusAccount
                {
                    Id = EnvironmentVariables.STATUS_CONFIRMED,
                    Name = "Confirmed",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new StatusAccount
                {
                    Id = EnvironmentVariables.STATUS_BANNED,
                    Name = "Banned",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<StatusAccount>().HasData(statuses);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<DateTimeOffset>()
                .HaveConversion<CustomDateTimeConversion>();
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
