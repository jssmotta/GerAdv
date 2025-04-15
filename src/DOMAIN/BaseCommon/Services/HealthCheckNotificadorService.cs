using Domain.BaseCommon.Helpers;

namespace MenphisSI.GerBOL.HealthCheck;

public class HealthCheckNotificadorService([Required] string uri) : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;
    private readonly string _uri = uri;

    private const int PHoraParaLembrar = 12; // Definido pela Magnanima Dra. Aliçar Ibrahim

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {       
        try
        {
            using var oCnn = Configuracoes.GetConnectionByUri(_uri);
            if (oCnn is null)
            {
                return CreateUnhealthyResult("Conexão não disponível");
            }

            if (await ShouldSendNotificationsNow(oCnn))
            {
                var notificationsResult = await SendNotificationsAndGetResult(oCnn);
                return notificationsResult;
            }

            return CreateHealthyResult("Notificador operacional");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Verificação de saúde falhou");
            return CreateUnhealthyResult("Erro durante verificação", ex);
        }
    }

    private async Task<bool> ShouldSendNotificationsNow(SqlConnection oCnn)
    {
        var dbOperator = new DBOperador { ID = 1 };

        if (DateTime.Now.Hour > PHoraParaLembrar && DateTime.Now.Hour <= 21) // envia novos booletos somente em horário comercial.
        {
            var pendingNotificationKey = await GetPendingNotificationKey(oCnn);
            if (!string.IsNullOrEmpty(pendingNotificationKey))
            {
                if (dbOperator.ReadCfgBool(pendingNotificationKey, oCnn))
                {
                    return false;
                }

                // Mesmo sem ter a certeza do envio já marca como enviado para evitar erros
                using var oCnnRw = Configuracoes.GetConnectionByUriRw(_uri);
                dbOperator.WriteCfgBool(pendingNotificationKey, true, oCnn);

                return true;
            }
        }

        if (DateTime.Now.Hour == PHoraParaLembrar)
        {            
            var scheduleKey = GetScheduleKey();
            return !dbOperator.ReadCfgBool(scheduleKey, oCnn);
        }
        return false;
    }

    private async Task<string> GetPendingNotificationKey(SqlConnection oCnn)
    {
        const string PendingNotificationQuery = @"
        SELECT TOP 1 d.data FROM (
            SELECT 
                CASE WHEN ageDtAtu IS NULL OR ageDtCad > ageDtAtu 
                THEN ageDtCad ELSE ageDtAtu END AS data 
            FROM dbo.Agenda a 
            WHERE (a.ageConcluido IS NULL OR a.ageConcluido = 0) 
            AND a.ageCompromisso LIKE '%Valor%' 
            AND (a.ageData >= DATEADD(DAY, -3, GETDATE()) 
            AND a.ageData <= DATEADD(DAY, 2, GETDATE()))
        ) d;";

        var dataKey = await ConfiguracoesDBT.GetScalarAsync(PendingNotificationQuery, oCnn);
        return dataKey?.ToString() ?? string.Empty;
    }

    private string GetScheduleKey()
    {
        string key = $"boletos-send-time-{DateTime.Now:dd/MM/yyyy}-{_uri}";

        //#if DEBUG
        //        key = $"boletos-send-time-{DateTime.Now}";
        //#endif

        return key;
    }

    private async Task<HealthCheckResult> SendNotificationsAndGetResult(SqlConnection oCnn)
    {
        string key = GetScheduleKey();

        // Marca como processado para evitar reprocessamento
        using var writeConnection = Configuracoes.GetConnectionByUriRw(_uri);
        var dbOperator = new DBOperador { ID = 1 };
        dbOperator.WriteCfgBool(key, true, writeConnection);

        // Envia as notificações
        var notificationService = new EnvioNotificacoes();
        int sentCount = notificationService.EnviarNotificacoesDeBoletos(_uri, oCnn);

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
