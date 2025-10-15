using Bogus;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour générer des données fictives avec Bogus
    /// </summary>
    public class FakeDataService(
        MainContext context,
        UserManager<UserApp> userManager,
        RoleManager<RoleApp> roleManager)
    {
        private readonly Faker _faker = new Faker("fr");

        /// <summary>
        /// Génère des utilisateurs fictifs avec différents rôles
        /// </summary>
        /// <param name="numberOfUsers">Nombre d'utilisateurs à générer par rôle</param>
        /// <returns>Résultat de l'opération avec statistiques</returns>
        public async Task<ResponseDTO<object>> GenerateFakeUsersAsync(int numberOfUsers = 10)
        {
            try
            {
                var createdUsers = new
                {
                    Students = 0,
                    Teachers = 0,
                    Admins = 0,
                    Total = 0
                };

                // Récupérer les genres et statuts disponibles
                var genders = await context.Genders.Where(g => g.ArchivedAt == null).ToListAsync();
                var confirmedStatus = await context.Statuses.FirstOrDefaultAsync(s => s.Id == HardCode.STATUS_CONFIRMED);

                if (!genders.Any() || confirmedStatus == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Les données de base (genres, statuts) doivent être présentes avant de générer des utilisateurs",
                        Data = null
                    };
                }

                int studentsCreated = 0, teachersCreated = 0, adminsCreated = 0;

                // Générer des étudiants
                studentsCreated = await GenerateUsersWithRole("Student", numberOfUsers, genders, confirmedStatus);

                // Générer des enseignants
                teachersCreated = await GenerateUsersWithRole("Teacher", numberOfUsers, genders, confirmedStatus);

                // Générer quelques admins
                adminsCreated = await GenerateUsersWithRole("Admin", Math.Max(1, numberOfUsers / 5), genders, confirmedStatus);

                return new ResponseDTO<object>
                {
                    Status = 201,
                    Message = "Utilisateurs fictifs créés avec succès",
                    Data = new
                    {
                        Students = studentsCreated,
                        Teachers = teachersCreated,
                        Admins = adminsCreated,
                        Total = studentsCreated + teachersCreated + adminsCreated
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la génération des utilisateurs: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Génère des utilisateurs avec un rôle spécifique
        /// </summary>
        private async Task<int> GenerateUsersWithRole(string roleName, int count, List<Gender> genders, StatusAccount confirmedStatus)
        {
            int created = 0;
            var userFaker = new Faker<UserApp>("fr")
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.DateOfBirth, f => f.Date.PastOffset(40, DateTime.UtcNow.AddYears(-18)))
                .RuleFor(u => u.GenderId, f => f.PickRandom(genders).Id)
                .RuleFor(u => u.StatusId, f => confirmedStatus.Id)
                .RuleFor(u => u.EmailConfirmed, f => true)
                .RuleFor(u => u.DataProcessingConsent, f => true)
                .RuleFor(u => u.PrivacyPolicyConsent, f => true)
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Title, f => f.Name.JobTitle())
                .RuleFor(u => u.Description, f => f.Lorem.Paragraph())
                .RuleFor(u => u.CreatedAt, f => DateTimeOffset.UtcNow)
                .RuleFor(u => u.UpdatedAt, f => DateTimeOffset.UtcNow);

            for (int i = 0; i < count; i++)
            {
                var user = userFaker.Generate();
                user.UserName = $"{user.FirstName.ToLower()}.{user.LastName.ToLower()}@fake.com";
                user.Email = user.UserName;
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();

                // Vérifier si l'utilisateur existe déjà
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    var result = await userManager.CreateAsync(user, "FakePassword123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                        created++;
                    }
                }
            }

            return created;
        }

        /// <summary>
        /// Génère des adresses fictives pour les utilisateurs existants
        /// </summary>
        /// <param name="numberOfAddressesPerUser">Nombre d'adresses par utilisateur</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> GenerateFakeAddressesAsync(int numberOfAddressesPerUser = 2)
        {
            try
            {
                var users = await context.Users
                    .Where(u => u.ArchivedAt == null)
                    .ToListAsync();

                if (!users.Any())
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Aucun utilisateur trouvé. Veuillez d'abord générer des utilisateurs.",
                        Data = null
                    };
                }

                var addressFaker = new Faker<Address>("fr")
                    .RuleFor(a => a.Id, f => Guid.NewGuid())
                    .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                    .RuleFor(a => a.City, f => f.Address.City())
                    .RuleFor(a => a.State, f => f.Address.State())
                    .RuleFor(a => a.Country, f => "France")
                    .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
                    .RuleFor(a => a.AdditionalInfo, f => f.Lorem.Sentence())
                    .RuleFor(a => a.Latitude, f => (float?)f.Address.Latitude())
                    .RuleFor(a => a.Longitude, f => (float?)f.Address.Longitude())
                    .RuleFor(a => a.CreatedAt, f => DateTimeOffset.UtcNow);

                int totalCreated = 0;
                foreach (var user in users)
                {
                    for (int i = 0; i < numberOfAddressesPerUser; i++)
                    {
                        var address = addressFaker.Generate();
                        address.UserId = user.Id;
                        context.Addresses.Add(address);
                        totalCreated++;
                    }
                }

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 201,
                    Message = "Adresses fictives créées avec succès",
                    Data = new { TotalAddresses = totalCreated, Users = users.Count }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la génération des adresses: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Génère des types de créneaux fictifs
        /// </summary>
        /// <param name="count">Nombre de types à générer</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> GenerateFakeTypeSlotsAsync(int count = 5)
        {
            try
            {
                var typeSlotNames = new List<string>
                {
                    "Cours individuel", "Cours collectif", "Atelier pratique", 
                    "Conférence", "Tutorat", "Session de questions-réponses",
                    "Cours intensif", "Cours de révision", "Mentorat"
                };

                var colors = new List<string>
                {
                    "#FF6B6B", "#4ECDC4", "#45B7D1", "#96CEB4", 
                    "#FFEAA7", "#DFE6E9", "#74B9FF", "#A29BFE"
                };

                var icons = new List<string>
                {
                    "fa-user", "fa-users", "fa-chalkboard-teacher",
                    "fa-book", "fa-graduation-cap", "fa-lightbulb"
                };

                int created = 0;
                var random = new Random();

                for (int i = 0; i < Math.Min(count, typeSlotNames.Count); i++)
                {
                    var existingType = await context.TypeSlots
                        .FirstOrDefaultAsync(t => t.Name == typeSlotNames[i] && t.ArchivedAt == null);

                    if (existingType == null)
                    {
                        var typeSlot = new TypeSlot
                        {
                            Id = Guid.NewGuid(),
                            Name = typeSlotNames[i],
                            Color = colors[random.Next(colors.Count)],
                            Icon = icons[random.Next(icons.Count)],
                            CreatedAt = DateTimeOffset.UtcNow
                        };

                        context.TypeSlots.Add(typeSlot);
                        created++;
                    }
                }

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 201,
                    Message = "Types de créneaux créés avec succès",
                    Data = new { TotalCreated = created }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la génération des types de créneaux: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Génère des créneaux fictifs pour les enseignants
        /// </summary>
        /// <param name="numberOfSlotsPerTeacher">Nombre de créneaux par enseignant</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> GenerateFakeSlotsAsync(int numberOfSlotsPerTeacher = 10)
        {
            try
            {
                var teachers = await userManager.GetUsersInRoleAsync("Teacher");
                var typeSlots = await context.TypeSlots
                    .Where(t => t.ArchivedAt == null)
                    .ToListAsync();

                if (!teachers.Any())
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Aucun enseignant trouvé. Veuillez d'abord générer des utilisateurs avec le rôle Teacher.",
                        Data = null
                    };
                }

                if (!typeSlots.Any())
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Aucun type de créneau trouvé. Veuillez d'abord générer des types de créneaux.",
                        Data = null
                    };
                }

                int totalCreated = 0;
                var slotFaker = new Faker();

                foreach (var teacher in teachers)
                {
                    for (int i = 0; i < numberOfSlotsPerTeacher; i++)
                    {
                        var dateFrom = slotFaker.Date.FutureOffset(60).AddHours(slotFaker.Random.Int(8, 18));
                        var dateTo = dateFrom.AddHours(slotFaker.Random.Int(1, 3));

                        var slot = new Slot
                        {
                            Id = Guid.NewGuid(),
                            DateFrom = dateFrom,
                            DateTo = dateTo,
                            TeacherId = teacher.Id,
                            TypeId = slotFaker.PickRandom(typeSlots).Id,
                            CreatedAt = DateTimeOffset.UtcNow
                        };

                        context.Slots.Add(slot);
                        totalCreated++;
                    }
                }

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 201,
                    Message = "Créneaux fictifs créés avec succès",
                    Data = new { TotalSlots = totalCreated, Teachers = teachers.Count }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la génération des créneaux: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Génère toutes les données fictives en une seule fois
        /// </summary>
        /// <returns>Résultat de l'opération avec statistiques complètes</returns>
        public async Task<ResponseDTO<object>> GenerateAllFakeDataAsync()
        {
            try
            {
                var results = new Dictionary<string, object>();

                // 1. Générer les utilisateurs
                var usersResult = await GenerateFakeUsersAsync(20);
                results["Users"] = usersResult.Data;

                // 2. Générer les adresses
                var addressesResult = await GenerateFakeAddressesAsync(2);
                results["Addresses"] = addressesResult.Data;

                // 3. Générer les types de créneaux
                var typeSlotsResult = await GenerateFakeTypeSlotsAsync(6);
                results["TypeSlots"] = typeSlotsResult.Data;

                // 4. Générer les créneaux
                var slotsResult = await GenerateFakeSlotsAsync(15);
                results["Slots"] = slotsResult.Data;

                return new ResponseDTO<object>
                {
                    Status = 201,
                    Message = "Toutes les données fictives ont été générées avec succès",
                    Data = results
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la génération complète des données: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Supprime toutes les données fictives (utilisateurs avec email @fake.com)
        /// </summary>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> ClearFakeDataAsync()
        {
            try
            {
                var fakeUsers = await context.Users
                    .Where(u => u.Email!.Contains("@fake.com"))
                    .ToListAsync();

                int deletedCount = 0;

                foreach (var user in fakeUsers)
                {
                    // Supprimer les adresses liées
                    var addresses = await context.Addresses.Where(a => a.UserId == user.Id).ToListAsync();
                    context.Addresses.RemoveRange(addresses);

                    // Supprimer les créneaux liés
                    var slots = await context.Slots.Where(s => s.TeacherId == user.Id).ToListAsync();
                    context.Slots.RemoveRange(slots);

                    // Supprimer l'utilisateur
                    await userManager.DeleteAsync(user);
                    deletedCount++;
                }

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Données fictives supprimées avec succès",
                    Data = new { DeletedUsers = deletedCount }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression des données: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}