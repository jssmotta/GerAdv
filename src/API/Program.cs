using MenphisSI.BaseCommon.Controllers;
using MenphisSI.BaseCommon.Helpers;

var logger = ProgramNLog.ConfigureNLog();

try
{
    logger.Info("=== INICIANDO WEBAPI ===");
    logger.Info($"Versão: {typeof(Program).Assembly.GetName().Version}");
    logger.Info($"Diretório de trabalho: {Directory.GetCurrentDirectory()}");

    var builder = WebApplication.CreateBuilder(args);

    logger.Info($"Environment: {builder.Environment.EnvironmentName}");
    logger.Info($"ApplicationName: {builder.Environment.ApplicationName}");
    logger.Info($"ContentRootPath: {builder.Environment.ContentRootPath}");

    // Determinar configuração baseada no ambiente
    // O ASP.NET Core automaticamente carrega appsettings.{Environment}.json
    ConfiguracaoInicializacao? configuracao = null;

    if (builder.Environment.IsDevelopment())
    {
        logger.Info("Ambiente de desenvolvimento detectado - usando CriarConfiguracaoDesenvolvimento()");
        configuracao = IniciarAppsAvancado.CriarConfiguracaoDesenvolvimento();

        // Personalizar configuração para desenvolvimento se necessário
        configuracao.RegistrarServicosCustomizados = (builder) =>
        {
            logger.Info("Registrando serviços customizados para desenvolvimento");
        };
    }
    else
    {
        // Para todos os outros ambientes (Production, PIXBOL, Staging, etc.)
        // Usa a configuração de produção que irá ler as origens CORS do appsettings.{Environment}.json
        logger.Info($"Ambiente '{builder.Environment.EnvironmentName}' detectado - usando configuração de produção");
        logger.Info("As configurações CORS serão lidas do arquivo appsettings.{Environment}.json");
        configuracao = IniciarAppsAvancado.CriarConfiguracaoSistemaMenphis();
    }

    logger.Info("=== FASE 1: Inicializando UriApi ===");
    try
    {
        MenphisSI.GerEntityTools.Apis.UriApi.InitializeConfiguration(builder.Configuration);
        logger.Info("? UriApi inicializado com sucesso");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO CRÍTICO ao inicializar UriApi");
        throw;
    }

    logger.Info("=== FASE 2: Configurando Builder ===");
    try
    {
        IniciarAppsAvancado.ConfigurarBuilder(builder, configuracao, logger);
        logger.Info("? Builder configurado com sucesso");
        logger.Info($"? Política CORS '{configuracao.NomePoliticaCORS}' configurada");

        // Log das origens CORS carregadas para debug
        var corsOrigins = builder.Configuration.GetSection("AppSettings:CORS:AllowedOrigins").Get<string[]>();
        if (corsOrigins != null && corsOrigins.Length > 0)
        {
            logger.Info($"? Origens CORS carregadas do appsettings.{builder.Environment.EnvironmentName}.json:");
            foreach (var origin in corsOrigins)
            {
                logger.Info($"  - {origin}");
            }
        }
        else
        {
            logger.Warn("? Nenhuma origem CORS encontrada na configuração");
        }
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO CRÍTICO ao configurar builder");
        throw;
    }

    logger.Info("=== FASE 3: Registrando Serviços Customizados ===");
    try
    {
        // Registrar GerarSKUService e suas dependências
        logger.Info("Registrando GerarSKUService...");
        builder.Services.AddScoped<MenphisSI.GerAdv.Interface.IGerarSKUService, GerarSKUService>();
        builder.Services.AddScoped<SubiProdutoECriarSKU>();

        // Registrar ImageProcessorService
        logger.Info("Registrando ImageProcessorService...");
        builder.Services.Configure<ImageProcessorSettings>(options =>
        {
            options.TempFolderPath = "temp";
            options.AssetsFolderPath = "assets";
            options.FontPath = "fonts";
        });
        builder.Services.AddScoped<IImageProcessorService, ImageProcessorService>();

        logger.Info("? Serviços customizados registrados com sucesso");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO ao registrar serviços customizados");
        throw;
    }

    logger.Info("=== FASE 4: Construindo aplicação (builder.Build()) ===");
    logger.Info("Aguardando construção da aplicação...");

    var app = builder.Build();

    logger.Info("? Aplicação construída com sucesso");

    logger.Info("=== FASE 5: Configurando Lifetime Events ===");
    try
    {
        app.Lifetime.ApplicationStarted.Register(() =>
        {
            try
            {
                var addresses = app.Urls;
                var urlList = addresses != null && addresses.Any() ? string.Join(", ", addresses) : "(nenhuma URL configurada)";
                logger.Info($"? ApplicationStarted - URLs: {urlList}");
                logger.Info($"? Aplicação está RODANDO e pronta para receber requisições");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "? Erro ao processar ApplicationStarted");
            }
        });

        app.Lifetime.ApplicationStopping.Register(() =>
        {
            logger.Info("ApplicationStopping - Aplicação está sendo encerrada");
        });

        app.Lifetime.ApplicationStopped.Register(() =>
        {
            logger.Info("ApplicationStopped - Aplicação foi encerrada");
        });

        logger.Info("? Lifetime events configurados");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? Erro ao configurar lifetime events (não crítico, continuando...)");
    }

    logger.Info("=== FASE 6: Configurando Aplicação ===");
    try
    {
        IniciarAppsAvancado.ConfigurarAplicacao(app, configuracao, logger);
        logger.Info("? Aplicação configurada com sucesso");
        logger.Info($"? Middleware CORS '{configuracao.NomePoliticaCORS}' ativado");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO CRÍTICO ao configurar aplicação");
        throw;
    }

    logger.Info("=== FASE 7: Configurando Endpoints ===");

    // Auditor
    try
    {
        AuditorController.ConfigureAuditorEndpoints(app);
        logger.Info("? Endpoints Auditor configurados");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO ao configurar endpoints Auditor");
        throw;
    }

    // Robots
    try
    {
        Robots.ConfigureRobotEndpoints(app);
        logger.Info("? Endpoints Robots configurados");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO ao configurar endpoints Robots");
        throw;
    }

    // Agenda V2
    try
    {
        // app.MapAgendaEndpointsV2();
        logger.Info("? Endpoints AgendaEndpointsV2 configurados");
    }
    catch (Exception ex)
    {
        logger.Error(ex, "? ERRO ao configurar endpoints AgendaEndpointsV2");
        throw;
    }

    // HealthCheck
    if (configuracao.HabilitarHealthChecks)
    {
        try
        {
            HealthCheckController.ConfigureHealthCheckEndpoints(app);
            logger.Info("? Endpoints HealthCheckController configurados");
        }
        catch (Exception ex)
        {
            logger.Error(ex, "? ERRO ao configurar endpoints HealthCheckController");
            throw;
        }
    }

    logger.Info("=== TODAS AS CONFIGURAÇÕES CONCLUÍDAS COM SUCESSO ===");
    logger.Info($"Ambiente: {builder.Environment.EnvironmentName}");
    logger.Info($"ContentRootPath: {builder.Environment.ContentRootPath}");
    logger.Info($"Política CORS ativa: {configuracao.NomePoliticaCORS}");

    // Garantir que todos os logs foram escritos
    LogManager.Flush(TimeSpan.FromSeconds(2));

    logger.Info("=== CHAMANDO app.Run() - INICIANDO SERVIDOR HTTP ===");
    logger.Info("A aplicação está pronta e aguardando requisições HTTP...");


    //using var oCnn = ConfiguracoesSys.GetConnectionByUriRw("FTC");
    //ConfiguracoesDBT.ExecuteSqlCreate($"delete from {DBProdutoFichaTecnicaTemporariaDicInfo.PTabelaNome};", oCnn);



    // Esta linha BLOQUEIA até a aplicação ser encerrada
    app.Run();

    // Código após app.Run() só executa quando a aplicação é encerrada
    logger.Info("? app.Run() retornou - Aplicação foi encerrada normalmente");
}
catch (Exception exception)
{
    logger.Error(exception, "??? ERRO FATAL - Aplicação foi encerrada devido a uma exceção ???");
    logger.Error($"Tipo de exceção: {exception.GetType().Name}");
    logger.Error($"Mensagem: {exception.Message}");
    logger.Error($"StackTrace: {exception.StackTrace}");

    if (exception.InnerException != null)
    {
        logger.Error($"Inner Exception: {exception.InnerException.Message}");
        logger.Error($"Inner StackTrace: {exception.InnerException.StackTrace}");
    }

    // Garantir que os logs de erro foram escritos
    LogManager.Flush(TimeSpan.FromSeconds(5));

    // Aguarda para garantir que os logs foram salvos
    System.Threading.Thread.Sleep(2000);

    throw;
}
finally
{
    logger.Info("=== FINALIZANDO APLICAÇÃO - LogManager.Shutdown() ===");
    LogManager.Shutdown();
}

