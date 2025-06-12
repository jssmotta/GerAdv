#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.HealthCheck;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public class ProDespesasHealthCheck(IOptions<AppSettings> appSettings, ProDespesasService prodespesasService, HybridCache cache) : IHealthCheck, IDisposable
{
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private static readonly Logger _logger = AppSettingsHealthCheck.ConfigureNLog();
    private readonly ProDespesasService _prodespesasService = prodespesasService;
    private bool _disposed;
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var uris = _uris.Split(',');
            var healthData = new Dictionary<string, object>();
            var isHealthy = true;
            var exceptions = new List<Exception>();
            var maxId = 0;
            foreach (var uri in uris)
            {
                if (uri.IsEmpty())
                {
                    isHealthy = false;
                    _logger.Warn("Uri is empty");
#pragma warning disable CA2208 // Instantiate argument exceptions correctly

                    throw new ArgumentNullException(nameof(uri), "Uri is empty");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

                }

                MsiSqlConnection? connection = null;
                try
                {
                    using var scope = Configuracoes.CreateConnectionScope(uri);
                    connection = scope.Connection;
                    if (connection == null)
                    {
                        isHealthy = false;
                        var errorMessage = $"Connection could not be established.";
                        _logger.Warn("Failed to create connection for uri {0}: {1}", uri, errorMessage);
                        healthData[$"domain_{uri}"] = new
                        {
                            status = "Unhealthy",
                            message = "Connection could not be established",
                            details = errorMessage,
                            timestamp = DateTime.UtcNow
                        };
                        continue;
                    }

                    await using var command = connection.CreateCommand();
                    command.CommandText = "SELECT 1";
                    command.CommandTimeout = 5;
                    await command.ExecuteScalarAsync(cancellationToken);
                    try
                    {
                        if (DBProDespesasDicInfo.CampoCodigo.NotIsEmpty())
                        {
                            await using var tableCheck = connection.CreateCommand();
                            tableCheck.CommandText = $"SELECT TOP (1) MAX(desCodigo) FROM {"ProDespesas".dbo(connection)} (NOLOCK);";
                            tableCheck.CommandTimeout = 5;
                            var retId = await tableCheck.ExecuteScalarAsync(cancellationToken);
                            if (retId != null && retId != DBNull.Value)
                            {
                                maxId = Convert.ToInt32(retId);
                            }
                        }

                        {
                            await using var tableCheck = connection.CreateCommand();
                            tableCheck.CommandText = $"SELECT TOP (1) desLigacaoID,desCliente,desCorrigido,desData,desValorOriginal,desProcesso,desQuitado,desDataCorrecao,desValor,desTipo,desHistorico,desLivroCaixa,desGUID FROM {"ProDespesas".dbo(connection)} (NOLOCK);";
                            tableCheck.CommandTimeout = 5;
                            _ = await tableCheck.ExecuteScalarAsync(cancellationToken);
                        }

                        healthData[$"domain_{uri}"] = new
                        {
                            status = "Healthy",
                            message = "SELECT ProDespesas successful",
                            timestamp = DateTime.UtcNow
                        };
                    }
                    catch (Exception ex)
                    {
                        isHealthy = false;
                        exceptions.Add(ex);
                        _logger.Warn(ex, "SELECT ProDespesas failed for {0}. Error: {1}", uri, ex.Message);
                        healthData[$"domain_{uri}"] = new
                        {
                            status = "Unhealthy",
                            message = ex.Message,
                            details = ex.StackTrace,
                            timestamp = DateTime.UtcNow
                        };
                    }

                    await connection.CloseAsync();
                    healthData[$"domain_{uri}"] = new
                    {
                        status = "Healthy",
                        message = "Connection successful",
                        timestamp = DateTime.UtcNow
                    };
                }
                catch (Exception ex)when (ex is TaskCanceledException)
                {
                    isHealthy = false;
                    _logger.Error("Database connection was canceled for {Uri}.", uri);
                    healthData[$"domain_{uri}"] = new
                    {
                        status = "Unhealthy",
                        message = "Task was canceled",
                        details = ex.StackTrace,
                        timestamp = DateTime.UtcNow
                    };
                }
                catch (Exception ex)
                {
                    isHealthy = false;
                    exceptions.Add(ex);
                    _logger.Error(ex, "Database connection failed for {0}. Error: {1}", uri, ex.Message);
                    healthData[$"domain_{uri}"] = new
                    {
                        status = "Unhealthy",
                        message = ex.Message,
                        details = ex.StackTrace,
                        timestamp = DateTime.UtcNow
                    };
                }
                finally
                {
                    if (connection?.State == ConnectionState.Open)
                    {
                        try
                        {
                            await connection.CloseAsync();
                            await connection.DisposeAsync();
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "Error closing connection for {0}", uri);
                        }
                    }
                }

                try
                {
                    if (maxId > 0)
                    {
                        var token = new CancellationToken();
                        _ = _prodespesasService.GetById(maxId, uri, token);
                    }

                    healthData.Add("GetById", new { status = "Healthy", message = "Get Id 1 is operational", timestamp = DateTime.UtcNow });
                }
                catch (Exception ex)
                {
                    isHealthy = false;
                    exceptions.Add(ex);
                    healthData.Add("GetById", new { status = "Unhealthy", message = ex.Message, timestamp = DateTime.UtcNow });
                    _logger.Warn(ex, "Health check failed for GetById");
                }

                try
                {
                    var token = new CancellationToken();
                    var cacheKey = $"HealthCheck-{uri}-ProDespesas";
                    var entryOptions = new HybridCacheEntryOptions
                    {
                        Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
                        LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
                    };
                    _ = await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetData(uri, cancel), entryOptions, cancellationToken: token);
                    static async Task<IEnumerable<Models.ProDespesas>> GetData(string uri, CancellationToken token)
                    {
                        await Task.Delay(1, token);
                        return[new Models.ProDespesas
                        {
                        }

                        ];
                    }

                    healthData.Add("cache", new { status = "Healthy", message = "Cache is operational", timestamp = DateTime.UtcNow });
                }
                catch (Exception ex)
                {
                    isHealthy = false;
                    exceptions.Add(ex);
                    healthData.Add("cache", new { status = "Unhealthy", message = ex.Message, timestamp = DateTime.UtcNow });
                    _logger.Warn(ex, "Health check failed for cache");
                }
            }

            return isHealthy ? HealthCheckResult.Healthy("ProDespesas is operational", healthData) : exceptions.Count > 0 ? HealthCheckResult.Unhealthy("One or more systems are not operational", exceptions.First(), healthData) : HealthCheckResult.Unhealthy("One or more systems are not operational", null, healthData);
        }
        catch (Exception ex)
        {
            _logger.Warn(ex, "Health check failed");
            return HealthCheckResult.Unhealthy("Health check failed", ex);
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