using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des créneaux
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class SlotsController(SlotsService slotsService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les créneaux
        /// </summary>
        /// <returns>Liste de tous les créneaux</returns>
        /// <response code="200">Créneaux récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<SlotResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<SlotResponseDTO>>>> GetAllSlots()
        {
            var response = await slotsService.GetAllSlotsAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un créneau par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du créneau</param>
        /// <returns>Créneau trouvé</returns>
        /// <response code="200">Créneau récupéré avec succès</response>
        /// <response code="404">Créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<SlotResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<SlotResponseDTO>>> GetSlotById(
            [FromRoute] Guid id)
        {
            var response = await slotsService.GetSlotByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les créneaux d'un enseignant
        /// </summary>
        /// <param name="teacherId">Identifiant de l'enseignant</param>
        /// <returns>Liste des créneaux de l'enseignant</returns>
        /// <response code="200">Créneaux de l'enseignant récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("teacher/{teacherId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<SlotResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<SlotResponseDTO>>>> GetSlotsByTeacherId(
            [FromRoute] Guid teacherId)
        {
            var response = await slotsService.GetSlotsByTeacherIdAsync(teacherId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les créneaux disponibles (non réservés et futurs)
        /// </summary>
        /// <returns>Liste des créneaux disponibles</returns>
        /// <response code="200">Créneaux disponibles récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("available")]
        [ProducesResponseType(typeof(ResponseDTO<List<SlotResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<SlotResponseDTO>>>> GetAvailableSlots()
        {
            var response = await slotsService.GetAvailableSlotsAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau créneau
        /// </summary>
        /// <param name="slotDto">Données du créneau à créer</param>
        /// <returns>Créneau créé</returns>
        /// <response code="201">Créneau créé avec succès</response>
        /// <response code="400">Données invalides ou conflit horaire</response>
        /// <response code="404">Enseignant ou type de créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<SlotResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<SlotResponseDTO>>> CreateSlot(
            [FromBody] SlotCreateDTO slotDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Données de validation invalides",
                    Data = ModelState
                });
            }

            var response = await slotsService.CreateSlotAsync(slotDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un créneau existant
        /// </summary>
        /// <param name="id">Identifiant du créneau à mettre à jour</param>
        /// <param name="slotDto">Nouvelles données du créneau</param>
        /// <returns>Créneau mis à jour</returns>
        /// <response code="200">Créneau mis à jour avec succès</response>
        /// <response code="400">Données invalides, conflit horaire ou créneau déjà réservé</response>
        /// <response code="404">Créneau, enseignant ou type de créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<SlotResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<SlotResponseDTO>>> UpdateSlot(
            [FromRoute] Guid id,
            [FromBody] SlotUpdateDTO slotDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Données de validation invalides",
                    Data = ModelState
                });
            }

            var response = await slotsService.UpdateSlotAsync(id, slotDto, User);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un créneau (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du créneau à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Créneau supprimé avec succès</response>
        /// <response code="400">Créneau déjà réservé</response>
        /// <response code="404">Créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteSlot(
            [FromRoute] Guid id)
        {
            // For now, we'll need to pass a teacher ID - this might need to be adjusted based on your business logic
            // You might want to get this from the authenticated user or pass it as a parameter
            var teacherId = Guid.Empty; // This needs to be properly implemented based on your authentication

            var response = await slotsService.DeleteSlotAsync(id, teacherId);
            
            return StatusCode(response.Status, response);
        }
    }
}
