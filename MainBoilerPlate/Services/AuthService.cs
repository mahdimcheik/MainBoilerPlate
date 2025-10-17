using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service d'authentification pour gérer l'inscription, la connexion et les opérations liées aux utilisateurs
    /// </summary>
    public class AuthService
    {
        private readonly MainContext context;
        private readonly UserManager<UserApp> userManager;
        private readonly IWebHostEnvironment _env;
        private readonly MailService mailService;

        /// <summary>
        /// Initialise une nouvelle instance du service d'authentification
        /// </summary>
        /// <param name="context">Contexte de base de données</param>
        /// <param name="userManager">Gestionnaire d'utilisateurs Identity</param>
        /// <param name="env">Environnement d'hébergement web</param>
        public AuthService(
            MainContext context,
            UserManager<UserApp> userManager,
            IWebHostEnvironment env,
            MailService mailService
        )
        {
            this.context = context;
            this.userManager = userManager;
            this._env = env;
            this.mailService = mailService;
        }

        /// <summary>
        /// Enregistre un nouvel utilisateur
        /// </summary>
        /// <param name="newUserDTO">Données de création de l'utilisateur</param>
        /// <returns>Réponse contenant les informations de l'utilisateur créé</returns>
        public async Task<ResponseDTO<UserResponseDTO>> Register(UserCreateDTO newUserDTO)
        {
            // Vérifier le consentement
            if (!newUserDTO.DataProcessingConsent || !newUserDTO.PrivacyPolicyConsent)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Status = 400,
                    Message =
                        "\"Le consentement est obligatoire pour acceder aux fonctionnalités de cette application\"",
                };
            }

            bool isEmailAlreadyUsed = await IsEmailAlreadyUsedAsync(newUserDTO.Email);
            // Vérifier si l'adresse e-mail est déjà utilisée
            if (isEmailAlreadyUsed)
            {
                // Si l'adresse e-mail est déjà utilisée, mettre à jour la réponse et sauter vers l'étiquette UserAlreadyExisted
                return new ResponseDTO<UserResponseDTO>
                {
                    Status = 400,
                    Message = "\"L'email est déjà utilisé\"",
                };
            }
            // Créer un nouvel utilisateur en utilisant les données du modèle et la base de données contextuelle
            UserApp newUser = newUserDTO.ToUser();
            newUser.CreatedAt = DateTime.Now;
            newUser.StatusId = HardCode.STATUS_PENDING;

            // Obtenir la date actuelle
            DateTimeOffset date = DateTimeOffset.UtcNow;

            // Tenter de créer un nouvel utilisateur avec le gestionnaire d'utilisateurs
            IdentityResult result = await userManager.CreateAsync(newUser, newUserDTO.Password);

            // Tenter d'ajouter l'utilisateur aux rôles spécifiés dans le modèle
            IdentityResult roleResult = await userManager.AddToRolesAsync(
                user: newUser,
                roles: newUserDTO.RoleId == HardCode.ROLE_TEACHER ? ["Teacher"] : ["Student"]
            );

            // Vérifier si la création de l'utilisateur a échoué
            if (!result.Succeeded)
            {
                // Si la création a échoué, ajouter les erreurs au modèle d'état pour retourner une réponse BadRequest
                var errors = Enumerable.Empty<string>();
                foreach (var error in result.Errors)
                {
                    errors.Append(error.Description);
                }

                // Retourner une réponse BadRequest avec le modèle d'état contenant les erreurs
                return new ResponseDTO<UserResponseDTO>
                {
                    Message = "Création échouée",
                    Status = 401,
                    Data = null,
                };
            }

            // Si tout s'est bien déroulé, enregistrer les changements dans le contexte de base de données
            await context.SaveChangesAsync();

            try
            {
                var confirmationLink = await GenerateAccountConfirmationLink(newUser);
                await mailService.SendConfirmAccount(newUser, confirmationLink ?? "");

                // Retourne une réponse avec le statut déterminé, l'identifiant de l'utilisateur, le message de réponse et le statut complet
                return new ResponseDTO<UserResponseDTO>
                {
                    Message = "Profil créé",
                    Status = 201,
                    Data = new UserResponseDTO(newUser, null),
                };
            }
            catch (Exception e)
            {
                // En cas d'exception, afficher la trace et retourner une réponse avec le statut approprié
                Console.WriteLine(e);
                return new ResponseDTO<UserResponseDTO>
                {
                    Status = 40,
                    Message = "Le compte n'est pas créé!!!",
                };
            }
        }

        public async Task<ResponseDTO<UserResponseDTO>> GetPublicInformations(Guid userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if(user is null)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Message = "Demande acceptée",
                    Status = 400,
                    Data = null
                };
            }
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = context.Roles.ToList();

            var rolesDetailed = roles
                .Where(r => userRoles.Contains(r.Name ?? string.Empty))
                .Select(r => new RoleAppResponseDTO(r))
                .ToList();

            return
                new ResponseDTO<UserResponseDTO>
                {
                    Message = "Demande acceptée",
                    Status = 200,
                    Data = new UserResponseDTO(user, rolesDetailed),                   
                };            
        }


        public async Task<ResponseDTO<bool>> SetStatusConfirmed(Guid UserId)
        {
            await context.Users.ExecuteUpdateAsync(up =>
                up.SetProperty(u => u.StatusId, HardCode.STATUS_CONFIRMED)
            );
            return new ResponseDTO<bool> { Message = "Compte confirmé", Status = 201 };
        }

        /// <summary>
        /// Renvoie un email de confirmation à l'utilisateur
        /// </summary>
        /// <param name="newUser">Utilisateur pour lequel renvoyer l'email</param>
        /// <returns>Réponse indiquant le succès ou l'échec de l'envoi</returns>
        /*
         public async Task<ResponseDTO<UserResponseDTO>> ResendConfirmationMail(UserApp newUser)
        {
            try
            {
                var confirmationLink = await GenerateAccountConfirmationLink(newUser);
                await mailService.ScheduleSendConfirmationEmail(
                    new Mail
                    {
                        MailBody = confirmationLink,
                        MailSubject = "Mail de confirmation",
                        MailTo = newUser.Email ?? "mahdi.mcheik@hotmail.fr",
                    },
                    confirmationLink ?? ""
                );

                // Retourne une réponse avec le statut déterminé, l'identifiant de l'utilisateur, le message de réponse et le statut complet
                return new ResponseDTO<UserResponseDTO>
                {
                    Message = "Email envoyé",
                    Status = 201,
                    Data = newUser.ToUserResponseDTO(),
                };
            }
            catch (Exception e)
            {
                // En cas d'exception, afficher la trace et retourner une réponse avec le statut approprié
                Console.WriteLine(e);
                return new ResponseDTO<UserResponseDTO>
                {
                    Status = 40,
                    Message = "L'email n'est pas envoyé!!!",
                };
            }
        }*/

        /// <summary>
        /// Met à jour les informations d'un utilisateur
        /// </summary>
        /// <param name="model">Données de mise à jour</param>
        /// <param name="UserPrincipal">Principal de l'utilisateur connecté</param>
        /// <returns>Réponse contenant les informations mises à jour</returns>
        public async Task<ResponseDTO<UserResponseDTO>> Update(
            UserUpdateDTO model,
            ClaimsPrincipal UserPrincipal
        )
        {
            var user = CheckUser.GetUserFromClaim(UserPrincipal, context);
            if (user is null)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Status = 40,
                    Message = "Le compte n'existe pas ou ne correspond pas",
                };
            }
            
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                // Load user with existing relationships
                var userWithLanguages = await context
                    .Users.Where(u => u.Id == user.Id)
                    .Include(u => u.Languages)
                    .Include(u => u.ProgrammingLanguages)
                    .FirstOrDefaultAsync();

                if (userWithLanguages == null)
                {
                    return new ResponseDTO<UserResponseDTO>
                    {
                        Status = 404,
                        Message = "Utilisateur non trouvé",
                    };
                }

                // Update basic data
                model.UpdateUser(userWithLanguages);

                // Clear existing language relationships
                userWithLanguages.Languages.Clear();
                userWithLanguages.ProgrammingLanguages.Clear();

                // Add new languages
                if (model.LanguagesIds?.Any() == true)
                {
                    var newLanguages = await context
                        .Languages.Where(l => model.LanguagesIds.Contains(l.Id))
                        .ToListAsync();
                    
                    foreach (var language in newLanguages)
                    {
                        userWithLanguages.Languages.Add(language);
                    }
                }

                // Add new programming languages
                if (model.ProgrammingLanguagesIds?.Any() == true)
                {
                    var newProgrammingLanguages = await context
                        .ProgrammingLanguages.Where(l => model.ProgrammingLanguagesIds.Contains(l.Id))
                        .ToListAsync();
                    
                    foreach (var programmingLanguage in newProgrammingLanguages)
                    {
                        userWithLanguages.ProgrammingLanguages.Add(programmingLanguage);
                    }
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                var userRoles = await userManager.GetRolesAsync(userWithLanguages);
                var roles = context.Roles.ToList();

                var rolesDetailed = roles
                    .Where(r => userRoles.Contains(r.Name ?? string.Empty))
                    .Select(r => new RoleAppResponseDTO(r))
                    .ToList();
                return new ResponseDTO<UserResponseDTO>
                {
                    Message = "Profil mis à jour",
                    Status = 200,
                    Data = new UserResponseDTO(userWithLanguages, rolesDetailed),
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ResponseDTO<UserResponseDTO> { Status = 500, Message = ex.Message };
            }
        }

        /// <summary>
        /// Confirme l'email d'un utilisateur
        /// </summary>
        /// <param name="userId">ID de l'utilisateur</param>
        /// <param name="confirmationToken">Token de confirmation</param>
        /// <returns>Réponse indiquant le succès ou l'échec de la confirmation</returns>
        public async Task<ResponseDTO<string?>> EmailConfirmation(
            string userId,
            string confirmationToken
        )
        {
            UserApp user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return new ResponseDTO<string?> { Message = "Validation échouée", Status = 400 };
            }

            IdentityResult result = await userManager.ConfirmEmailAsync(user, confirmationToken);

            if (result.Succeeded)
            {
                return new ResponseDTO<string?>
                {
                    Message =
                        $"{EnvironmentVariables.API_FRONT_URL}/auth/email-confirmation-success",
                    Status = 200,
                };
            }

            return new ResponseDTO<string?> { Message = "Validation échouée", Status = 400 };
        }

        /// <summary>
        /// Met à jour le token de rafraîchissement
        /// </summary>
        /// <param name="refreshToken">Token de rafraîchissement</param>
        /// <param name="httpContext">Contexte HTTP</param>
        /// <returns>Réponse contenant les nouvelles informations de connexion</returns>
        public async Task<ResponseDTO<LoginOutputDTO>> UpdateRefreshToken(
            string refreshToken,
            HttpContext httpContext
        )
        {
            var refreshTokenDB = await context
                .RefreshTokens.Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.Token == refreshToken && x.ExpirationDate > DateTimeOffset.UtcNow
                );

            if (refreshTokenDB is null || refreshTokenDB.User is null)
            {
                return new ResponseDTO<LoginOutputDTO>
                {
                    Message = "Token expiré ou non valide",
                    Status = 401,
                };
            }

            httpContext.Response.Headers.Append(
                key: "Access-Control-Allow-Credentials",
                value: "true"
            );

            var userRoles = await userManager.GetRolesAsync(refreshTokenDB.User);
            var roles = context.Roles.ToList();

            var rolesDetailed = roles
                .Where(r => userRoles.Contains(r.Name ?? string.Empty))
                .Select(r => new RoleAppResponseDTO(r))
                .ToList();

            return new ResponseDTO<LoginOutputDTO>
            {
                Message = "Autorisation renouvelée",
                Data = new LoginOutputDTO
                {
                    User = new UserResponseDTO(refreshTokenDB.User, rolesDetailed),
                    Token = await GenerateAccessTokenAsync(refreshTokenDB.User),
                    RefreshToken = refreshToken,
                },
                Status = 200,
            };
        }

        /// <summary>
        /// Initie le processus de récupération de mot de passe
        /// </summary>
        /// <param name="model">Données de récupération</param>
        /// <returns>Réponse contenant les informations de récupération</returns>
        public async Task<ResponseDTO<PasswordResetResponseDTO>> ForgotPassword(
            ForgotPasswordInput model
        )
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                try
                {
                    var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                    resetToken = HttpUtility.UrlEncode(resetToken);

                    var resetLink =
                        EnvironmentVariables.API_FRONT_URL
                        + "/auth/reset-password?userId="
                        + user.Id
                        + "&resetToken="
                        + resetToken;

                    // Tentative d'envoi de l'e-mail pour la regénération du mot de passe

                    //await mailService.ScheduleSendResetEmail(
                    //    new Mail
                    //    {
                    //        MailSubject = "Mail de réinitialisation",
                    //        MailTo = user.Email,
                    //    },
                    //    resetLink
                    //);

                    return new ResponseDTO<PasswordResetResponseDTO>
                    {
                        Message =
                            "Un email de réinitialisation vient d'être envoyé à cette adresse "
                            + user.Email,
                        Status = 200,
                        Data = new PasswordResetResponseDTO
                        {
                            ResetToken = resetToken,
                            Email = user.Email,
                            Id = user.Id,
                        },
                    };
                }
                catch
                {
                    return new ResponseDTO<PasswordResetResponseDTO>
                    {
                        Message = "Erreur de réinitialisation, réessayez plus tard ",
                        Status = 400,
                    };
                }
            }

            return new ResponseDTO<PasswordResetResponseDTO>
            {
                Message = "Erreur de réinitialisation, réessayez plus tard ",
                Status = 400,
            };
        }

        /// <summary>
        /// Change le mot de passe d'un utilisateur
        /// </summary>
        /// <param name="model">Données de récupération de mot de passe</param>
        /// <returns>Réponse indiquant le succès ou l'échec du changement</returns>
        public async Task<ResponseDTO<string?>> ChangePassword(PasswordRecoveryInput model)
        {
            UserApp? user = await userManager.FindByIdAsync(model.UserId);
            if (user is null)
            {
                return new ResponseDTO<string?>
                {
                    Message = "L'utilisateur n'existe pas",
                    Status = 404,
                };
            }

            IdentityResult result = await userManager.ResetPasswordAsync(
                user: user,
                token: model.ResetToken,
                newPassword: model.Password
            );

            var newRefreshToken = await RenewRefreshTokenAsync(user);

            if (result.Succeeded)
            {
                return new ResponseDTO<string?>
                {
                    Message = "Mot de passe vient d'être modifié",
                    Status = 201,
                };
            }

            return new ResponseDTO<string?>
            {
                Message = "Problème de validation, votre token est valid ?",
                Status = 404,
            };
        }

        /// <summary>
        /// Connecte un utilisateur
        /// </summary>
        /// <param name="model">Données de connexion</param>
        /// <param name="response">Réponse HTTP</param>
        /// <returns>Réponse contenant les informations de connexion</returns>
        public async Task<ResponseDTO<LoginOutputDTO>> Login(
            UserLoginDTO model,
            HttpResponse response
        )
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new ResponseDTO<LoginOutputDTO>
                {
                    Message = "L'utilisateur n'existe pas ",
                    Status = 404,
                };
            }

            var result = await userManager.CheckPasswordAsync(user: user, password: model.Password);
            if (!userManager.CheckPasswordAsync(user: user, password: model.Password).Result)
            {
                return new ResponseDTO<LoginOutputDTO>
                {
                    Message = "Connexion échouée",
                    Status = 401,
                };
            }

            // à la connection, je crée ou je met à jour le refreshtoken
            var refreshToken = await CreateOrUpdateTokenAsync(user, forceReset: true);

            await context.SaveChangesAsync();
            // to allow cookies sent from the front end
            response.Headers.Append(key: "Access-Control-Allow-Credentials", value: "true");
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = context.Roles.ToList();

            var rolesDetailed = roles
                .Where(r => userRoles.Contains(r.Name ?? string.Empty))
                .Select(r => new RoleAppResponseDTO(r))
                .ToList();

            response.Cookies.Append(
                "refreshToken",
                refreshToken.Token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddDays(
                        EnvironmentVariables.COOKIES_VALIDITY_DAYS
                    ),
                }
            );

            return new ResponseDTO<LoginOutputDTO>
            {
                Message = "Connexion réussite",
                Status = 200,
                Data = new LoginOutputDTO
                {
                    Token = await GenerateAccessTokenAsync(user),
                    RefreshToken = refreshToken?.Token,
                    User = new UserResponseDTO(user, rolesDetailed),
                },
            };
        }

        private async Task<RefreshToken?> CreateOrUpdateTokenAsync(
            UserApp user,
            bool forceReset = false
        )
        {
            // à la connection, je crée ou je met à jour le refreshtoken
            var refreshToken = context.RefreshTokens.FirstOrDefault(x => x.UserId == user.Id);

            if (refreshToken is null)
            {
                refreshToken = new RefreshToken
                {
                    Id = Guid.NewGuid(),
                    Token = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    ExpirationDate = DateTimeOffset.UtcNow.AddDays(
                        EnvironmentVariables.COOKIES_VALIDITY_DAYS
                    ),
                };
                context.RefreshTokens.Add(refreshToken);
            }
            else if (forceReset)
            {
                refreshToken.UserId = user.Id;
                refreshToken.ExpirationDate = DateTimeOffset.UtcNow.AddDays(
                    EnvironmentVariables.COOKIES_VALIDITY_DAYS
                );
            }

            await context.SaveChangesAsync();

            return refreshToken;
        }

        private async Task<RefreshToken?> RenewRefreshTokenAsync(UserApp user)
        {
            var refreshToken = context.RefreshTokens.FirstOrDefault(x => x.UserId == user.Id);

            if (refreshToken is null)
            {
                context.RefreshTokens.Add(
                    new RefreshToken
                    {
                        Id = Guid.NewGuid(),
                        Token = Guid.NewGuid().ToString(),
                        UserId = user.Id,
                        ExpirationDate = DateTimeOffset.UtcNow.AddDays(
                            EnvironmentVariables.COOKIES_VALIDITY_DAYS
                        ),
                    }
                );
            }
            else
            {
                refreshToken.Token = Guid.NewGuid().ToString();
                refreshToken.UserId = user.Id;
                refreshToken.ExpirationDate = DateTimeOffset.UtcNow.AddDays(
                    EnvironmentVariables.COOKIES_VALIDITY_DAYS
                );
            }

            await context.SaveChangesAsync();

            return refreshToken;
        }

        /// <summary>
        /// Génère un token d'accès JWT pour l'utilisateur
        /// </summary>
        /// <param name="user">Utilisateur pour lequel générer le token</param>
        /// <returns>Token JWT en string</returns>
        public async Task<string> GenerateAccessTokenAsync(UserApp user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(EnvironmentVariables.JWT_KEY)
            );
            var credentials = new SigningCredentials(
                key: securityKey,
                algorithm: SecurityAlgorithms.HmacSha256
            );

            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(type: ClaimTypes.Email, value: user.Email),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(type: ClaimTypes.Role, value: userRole));
            }

            var token = new JwtSecurityToken(
                issuer: EnvironmentVariables.API_BACK_URL,
                audience: EnvironmentVariables.API_BACK_URL,
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(EnvironmentVariables.TOKEN_VALIDITY_MINUTES),
                signingCredentials: credentials
            );

            context.Entry(user).State = EntityState.Modified;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string?> GenerateAccountConfirmationLink(UserApp user)
        {
            var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            confirmationToken = HttpUtility.UrlEncode(confirmationToken);

            var confirmationLink =
                EnvironmentVariables.API_BACK_URL
                + "/auth/email-confirmation?userId="
                + user.Id
                + "&confirmationToken="
                + confirmationToken;

            return confirmationLink;
        }

        private async Task<bool> IsEmailAlreadyUsedAsync(string email)
        {
            var existingUser = await userManager.FindByEmailAsync(email);
            return existingUser != null;
        }
    }
}
