﻿using Domain.BaseCommon.Helpers;

namespace MenphisSI.GerAdv.HealthCheck;

public class HealthCheckNotificadorAniversariantesService([Required] string uri) : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;
    private readonly string _uri = uri;
    private const int PHoraProcessamento = 7;
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {

#if (!DEBUG)

            if (IsNotDiaOperacional())
            {
                return CreateHealthyResult("Notificador operacional");
            }

            if (IsHoraProcessamento())
#endif
            {
                using var oCnn = await Configuracoes.GetConnectionByUriAsync(_uri);
                if (oCnn is null)
                {
                    return CreateUnhealthyResult("Conexão não disponível");
                }
                _ = await SendNotificationsAndGetResult(oCnn);
            }
           

            return CreateHealthyResult("Notificador operacional");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Verificação de saúde falhou");
            return CreateUnhealthyResult("Erro durante verificação", ex);
        }
    }

    private bool IsHoraProcessamento() =>
            DateTime.Now.Hour == PHoraProcessamento;

    private bool IsNotDiaOperacional() =>
        DateTime.Now.DayOfWeek != DayOfWeek.Monday &&
        DateTime.Now.DayOfWeek != DayOfWeek.Thursday;

    private string GetScheduleKey()
    {
        string key = $"notificador-aniversariantes.net-sender-time-{_uri}-{DateTime.Now:dd/MM/yyyy}";
#if (DEBUG)
        key = $"notificador-aniversariantes-advnet-sender-time-{_uri}-{DateTime.Now}";
#endif
        return key;
    }

    private async Task<HealthCheckResult> SendNotificationsAndGetResult(SqlConnection oCnn)
    {
        string key = GetScheduleKey();

        var dbOperator = new DBOperador { ID = 1 };

        if (dbOperator.ReadCfgBool(key, oCnn))
        {
            // Se já foi processado, não faz nada
            return CreateHealthyResult("Notificador já processado", null);
        }

        // Marca como processado para evitar reprocessamento
        using var writeConnection = await Configuracoes.GetConnectionByUriRwAsync(_uri);
        dbOperator.WriteCfgBool(key, true, writeConnection);

        // Envia as notificações
        var notificationService = new EnvioNotificacoesAniversariantes();
        int sentCount = notificationService.EnviarEmailsParaAdvogados(uri, oCnn);
#if (!DEBUG)
        sentCount += notificationService.EnviarEmailsParaFuncionarios(uri, oCnn);
#endif
        var data = new Dictionary<string, object>
    {
        { "EnviosRealizados", sentCount.ToString("N0") }
    };

        if (sentCount > 0)
        {
            return CreateUnhealthyResult($"E-mails enviados: {sentCount}", null, data);
        }

        return CreateHealthyResult("Notificador operacional", data);
    }

    private HealthCheckResult CreateHealthyResult(string message, Dictionary<string, object>? data = null)
    {
        var healthData = new Dictionary<string, object>();
        healthData["Notificador"] = new
        {
            status = "Healthy",
            message,
            timestamp = DateTime.UtcNow,
            data
        };

        return HealthCheckResult.Healthy(message, healthData);
    }

    private HealthCheckResult CreateUnhealthyResult(string message, Exception? exception = null, Dictionary<string, object>? data = null)
    {
        var healthData = new Dictionary<string, object>();
        healthData["Notificador"] = new
        {
            status = "Unhealthy",
            message,
            timestamp = DateTime.UtcNow,
            data,
            details = exception?.StackTrace
        };

        return HealthCheckResult.Unhealthy(message, exception, healthData);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
            (_logger as IDisposable)?.Dispose();
        }

        _disposed = true;
    }



}
