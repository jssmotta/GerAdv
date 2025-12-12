using Asp.Versioning;
using Domain.Sistemas.Auditor;
using Domain.Sistemas.Voice.Extensions;
using MenphisSI.GerAdv.Serialization;
using MenphisSI.HealthCheck;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.RateLimiting;

namespace MenphisSI.BaseCommon.Services;

/// <summary>
/// Classe gen�rica para inicializa��o de aplica��es ASP.NET Core
/// Segregada para permitir testes unit�rios e reutiliza��o em outros sistemas
/// </summary>
public static class IniciarApps
{
    #region Configuration Methods

    /// <summary>
    /// Configura as configura��es b�sicas do aplicativo
    /// </summary>
    public static void ConfigurarConfiguracoes(WebApplicationBuilder builder)
    {
        // ConfigurationManager j� herda de IConfiguration, n�o precisa de SetBasePath expl�cito
        builder.Configuration 
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
        //builder.Host.UseNLog();
        
        builder.Services.ConfigureAuditorJson();
        MenphisSI.GerAdv.Serialization.AddServices.Add(builder);
    }

    /// <summary>
    /// Configura os servi�os b�sicos do ASP.NET Core
    /// </summary>
    public static void ConfigurarServicosBasicos(WebApplicationBuilder builder)
    {
        //builder.Services.AddOpenApi();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();
        builder.Services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddFixedWindowLimiter("DefaultPolicy", opt =>
            {
                opt.Window = TimeSpan.FromMinutes(1);
                opt.PermitLimit = 100;
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 2;
            });
        });



        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        ConfigurarApiVersioning(builder);
        ConfigurarCompressaoResposta(builder);
        ConfigurarCache(builder);
        ConfigurarJsonOptions(builder);
    }

    /// <summary>
    /// Configura o versionamento da API
    /// </summary>
    public static void ConfigurarApiVersioning(WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });
    }

    /// <summary>
    /// Configura a compress�o de resposta
    /// </summary>
    public static void ConfigurarCompressaoResposta(WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
        });
    }

    /// <summary>
    /// Configura cache em mem�ria e h�brido
    /// </summary>
    public static void ConfigurarCache(WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        builder.Services.AddHybridCache();
        builder.Services.AddSingleton<IHybridCache, HybridCacheWrapper>();
        builder.Services.AddScoped<IConnectionService, ConnectionService>();
    }

    /// <summary>
    /// Configura op��es de serializa��o JSON
    /// </summary>
    public static void ConfigurarJsonOptions(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.PropertyNamingPolicy = null;
               options.JsonSerializerOptions.DictionaryKeyPolicy = null;
           });
    }

    #endregion

    #region Security Methods

    /// <summary>
    /// Configura autentica��o JWT
    /// </summary>
    public static void ConfigurarAutenticacaoJWT(WebApplicationBuilder builder)
    {
        var key = ObterChaveSecreta(builder.Configuration);
        var secret = builder.Configuration["AppSettings:Secret"];

        if (!string.IsNullOrEmpty(secret))
        {
            Environment.SetEnvironmentVariable("Secret", secret);
        }

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        })
        .AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = ctx =>
                {
                    var raw = ctx.Request.Headers["Authorization"].FirstOrDefault();
                    if (!string.IsNullOrEmpty(raw) && !raw.Contains('.'))
                    {
                        // n�o � JWT (evita log IDX12741)
                        ctx.NoResult();
                    }
                    return Task.CompletedTask;
                }
            };

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    /// <summary>
    /// Obt�m a chave secreta para JWT
    /// </summary>
    public static byte[] ObterChaveSecreta(Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        var secret = configuration["AppSettings:Secret"] ?? "";
        return Encoding.ASCII.GetBytes(secret);
    }

    #endregion

    #region CORS Methods

    /// <summary>
    /// Configura CORS com origens espec�ficas
    /// </summary>
    public static void ConfigurarCORS(WebApplicationBuilder builder)
    {
        var corsSites = ObterOrigensCORS(builder.Configuration);
        var listCors = ObterListaCORSDesenvolvimento();
        listCors.AddRange(corsSites);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins([.. listCors])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
        });


    }

    /// <summary>
    /// Obt�m as origens CORS da configura��o
    /// </summary>
    public static string[] ObterOrigensCORS(Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        return configuration.GetSection("AppSettings:CORS:AllowedOrigins").Get<string[]>() ?? [];
    }

    /// <summary>
    /// Obt�m a lista de CORS para desenvolvimento
    /// </summary>
    public static List<string> ObterListaCORSDesenvolvimento()
    {
#if (DEBUG || DEBUG_API_URL)
        return ["http://localhost:3000", "http://localhost:3001"];
#else
        return new List<string>();
#endif
    }

    #endregion

    #region Service Registration Methods

    /// <summary>
    /// Registra servi�os espec�ficos do dom�nio
    /// </summary>
    public static void RegistrarServicosDominio(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuditorService, AuditorService>();
        
        // Registrar EntityService para comunicação com a API de entidades
        builder.Services.AddScoped<MenphisSI.GerEntityTools.Services.IEntityService, MenphisSI.GerEntityTools.Services.EntityServices>();

        // Adicionar depend�ncias do UserService
        builder.Services.AddScoped<IOperadorService, GerAdv.Services.OperadorService>();
        builder.Services.AddScoped<IOperadorReader, GerAdv.Readers.OperadorReader>();
        builder.Services.AddScoped<IFOperadorFactory, FOperadorFactory>();

        // Registrar servi�os de comando de voz
        builder.Services.AddVoiceCommandServices();

        MenphisSI.GerAdv.Services.AddServices.Add(builder);

        try
        {
            // Registrar outros servi�os espec�ficos do dom�nio se dispon�veis
            var addServicesType = Type.GetType("MenphisSI.GerAdv.Services.AddServices");
            if (addServicesType != null)
            {
                var addMethod = addServicesType.GetMethod("Add", new[] { typeof(WebApplicationBuilder) });
                addMethod?.Invoke(null, new object[] { builder });
            }

            // Repetir para outros namespaces
            var validationsType = Type.GetType("MenphisSI.GerAdv.Validations.AddServices");
            validationsType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });

            var readersType = Type.GetType("MenphisSI.GerAdv.Readers.AddServices");
            readersType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });

            var writersType = Type.GetType("MenphisSI.GerAdv.Writers.AddServices");
            writersType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });

            var wheresType = Type.GetType("MenphisSI.GerAdv.Wheres.AddServices");
            wheresType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });

            var entityType = Type.GetType("MenphisSI.GerAdv.Entity.AddServices");
            entityType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });

            var serializationType = Type.GetType("MenphisSI.GerAdv.Serialization.AddServices");
            serializationType?.GetMethod("Add", new[] { typeof(WebApplicationBuilder) })?.Invoke(null, new object[] { builder });
        }
        catch (Exception)
        {
            // Se algum servi�o n�o estiver dispon�vel, continua sem falhar
        }
    }

    /// <summary>
    /// Configura health checks
    /// </summary>
    public static void ConfigurarHealthChecks(WebApplicationBuilder builder, Logger logger)
    {

        var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
        AppSettingsHealthCheck.Add(builder, logger, appSettings);
        
    }


    /// <summary>
    /// Inicializa configura��es externas
    /// </summary>
    public static void InicializarConfiguracoes(WebApplicationBuilder builder)
    {


        try
        {
            // Initialize Token helper configuration directly instead of using reflection
            // MenphisSI.GerEntityTools.Helper.Token.InitializeConfiguration(builder.Configuration);
        }
        catch (Exception ex)
        {
            // Log the error but continue execution
            // If logging is available, log the specific error
            System.Diagnostics.Debug.WriteLine($"Failed to initialize Token configuration: {ex.Message}");
        }

        ConfigurarCORS(builder);
    }

    #endregion

    #region Application Configuration Methods

    /// <summary>
    /// Configura o pipeline da aplica��o
    /// </summary>
    public static void ConfigurarPipeline(WebApplication app)
    {
        ConfigurarMiddlewares(app);
        ConfigurarRoteamento(app);
        ConfigurarCultura();
    }

    /// <summary>
    /// Configura middlewares da aplica��o
    /// </summary>
    public static void ConfigurarMiddlewares(WebApplication app)
    {
        // ========================================
        // Exception Handler - PRIMEIRO DE TODOS!
        // ========================================
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                
                // CRÍTICO: Garantir que CORS headers sejam enviados mesmo com erro
                if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
                {
                    var origin = context.Request.Headers["Origin"].ToString();
                    if (!string.IsNullOrEmpty(origin))
                    {
                        context.Response.Headers.Append("Access-Control-Allow-Origin", origin);
                        context.Response.Headers.Append("Access-Control-Allow-Credentials", "true");
                    }
                }
                
                await context.Response.WriteAsync("{\"error\":\"Internal server error\"}");
            });
        });
        
        // ========================================
        // CORS DEVE SER O SEGUNDO MIDDLEWARE!
        // ========================================
        // Isso garante que requisições OPTIONS (preflight) sejam tratadas
        // ANTES de qualquer autenticação ou validação
        app.UseCors("AllowSpecificOrigins");
        
        // HSTS - HTTP Strict Transport Security
        app.UseHsts();
        
        // Security Headers
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Append("X-Frame-Options", "DENY");
            context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");
            context.Response.Headers.Append("Permissions-Policy", "geolocation=(), microphone=(), camera=()");
            await next();
        });

        // Rate Limiter
        app.UseRateLimiter();
        
        // HTTPS Redirection
        app.UseHttpsRedirection();
        
        // Response Compression
        app.UseResponseCompression();
        
        // Routing - OBRIGATÓRIO antes de Authentication/Authorization
        app.UseRouting();
        
        // Authentication & Authorization
        app.UseAuthentication();
        app.UseMiddleware<JwtMiddleware>();
        app.UseAuthorization();
        
        // MapControllers - DEVE estar DEPOIS de UseRouting e UseAuthorization
        app.MapControllers();
    }

    /// <summary>
    /// Configura health checks na aplica��o
    /// </summary>
    public static void ConfigurarHealthChecksApp(WebApplication app)
    {
        try
        {
            var healthCheckControllerType = Type.GetType("MenphisSI.BaseCommon.Controllers.HealthCheckController");
            healthCheckControllerType?.GetMethod("ConfigureHealthCheckEndpoints")?.Invoke(null, new object[] { app });
        }
        catch (Exception)
        {
            // Se o HealthCheckController n�o estiver dispon�vel, continua sem falhar
        }

        AppSettingsHealthCheck.Use(app);
    }

    /// <summary>
    /// Configura roteamento da aplica��o
    /// </summary>
    public static void ConfigurarRoteamento(WebApplication app)
    {
        app.MapControllers();
    }

    /// <summary>
    /// Configura cultura da aplica��o
    /// </summary>
    public static void ConfigurarCultura()
    {
        try
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
        catch (CultureNotFoundException)
        {
            // Se pt-BR n�o estiver dispon�vel, usar a cultura padr�o do sistema
            // ou tentar uma cultura alternativa
            try
            {
                var cultureInfo = new CultureInfo("pt");
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            }
            catch (CultureNotFoundException)
            {
                // Se ainda assim falhar, manter a cultura atual do sistema
                // N�o for�ar uma cultura que pode n�o estar dispon�vel
            }
        }
    }

    #endregion

    #region Endpoint Methods

    /// <summary>
    /// Configura endpoints customizados
    /// </summary>
    public static void ConfigurarEndpointsCustomizados(WebApplication app, Logger? logger = null)
    {
        ConfigurarEndpointRoot(app, logger);
        ConfigurarEndpointApi(app, logger);
    }

    /// <summary>
    /// Configura endpoint raiz
    /// </summary>
    public static void ConfigurarEndpointRoot(WebApplication app, Logger? logger = null)
    {
        app.MapGet("/", (HttpContext context) =>
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            LogRedirecionamento(logger, ipAddress, "root");
            context.Response.Redirect("https://menphis.com.br/?ur=aaj");
            return Task.CompletedTask;
        }).ShortCircuit(200);
    }

    /// <summary>
    /// Configura endpoint da API
    /// </summary>
    public static void ConfigurarEndpointApi(WebApplication app, Logger? logger = null)
    {
        app.MapGet("/api/v1/", (HttpContext context) =>
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            LogRedirecionamento(logger, ipAddress, "api");
            context.Response.Redirect("https://menphis.com.br/?ur=aajpi");
            return Task.CompletedTask;
        }).ShortCircuit(200);
    }

    /// <summary>
    /// Log de redirecionamento (apenas em produ��o)
    /// </summary>
    public static void LogRedirecionamento(Logger? logger, string? ipAddress, string tipo)
    {
#if (!DEBUG)
        logger?.Info($"Redirecionado para Menphis ({tipo}) - IP: {ipAddress}");
#endif
    }

    #endregion

    #region Main Initialization Methods

    ///// <summary>
    ///// M�todo principal para configurar o builder
    ///// </summary>
    //public static void ConfigurarBuilder(WebApplicationBuilder builder, Logger? logger = null)
    //{
    //    ConfigurarConfiguracoes(builder);
    //    ConfigurarServicosBasicos(builder);
    //    ConfigurarCORS(builder);
    //    ConfigurarAutenticacaoJWT(builder);
    //    InicializarConfiguracoes(builder);
    //    RegistrarServicosDominio(builder);
    //    ConfigurarHealthChecks(builder, logger);
    //}

    /// <summary>
    /// M�todo principal para configurar a aplica��o
    /// </summary>
    public static void ConfigurarAplicacao(WebApplication app, Logger? logger = null)
    {
        ConfigurarHealthChecksApp(app);
        ConfigurarPipeline(app);
        ConfigurarEndpointsCustomizados(app, logger);

    }

    #endregion
}