using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace MenphisSI.GerAdv.HealthCheck;
public partial class AppSettingsHealthCheck
{
    public static Logger ConfigureNLog() => 
        WebApi.BaseCommon.Helpers.ProgramNLog.ConfigureHealthCheckNLog();
     
    public static void Add(WebApplicationBuilder builder, Logger logger, AppSettings settings)
    {
        builder.Services.AddHealthChecks().AddCheck<HealthCheckMemoryService>("Memory", failureStatus: HealthStatus.Degraded, tags: ["Memory"]);

        {
            var n = 0;
            foreach (var uri in settings.UrisNotificadorAgenda.Split(";"))
            {
                builder.Services.AddHealthChecks()
                    .AddCheck($"Notificador - {++n}", new HealthCheckNotificadorService(uri), failureStatus: HealthStatus.Degraded, tags: ["Notificador"]);
            }
        }

        {
            var n = 0;
            foreach (var uri in settings.UrisAniversariantes.Split(";"))
            {
                builder.Services.AddHealthChecks()
                    .AddCheck($"Niver - {++n}", new HealthCheckNotificadorAniversariantesService(uri), failureStatus: HealthStatus.Degraded, tags: ["Notificador"]);
            }

        }

        {
            var n = 0;
            foreach (var uri in settings.UrisCheck.Split(";"))
            {
                builder.Services.AddHealthChecks()
                    .AddCheck($"DB Status - {++n}", new HealthCheckCheckService(uri), failureStatus: HealthStatus.Degraded, tags: ["Notificador"]);
            }

        }

    }
    public static void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecksUI(options =>
        { 
            // Aumentar intervalo entre notificações de falha para reduzir overhead
            options.SetMinimumSecondsBetweenFailureNotifications(300); // 5 minutos ao invés de 60 segundos
            
#if (DEBUG)
            // Em desenvolvimento, avaliar a cada 30 segundos
            options.SetEvaluationTimeInSeconds(30);  // Aumentado de 15 para 30
            options.MaximumHistoryEntriesPerEndpoint(30); // Reduzido de 60 para 30
#else
            // Em produção, avaliar a cada 30 minutos ao invés de 10
            options.SetEvaluationTimeInSeconds(60*30); // 30 minutos
            options.MaximumHistoryEntriesPerEndpoint(24); // Reduzido de 60 para 24 (últimas 12 horas com intervalo de 30 min)
#endif
        }).AddInMemoryStorage();
    }

    public static void Use(WebApplication app)
    {
        app.MapHealthChecks("/healthcheck", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options =>
        {           
            options.UIPath = "/dashboard";
            options.ApiPath = "/healthui-api";
            options.UseRelativeApiPath = false;
        });

        app.MapGet("/testhealthcheck", async (HttpContext context) =>
        {
            var healthCheckService = context.RequestServices.GetRequiredService<HealthCheckService>();
            var report = await healthCheckService.CheckHealthAsync();
            context.Response.ContentType = "application/json";
            await UIResponseWriter.WriteHealthCheckUIResponse(context, report);
        });
    }
}
