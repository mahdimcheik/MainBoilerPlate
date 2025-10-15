using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MainBoilerPlate.Controllers
{
    /// <summary>
    /// Contrôleur pour générer des données fictives de test
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class FakeDataController(FakeDataService fakeDataService) : ControllerBase
    {
        /// <summary>
        /// Génère des utilisateurs fictifs avec différents rôles (Admin, Teacher, Student)
        /// </summary>
        /// <param name="count">Nombre d'utilisateurs à générer par rôle (par défaut: 10)</param>
        /// <returns>Statistiques des utilisateurs créés</returns>
        /// <response code="201">Utilisateurs créés avec succès</response>
        /// <response code="400">Erreur de validation ou données de base manquantes</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("users")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> GenerateFakeUsers(
            [FromQuery] int count = 10)
        {
            if (count <= 0 || count > 100)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Le nombre d'utilisateurs doit être entre 1 et 100",
                    Data = null
                });
            }

            var response = await fakeDataService.GenerateFakeUsersAsync(count);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Génère des adresses fictives pour les utilisateurs existants
        /// </summary>
        /// <param name="addressesPerUser">Nombre d'adresses par utilisateur (par défaut: 2)</param>
        /// <returns>Nombre d'adresses créées</returns>
        /// <response code="201">Adresses créées avec succès</response>
        /// <response code="400">Aucun utilisateur trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("addresses")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> GenerateFakeAddresses(
            [FromQuery] int addressesPerUser = 2)
        {
            if (addressesPerUser <= 0 || addressesPerUser > 10)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Le nombre d'adresses par utilisateur doit être entre 1 et 10",
                    Data = null
                });
            }

            var response = await fakeDataService.GenerateFakeAddressesAsync(addressesPerUser);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Génère des types de créneaux fictifs
        /// </summary>
        /// <param name="count">Nombre de types de créneaux à générer (par défaut: 5)</param>
        /// <returns>Nombre de types de créneaux créés</returns>
        /// <response code="201">Types de créneaux créés avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("type-slots")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> GenerateFakeTypeSlots(
            [FromQuery] int count = 5)
        {
            if (count <= 0 || count > 20)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Le nombre de types de créneaux doit être entre 1 et 20",
                    Data = null
                });
            }

            var response = await fakeDataService.GenerateFakeTypeSlotsAsync(count);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Génère des créneaux fictifs pour les enseignants
        /// </summary>
        /// <param name="slotsPerTeacher">Nombre de créneaux par enseignant (par défaut: 10)</param>
        /// <returns>Nombre de créneaux créés</returns>
        /// <response code="201">Créneaux créés avec succès</response>
        /// <response code="400">Aucun enseignant ou type de créneau trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("slots")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> GenerateFakeSlots(
            [FromQuery] int slotsPerTeacher = 10)
        {
            if (slotsPerTeacher <= 0 || slotsPerTeacher > 50)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Le nombre de créneaux par enseignant doit être entre 1 et 50",
                    Data = null
                });
            }

            var response = await fakeDataService.GenerateFakeSlotsAsync(slotsPerTeacher);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Génère un jeu complet de données fictives (utilisateurs, adresses, types de créneaux, créneaux)
        /// </summary>
        /// <returns>Statistiques complètes des données générées</returns>
        /// <response code="201">Toutes les données créées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("all")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> GenerateAllFakeData()
        {
            var response = await fakeDataService.GenerateAllFakeDataAsync();
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime toutes les données fictives générées (utilisateurs avec email @fake.com et données liées)
        /// </summary>
        /// <returns>Nombre d'utilisateurs supprimés</returns>
        /// <response code="200">Données fictives supprimées avec succès</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("clear")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> ClearFakeData()
        {
            var response = await fakeDataService.ClearFakeDataAsync();
            return StatusCode(response.Status, response);
        }
    }
}