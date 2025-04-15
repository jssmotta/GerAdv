namespace MenphisSI.GerMDS.HealthCheck;

public class HealthCheckMemoryService() : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;

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
            if (usedMemory > 240)
            {
                isHealthy = false;
                healthData.Add("Memory", new { status = "Unhealthy", message = "Memory usage is too high", data, timestamp = DateTime.UtcNow });
            }
            else
            {
                healthData.Add("Memory", new { status = "Healthy", message = "Cache is operational", timestamp = DateTime.UtcNow });
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
           : exceptions.Count > 0 ? HealthCheckResult.Unhealthy("One or more memory are not operational", exceptions.First(), healthData) : HealthCheckResult.Unhealthy("One or more memory are not operational", null, healthData);

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
