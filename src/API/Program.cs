/*
 
Ajuda para a IA: Os Health Checks ESTÃO REGISTRADOS corretamente!
O fluxo completo é:
1.	Program.cs chama Start upAppAdvanced.ConfigurarBuilder(builder, configuracao, logger)
2.	ConfigurarBuilder(WebApplicationBuilder, ConfiguracaoInicializacao?, Logger?) chama configuracao.ConfigurarHealthChecksCustomizados?.Invoke(builder, logger)
3.	ConfigurarHealthChecksAppSG(WebApplicationBuilder, Logger?) chama AppSettingsHealthCheckDefault.Add(builder)
4.	Add(WebApplicationBuilder) registra os 4 Health Check services no DI com AddHealthChecks().AddCheck<T>()

 */

using API.OpenTelemetry;
using API.Resilience;
using API.Sistemas.Auditor;
using MenphisSI.BaseCommon.Controllers;
using MenphisSI.BaseCommon.Helpers;
using MenphisSI.BaseCommon.Metrics;
using MenphisSI.BaseCommon.UserController;
using MenphisSI.SGSys.StartApp;
using MenphisSI.Shared.BaseCommon.API.Guardian;
using MenphisSI.Shared.BaseCommon.API.Prometheus;
using MenphisSI.Shared.StartApp;

var logger = ProgramNLog.ConfigureNLog();

try
{
    logger.Info("Iniciado WebApi");

    var builder = WebApplication.CreateBuilder(args);

    

    // Registrar IUsersMetrics para o controller genérico
    builder.Services.AddSingleton<IUsersMetrics, UsersMetricsAdapter>();

    // Configurar URLs incluindo porta para métricas Prometheus (apenas se porta separada configurada)
    var openTelemetrySettings = builder.Configuration
        .GetSection(OpenTelemetrySettings.SectionName)
        .Get<OpenTelemetrySettings>() ?? new OpenTelemetrySettings();

    // Apenas configura porta separada se PrometheusPort > 0
    if (openTelemetrySettings.Enabled && openTelemetrySettings.UseSeparatePort)
    {
        var currentUrls = builder.Configuration["urls"] ?? builder.Configuration["ASPNETCORE_URLS"] ?? "http://*:80";
        var prometheusUrl = $"http://localhost:{openTelemetrySettings.PrometheusPort}";

        // Adicionar porta do Prometheus se não estiver já configurada
        if (!currentUrls.Contains($":{openTelemetrySettings.PrometheusPort}"))
        {
            builder.WebHost.UseUrls(currentUrls, prometheusUrl);
            logger.Info($"Configurado Prometheus em porta separada: {prometheusUrl}{openTelemetrySettings.PrometheusEndpoint}");
        }
    }
    else if (openTelemetrySettings.Enabled)
    {
        logger.Info($"Prometheus configurado no mesmo endpoint da API: {openTelemetrySettings.PrometheusEndpoint}");
    }

    

    // Adicionar configuração de resiliência (Polly Circuit Breaker)
    builder.Services.AddResilienceConfiguration(builder.Configuration);

    // Adicionar configuração de Bulkhead (controle de concorrência)
    builder.Services.AddBulkheadPolicies(builder.Configuration);

    SettingsMetrics.ConfigurarBuilder(builder);

    // Determinar configuração baseada no ambiente usando a nova estrutura
    ConfiguracaoInicializacao configuracao = builder.Environment.IsDevelopment()
        ? AppSGStartup.CriarConfiguracaoAppSG(isDevelopment: true)
        : AppSGStartup.CriarConfiguracaoAppSG(isDevelopment: false);

    if (builder.Environment.IsDevelopment())
    {
        logger.Info("Ambiente de desenvolvimento detectado");

        // Personalizar configuração para desenvolvimento se necessário
        configuracao.ConfigurarEndpointsCustomizados = (app) =>
        {
            // Endpoints úteis para desenvolvimento
            app.MapGet("/dev/info", () => new
            {
                Environment = "Development",
                Version = "1.0.0-dev",
                Timestamp = DateTime.Now,
                MachineName = Environment.MachineName
            });

            app.MapGet("/dev/config", () => new
            {
                Message = "Usando configuração de desenvolvimento",
                CORS = configuracao.OrigensCORSDesenvolvimento,
                JWT_RequireHttps = configuracao.ConfiguracaoJWT.RequireHttpsMetadata
            });
        };
    }
    else if (builder.Environment.IsProduction())
    {
        logger.Info("Ambiente de produção detectado");
    }
    else
    {
        logger.Info("Ambiente não específico detectado - usando configuração padrão");
    }

    // Obter configurações de resiliência
    var resilienceSettings = builder.Configuration
        .GetSection(ResilienceSettings.SectionName)
        .Get<ResilienceSettings>() ?? new ResilienceSettings();

#if HAS_LCK
    // Configurar HttpClient Factory para DevToolsApi com políticas de resiliência
    builder.Services.AddHttpClient<IDevToolsApiClient, DevToolsApiClient>((sp, client) =>
    {
        var config = sp.GetRequiredService<IConfiguration>();
        var baseUrl = config["DevToolsApi:BaseUrl"]!;
        client.BaseAddress = new Uri(baseUrl);
        client.Timeout = TimeSpan.FromSeconds(config.GetValue<int>("DevToolsApi:TimeoutSeconds", 30));
    })
    .AddResiliencePolicies(resilienceSettings)
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        MaxConnectionsPerServer = 10,
        AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
    });
    builder.Services.AddScoped<ILoginValidationService, DevToolsLoginValidationService>();
