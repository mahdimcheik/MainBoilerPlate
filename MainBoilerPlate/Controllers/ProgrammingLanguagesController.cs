using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des langages de programmation
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class ProgrammingLanguagesController(ProgrammingLanguagesService programmingLanguagesService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les langages de programmation
        /// </summary>
        /// <returns>Liste de tous les langages de programmation</returns>
        /// <response code="200">Langages de programmation récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<ProgrammingLanguageResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<ProgrammingLanguageResponseDTO>>>> GetAllProgrammingLanguages()
        {
            var response = await programmingLanguagesService.GetAllProgrammingLanguagesAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un langage de programmation par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du langage de programmation</param>
        /// <returns>Langage de programmation trouvé</returns>
        /// <response code="200">Langage de programmation récupéré avec succès</response>
        /// <response code="404">Langage de programmation non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<ProgrammingLanguageResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ProgrammingLanguageResponseDTO>>> GetProgrammingLanguageById(
            [FromRoute] Guid id)
        {
            var response = await programmingLanguagesService.GetProgrammingLanguageByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les langages de programmation d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Liste des langages de programmation de l'utilisateur</returns>
        /// <response code="200">Langages de programmation de l'utilisateur récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("user/{userId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<ProgrammingLanguageResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<ProgrammingLanguageResponseDTO>>>> GetProgrammingLanguagesByUserId(
            [FromRoute] Guid userId)
        {
            var response = await programmingLanguagesService.GetProgrammingLanguagesByUserIdAsync(userId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau langage de programmation
        /// </summary>
        /// <param name="programmingLanguageDto">Données du langage de programmation à créer</param>
        /// <returns>Langage de programmation créé</returns>
        /// <response code="201">Langage de programmation créé avec succès</response>
        /// <response code="400">Données invalides ou langage de programmation existant</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<ProgrammingLanguageResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ProgrammingLanguageResponseDTO>>> CreateProgrammingLanguage(
            [FromBody] ProgrammingLanguageCreateDTO programmingLanguageDto)
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

            var response = await programmingLanguagesService.CreateProgrammingLanguageAsync(programmingLanguageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un langage de programmation existant
        /// </summary>
        /// <param name="id">Identifiant du langage de programmation à mettre à jour</param>
        /// <param name="programmingLanguageDto">Nouvelles données du langage de programmation</param>
        /// <returns>Langage de programmation mis à jour</returns>
        /// <response code="200">Langage de programmation mis à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de langage déjà utilisé</response>
        /// <response code="404">Langage de programmation non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<ProgrammingLanguageResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<ProgrammingLanguageResponseDTO>>> UpdateProgrammingLanguage(
            [FromRoute] Guid id,
            [FromBody] ProgrammingLanguageUpdateDTO programmingLanguageDto)
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

            var response = await programmingLanguagesService.UpdateProgrammingLanguageAsync(id, programmingLanguageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un langage de programmation (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du langage de programmation à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Langage de programmation supprimé avec succès</response>
        /// <response code="404">Langage de programmation non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteProgrammingLanguage(
            [FromRoute] Guid id)
        {
            var response = await programmingLanguagesService.DeleteProgrammingLanguageAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Associe un langage de programmation à un utilisateur
        /// </summary>
        /// <param name="userProgrammingLanguageDto">Données d'association utilisateur-langage de programmation</param>
        /// <returns>Résultat de l'opération d'association</returns>
        /// <response code="200">Langage de programmation associé à l'utilisateur avec succès</response>
        /// <response code="400">Association déjà existante ou données invalides</response>
        /// <response code="404">Utilisateur ou langage de programmation non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("user/add")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> AddProgrammingLanguageToUser(
            [FromBody] UserProgrammingLanguageDTO userProgrammingLanguageDto)
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

            var response = await programmingLanguagesService.AddProgrammingLanguageToUserAsync(userProgrammingLanguageDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Dissocie un langage de programmation d'un utilisateur
        /// </summary>
        /// <param name="userProgrammingLanguageDto">Données de dissociation utilisateur-langage de programmation</param>
        /// <returns>Résultat de l'opération de dissociation</returns>
        /// <response code="200">Langage de programmation dissocié de l'utilisateur avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="404">Utilisateur non trouvé ou langage de programmation non associé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("user/remove")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> RemoveProgrammingLanguageFromUser(
            [FromBody] UserProgrammingLanguageDTO userProgrammingLanguageDto)
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

            var response = await programmingLanguagesService.RemoveProgrammingLanguageFromUserAsync(userProgrammingLanguageDto);
            
            return StatusCode(response.Status, response);
        }
    }
}