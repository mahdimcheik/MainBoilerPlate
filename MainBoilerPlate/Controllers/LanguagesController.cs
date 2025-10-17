using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des langues
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class LanguagesController(LanguagesService languagesService, MainContext context) : ControllerBase
    {
        /// <summary>
        /// Récupère toutes les langues
        /// </summary>
        /// <returns>Liste de toutes les langues</returns>
        /// <response code="200">Langues récupérées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<LanguageResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<LanguageResponseDTO>>>> GetAllLanguages([FromBody] DynamicFilters<Language> tableState)
        {
            var response = await languagesService.GetAllLanguagesAsync(tableState);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère une langue par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique de la langue</param>
        /// <returns>Langue trouvée</returns>
        /// <response code="200">Langue récupérée avec succès</response>
        /// <response code="404">Langue non trouvée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<LanguageResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<LanguageResponseDTO>>> GetLanguageById(
            [FromRoute] Guid id)
        {
            var response = await languagesService.GetLanguageByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère toutes les langues d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Liste des langues de l'utilisateur</returns>
        /// <response code="200">Langues de l'utilisateur récupérées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("user/{userId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<LanguageResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<LanguageResponseDTO>>>> GetLanguagesByUserId(
            [FromRoute] Guid userId)
        {
            var response = await languagesService.GetLanguagesByUserIdAsync(userId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée une nouvelle langue
        /// </summary>
        /// <param name="languageDto">Données de la langue à créer</param>
        /// <returns>Langue créée</returns>
        /// <response code="201">Langue créée avec succès</response>
        /// <response code="400">Données invalides ou langue existante</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<LanguageResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<LanguageResponseDTO>>> CreateLanguage(
            [FromBody] LanguageCreateDTO languageDto)
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

            var response = await languagesService.CreateLanguageAsync(languageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour une langue existante
        /// </summary>
        /// <param name="id">Identifiant de la langue à mettre à jour</param>
        /// <param name="languageDto">Nouvelles données de la langue</param>
        /// <returns>Langue mise à jour</returns>
        /// <response code="200">Langue mise à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de langue déjà utilisé</response>
        /// <response code="404">Langue non trouvée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<LanguageResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<LanguageResponseDTO>>> UpdateLanguage(
            [FromRoute] Guid id,
            [FromBody] LanguageUpdateDTO languageDto)
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

            var response = await languagesService.UpdateLanguageAsync(id, languageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime une langue (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant de la langue à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Langue supprimée avec succès</response>
        /// <response code="404">Langue non trouvée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteLanguage(
            [FromRoute] Guid id)
        {
            var response = await languagesService.DeleteLanguageAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Associe une langue à un utilisateur
        /// </summary>
        /// <param name="userLanguageDto">Données d'association utilisateur-langue</param>
        /// <returns>Résultat de l'opération d'association</returns>
        /// <response code="200">Langue associée à l'utilisateur avec succès</response>
        /// <response code="400">Association déjà existante ou données invalides</response>
        /// <response code="404">Utilisateur ou langue non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("user/add")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> AddLanguageToUser(
            [FromBody] UserLanguageDTO userLanguageDto)
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

            var response = await languagesService.AddLanguageToUserAsync(userLanguageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Associe une langue à un utilisateur
        /// </summary>
        /// <param name="userLanguageDto">Données d'association utilisateur-langue</param>
        /// <returns>Résultat de l'opération d'association</returns>
        /// <response code="200">Langue associée à l'utilisateur avec succès</response>
        /// <response code="400">Association déjà existante ou données invalides</response>
        /// <response code="404">Utilisateur ou langue non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("user/update-languages")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<LanguageResponseDTO>>>> UpdateLanguagesForUser(
            [FromBody] Guid[] languagesIds)
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            if (!ModelState.IsValid || user is null)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Données de validation invalides",
                    Data = ModelState
                });
            }

            var response = await languagesService.UpdateLanguagesForUser(user, languagesIds);

            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Dissocie une langue d'un utilisateur
        /// </summary>
        /// <param name="userLanguageDto">Données de dissociation utilisateur-langue</param>
        /// <returns>Résultat de l'opération de dissociation</returns>
        /// <response code="200">Langue dissociée de l'utilisateur avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="404">Utilisateur non trouvé ou langue non associée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("user/remove")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> RemoveLanguageFromUser(
            [FromBody] UserLanguageDTO userLanguageDto)
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

            var response = await languagesService.RemoveLanguageFromUserAsync(userLanguageDto);
            
            return StatusCode(response.Status, response);
        }
    }
}