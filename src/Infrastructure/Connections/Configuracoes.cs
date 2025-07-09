using MenphisSI.Connections;


namespace MenphisSI;

public static partial class Configuracoes
{
    public const string PCmdReadOnly = "ApplicationIntent=ReadOnly;";


    /// <summary>
    /// Obtém uma conexão somente leitura do pool para a URI especificada
    /// </summary>
    public static MsiSqlConnection? GetConnectionByUri(in string uri)
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
    public static async Task<MsiSqlConnection?> GetConnectionByUriAsync(string uri)
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

    public static MsiSqlConnection? GetConnectionByUriRw(in string uri)
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

    public static async Task<MsiSqlConnection?> GetConnectionByUriRwAsync(string uri)
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
        var baseConnection = readOnly ? ConnectionString(uri) : ConnectionStringRw(uri);
        var connectionString = readOnly ? $"{baseConnection}" : baseConnection;

        return connectionString;

    }
    public static ConnectionScope CreateConnectionScope(string uri, bool readOnly = true)
    {
        var connection = readOnly ? GetConnectionByUri(uri) : GetConnectionByUriRw(uri);
        return new ConnectionScope(connection ?? throw new ArgumentNullException("Connection string null"));
    }

    public static ConnectionScope CreateConnectionScopeRw(string uri, bool readOnly = false)
    {
        var connection = readOnly ? GetConnectionByUri(uri) : GetConnectionByUriRw(uri);
        return new ConnectionScope(connection ?? throw new ArgumentNullException("Connection string null"));
    }
    public static async Task<T> UseConnectionAsync<T>(string uri, Func<MsiSqlConnection, Task<T>> action, bool readOnly = true)
    {
        using var scope = readOnly ?
            await GetConnectionByUriAsync(uri) :
            await GetConnectionByUriRwAsync(uri);

        return scope == null
            ? throw new InvalidOperationException("Não foi possível estabelecer conexão com o banco de dados")
            : await action(scope);
    }
}
