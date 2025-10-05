using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des expériences
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class ExperiencesController(ExperiencesService experiencesService) : ControllerBase
    {
        /// <summary>
        /// Récupère toutes les expériences
        /// </summary>
        /// <returns>Liste de toutes les expériences</returns>
        /// <response code="200">Expériences récupérées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<ExperienceResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<ExperienceResponseDTO>>>> GetAllExperiences()
        {
            var response = await experiencesService.GetAllExperiencesAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère une expérience par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique de l'expérience</param>
        /// <returns>Expérience trouvée</returns>
        /// <response code="200">Expérience récupérée avec succès</response>
        /// <response code="404">Expérience non trouvée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<ExperienceResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ExperienceResponseDTO>>> GetExperienceById(
            [FromRoute] Guid id)
        {
            var response = await experiencesService.GetExperienceByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère toutes les expériences d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Liste des expériences de l'utilisateur</returns>
        /// <response code="200">Expériences de l'utilisateur récupérées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("user/{userId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<ExperienceResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<ExperienceResponseDTO>>>> GetExperiencesByUserId(
            [FromRoute] Guid userId)
        {
            var response = await experiencesService.GetExperiencesByUserIdAsync(userId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée une nouvelle expérience
        /// </summary>
        /// <param name="experienceDto">Données de l'expérience à créer</param>
        /// <returns>Expérience créée</returns>
        /// <response code="201">Expérience créée avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="404">Utilisateur non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<ExperienceResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ExperienceResponseDTO>>> CreateExperience(
            [FromBody] ExperienceCreateDTO experienceDto)
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

            var response = await experiencesService.CreateExperienceAsync(experienceDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour une expérience existante
        /// </summary>
        /// <param name="id">Identifiant de l'expérience à mettre à jour</param>
        /// <param name="experienceDto">Nouvelles données de l'expérience</param>
        /// <returns>Expérience mise à jour</returns>
        /// <response code="200">Expérience mise à jour avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="404">Expérience ou utilisateur non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<ExperienceResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ExperienceResponseDTO>>> UpdateExperience(
            [FromRoute] Guid id,
            [FromBody] ExperienceUpdateDTO experienceDto)
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

            var response = await experiencesService.UpdateExperienceAsync(id, experienceDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime une expérience (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant de l'expérience à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Expérience supprimée avec succès</response>
        /// <response code="404">Expérience non trouvée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteExperience(
            [FromRoute] Guid id)
        {
            var response = await experiencesService.DeleteExperienceAsync(id);
            
            return StatusCode(response.Status, response);
        }
    }
}