#endif

    // Registrar ILoginValidationService usando DevToolsApiClient


    // Configurar HttpClient para reCAPTCHA com políticas de resiliiência
    var reCaptchaResilienceSettings = new ResilienceSettings
    {
        MaxRetryAttempts = 3,
        RetryDelaySeconds = 1,
        TimeoutSeconds = 10,
        CircuitBreakerFailureThreshold = 5,
        CircuitBreakerDurationSeconds = 30
    };

    builder.Services.AddHttpClient("ReCaptcha", client =>
    {
        client.Timeout = TimeSpan.FromSeconds(15);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    })
    .AddResiliencePolicies(reCaptchaResilienceSettings)
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        MaxConnectionsPerServer = 5,
        AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
    });

    // Configurar serviços de voz específicos do AppSG
    AppSGStartup.ConfigurarVoiceServices(builder);

    // Inicializar configurações externas do AppSG
    AppSGStartup.InicializarConfiguracoes(builder);

    // Configurar builder usando a classe StartupAppAdvanced genérica com configuração específica do APPSG
    StartupAppAdvanced.ConfigurarBuilder(builder, configuracao, logger);

    var app = builder.Build();

   // Configurar middlewares específicos do AppSG (geo-blocking)
    AppSGStartup.ConfigurarMiddlewaresAppSG(app);

    // Configurar aplicação usando a classe StartupAppAdvanced genérica
    StartupAppAdvanced.ConfigurarAplicacao(builder, app, configuracao, logger);

    // Enable Developer Exception Page in development for detailed errors
    if (builder.Environment.IsDevelopment())
    { 
        logger.Info("Developer exception page enabled");
    }
    else
    {
        // PROMETHEU E GUARDIAN - Restrições de acesso aos endpoints
        AddTelemetryService.UsePrometheusEndpointRestriction(app, builder.Configuration);
        GuardianDashboard.UseGuardianEndpointRestriction(app, builder.Configuration, logger);
    }

    //// 07-01-2026 - Aplicar rate limiting apenas para endpoints que não sejam /metrics
    //app.UseWhen(
    //context => !context.Request.Path.StartsWithSegments("/metrics"),
    //appBuilder => {
    //    appBuilder.UseRateLimiter(); // ou seu middleware de rate limit
    //    }
    //);

    // Configurar endpoint do Prometheus para métricas OpenTelemetry
    app.UseGenesysPrometheus(builder.Configuration);

 

    AuditorController.ConfigureAuditorEndpoints(app);

    Robots.ConfigureRobotEndpoints(app);

    // Endpoint para verificar status do Circuit Breaker
    app.MapGet("/resilience/status", (IResilienceService resilienceService) =>
    {
        return Results.Ok(new
        {
            Status = "Resilience Service Active",
            Timestamp = DateTime.UtcNow
        });
    }).AllowAnonymous();

    // Servir arquivos estáticos (incluindo monitor.html)
    app.UseStaticFiles();

    // Configurar endpoints específicos do HealthCheckController diretamente aqui no Program.cs
    if (configuracao.HabilitarHealthChecks)
    {
        try
        {
            HealthCheckController.ConfigureHealthCheckEndpoints(app);
            logger.Info("Endpoints do HealthCheckController configurados com sucesso");
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Erro ao configurar endpoints do HealthCheckController");
        }
    }
    /*
    // Diagnostic: list mapped endpoints to help debug routing
    try
    {
        var endpoints = app.Services.GetService<EndpointDataSource>();
        logger.Info("---- MAPPED ENDPOINTS ----");
        if (endpoints != null)
        {
            foreach (var ep in endpoints.Endpoints)
            {
                logger.Info(ep.DisplayName ?? ep.ToString());
            }
        }
        else
        {
            logger.Warn("EndpointDataSource not available");
        }
        logger.Info("--------------------------");
    }
    catch (Exception ex)
    {
        logger.Warn(ex, "Falha ao listar endpoints");
    }
    */
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
