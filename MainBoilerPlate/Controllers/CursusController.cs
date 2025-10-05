using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des cursus
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class CursusController(CursusService cursusService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les cursus
        /// </summary>
        /// <returns>Liste de tous les cursus</returns>
        /// <response code="200">Cursus récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ResponseDTO<List<CursusResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<CursusResponseDTO>>>> GetAllCursus()
        {
            var response = await cursusService.GetAllCursusAsync();
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un cursus par son identifiant
        /// </summary>
        /// <param name="id">Identifiant unique du cursus</param>
        /// <returns>Cursus trouvé</returns>
        /// <response code="200">Cursus récupéré avec succès</response>
        /// <response code="404">Cursus non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<CursusResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<CursusResponseDTO>>> GetCursusById(
            [FromRoute] Guid id)
        {
            var response = await cursusService.GetCursusByIdAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les cursus d'un enseignant
        /// </summary>
        /// <param name="teacherId">Identifiant de l'enseignant</param>
        /// <returns>Liste des cursus de l'enseignant</returns>
        /// <response code="200">Cursus de l'enseignant récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("teacher/{teacherId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<CursusResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<CursusResponseDTO>>>> GetCursusByTeacherId(
            [FromRoute] Guid teacherId)
        {
            var response = await cursusService.GetCursusByTeacherIdAsync(teacherId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les cursus d'un niveau
        /// </summary>
        /// <param name="levelId">Identifiant du niveau</param>
        /// <returns>Liste des cursus du niveau</returns>
        /// <response code="200">Cursus du niveau récupérés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("level/{levelId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<List<CursusResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<CursusResponseDTO>>>> GetCursusByLevelId(
            [FromRoute] Guid levelId)
        {
            var response = await cursusService.GetCursusByLevelIdAsync(levelId);
            
            if (response.Status == 200)
            {
                return Ok(response);
            }
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Crée un nouveau cursus
        /// </summary>
        /// <param name="cursusDto">Données du cursus à créer</param>
        /// <returns>Cursus créé</returns>
        /// <response code="201">Cursus créé avec succès</response>
        /// <response code="400">Données invalides ou cursus existant</response>
        /// <response code="404">Niveau, enseignant ou catégorie non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseDTO<CursusResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<CursusResponseDTO>>> CreateCursus(
            [FromBody] CursusCreateDTO cursusDto)
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

            var response = await cursusService.CreateCursusAsync(cursusDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour un cursus existant
        /// </summary>
        /// <param name="id">Identifiant du cursus à mettre à jour</param>
        /// <param name="cursusDto">Nouvelles données du cursus</param>
        /// <returns>Cursus mis à jour</returns>
        /// <response code="200">Cursus mis à jour avec succès</response>
        /// <response code="400">Données invalides ou nom de cursus déjà utilisé</response>
        /// <response code="404">Cursus, niveau, enseignant ou catégorie non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<CursusResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<CursusResponseDTO>>> UpdateCursus(
            [FromRoute] Guid id,
            [FromBody] CursusUpdateDTO cursusDto)
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

            var response = await cursusService.UpdateCursusAsync(id, cursusDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un cursus (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du cursus à supprimer</param>
        /// <returns>Résultat de l'opération de suppression</returns>
        /// <response code="200">Cursus supprimé avec succès</response>
        /// <response code="404">Cursus non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> DeleteCursus(
            [FromRoute] Guid id)
        {
            var response = await cursusService.DeleteCursusAsync(id);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Associe une catégorie à un cursus
        /// </summary>
        /// <param name="cursusCategoryDto">Données d'association cursus-catégorie</param>
        /// <returns>Résultat de l'opération d'association</returns>
        /// <response code="200">Catégorie associée au cursus avec succès</response>
        /// <response code="400">Association déjà existante ou données invalides</response>
        /// <response code="404">Cursus ou catégorie non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("category/add")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> AddCategoryToCursus(
            [FromBody] CursusCategoryDTO cursusCategoryDto)
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

            var response = await cursusService.AddCategoryToCursusAsync(cursusCategoryDto);
            
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Dissocie une catégorie d'un cursus
        /// </summary>
        /// <param name="cursusCategoryDto">Données de dissociation cursus-catégorie</param>
        /// <returns>Résultat de l'opération de dissociation</returns>
        /// <response code="200">Catégorie dissociée du cursus avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="404">Cursus non trouvé ou catégorie non associée</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("category/remove")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> RemoveCategoryFromCursus(
            [FromBody] CursusCategoryDTO cursusCategoryDto)
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

            var response = await cursusService.RemoveCategoryFromCursusAsync(cursusCategoryDto);
            
            return StatusCode(response.Status, response);
        }
    }
}