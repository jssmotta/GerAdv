using MenphisSI.BaseCommon.UserController;
using MenphisSI.GerAdv.HealthCheck;
using MenphisSI.HealthCheck;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MenphisSI.GerEntityTools.Entity;
using Domain.BaseCommon.Helpers;
using MenphisSI.Shared.Infrastructure.CheckDb;
using MenphisSI.Shared.StartApp;
using AuditorService = Domain.BaseCommon.Auditor.AuditorService;
using IConnectionService = MenphisSI.Shared.Infrastructure.Connections.IConnectionService;

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
        builder.Services.AddSingleton<IEntityService, EntityServices>();
        builder.Services.AddSingleton<IEntityServiceEml, EntityServicesEml>();
        builder.Services.AddSingleton<SendEmailApi>();

       // Register AppSG-specific ConnectionService
       builder.Services.AddScoped<IConnectionService, ConnectionService>(); 

        builder.Services.AddScoped<IConfiguracoesSys, ConfiguracoesSysX>();

        // Register MonitorController's IConnectionService adapter
        builder.Services.AddScoped<MenphisSI.Shared.Infrastructure.CheckDb.IConnectionService>(sp => 
        {
            var realService = sp.GetRequiredService<IConnectionService>();
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

        // Read notification URIs from configuration and register a health check for each
        var urisNotificadorAgendaStr = builder.Configuration.GetValue<string>("AppSettings:UrisNotificadorAgenda") ?? "";
        var urisNotificadorAgenda = urisNotificadorAgendaStr.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(u => u.Trim()).ToList();

        var urisAniversariantesStr = builder.Configuration.GetValue<string>("AppSettings:UrisAniversariantes") ?? "";
        var urisAniversariantes = urisAniversariantesStr.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(u => u.Trim()).ToList();

        // Read time configuration from settings
        var horaDia = Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<int>(builder.Configuration, "AppSettings:HoraDia", 8);
        var horaNovos = Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<int>(builder.Configuration, "AppSettings:HoraNovos", 20);

        var healthBuilder = builder.Services.AddHealthChecks();

        // Build a temporary provider to resolve dependencies required for constructing the health check instances
        var tempProvider = builder.Services.BuildServiceProvider();
        var sendEmailApi = tempProvider.GetRequiredService<SendEmailApi>();

        // Register one health check instance per configured URI for the agenda notifier
        foreach (var tenantKey in urisNotificadorAgenda)
        {
            var name = $"Notification-{tenantKey}";
            healthBuilder.AddCheck(name, new HealthCheckNotificadorService(tenantKey, sendEmailApi, horaDia, horaNovos), tags: ["notify"]);
        }

 
        // Register one health check instance per configured URI for the aniversariantes notifier
        foreach (var tenantKey in urisAniversariantes)
        {
            var name = $"Aniversariantes-{tenantKey}";
            // EnvioNotificacoesAniversariantes depends on SendEmailApi
            var envio = new EnvioNotificacoesAniversariantes(sendEmailApi);
            healthBuilder.AddCheck(name, new HealthCheckNotificadorAniversariantesService(tenantKey, envio, horaDia), tags: new[] { "Niver" });
        }

 

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
       // builder.Services.AddVoiceCommandServices();
     
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
