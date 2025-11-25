namespace MenphisSI.GerAdv.HealthCheck;

public class HealthCheckMemoryService() : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;
    private static DateTime _lastCleanup = DateTime.Now;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1, cancellationToken);

        var healthData = new Dictionary<string, object>();
        bool isHealthy;
        List<Exception> exceptions = [];

        var usedMemory = GC.GetTotalMemory(false) / 1024 / 1024; // Convert to MB

        try
        {
            var data = new Dictionary<string, object>
            {
                { "UsedMemory MB", usedMemory.ToString("N0") },
            };
            
            isHealthy = true;
            
            // Limitar agora em 400 MB ao invés de 240 MB
            if (usedMemory > 400)
            {
                isHealthy = false;
                healthData.Add("Memory", new { status = "Unhealthy", message = "Memory usage is too high", data, timestamp = DateTime.UtcNow });
                
                // Forçar limpeza agressiva
                TryAggressiveCleanup();
            }
            else if (usedMemory > 300)
            {
                // Aviso de memória alta
                healthData.Add("Memory", new { status = "Warning", message = "Memory usage is elevated", data, timestamp = DateTime.UtcNow });
                
                // Limpeza moderada a cada 2 minutos
                if ((DateTime.Now - _lastCleanup).TotalMinutes > 2)
                {
                    TryModerateCleanup();
                }
            }
            else
            {
                healthData.Add("Memory", new { status = "Healthy", message = "Memory is operational", data, timestamp = DateTime.UtcNow });
            }
        }
        catch (Exception ex)
        {
            exceptions.Add(ex);
            _logger.Error(ex, "Health check CGMemory falhou.");
            isHealthy = false;
          
            healthData["Memory"] = new
            {
                status = "Unhealthy",
                message = "Task was canceled",
                details = ex.StackTrace,
                timestamp = DateTime.UtcNow
            };
        }

        return isHealthy
           ? HealthCheckResult.Healthy($"Memory is operational, memory used MB: {usedMemory:N0}", healthData)
           : exceptions.Count > 0 ? HealthCheckResult.Unhealthy("One or more memory are not operational", exceptions.First(), healthData) 
           : HealthCheckResult.Unhealthy("One or more memory are not operational", null, healthData);
    }

    private static void TryModerateCleanup()
    {
        try
        {
            _lastCleanup = DateTime.Now;
            
            // Garbage collection de geração 1
            GC.Collect(1, GCCollectionMode.Optimized, false, false);
            
            _logger.Info("Moderate memory cleanup executed");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error during moderate cleanup");
        }
    }

    private static void TryAggressiveCleanup()
    {
        try
        {
            _lastCleanup = DateTime.Now;
            
            // Garbage collection agressiva
            GC.Collect(2, GCCollectionMode.Aggressive, true, true);
            GC.WaitForPendingFinalizers();
            GC.Collect(2, GCCollectionMode.Aggressive, true, true);
            
            _logger.Warn("Aggressive memory cleanup executed due to high memory usage");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error during aggressive cleanup");
        }
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
