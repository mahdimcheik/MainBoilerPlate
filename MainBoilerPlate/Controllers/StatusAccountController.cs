using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des statuts de compte
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class StatusAccountController(StatusAccountService statusAccountService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les statuts de compte
        /// </summary>
        /// <returns>Liste de tous les statuts de compte</returns>
        /// <response code="200">Statuts de compte récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<StatusAccountResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<StatusAccountResponseDTO>>>> GetAllStatusAccounts([FromBody] DynamicFilters<StatusAccount> tableState)
        {
            var response = await statusAccountService.GetAllStatusAccountsAsync(tableState);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un statut de compte par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du statut de compte</param>
        /// <returns>Statut de compte trouvé</returns>
        /// <response code="200">Statut de compte récupéré avec succès</response>
        /// <response code="404">Statut de compte non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<StatusAccountResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<StatusAccountResponseDTO>>> GetStatusAccountById(
            [FromRoute] Guid id)
        {
            var response = await statusAccountService.GetStatusAccountByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau statut de compte
        /// </summary>
        /// <param name="statusDto">Données du statut de compte à créer</param>
        /// <returns>Statut de compte créé</returns>
        /// <response code="201">Statut de compte créé avec succès</response>
        /// <response code="400">Données invalides ou statut de compte existant</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<StatusAccountResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<StatusAccountResponseDTO>>> CreateStatusAccount(
            [FromBody] StatusAccountCreateDTO statusDto)
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

            var response = await statusAccountService.CreateStatusAccountAsync(statusDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un statut de compte existant
        /// </summary>
        /// <param name="id">Identifiant du statut de compte à mettre à jour</param>
        /// <param name="statusDto">Nouvelles données du statut de compte</param>
        /// <returns>Statut de compte mis à jour</returns>
        /// <response code="200">Statut de compte mis à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de statut de compte déjà utilisé</response>
        /// <response code="404">Statut de compte non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<StatusAccountResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<StatusAccountResponseDTO>>> UpdateStatusAccount(
            [FromRoute] Guid id,
            [FromBody] StatusAccountUpdateDTO statusDto)
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

            var response = await statusAccountService.UpdateStatusAccountAsync(id, statusDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un statut de compte (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du statut de compte à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Statut de compte supprimé avec succès</response>
        /// <response code="400">Statut de compte utilisé par des utilisateurs</response>
        /// <response code="404">Statut de compte non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteStatusAccount(
            [FromRoute] Guid id)
        {
            var response = await statusAccountService.DeleteStatusAccountAsync(id);
            
            return StatusCode(response.Status, response);
        }
    }
}