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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gender> Genders { get; set; }

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

            // Entities  properties

            builder.Entity<UserApp>(e =>
            {
                e.HasKey(u => u.Id);
                e.Property(u => u.Id).IsRequired().HasMaxLength(64);
                e.Property(u => u.FirstName).IsRequired().HasMaxLength(64);
                e.Property(u => u.LastName).IsRequired().HasMaxLength(64);
                e.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
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
                r.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
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
            });

            //relationships
            builder.Entity<UserApp>().HasMany(u => u.Adresses).WithOne(a => a.User);

            builder
                .Entity<UserApp>()
                .HasOne(u => u.Gender)
                .WithMany()
                .HasForeignKey(u => u.GenderId);

            builder.Entity<UserApp>()
                .HasMany(u => u.Adresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

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
                    Id = EnvironmentVariables.ROLE_USER,
                    Name = "User",
                    NormalizedName = "USER",
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
    }
}
