using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des rôles d'application
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class RoleAppController(RoleAppService roleAppService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les rôles
        /// </summary>
        /// <returns>Liste de tous les rôles</returns>
        /// <response code="200">Rôles récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<RoleAppResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<RoleAppResponseDTO>>>> GetAllRoles([FromBody]DynamicFilters<RoleApp> tableState)
        {
            var response = await roleAppService.GetAllRolesAsync(tableState);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un rôle par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du rôle</param>
        /// <returns>Rôle trouvé</returns>
        /// <response code="200">Rôle récupéré avec succès</response>
        /// <response code="404">Rôle non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<RoleAppResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<RoleAppResponseDTO>>> GetRoleById(
            [FromRoute] Guid id)
        {
            var response = await roleAppService.GetRoleByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un rôle par son nom
        /// </summary>
        /// <param name="name">Nom du rôle</param>
        /// <returns>Rôle trouvé</returns>
        /// <response code="200">Rôle récupéré avec succès</response>
        /// <response code="404">Rôle non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("by-name/{name}")]
        [ProducesResponseType(typeof(ResponseDTO<RoleAppResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<RoleAppResponseDTO>>> GetRoleByName(
            [FromRoute] string name)
        {
            var response = await roleAppService.GetRoleByNameAsync(name);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau rôle
        /// </summary>
        /// <param name="roleDto">Données du rôle à créer</param>
        /// <returns>Rôle créé</returns>
        /// <response code="201">Rôle créé avec succès</response>
        /// <response code="400">Données invalides ou rôle existant</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<RoleAppResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<RoleAppResponseDTO>>> CreateRole(
            [FromBody] RoleAppCreateDTO roleDto)
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

            var response = await roleAppService.CreateRoleAsync(roleDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un rôle existant
        /// </summary>
        /// <param name="id">Identifiant du rôle à mettre à jour</param>
        /// <param name="roleDto">Nouvelles données du rôle</param>
        /// <returns>Rôle mis à jour</returns>
        /// <response code="200">Rôle mis à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de rôle déjà utilisé</response>
        /// <response code="404">Rôle non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<RoleAppResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<RoleAppResponseDTO>>> UpdateRole(
            [FromRoute] Guid id,
            [FromBody] RoleAppUpdateDTO roleDto)
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

            var response = await roleAppService.UpdateRoleAsync(id, roleDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère le nombre d'utilisateurs assignés à un rôle
        /// </summary>
        /// <param name="id">Identifiant du rôle</param>
        /// <returns>Nombre d'utilisateurs dans le rôle</returns>
        /// <response code="200">Nombre récupéré avec succès</response>
        /// <response code="404">Rôle non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}/users-count")]
        [ProducesResponseType(typeof(ResponseDTO<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<int>>> GetUsersCountInRole(
            [FromRoute] Guid id)
        {
            var response = await roleAppService.GetUsersCountInRoleAsync(id);
            
            return StatusCode(response.Status, response);
        }
    }
}