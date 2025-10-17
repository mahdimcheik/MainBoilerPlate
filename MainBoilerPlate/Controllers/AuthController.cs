using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MainBoilerPlate.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Attributes

        /// <summary>
        /// Contexte de la base de données.
        /// </summary>
        private readonly MainContext _context;

        /// <summary>
        /// Gestionnaire des utilisateurs.
        /// </summary>
        private readonly UserManager<UserApp> _userManager;
        private readonly AuthService authService;

        /// <summary>
        /// Constructeur du contrôleur des utilisateurs.
        /// </summary>
        /// <param name="context">Contexte de la base de données.</param>
        /// <param name="userManager">Gestionnaire des utilisateurs.</param>
        /// <param name="fakerService">Service pour générer des données fictives.</param>
        /// <param name="authService">Service d'authentification.</param>
        /// <param name="connectionManager">Gestionnaire des connexions SignalR.</param>
        public AuthController(
            MainContext context,
            UserManager<UserApp> userManager,
            AuthService authService
        )
        {
            this._context = context;
            this._userManager = userManager;
            this.authService = authService;
        }

        #endregion

        #region Register update upload

        /// <summary>
        /// Enregistre un nouvel utilisateur.
        /// </summary>
        /// <param name="model">Données de création de l'utilisateur.</param>
        /// <returns>Résultat de l'opération.</returns>
        [AllowAnonymous]
        [EnableCors]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseDTO<UserResponseDTO>>> Register(
            [FromBody] UserCreateDTO model
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new ResponseDTO<object> { Status = 404, Message = "Problème de validation" }
                );
            }

            var response = await authService.Register(model);

            if (response.Status == 200 || response.Status == 201)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        //[Authorize(Roles = "Admin , SuperAdmin")]
        [EnableCors]
        [Route("confirm-status")]
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<UserResponseDTO>>> ConfirmStatus(
            [FromQuery] Guid userId
        )
        {
            var response = await authService.SetStatusConfirmed(userId);

            if (response.Status == 200 || response.Status == 201)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Met à jour les informations d'un utilisateur.
        /// </summary>
        /// <param name="model">Données de mise à jour de l'utilisateur.</param>
        /// <returns>Résultat de l'opération.</returns>
        [EnableCors]
        [Route("update")]
        [HttpPatch]
        public async Task<ActionResult<ResponseDTO<UserResponseDTO>>> Update(
            [FromBody] UserUpdateDTO model
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.Update(model, HttpContext.User);

            if (result.Status == 200 || result.Status == 201)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion

        #region POST Login

        /// <summary>
        /// Connecte un utilisateur.
        /// </summary>
        /// <param name="model">Données de connexion de l'utilisateur.</param>
        /// <returns>Résultat de l'opération.</returns>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<ResponseDTO<LoginOutputDTO>>> Login(
            [FromBody] UserLoginDTO model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(
                    new ResponseDTO<object>
                    {
                        Message = "Connexion échouée",
                        Status = 401,
                        Data = ModelState,
                    }
                );
            var result = await authService.Login(model, HttpContext.Response);

            if (result.Status == 200 || result.Status == 201)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion

        #region Confirm account

        /// <summary>
        /// Valide une adresse e-mail.
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        /// <param name="confirmationToken">Token de confirmation.</param>
        /// <returns>Résultat de l'opération.</returns>
        [AllowAnonymous]
        [Route("email-confirmation")]
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<string>>> EmailConfirmation(
            [FromQuery] string userId,
            [FromQuery] string confirmationToken
        )
        {
            var result = await authService.EmailConfirmation(userId, confirmationToken);

            if (result.Status == 200 || result.Status == 201)
            {
                return Redirect(result.Message);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Récupère un nouveau lien de confirmation.
        /// </summary>
        /// <returns>Résultat de l'opération.</returns>
        /*
        [AllowAnonymous]
        [HttpGet("resend-confirmation-link")]
        public async Task<ActionResult<ResponseDTO<UserResponseDTO>?>> ResendConfirmationLink()
        {
            var user = CheckUser.GetUserFromClaim(HttpContext.User, _context);

            if (user == null)
                return BadRequest(
                    new ResponseDTO<object> { Message = "Vous n'êtes pas connecté", Status = 401 }
                );

            var res = await authService.ResendConfirmationMail(user);

            return res.Status >= 400 ? BadRequest(res) : Ok(res);
        }*/

        #endregion

        #region CurrentUser informations

        /// <summary>
        /// Récupère les informations de l'utilisateur connecté.
        /// </summary>
        /// <returns>Informations de l'utilisateur.</returns>
        [HttpGet("my-informations")]
        public async Task<ActionResult<ResponseDTO<UserInfosWithtoken>>> GetMyInformations()
        {
            var user = CheckUser.GetUserFromClaim(HttpContext.User, _context);

            if (user == null)
                return BadRequest(
                    new ResponseDTO<UserInfosWithtoken>
                    {
                        Message = "Vous n'êtes pas connecté",
                        Status = 401,
                    }
                );

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _context.Roles.ToList();

            var rolesDetailed = roles
                .Where(r => userRoles.Contains(r.Name ?? string.Empty))
                .Select(r => new RoleAppResponseDTO(r))
                .ToList();

            return Ok(
                new ResponseDTO<UserInfosWithtoken>
                {
                    Message = "Demande acceptée",
                    Status = 200,
                    Data = new UserInfosWithtoken
                    {
                        Token = await authService.GenerateAccessTokenAsync(user),
                        User = new UserResponseDTO(user, rolesDetailed),
                    },
                }
            );
        }

        /// <summary>
        /// Récupère les informations de l'utilisateur connecté.
        /// </summary>
        /// <returns>Informations de l'utilisateur.</returns>
        [HttpGet("public-informations")]
        public async Task<ActionResult<ResponseDTO<UserResponseDTO>>> GetPublicInformations(
            Guid userId
        )
        {
            var response = await authService.GetPublicInformations(userId);
            if (response.Status >= 400)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion

        #region POST AskForPasswordRecoveryMail

        /// <summary>
        /// Demande un e-mail de récupération de mot de passe.
        /// </summary>
        /// <param name="model">Données pour la récupération du mot de passe.</param>
        /// <returns>Résultat de l'opération.</returns>
        [AllowAnonymous]
        [Route("forgot-password")]
        [HttpPost]
        public async Task<ActionResult<ResponseDTO<PasswordResetResponseDTO?>>> ForgotPassword(
            [FromBody] ForgotPasswordInput model
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new ResponseDTO<PasswordResetResponseDTO?>
                    {
                        Message = "Demande refusée",
                        Status = 400,
                    }
                );
            }

            var result = await authService.ForgotPassword(model);

            if (result.Status == 200 || result.Status == 201)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion

        #region PasswordChange after recovery

        /// <summary>
        /// Change le mot de passe après une récupération.
        /// </summary>
        /// <param name="model">Données pour changer le mot de passe.</param>
        /// <returns>Résultat de l'opération.</returns>
        [AllowAnonymous]
        [Route("reset-password")]
        [HttpPost]
        public async Task<ActionResult<ResponseDTO<string?>>> ChangePassword(
            [FromBody] PasswordRecoveryInput model
        )
        {
            if (!ModelState.IsValid || model.Password != model.PasswordConfirmation)
            {
                return BadRequest(
                    new ResponseDTO<string?> { Message = "Demande refusée", Status = 400 }
                );
            }

            var result = await authService.ChangePassword(model);

            if (result.Status == 200 || result.Status == 201)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion

        #region refresh token

        /// <summary>
        /// Met à jour le token de rafraîchissement.
        /// </summary>
        /// <returns>Résultat de l'opération.</returns>
        [Route("refresh-token")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<LoginOutputDTO?>>> UpdateRefreshToken()
        {
            if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
            {
                return Unauthorized(
                    new ResponseDTO<LoginOutputDTO?>
                    {
                        Message = "Refresh token non-existant",
                        Status = 401,
                    }
                );
            }

            var result = await authService.UpdateRefreshToken(refreshToken, HttpContext);

            if (result.Status == 200 || result.Status == 201)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion
        #region logout
        [AllowAnonymous]
        [HttpGet("logout")]
        public async Task<ActionResult<ResponseDTO<object?>>> Logout()
        {
            // Récupération de l'email/nom d'utilisateur actuel pour nettoyer les connexions
            var userEmail = HttpContext.User?.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ??
                           HttpContext.User?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ??
                           HttpContext.User?.Identity?.Name;

            Response.Cookies.Delete("refreshToken");

            return Ok(new ResponseDTO<object>
            {
                Message = "Vous êtes déconnecté",
                Status = 200
            });
        }
        #endregion
    }
}
