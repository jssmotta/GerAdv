using MenphisSI.Connections;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NLog;
namespace Domain.BaseCommon.Services.HealthChecks;

public class HealthCheckConnectionPoolService() : IHealthCheck, IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private bool _disposed;
    private static DateTime _lastCheck = DateTime.MinValue;
    private static readonly TimeSpan _cacheInterval = TimeSpan.FromSeconds(10);

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var healthData = new Dictionary<string, object>();
        bool isHealthy = true;
        List<Exception> exceptions = [];

        try
        {
            var now = DateTime.UtcNow;
            
            if ((now - _lastCheck) > _cacheInterval)
            {
                _lastCheck = now;
            }

            // Get connection pool statistics
            var poolInfo = DbConnectionFactory.GetPoolStatistics();

            var data = new Dictionary<string, object>
            {
                { "TotalPools", poolInfo.TotalPools },
                { "TotalConnections", poolInfo.TotalConnections },
                { "TotalIdleConnections", poolInfo.TotalIdleConnections },
                { "LargestPool", poolInfo.LargestPoolSize },
                { "Cached", (now - _lastCheck).TotalSeconds < 1 }
            };

            // Alert if too many idle connections (potential leak)
            if (poolInfo.TotalIdleConnections > 50)
            {
                isHealthy = false;
                healthData.Add("ConnectionPool", new
                {
                    status = "Unhealthy",
                    message = $"Muitas conexões ociosas: {poolInfo.TotalIdleConnections}. Possível connection leak!",
                    data,
                    timestamp = DateTime.UtcNow
                });
            }
            else if (poolInfo.TotalIdleConnections > 25)
            {
                healthData.Add("ConnectionPool", new
                {
                    status = "Degraded",
                    message = $"Número elevado de conexões ociosas: {poolInfo.TotalIdleConnections}",
                    data,
                    timestamp = DateTime.UtcNow
                });
            }
            else
            {
                healthData.Add("ConnectionPool", new
                {
                    status = "Healthy",
                    message = $"Connection pool normal: {poolInfo.TotalConnections} conexões totais, {poolInfo.TotalIdleConnections} ociosas",
                    data,
                    timestamp = DateTime.UtcNow
                });
            }
        }
        catch (Exception ex)
        {
            exceptions.Add(ex);
            _logger.Error(ex, "Health check ConnectionPool falhou.");
            isHealthy = false;

            healthData["ConnectionPool"] = new
            {
                status = "Unhealthy",
                message = ex.Message,
                details = ex.StackTrace,
                timestamp = DateTime.UtcNow
            };
        }

        return isHealthy
           ? HealthCheckResult.Healthy("Connection pool is healthy", healthData)
           : exceptions.Count > 0
               ? HealthCheckResult.Unhealthy("Connection pool health check failed", exceptions.First(), healthData)
               : HealthCheckResult.Unhealthy("Connection pool issues detected", null, healthData);
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
