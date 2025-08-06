using System.Collections.Concurrent;
using System.Timers;

namespace MenphisSI.Connections;

public static class DbConnectionFactory
{
    // Usar valores configuráveis
    private const int MaxPoolSize = 100;
    private const int MinPoolSize = 10;

    // Adicionar monitoramento do pool
    private static readonly ConcurrentDictionary<string, PoolStats> _poolStats = new();

    // Adicionar timeout configurável para conexões ociosas
    private const int IdleTimeout = 300; // 5 minutos

    private const int ConnectionTimeout = 15; // 15 segundos

    // Implementar limpeza periódica de conexões ociosas
    private static readonly System.Timers.Timer _cleanupTimer;

    // Pool de conexões gerenciado pela factory
    private static readonly ConcurrentDictionary<string, ConcurrentQueue<ConnectionWrapper>> _connectionPools = new();

    static DbConnectionFactory()
    {
        _cleanupTimer = new System.Timers.Timer(IdleTimeout * 1000);
        _cleanupTimer.Elapsed += CleanupIdleConnections;
        _cleanupTimer.Start();
    }

    public static async Task<MsiSqlConnection> GetConnectionAsync(string connectionString)
    {
       
        if (!_connectionPools.TryGetValue(connectionString, out var pool))
        {
            pool = new ConcurrentQueue<ConnectionWrapper>();
            try
            {
                lock (_connectionPools)
                {
                    _connectionPools.TryAdd(connectionString, pool);
                }
            }
            catch (Exception ex) { var err = ex.Message; }
            await InitializePoolAsync(connectionString, pool);
        }

        if (pool.TryDequeue(out var connectionWrapper))
        {
            if (connectionWrapper.Connection.State == ConnectionState.Closed)
            {
                try
                {
                    await connectionWrapper.Connection.OpenAsync();
                    connectionWrapper.LastUsed = DateTime.Now; // Update LastUsed
                    return connectionWrapper.Connection;
                }
                catch
                {
                    return await CreateNewConnectionAsync(connectionString);
                }
            }

            connectionWrapper.LastUsed = DateTime.Now; // Update LastUsed
            return connectionWrapper.Connection;
        }

        return await CreateNewConnectionAsync(connectionString);
    }

    public static MsiSqlConnection GetConnection(string connectionString)
    {
        return GetConnectionAsync(connectionString).GetAwaiter().GetResult();
    }

    public static void ReturnConnection(MsiSqlConnection connection)
    {
        if (connection == null) return;

        try
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

            if (_connectionPools.TryGetValue(connection.ConnectionString, out var pool))
            {
                pool.Enqueue(new ConnectionWrapper(connection));
            }
        }
        catch
        {
            try { connection.Dispose(); } catch { }
        }
    }

    private static async Task InitializePoolAsync(string connectionString, ConcurrentQueue<ConnectionWrapper> pool)
    {
        for (int i = 0; i < MinPoolSize; i++)
        {
            var connection = await CreateNewConnectionAsync(connectionString);
            pool.Enqueue(new ConnectionWrapper(connection));
        }
    }

    private static async Task<MsiSqlConnection> CreateNewConnectionAsync(string connectionString)
    {
        var builder = new SqlConnectionStringBuilder(connectionString)
        {
            ConnectTimeout = ConnectionTimeout,
            Pooling = true,
            MinPoolSize = MinPoolSize,
            MaxPoolSize = MaxPoolSize
        };

        var connection = new MsiSqlConnection(builder.ConnectionString);
        await connection.OpenAsync();
        return connection;
    }

    private static void CleanupIdleConnections(object sender, ElapsedEventArgs e)
    {
        foreach (var pool in _connectionPools.Values)
        {
            while (pool.TryPeek(out var connectionWrapper) && (DateTime.Now - connectionWrapper.LastUsed).TotalSeconds > IdleTimeout)
            {
                if (pool.TryDequeue(out connectionWrapper))
                {
                    connectionWrapper.Connection.Dispose();
                }
            }
        }
    }

    public static ConnectionScope CreateScope(string connectionString)
    {
        return new ConnectionScope(GetConnection(connectionString));
    }
}
