using MenphisSI.Connections;
using NLog;

namespace MenphisSI;

public static partial class ConfiguracoesSys
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    public const string PCmdReadOnly = "ApplicationIntent=ReadOnly;";
    public const string PStringExtraPerformance = "Connection Lifetime=300;ConnectRetryCount=3;ConnectRetryInterval=10;";
 
    
    public static async Task<MsiSqlConnection> GetConnectionByUriAsync(string uri)
    {
        try
        {
            var connectionString = await GetCachedConnectionString(uri, true);
            var useDbo = (await ConfiguracoesSysX.ProdutoNet(uri)).Dbo;
            return await DbConnectionFactory.GetConnectionAsync(connectionString, useDbo, uri);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Erro ao obter conexão ReadOnly (Async) para URI: {Uri}. Detalhes: {Message}", uri, ex.Message);
            throw new InvalidOperationException("Erro conectando com BD (Async): " + ex.Message, ex);
        }
    }
     

    public static async Task<MsiSqlConnection> GetConnectionByUriRwAsync(string uri)
    {
        try
        {
            var connectionString = await GetCachedConnectionString(uri, false);
            var useDbo = (await ConfiguracoesSysX.ProdutoNet(uri)).Dbo;
            return await DbConnectionFactory.GetConnectionAsync(connectionString, useDbo, uri);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Erro ao obter conexão RW (Async) para URI: {Uri}. Detalhes: {Message}", uri, ex.Message);
            throw new InvalidOperationException("Erro conectando com BD", ex);
        }
    }

    
     

   
   public static async Task<string> GetCachedConnectionString(string uri, bool readOnly)
   {
       var baseConnection = readOnly ? await ConfiguracoesSysX.ConnectionStringAsync(uri) : await ConfiguracoesSysX.ConnectionStringRwAsync(uri);
       var connectionString = readOnly ? $"{baseConnection}" : baseConnection;

       return connectionString;

   }
   
   public static ConnectionScope CreateConnectionScope(string uri, bool readOnly = true)
   {
       var connection = readOnly ? GetConnectionByUriAsync(uri).GetAwaiter().GetResult() : GetConnectionByUriRwAsync(uri).GetAwaiter().GetResult();
       return new ConnectionScope(connection ?? throw new InvalidOperationException($"Não foi possível obter conexão para URI: {uri}"));
   }


   public static ConnectionScope CreateConnectionScopeRw(string uri, bool readOnly = false)
   {
       var connection = readOnly ? GetConnectionByUriAsync(uri).GetAwaiter().GetResult() : GetConnectionByUriRwAsync(uri).GetAwaiter().GetResult();
       return new ConnectionScope(connection ?? throw new InvalidOperationException($"Não foi possível obter conexão RW para URI: {uri}"));
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
