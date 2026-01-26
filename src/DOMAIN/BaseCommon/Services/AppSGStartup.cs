using Domain.Sistemas.Voice.Extensions;
using MenphisSI.BaseCommon.UserController;
using MenphisSI.HealthCheck;
using MenphisSI.Shared.Infrastructure.CheckDb;
using MenphisSI.Shared.Infrastructure.HealthChecks;
using MenphisSI.Shared.StartApp;
using AuditorService = Domain.BaseCommon.Auditor.AuditorService;

namespace MenphisSI.SGSys.StartApp;

/// <summary>
/// AppSG-specific service configuration
/// </summary>
public static class AppSGStartup
{
    /// <summary>
    /// Registers all AppSG-specific services
    /// </summary>
    public static void RegistrarServicosAppSG(WebApplicationBuilder builder)
    {
        // Configure AppSG-specific JSON Auditor
        builder.Services.ConfigureAuditorJson();
        AddServicesJson.Add(builder);

        // Register user services - specific UserService
        builder.Services.AddScoped<IUserService<OperadorResponse>, UserService>();
        builder.Services.AddScoped<IAuditorService, AuditorService>();

        // Register generic UserController services
        builder.Services.AddSingleton<IPasswordValidator, DefaultPasswordValidator>();

        // Register generic UserController services
        builder.Services.AddScoped<IPasswordValidator, DefaultPasswordValidator>();       


        // Register EntityService
        builder.Services.AddSingleton<MenphisSI.GerEntityTools.Services.IEntityService, MenphisSI.GerEntityTools.Services.EntityServices>();

        // Register AppSG-specific ConnectionService
        builder.Services.AddScoped<MenphisSI.IConnectionService, ConnectionService>();

        // Register MonitorController's IConnectionService adapter
        builder.Services.AddScoped<MenphisSI.Shared.Infrastructure.CheckDb.IConnectionService>(sp => 
        {
            var realService = sp.GetRequiredService<MenphisSI.IConnectionService>();
            return new ConnectionServiceAdapter(realService);
        });

        AddServicesCustom.Add(builder);
    }

    /// <summary>
    /// Configures APPSG-specific health checks
    /// </summary>
    public static void ConfigurarHealthChecksAppSG(WebApplicationBuilder builder, Logger? logger)
    {
        // Register HealthChecks UI with database (required for /dashboard and /healthui-api endpoints)
        AppSettingsHealthCheckDefault.AddX(builder);
        
        // Register basic health check services
        AppSettingsHealthCheckDefault.Add(builder);

#if HAS_LCK
        // Add custom health checks
        builder.Services.AddHealthChecks()
            // GeoDbHealthCheck optimized with Lazy Singleton (reduces ~16MB of memory)
            .AddGeoBlockingHealthCheck("Geo Ip-db")
            // ConnectionPool health check to monitor database connections
            .AddCheck<HealthCheckConnectionPoolService>("Connections pool", tags: ["database", "connections", "pool"]);
#endif
            }


    /// <summary>
    /// Configures APPSG health check endpoints
    /// </summary>
    public static void ConfigurarHealthCheckEndpointsAppSG(WebApplication app)
    {
        AppSettingsHealthCheckDefault.Use(app);
    }

    /// <summary>
    /// Configures APPSG voice services
    /// </summary>
    public static void ConfigurarVoiceServices(WebApplicationBuilder builder)
    {
        builder.Services.AddVoiceCommandServices();
     
    }

    /// <summary>
    /// Initializes APPSG external configurations
    /// </summary>
    public static void InicializarConfiguracoes(WebApplicationBuilder builder)
    {
        try
        {
            // Initialize UriApi configuration directly instead of using reflection
            MenphisSI.GerEntityTools.Apis.UriApi.InitializeConfiguration(builder.Configuration);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to initialize UriApi configuration: {ex.Message}");
        }
    }

    /// <summary>
    /// Configures APPSG-specific middlewares
    /// </summary>
    public static void ConfigurarMiddlewaresAppSG(WebApplication app)
    {
#if HAS_LCK
        // Add geo-blocking middleware
        app.UseGeoBlockingWithForwardedHeaders();
#endif
    }

    /// <summary>
    /// Configures APPSG-specific JWT middleware
    /// </summary>
    public static void ConfigurarMiddlewareJWT(WebApplication app)
    {
        // Use specific JwtMiddleware
        app.UseMiddleware<JwtMiddlewareAppSG>();
    }

    /// <summary>
    /// Creates a complete configuration for APPSG
    /// </summary>
    public static ConfiguracaoInicializacao CriarConfiguracaoAppSG(bool isDevelopment = false)
    {
        var configuracao = isDevelopment
            ? StartupApp.CriarConfiguracaoDesenvolvimento()
            : StartupApp.CriarConfiguracaoSistemaAppSG();
        
        // Configure APPSG-specific actions
        configuracao.RegistrarServicosDominio = RegistrarServicosAppSG;
        configuracao.ConfigurarHealthChecksCustomizados = ConfigurarHealthChecksAppSG;
        configuracao.ConfigurarMiddlewareJWT = ConfigurarMiddlewareJWT;
        configuracao.ConfigurarHealthCheckEndpoints = ConfigurarHealthCheckEndpointsAppSG;

        return configuracao;
    }
}
