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
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        // cursus
        public DbSet<LevelCursus> LevelCursuses { get; set; }
        public DbSet<CategoryCursus> CategoryCursuses { get; set; }
        public DbSet<Cursus> Cursuses { get; set; }

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
            builder.Entity<Formation>().ToTable("Formations");
            builder.Entity<Experience>().ToTable("Experiences");
            builder.Entity<Language>().ToTable("Languages");
            builder.Entity<ProgrammingLanguage>().ToTable("ProgrammingLanguages");
            builder.Entity<Cursus>().ToTable("Cursuses");

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

            builder.Entity<LevelCursus>(g =>
            {
                g.HasKey(g => g.Id);
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

            builder.Entity<CategoryCursus>(g =>
            {
                g.HasKey(g => g.Id);
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

            builder.Entity<Cursus>(g =>
            {
                g.HasKey(g => g.Id);
                g.Property(g => g.Name).IsRequired().HasMaxLength(64);
                g.Property(g => g.Color).IsRequired().HasMaxLength(16);
                g.Property(g => g.Icon).HasMaxLength(256);
                g.Property(g => g.ImgUrl).HasMaxLength(256);
                g.Property(e => e.Description).HasMaxLength(512);
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

            builder.Entity<Formation>(f =>
            {
                f.HasKey(f => f.Id);
                f.Property(f => f.Title).IsRequired().HasMaxLength(200);
                f.Property(f => f.Description).IsRequired().HasMaxLength(1000);
                f.Property(f => f.Institution).IsRequired().HasMaxLength(200);
                f.Property(f => f.DateFrom).IsRequired().HasColumnType("timestamp with time zone");
                f.Property(f => f.DateTo).HasColumnType("timestamp with time zone");
                f.Property(f => f.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                f.Property(f => f.UpdatedAt).HasColumnType("timestamp with time zone");
                f.Property(f => f.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<Experience>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Title).IsRequired().HasMaxLength(200);
                e.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                e.Property(e => e.Institution).IsRequired().HasMaxLength(200);
                e.Property(e => e.DateFrom).IsRequired().HasColumnType("timestamp with time zone");
                e.Property(e => e.DateTo).HasColumnType("timestamp with time zone");
                e.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone");
                e.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<Language>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(200);
                e.Property(e => e.Color).IsRequired().HasMaxLength(200);
                e.Property(e => e.Icon).HasMaxLength(200);
                e.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone");
                e.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            builder.Entity<ProgrammingLanguage>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(200);
                e.Property(e => e.Color).IsRequired().HasMaxLength(200);
                e.Property(e => e.Icon).HasMaxLength(200);
                e.Property(e => e.Description).HasMaxLength(200);
                e.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnType("timestamp with time zone")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone");
                e.Property(e => e.ArchivedAt).HasColumnType("timestamp with time zone");
            });

            // relationships
            builder
                .Entity<UserApp>()
                .HasMany(u => u.Adresses)
                .WithOne(a => a.User)
                .HasForeignKey(A => A.UserId);
            builder
                .Entity<UserApp>()
                .HasMany(u => u.Formations)
                .WithOne(a => a.User)
                .HasForeignKey(A => A.UserId);
            builder
                .Entity<UserApp>()
                .HasMany(u => u.Experiences)
                .WithOne(a => a.User)
                .HasForeignKey(A => A.UserId);

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

            builder
                .Entity<UserApp>()
                .HasMany(u => u.TeacherCursuses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            builder
                .Entity<UserApp>()
                .HasMany(c => c.Languages)
                .WithMany(cat => cat.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersXLanguages",
                    j =>
                        j.HasOne<Language>()
                            .WithMany()
                            .HasForeignKey("LanguageId")
                            .OnDelete(DeleteBehavior.Restrict),
                    j =>
                        j.HasOne<UserApp>()
                            .WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.Restrict)
                );

            builder
                .Entity<UserApp>()
                .HasMany(c => c.ProgrammingLanguages)
                .WithMany(cat => cat.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersXProgrammingLanguages",
                    j =>
                        j.HasOne<ProgrammingLanguage>()
                            .WithMany()
                            .HasForeignKey("ProgrammingLanguageId")
                            .OnDelete(DeleteBehavior.Restrict),
                    j =>
                        j.HasOne<UserApp>()
                            .WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.Restrict)
                );

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

            // Cursus => Level, UserApp
            builder.Entity<Cursus>().HasOne(c => c.Level).WithMany().HasForeignKey(c => c.LevelId);

            builder
                .Entity<Cursus>()
                .HasMany(c => c.Categories)
                .WithMany(cat => cat.Cursuses)
                .UsingEntity<Dictionary<string, object>>(
                    "CursusXCategories",
                    j =>
                        j.HasOne<CategoryCursus>()
                            .WithMany()
                            .HasForeignKey("CategorieId")
                            .OnDelete(DeleteBehavior.Restrict),
                    j =>
                        j.HasOne<Cursus>()
                            .WithMany()
                            .HasForeignKey("CursusId")
                            .OnDelete(DeleteBehavior.Restrict)
                );
            

            // Seed Roles
            List<RoleApp> roles = new()
            {
                new RoleApp
                {
                    Id = HardCode.ROLE_SUPER_ADMIN,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = HardCode.ROLE_ADMIN,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = HardCode.ROLE_TEACHER,
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                    CreatedAt = DateTime.UtcNow,
                },
                new RoleApp
                {
                    Id = HardCode.ROLE_STUDENT,
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
                    Id = HardCode.GENDER_FEMALE,
                    Name = "Female",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Gender
                {
                    Id = HardCode.GENDER_MALE,
                    Name = "Male",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Gender
                {
                    Id = HardCode.GENDER_OTHER,
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
                    Id = HardCode.STATUS_PENDING,
                    Name = "Pending",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new StatusAccount
                {
                    Id = HardCode.STATUS_CONFIRMED,
                    Name = "Confirmed",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new StatusAccount
                {
                    Id = HardCode.STATUS_BANNED,
                    Name = "Banned",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<StatusAccount>().HasData(statuses);

            // seed level cursus
            List<LevelCursus> levelsCursus = new()
            {
                new LevelCursus
                {
                    Id = HardCode.LEVEL_BEGINNER,
                    Name = "Beginner",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new LevelCursus
                {
                    Id = HardCode.LEVEL_INTERMEDIATE,
                    Name = "Intermediate",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new LevelCursus
                {
                    Id = HardCode.LEVEL_ADVANCED,
                    Name = "Advanced",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<LevelCursus>().HasData(levelsCursus);

            // seed categories cursus
            List<CategoryCursus> categoryCursuses = new()
            {
                new CategoryCursus
                {
                    Id = HardCode.CATEGORY_SOFT,
                    Name = "Soft skills",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new CategoryCursus
                {
                    Id = HardCode.CATEGORY_TECHNICS,
                    Name = "Technics",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new CategoryCursus
                {
                    Id = HardCode.CATEGORY_FRONT,
                    Name = "Front-end",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new CategoryCursus
                {
                    Id = HardCode.CATEGORY_BACK,
                    Name = "Back-end",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<CategoryCursus>().HasData(categoryCursuses);

            // seed languages
            List<Language> languages = new()
            {
                new Language
                {
                    Id = HardCode.LANGUAGE_FRENCH,
                    Name = "French",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Language
                {
                    Id = HardCode.LANGUAGE_ENGLISH,
                    Name = "English",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Language
                {
                    Id = HardCode.LANGUAGE_ARAB,
                    Name = "Arab",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new Language
                {
                    Id = HardCode.LANGUAGE_SPANISH,
                    Name = "Spanich",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<Language>().HasData(languages);

            // seed languages
            List<ProgrammingLanguage> programmingLanguages = new()
            {
                new ProgrammingLanguage
                {
                    Id = HardCode.LANGUAGE_JS,
                    Name = "JavaScript",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new ProgrammingLanguage
                {
                    Id = HardCode.LANGUAGE_JAVA,
                    Name = "Java",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new ProgrammingLanguage
                {
                    Id = HardCode.LANGUAGE_CSHARP,
                    Name = "C#",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new ProgrammingLanguage
                {
                    Id = HardCode.LANGUAGE_CPP,
                    Name = "C++",
                    Color = "#ab69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
            };

            builder.Entity<ProgrammingLanguage>().HasData(programmingLanguages);

            // seed slot types
            // seed languages
            List<TypeSlot> typeSlots = new()
            {
                new TypeSlot
                {
                    Id = HardCode.SLOT_TYPE_VISIO,
                    Name = "Visio",
                    Color = "#ff69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                },
                new TypeSlot
                {
                    Id = HardCode.SLOT_TYPE_PRESENTIAL,
                    Name = "Présentiel",
                    Color = "#fa69b4",
                    Icon = "",
                    CreatedAt = DateTime.UtcNow,
                }
            };

            builder.Entity<TypeSlot>().HasData(typeSlots);

            // ✅ Configure navigation properties for Identity UserRoles
            // This allows .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            // UserManager will continue to work perfectly - this only adds EF navigation
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<Guid>>(userRole =>
            {
                userRole.HasOne<RoleApp>()
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne<UserApp>()
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
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
