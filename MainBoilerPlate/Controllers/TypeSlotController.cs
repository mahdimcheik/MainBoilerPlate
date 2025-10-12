using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des types de créneaux
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class TypeSlotController(TypeSlotService typeSlotService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les types de créneaux
        /// </summary>
        /// <returns>Liste de tous les types de créneaux</returns>
        /// <response code="200">Types de créneaux récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<TypeSlotResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<TypeSlotResponseDTO>>>> GetAllTypeSlots()
        {
            var response = await typeSlotService.GetAllTypeSlotsAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un type de créneau par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du type de créneau</param>
        /// <returns>Type de créneau trouvé</returns>
        /// <response code="200">Type de créneau récupéré avec succès</response>
        /// <response code="404">Type de créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<TypeSlotResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<TypeSlotResponseDTO>>> GetTypeSlotById(
            [FromRoute] Guid id)
        {
            var response = await typeSlotService.GetTypeSlotByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau type de créneau
        /// </summary>
        /// <param name="typeSlotDto">Données du type de créneau à créer</param>
        /// <returns>Type de créneau créé</returns>
        /// <response code="201">Type de créneau créé avec succès</response>
        /// <response code="400">Données invalides ou type de créneau existant</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<TypeSlotResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<TypeSlotResponseDTO>>> CreateTypeSlot(
            [FromBody] TypeSlotCreateDTO typeSlotDto)
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

            var response = await typeSlotService.CreateTypeSlotAsync(typeSlotDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un type de créneau existant
        /// </summary>
        /// <param name="id">Identifiant du type de créneau à mettre à jour</param>
        /// <param name="typeSlotDto">Nouvelles données du type de créneau</param>
        /// <returns>Type de créneau mis à jour</returns>
        /// <response code="200">Type de créneau mis à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de type de créneau déjà utilisé</response>
        /// <response code="404">Type de créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<TypeSlotResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<TypeSlotResponseDTO>>> UpdateTypeSlot(
            [FromRoute] Guid id,
            [FromBody] TypeSlotUpdateDTO typeSlotDto)
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

            var response = await typeSlotService.UpdateTypeSlotAsync(id, typeSlotDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un type de créneau (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du type de créneau à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Type de créneau supprimé avec succès</response>
        /// <response code="400">Type de créneau utilisé par des créneaux</response>
        /// <response code="404">Type de créneau non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteTypeSlot(
            [FromRoute] Guid id)
        {
            var response = await typeSlotService.DeleteTypeSlotAsync(id);
            
            return StatusCode(response.Status, response);
        }
    }
}