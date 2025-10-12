using System.Security.Claims;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des créneaux
    /// </summary>
    public class SlotsService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les créneaux
        /// </summary>
        /// <returns>Liste des créneaux</returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetAllSlotsAsync()
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Where(s => s.ArchivedAt == null)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .ToListAsync();

                // Vérifier la disponibilité de chaque créneau
                var slotResponses = new List<SlotResponseDTO>();
                foreach (var slot in slots)
                {
                    var isBooked = await context.Bookings.AnyAsync(b =>
                        b.SlotId == slot.Id && b.ArchivedAt == null
                    );

                    slotResponses.Add(new SlotResponseDTO(slot, !isBooked));
                }

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux récupérés avec succès",
                    Data = slotResponses,
                    Count = slotResponses.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des créneaux: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère un créneau par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <returns>Créneau trouvé</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> GetSlotByIdAsync(Guid id)
        {
            try
            {
                var slot = await context
                    .Slots.AsNoTracking()
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .FirstOrDefaultAsync(s => s.Id == id && s.ArchivedAt == null);

                if (slot == null)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier la disponibilité du créneau
                var isBooked = await context.Bookings.AnyAsync(b =>
                    b.SlotId == slot.Id && b.ArchivedAt == null
                );

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 200,
                    Message = "Créneau récupéré avec succès",
                    Data = new SlotResponseDTO(slot, !isBooked),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère les créneaux d'un enseignant
        /// </summary>
        /// <param name="teacherId">Identifiant de l'enseignant</param>
        /// <returns>Liste des créneaux de l'enseignant</returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetSlotsByTeacherIdAsync(
            Guid teacherId
        )
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Where(s => s.TeacherId == teacherId && s.ArchivedAt == null)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .ToListAsync();

                // Vérifier la disponibilité de chaque créneau
                var slotResponses = new List<SlotResponseDTO>();
                foreach (var slot in slots)
                {
                    var isBooked = await context.Bookings.AnyAsync(b =>
                        b.SlotId == slot.Id && b.ArchivedAt == null
                    );

                    slotResponses.Add(new SlotResponseDTO(slot, !isBooked));
                }

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux de l'enseignant récupérés avec succès",
                    Data = slotResponses,
                    Count = slotResponses.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message =
                        $"Erreur lors de la récupération des créneaux de l'enseignant: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère les créneaux disponibles
        /// </summary>
        /// <returns>Liste des créneaux disponibles</returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetAvailableSlotsAsync()
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Where(s => s.ArchivedAt == null && s.DateFrom > DateTimeOffset.UtcNow)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .ToListAsync();

                // Filtrer les créneaux non réservés
                var availableSlots = new List<SlotResponseDTO>();
                foreach (var slot in slots)
                {
                    var isBooked = await context.Bookings.AnyAsync(b =>
                        b.SlotId == slot.Id && b.ArchivedAt == null
                    );

                    if (!isBooked)
                    {
                        availableSlots.Add(new SlotResponseDTO(slot, true));
                    }
                }

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux disponibles récupérés avec succès",
                    Data = availableSlots,
                    Count = availableSlots.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message =
                        $"Erreur lors de la récupération des créneaux disponibles: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Crée un nouveau créneau
        /// </summary>
        /// <param name="slotDto">Données du créneau à créer</param>
        /// <returns>Créneau créé</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> CreateSlotAsync(SlotCreateDTO slotDto)
        {
            try
            {
                // Validation des dates
                if (slotDto.DateFrom >= slotDto.DateTo)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être antérieure à la date de fin",
                        Data = null,
                    };
                }

                if (slotDto.DateFrom <= DateTimeOffset.UtcNow)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être dans le futur",
                        Data = null,
                    };
                }

                //// Vérifier que l'enseignant existe
                //var teacherExists = await context.Users.AnyAsync(u => u.Id == slotDto.TeacherId);
                //if (!teacherExists)
                //{
                //    return new ResponseDTO<SlotResponseDTO>
                //    {
                //        Status = 404,
                //        Message = "Enseignant non trouvé",
                //        Data = null
                //    };
                //}

                // Vérifier que le type de créneau existe
                var typeExists = await context.TypeSlots.AnyAsync(t =>
                    t.Id == slotDto.TypeId && t.ArchivedAt == null
                );
                if (!typeExists)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Type de créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier qu'il n'y a pas de conflit horaire pour l'enseignant
                var hasConflict = await context.Slots.AnyAsync(s =>
                    s.TeacherId == slotDto.TeacherId
                    && s.ArchivedAt == null
                    && (
                        (slotDto.DateFrom >= s.DateFrom && slotDto.DateFrom < s.DateTo)
                        || (slotDto.DateTo > s.DateFrom && slotDto.DateTo <= s.DateTo)
                        || (slotDto.DateFrom <= s.DateFrom && slotDto.DateTo >= s.DateTo)
                    )
                );

                if (hasConflict)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Conflit horaire avec un autre créneau de l'enseignant",
                        Data = null,
                    };
                }

                var slot = new Slot
                {
                    Id = Guid.NewGuid(),
                    DateFrom = slotDto.DateFrom,
                    DateTo = slotDto.DateTo,
                    TeacherId = slotDto.TeacherId,
                    TypeId = slotDto.TypeId,
                    CreatedAt = DateTimeOffset.UtcNow,
                };

                context.Slots.Add(slot);
                await context.SaveChangesAsync();

                // Recharger avec les relations
                var createdSlot = await context
                    .Slots.Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .FirstOrDefaultAsync(s => s.Id == slot.Id);

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 201,
                    Message = "Créneau créé avec succès",
                    Data = new SlotResponseDTO(createdSlot!, true),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Met à jour un créneau existant
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <param name="slotDto">Nouvelles données du créneau</param>
        /// <returns>Créneau mis à jour</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> UpdateSlotAsync(
            Guid id,
            SlotUpdateDTO slotDto,
            ClaimsPrincipal User
        )
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            if (slotDto.TeacherId != user?.Id)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 400,
                    Message = "Vous ne pouvez pas modifer un créneau pour un autre enseignant",
                    Data = null,
                };
            }

            try
            {
                var slot = await context.Slots.FirstOrDefaultAsync(s =>
                    s.Id == id && s.ArchivedAt == null && s.Id == slotDto.TypeId
                );

                if (slot == null)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier si le créneau est déjà réservé
                var isBooked = await context.Bookings.AnyAsync(b =>
                    b.SlotId == id && b.ArchivedAt == null
                );

                if (isBooked)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Impossible de modifier un créneau déjà réservé",
                        Data = null,
                    };
                }

                // Validation des dates
                if (slotDto.DateFrom >= slotDto.DateTo)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être antérieure à la date de fin",
                        Data = null,
                    };
                }

                if (slotDto.DateFrom <= DateTimeOffset.UtcNow)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être dans le futur",
                        Data = null,
                    };
                }

                // Vérifier que le type de créneau existe
                var typeExists = await context.TypeSlots.AnyAsync(t =>
                    t.Id == slotDto.TypeId && t.ArchivedAt == null
                );
                if (!typeExists)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Type de créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier qu'il n'y a pas de conflit horaire pour l'enseignant (exclure le créneau actuel)
                var hasConflict = await context.Slots.AnyAsync(s =>
                    s.TeacherId == slotDto.TeacherId
                    && s.Id != id
                    && s.ArchivedAt == null
                    && (slotDto.DateFrom < s.DateTo && slotDto.DateTo > s.DateFrom)
                );

                if (hasConflict)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Conflit horaire avec un autre créneau de l'enseignant",
                        Data = null,
                    };
                }

                slotDto.UpdateSlot(slot);

                await context.SaveChangesAsync();

                // Recharger avec les relations
                var updatedSlot = await context
                    .Slots.Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .FirstOrDefaultAsync(s => s.Id == id);

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 200,
                    Message = "Créneau mis à jour avec succès",
                    Data = new SlotResponseDTO(updatedSlot!, true),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Archive un créneau (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteSlotAsync(Guid id, Guid teacherId)
        {
            try
            {
                var slot = await context.Slots.FirstOrDefaultAsync(s =>
                    s.Id == id && s.ArchivedAt == null && s.TeacherId == teacherId
                );

                if (slot == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier si le créneau est réservé
                var isBooked = await context.Bookings.AnyAsync(b =>
                    b.SlotId == id && b.ArchivedAt == null
                );

                if (isBooked)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 400,
                        Message = "Impossible de supprimer un créneau déjà réservé",
                        Data = null,
                    };
                }

                slot.ArchivedAt = DateTimeOffset.UtcNow;
                slot.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Créneau supprimé avec succès",
                    Data = null,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }
    }
}
