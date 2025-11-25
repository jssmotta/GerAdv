using System.Collections.Concurrent;
using System.Data;
using System.Timers;
using Microsoft.Data.SqlClient;

namespace MenphisSI.Connections;

public static class DbConnectionFactory
{
    // Reduzir tamanhos do pool para evitar memory leak
    private const int MaxPoolSize = 50;  // Reduzido de 100
    private const int MinPoolSize = 5;   // Reduzido de 10

    // Reduzir timeout para conexões ociosas
    private const int IdleTimeout = 120; // Reduzido de 300 para 120 segundos
    private const int ConnectionTimeout = 15; // Reduzido de 25 para 15 segundos

    // Limpeza mais frequente
    private static readonly System.Timers.Timer _cleanupTimer;
    
    // Adicionar limpeza agressiva periódica
    private static readonly System.Timers.Timer _aggressiveCleanupTimer;

    // Pool de conexões gerenciado pela factory
    private static readonly ConcurrentDictionary<string, ConcurrentQueue<ConnectionWrapper>> _connectionPools = new();

    static DbConnectionFactory()
    {
        _cleanupTimer = new System.Timers.Timer(IdleTimeout * 1000);
        _cleanupTimer.Elapsed += CleanupIdleConnections;
        _cleanupTimer.Start();
        
        // Limpeza agressiva a cada 5 minutos
        _aggressiveCleanupTimer = new System.Timers.Timer(300000);
        _aggressiveCleanupTimer.Elapsed += AggressiveCleanup;
        _aggressiveCleanupTimer.Start();
    }

    public static async Task<MsiSqlConnection> GetConnectionAsync(string? connectionString)
    {
        if (connectionString == null)
        {
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
            // Verificar se a conexão está válida
            if (connectionWrapper?.Connection != null)
            {
                // Se a conexão está há muito tempo ociosa, descartá-la
                if ((DateTime.Now - connectionWrapper.LastUsed).TotalSeconds > IdleTimeout)
                {
                    try
                    {
                        connectionWrapper.Connection.Dispose();
                    }
                    catch { }
                    
                    return await CreateNewConnectionAsync(connectionString);
                }
                
                if (connectionWrapper.Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        await connectionWrapper.Connection.OpenAsync();
                        connectionWrapper.LastUsed = DateTime.Now;
                        return connectionWrapper.Connection;
                    }
                    catch
                    {
                        connectionWrapper.Connection.Dispose();
                        return await CreateNewConnectionAsync(connectionString);
                    }
                }

                connectionWrapper.LastUsed = DateTime.Now;
                return connectionWrapper.Connection;
            }
            
            return await CreateNewConnectionAsync(connectionString);
        }

        // Limitar o tamanho do pool
        if (pool.Count >= MaxPoolSize)
        {
            // Forçar limpeza se o pool está muito grande
            CleanupPool(pool);
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

            foreach (var kvp in _connectionPools)
            {
                var pool = kvp.Value;
                
                // Limitar o tamanho do pool antes de retornar
                if (pool.Count >= MaxPoolSize)
                {
                    connection.Dispose();
                    return;
                }
                
                try
                {
                    var builder = new SqlConnectionStringBuilder(kvp.Key)
                    {
                        ConnectTimeout = ConnectionTimeout,
                        Pooling = true,
                        MinPoolSize = MinPoolSize,
                        MaxPoolSize = MaxPoolSize
                    };
                    
                    if (builder.ConnectionString == connection.ConnectionString)
                    {
                        pool.Enqueue(new ConnectionWrapper(connection));
                        return;
                    }
                }
                catch
                {
                }
            }
            
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
            try
            {
                var connection = await CreateNewConnectionAsync(connectionString);
                pool.Enqueue(new ConnectionWrapper(connection));
            }
            catch
            {
                // Ignorar erros durante inicialização
            }
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
            CleanupPool(pool);
        }
    }

    private static void CleanupPool(ConcurrentQueue<ConnectionWrapper> pool)
    {
        var tempQueue = new ConcurrentQueue<ConnectionWrapper>();
        
        while (pool.TryDequeue(out var connectionWrapper))
        {
            if (connectionWrapper != null && 
                (DateTime.Now - connectionWrapper.LastUsed).TotalSeconds <= IdleTimeout &&
                connectionWrapper.Connection?.State != ConnectionState.Broken)
            {
                tempQueue.Enqueue(connectionWrapper);
            }
            else
            {
                try
                {
                    connectionWrapper?.Connection?.Dispose();
                }
                catch { }
            }
        }
        
        // Recolocar conexões válidas de volta no pool
        while (tempQueue.TryDequeue(out var wrapper))
        {
            pool.Enqueue(wrapper);
        }
    }

    private static void AggressiveCleanup(object? sender, ElapsedEventArgs e)
    {
        foreach (var kvp in _connectionPools)
        {
            var pool = kvp.Value;
            
            // Se o pool está muito grande, reduzir para o tamanho mínimo
            while (pool.Count > MinPoolSize && pool.TryDequeue(out var wrapper))
            {
                try
                {
                    wrapper?.Connection?.Dispose();
                }
                catch { }
            }
        }
        
        // Forçar garbage collection se a memória está alta
        var usedMemory = GC.GetTotalMemory(false) / 1024 / 1024;
        if (usedMemory > 500) // Se usar mais de 500 MB
        {
            GC.Collect(2, GCCollectionMode.Aggressive, true, true);
            GC.WaitForPendingFinalizers();
        }
    }

    public static ConnectionScope CreateScope(string connectionString)
        => new ConnectionScope(GetConnection(connectionString));
}
