namespace MenphisSI.GerAdv.HealthCheck;

public class HealthCheckCheckService([Required] string uri) : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;
    private readonly string _uri = uri; 


    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {

        try
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return CreateHealthyResult("Notificador operacional");
            }

            using var writeConnection = await Configuracoes.GetConnectionByUriAsync(_uri);

            if (writeConnection is null)
            {
                return CreateUnhealthyResult("Conexão não disponível");
            }

            return CreateHealthyResult("Notificador operacional");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Verificação de saúde falhou");
            return CreateUnhealthyResult("Erro durante verificação", ex);
        }
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
