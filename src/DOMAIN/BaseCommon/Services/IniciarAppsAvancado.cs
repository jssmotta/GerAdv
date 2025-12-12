/*
 A ordem correta é:
1. CORS (DEVE SER O PRIMEIRO!)
2. HSTS
3. Security Headers
4. Rate Limiter
5. HTTPS Redirection
6. Compression
7. Routing
8. Authentication
9. Authorization
 
 */
using MenphisSI.BaseCommon;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Globalization;
using System.Threading.RateLimiting;

namespace MenphisSI.BaseCommon.Services;

/// <summary>
/// Vers�o avan�ada da classe IniciarApps com suporte a configura��es customizadas
/// Permite maior flexibilidade para reutiliza��o em diferentes sistemas
/// </summary>
public static class IniciarAppsAvancado
{
    #region Main Initialization Methods with Configuration

    /// <summary>
    /// M�todo principal para configurar o builder com configura��es customizadas
    /// </summary>
    public static void ConfigurarBuilder(WebApplicationBuilder builder, ConfiguracaoInicializacao? configuracao = null, Logger? logger = null)
    {
        configuracao ??= new ConfiguracaoInicializacao();

        IniciarApps.ConfigurarConfiguracoes(builder);
        ConfigurarServicosBasicos(builder, configuracao);
        ConfigurarCORS(builder, configuracao);
        IniciarApps.ConfigurarHealthChecks(builder, logger);

        if (configuracao.HabilitarAutenticacaoJWT)
        {
            ConfigurarAutenticacaoJWT(builder, configuracao.ConfiguracaoJWT);
        }

        IniciarApps.InicializarConfiguracoes(builder);
        
        // Registrar servi�os padr�o do dom�nio
        IniciarApps.RegistrarServicosDominio(builder);
        
        // Registrar servi�os espec�ficos do ClientesPesquisa
        try
        {
            var clientesPesquisaServicesType = Type.GetType("MenphisSI.ClientesPesquisa.Services.AddServices");
            if (clientesPesquisaServicesType != null)
            {
                var addMethod = clientesPesquisaServicesType.GetMethod("Add", new[] { typeof(WebApplicationBuilder) });
                addMethod?.Invoke(null, new object[] { builder });
            }
        }
        catch (Exception)
        {
            // Se o servi�o n�o estivesse dispon�vel, continua sem falhar
        }
        
        // Registrar servi�os customizados se especificados
        configuracao.RegistrarServicosCustomizados?.Invoke(builder);

        //if (configuracao.HabilitarHealthChecks)
        //{
        //    IniciarApps.ConfigurarHealthChecks(builder, logger);
        //}
    }

    /// <summary>
    /// M�todo principal para configurar a aplica��o com configura��es customizadas
    /// </summary>
    public static void ConfigurarAplicacao(WebApplication app, ConfiguracaoInicializacao? configuracao = null, Logger? logger = null)
    {
        configuracao ??= new ConfiguracaoInicializacao();

        if (configuracao.HabilitarHealthChecks)
        {
            IniciarApps.ConfigurarHealthChecksApp(app);
        }

        ConfigurarPipeline(app, configuracao);
        ConfigurarEndpointsCustomizados(app, configuracao, logger);
        
        // Configurar middlewares customizados se especificados
        configuracao.ConfigurarMiddlewaresCustomizados?.Invoke(app);
        
        // Configurar endpoints customizados se especificados
        configuracao.ConfigurarEndpointsCustomizados?.Invoke(app);
    }

    #endregion

    #region Enhanced Configuration Methods

    /// <summary>
    /// Configura os servi�os b�sicos com configura��es customizadas
    /// </summary>
    public static void ConfigurarServicosBasicos(WebApplicationBuilder builder, ConfiguracaoInicializacao configuracao)
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

        ConfigurarApiVersioning(builder, configuracao.ConfiguracaoApiVersioning);

        if (configuracao.HabilitarCompressao)
        {
            IniciarApps.ConfigurarCompressaoResposta(builder);
        }

