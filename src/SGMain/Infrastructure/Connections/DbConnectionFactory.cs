using System.Collections.Concurrent;
using System.Data;
using System.Timers;
using Microsoft.Data.SqlClient;

namespace MenphisSI.Connections;

public static class DbConnectionFactory
{
    // Usar valores configuráveis
    private const int MaxPoolSize = 100;
    private const int MinPoolSize = 10;     

    // Adicionar timeout configurável para conexões ociosas
    private const int IdleTimeout = 300;
    private const int ConnectionTimeout = 25; // 25 segundos

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

    public static async Task<MsiSqlConnection> GetConnectionAsync(string? connectionString)
    {
        if (connectionString == null) {
            throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null.");
        }
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
            catch (Exception) 
            {

            }
            await InitializePoolAsync(connectionString, pool);
        }

        if (pool.TryDequeue(out var connectionWrapper))
        {
            if (connectionWrapper?.Connection?.State == ConnectionState.Closed)
            {
                try
                {
                    await connectionWrapper.Connection.OpenAsync();
                    connectionWrapper.LastUsed = DateTime.Now; // Update LastUsed
                    return connectionWrapper.Connection!;
                }
                catch
                {
                    return await CreateNewConnectionAsync(connectionString);
                }
            }

            if (connectionWrapper?.Connection != null)
            {
                connectionWrapper.LastUsed = DateTime.Now; // Update LastUsed
                return connectionWrapper.Connection;
            }
            // If connectionWrapper or its Connection is null, create a new connection
            return await CreateNewConnectionAsync(connectionString);
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

            // Find the pool for this connection by checking all pools
            // since the connection's ConnectionString may have been modified by SqlConnectionStringBuilder
            foreach (var kvp in _connectionPools)
            {
                var pool = kvp.Value;
                // Check if this pool is for the same logical connection
                // by trying to create a new connection with the original key and comparing the result
                try
                {
                    var builder = new SqlConnectionStringBuilder(kvp.Key)
                    {
                        ConnectTimeout = ConnectionTimeout,
                        Pooling = true,
                        MinPoolSize = MinPoolSize,
                        MaxPoolSize = MaxPoolSize
                    };
                    
                    // If the normalized connection strings match, this is the right pool
                    if (builder.ConnectionString == connection.ConnectionString)
                    {
                        pool.Enqueue(new ConnectionWrapper(connection));
                        return;
                    }
                }
                catch
                {
                    // Continue to next pool if there's an issue with connection string comparison
                }
            }
            
            // If no matching pool found, dispose the connection
            connection.Dispose();
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

    private static void CleanupIdleConnections(object? sender, ElapsedEventArgs e)
    {
        foreach (var pool in _connectionPools.Values)
        {
            while (pool.TryPeek(out var connectionWrapper) && (DateTime.Now - connectionWrapper.LastUsed).TotalSeconds > IdleTimeout)
            {
                if (pool.TryDequeue(out connectionWrapper))
                {
                    connectionWrapper.Connection?.Dispose();
                }
            }
        }
    }

    public static ConnectionScope CreateScope(string connectionString)
    =>
        new ConnectionScope(GetConnection(connectionString));
    
}
