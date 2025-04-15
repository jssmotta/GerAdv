 
using System.Collections.Concurrent;


namespace MenphisSI;

public static partial class Configuracoes
{
    public const string PCmdReadOnly = "ApplicationIntent=ReadOnly;";

    // Cache thread-safe de connection strings
    private static readonly ConcurrentDictionary<string, string> ConnectionStringsUri = new();

    /// <summary>
    /// Obtém uma conexão somente leitura do pool para a URI especificada
    /// </summary>
    public static SqlConnection? GetConnectionByUri(in string uri)
    {
        try
        {
            var connectionString = GetCachedConnectionString(uri, true);
            return DbConnectionFactory.GetConnection(connectionString);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro conexão BD: " + ex.Message);
           
        }
    } 
    public static async Task<SqlConnection?> GetConnectionByUriAsync(string uri)
    {
        try
        {
            var connectionString = GetCachedConnectionString(uri, true);
            return await DbConnectionFactory.GetConnectionAsync(connectionString);
        }
        catch
        {
            return null;
        }
    }
     
    public static SqlConnection? GetConnectionByUriRw(in string uri)
    {
        try
        {
            var connectionString = GetCachedConnectionString(uri, false);
            return DbConnectionFactory.GetConnection(connectionString);
        }
        catch
        {
            return null;
        }
    }
     
    public static async Task<SqlConnection?> GetConnectionByUriRwAsync(string uri)
    {
        try
        {
            var connectionString = GetCachedConnectionString(uri, false);
            return await DbConnectionFactory.GetConnectionAsync(connectionString);
        }
        catch
        {
            return null;
        }
    }

  
    public static string? ConnectionByUri(in string uri)
    {
        return GetCachedConnectionString(uri, true);
    }

 
    private static string GetCachedConnectionString(string uri, bool readOnly)
    {

//#if (DEBUG)
//    return $"Server=localhost;Database=db_a998a9_mdsaj;Integrated Security=SSPI;TrustServerCertificate=True;";
//#endif

       
        var cacheKey = readOnly ? $"ro_{uri}" : $"rw_{uri}";

     
        if (ConnectionStringsUri.TryGetValue(cacheKey, out var cachedConnectionString))
        {
            return cachedConnectionString;
        }

     
        lock (ConnectionStringsUri)
        {
         
            if (ConnectionStringsUri.TryGetValue(cacheKey, out cachedConnectionString))
            {
                return cachedConnectionString;
            }

      
            var baseConnection = readOnly ? ConnectionString(uri) : ConnectionStringRw(uri);
            var connectionString = readOnly ? $"{PCmdReadOnly}{baseConnection}" : baseConnection;

        
            ConnectionStringsUri[cacheKey] = connectionString;

            return connectionString;
        }
    } 
    public static ConnectionScope CreateConnectionScope(string uri, bool readOnly = true)
    {
        var connection = readOnly ? GetConnectionByUri(uri) : GetConnectionByUriRw(uri);
        return new ConnectionScope(connection);
    }

    public static ConnectionScope CreateConnectionScopeRw(string uri, bool readOnly = false)
    {
        var connection = readOnly ? GetConnectionByUri(uri) : GetConnectionByUriRw(uri);
        return new ConnectionScope(connection);
    }
    public static async Task<T> UseConnectionAsync<T>(string uri, Func<SqlConnection, Task<T>> action, bool readOnly = true)
    {
        using var scope = readOnly ?
            await GetConnectionByUriAsync(uri) :
            await GetConnectionByUriRwAsync(uri);

        if (scope == null)
            throw new InvalidOperationException("Não foi possível estabelecer conexão com o banco de dados");

        return await action(scope);
    }
}
 