        if (configuracao.HabilitarCacheHibrido)
        {
            IniciarApps.ConfigurarCache(builder);
        }

        IniciarApps.ConfigurarJsonOptions(builder);
    }

    /// <summary>
    /// Configura API Versioning com configura��es customizadas
    /// </summary>
    public static void ConfigurarApiVersioning(WebApplicationBuilder builder, ConfiguracaoApiVersioning configuracao)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = configuracao.ReportApiVersions;
            options.AssumeDefaultVersionWhenUnspecified = configuracao.AssumeDefaultVersionWhenUnspecified;
            options.DefaultApiVersion = configuracao.DefaultApiVersion;
        });
    }

    /// <summary>
    /// Configura CORS com configura��es customizadas
    /// </summary>
    public static void ConfigurarCORS(WebApplicationBuilder builder, ConfiguracaoInicializacao configuracao)
    {
        var corsSites = IniciarApps.ObterOrigensCORS(builder.Configuration);
        var listCors = new List<string>(configuracao.OrigensCORSDesenvolvimento);
        listCors.AddRange(corsSites);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(configuracao.NomePoliticaCORS,
                policyBuilder =>
                {
                    policyBuilder.WithOrigins([.. listCors])
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
        });
    }

    /// <summary>
    /// Configura autentica��o JWT com configura��es customizadas
    /// </summary>
    public static void ConfigurarAutenticacaoJWT(WebApplicationBuilder builder, ConfiguracaoJWT configuracaoJWT)
    {
        var key = IniciarApps.ObterChaveSecreta(builder.Configuration);
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

            options.RequireHttpsMetadata = configuracaoJWT.RequireHttpsMetadata;
            options.SaveToken = configuracaoJWT.SaveToken;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = configuracaoJWT.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = configuracaoJWT.ValidateIssuer,
                ValidateAudience = configuracaoJWT.ValidateAudience,
                ClockSkew = configuracaoJWT.ClockSkew
            };
        });
    }

    /// <summary>
    /// Configura o pipeline da aplica��o com configura��es customizadas
    /// </summary>
    public static void ConfigurarPipeline(WebApplication app, ConfiguracaoInicializacao configuracao)
    {
        ConfigurarMiddlewares(app, configuracao);
        ConfigurarCultura(configuracao);
    }

    /// <summary>
    /// Configura middlewares da aplica��o com configura��es customizadas
    /// </summary>
    public static void ConfigurarMiddlewares(WebApplication app, ConfiguracaoInicializacao configuracao)
    {
        // Exception Handler - PRIMEIRO DE TODOS para capturar qualquer erro
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error("### EXCEPTION HANDLER - Exceção capturada ###");
                logger.Error($"Path: {context.Request.Path}");
                logger.Error($"Method: {context.Request.Method}");
                
                var exceptionFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                if (exceptionFeature != null)
                {
                    logger.Error($"Exception Type: {exceptionFeature.Error.GetType().Name}");
                    logger.Error($"Exception Message: {exceptionFeature.Error.Message}");
                    logger.Error($"Exception StackTrace: {exceptionFeature.Error.StackTrace}");
                }
                
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
        
        // Redirecionamento HTTPS
        app.UseHttpsRedirection();

        // Compressão de resposta (se habilitado)
        if (configuracao.HabilitarCompressao)
        {
            app.UseResponseCompression();
        }

        // CORS DEVE vir ANTES de UseRouting!
        app.UseCors(configuracao.NomePoliticaCORS);

        // Roteamento - OBRIGATÓRIO antes de Authentication/Authorization
        app.UseRouting();

        // Autenticação e Autorização (se habilitado)
        if (configuracao.HabilitarAutenticacaoJWT)
        {
            app.UseAuthentication();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
        }
        
        // Rate Limiting (se disponível no .NET 10)
        app.UseRateLimiter();
        
        // MapControllers - DEVE estar DEPOIS de UseRouting e UseAuthorization
        app.MapControllers();
    }

    /// <summary>
    /// Configura cultura da aplica��o com configura��es customizadas
    /// </summary>
    public static void ConfigurarCultura(ConfiguracaoInicializacao configuracao)
    {
        var cultureInfo = new CultureInfo(configuracao.Cultura);
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }

    /// <summary>
    /// Configura endpoints customizados com configura��es personalizadas
    /// </summary>
    public static void ConfigurarEndpointsCustomizados(WebApplication app, ConfiguracaoInicializacao configuracao, Logger? logger = null)
    {
        ConfigurarEndpointRoot(app, configuracao, logger);
        ConfigurarEndpointApi(app, configuracao, logger);
    }

    /// <summary>
    /// Configura endpoint raiz com URL customizada
    /// </summary>
    public static void ConfigurarEndpointRoot(WebApplication app, ConfiguracaoInicializacao configuracao, Logger? logger = null)
    {
        app.MapGet("/", (HttpContext context) =>
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            IniciarApps.LogRedirecionamento(logger, ipAddress, "root");
            context.Response.Redirect(configuracao.UrlRedirecionamentoRoot);
            return Task.CompletedTask;
        }).ShortCircuit(200);
    }

    /// <summary>
    /// Configura endpoint da API com URL customizada
    /// </summary>
    public static void ConfigurarEndpointApi(WebApplication app, ConfiguracaoInicializacao configuracao, Logger? logger = null)
    {
        app.MapGet("/api/v1/", (HttpContext context) =>
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            IniciarApps.LogRedirecionamento(logger, ipAddress, "api");
            context.Response.Redirect(configuracao.UrlRedirecionamentoApi);
            return Task.CompletedTask;
        }).ShortCircuit(200);
    }

    #endregion

    #region Utility Methods

    /// <summary>
    /// Cria uma configura��o padr�o para sistemas m�dicos
    /// </summary>
    public static ConfiguracaoInicializacao CriarConfiguracaoSistemaMenphis()
    {
        return new ConfiguracaoInicializacao
        {
            UrlRedirecionamentoRoot = "https://menphis.com.br/?ur=aaj",
            UrlRedirecionamentoApi = "https://menphis.com.br/?ur=aajpi",
            Cultura = "pt-BR",
            HabilitarHealthChecks = true,
            HabilitarCompressao = true,
            HabilitarCacheHibrido = true,
            HabilitarAutenticacaoJWT = true
        };
    }

    /// <summary>
    /// Cria uma configura��o padr�o para APIs simples
    /// </summary>
    public static ConfiguracaoInicializacao CriarConfiguracaoApiSimples()
    {
        return new ConfiguracaoInicializacao
        {
            UrlRedirecionamentoRoot = "https://menphis.com.br/",
            UrlRedirecionamentoApi = "https://menphis.com.br/api",
            Cultura = "pt-BR",
            HabilitarHealthChecks = false,
            HabilitarCompressao = false,
            HabilitarCacheHibrido = false,
            HabilitarAutenticacaoJWT = false
        };
    }

    /// <summary>
    /// Cria uma configura��o para desenvolvimento/testes
    /// </summary>
    public static ConfiguracaoInicializacao CriarConfiguracaoDesenvolvimento()
    {
        return new ConfiguracaoInicializacao
        {
            UrlRedirecionamentoRoot = "http://localhost:3000",
            UrlRedirecionamentoApi = "http://localhost:3000/api",
            Cultura = "pt-BR",
            OrigensCORSDesenvolvimento = new List<string> 
            { 
                "http://localhost:3000", 
                "http://localhost:3001", 
                "https://localhost:5001" 
            },
            HabilitarHealthChecks = true,
            HabilitarCompressao = true,
            HabilitarCacheHibrido = true,
            HabilitarAutenticacaoJWT = true,
            ConfiguracaoJWT = new ConfiguracaoJWT
            {
                RequireHttpsMetadata = false // Para desenvolvimento
            }
        };
    }

    #endregion
}