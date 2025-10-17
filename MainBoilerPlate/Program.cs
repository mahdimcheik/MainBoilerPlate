using System.Text;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Services;
using MainBoilerPlate.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Configurer les services
var services = builder.Services;
ConfigureServices(services);

var app = builder.Build();

// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MainContext>();
    context.Database.Migrate();

    // Seed default users
    SeedUsers(scope.ServiceProvider);
}

// Configurer le pipeline de middleware
ConfigureMiddlewarePipeline(app);

app.Run();

#region Services
static void ConfigureServices(IServiceCollection services)
{
    // add services
    services.AddTransient<AuthService>();
    services.AddTransient<MailService>();
    services.AddTransient<UsersService>();
    services.AddTransient<FormationsService>();
    services.AddTransient<AddressesService>();
    services.AddTransient<ExperiencesService>();
    services.AddTransient<LanguagesService>();
    services.AddTransient<ProgrammingLanguagesService>();
    services.AddTransient<CursusService>();
    services.AddTransient<CategoryCursusService>();
    services.AddTransient<LevelCursusService>();
    services.AddTransient<SlotsService>();
    services.AddTransient<TypeSlotService>();
    services.AddTransient<FakeDataService>();
    services.AddTransient<StatusAccountService>();
    services.AddTransient<RoleAppService>();

    services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });

    services.AddRouting(opt => opt.LowercaseUrls = true);

    var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

    // db
    var connString =
        $"Host={EnvironmentVariables.DB_HOST};"
        + $"Port={EnvironmentVariables.DB_PORT};"
        + $"Database={EnvironmentVariables.DB_NAME};"
        + $"Username={EnvironmentVariables.DB_USER};"
        + $"Password={EnvironmentVariables.DB_PASSWORD};";

    var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
    dataSourceBuilder.EnableDynamicJson();
    var dataSource = dataSourceBuilder.Build();

    services.AddDbContext<MainContext>(options =>
    {
        options.UseNpgsql(dataSource);
    });

    services.Configure<DataProtectionTokenProviderOptions>(options =>
    {
        options.TokenLifespan = TimeSpan.FromHours(1);
    });

    ConfigureCors(services);
    ConfigureControllers(services);
    ConfigureSwagger(services);
    ConfigureIdentity(services);
    ConfigureAuthentication(services);
}

static void ConfigureCors(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .SetIsOriginAllowed(CorsHelper.IsOriginAllowed)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithExposedHeaders("filename");
        });
    });
}

static void ConfigureControllers(IServiceCollection services)
{
    services.AddControllers().AddOData(o => o.Count().Filter().OrderBy().SetMaxTop(1000));
    services.AddEndpointsApiExplorer();
}

static void ConfigureIdentity(IServiceCollection services)
{
    services
        .AddIdentity<UserApp, RoleApp>()
        .AddEntityFrameworkStores<MainContext>()
        .AddRoleManager<RoleManager<RoleApp>>()
        .AddUserManager<UserManager<UserApp>>()
        .AddSignInManager<SignInManager<UserApp>>()
        .AddDefaultTokenProviders();

    services.Configure<IdentityOptions>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;

        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        options.User.AllowedUserNameCharacters =
            " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = true;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    });
}

static void ConfigureAuthentication(IServiceCollection services)
{
    services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = EnvironmentVariables.API_BACK_URL,
                ValidAudience = EnvironmentVariables.API_BACK_URL,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(EnvironmentVariables.JWT_KEY)
                ),
            };
        });
}

static void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.OperationFilter<ODataQueryOperationFilter>();
        c.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "MainBoilerPlate API",
                Version = "v1",
                Description = "API for MainBoilerPlate application",
            }
        );

        var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename);
        if (System.IO.File.Exists(xmlPath))
        {
            c.IncludeXmlComments(xmlPath);
        }

        c.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            }
        );

        c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    new string[] { }
                },
            }
        );
    });

    services.AddHttpClient();
}

#endregion

#region MiddleWare
static void ConfigureMiddlewarePipeline(WebApplication app)
{
    var supportedCultures = new string[] { "fr-FR" };
    app.UseRequestLocalization(options =>
        options
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures)
            .SetDefaultCulture("fr-FR")
    );

    // Add payload size limit middleware early in the pipeline
    app.Use(
        async (context, next) =>
        {
            if (context.Request.ContentLength > 200_000_000)
            {
                context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                await context.Response.WriteAsync("Payload Too Large");
                return;
            }

            await next.Invoke();
        }
    );

    app.UseStaticFiles();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    // Swagger should be available in all environments except production
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MainBoilerPlate API v1");
        c.RoutePrefix = string.Empty; // This makes Swagger UI available at the root URL
        c.DocumentTitle = "MainBoilerPlate API Documentation";
    });

    app.UseRouting();

    app.UseCors();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}
#endregion

#region seed data
static void SeedUsers(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<MainContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleApp>>();

        // Seed a default super admin user
        var superAdminEmail = new UserApp
        {
            FirstName = "Super",
            LastName = "Admin",
            UserName = EnvironmentVariables.SUPER_ADMIN_EMAIL,
            Email = EnvironmentVariables.SUPER_ADMIN_EMAIL,
            EmailConfirmed = true,
            DateOfBirth = new DateTime(1986, 04, 21),
            StatusId = HardCode.STATUS_CONFIRMED,
        };
        var superAdminPassword = EnvironmentVariables.SUPER_ADMIN_PASSWORD;
        if (userManager.FindByEmailAsync(superAdminEmail.Email).Result == null)
        {
            var createPowerUser = userManager
                .CreateAsync(superAdminEmail, superAdminPassword)
                .Result;
            if (createPowerUser.Succeeded)
            {
                if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
                {
                    var role = new RoleApp { Name = "SuperAdmin" };
                    roleManager.CreateAsync(role).Wait();
                }
                userManager.AddToRoleAsync(superAdminEmail, "SuperAdmin").Wait();
            }
        }
    }
}
#endregion
