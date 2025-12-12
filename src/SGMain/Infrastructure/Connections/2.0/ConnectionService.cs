using MenphisSI.Connections;
using MenphisSI.GerEntityTools.Services;

namespace MenphisSI;

/// <summary>
/// Implementação padrão do IConnectionService que utiliza os métodos estáticos existentes
/// </summary>
public class ConnectionService : IConnectionService
{
    private readonly IEntityService _entityService;

    public ConnectionService(IEntityService entityService)
    {
        _entityService = entityService ?? throw new ArgumentNullException(nameof(entityService));
        
        // Inicializar a propriedade estática para uso pelos métodos estáticos
        ConfiguracoesSys.EntityServiceInstance = _entityService;
    }

    /// <summary>
    /// Serviço de entidades para obter informações de conexão
    /// </summary>
    public IEntityService EntityService => _entityService;

    /// <summary>
    /// Obtém uma conexão somente leitura do pool para a URI especificada
    /// </summary>
    public MsiSqlConnection? GetConnectionByUri(in string uri)
    {
        return ConfiguracoesSys.GetConnectionByUri(uri);
    }

    /// <summary>
    /// Obtém uma conexão somente leitura do pool para a URI especificada (assíncrono)
    /// </summary>
    public async Task<MsiSqlConnection?> GetConnectionByUriAsync(string uri)
    {
        return await ConfiguracoesSys.GetConnectionByUriAsync(uri);
    }

    /// <summary>
    /// Obtém uma conexão de leitura/escrita do pool para a URI especificada
    /// </summary>
    public MsiSqlConnection? GetConnectionByUriRw(in string uri)
    {
        return ConfiguracoesSys.GetConnectionByUriRw(uri);
    }

    /// <summary>
    /// Obtém uma conexão de leitura/escrita do pool para a URI especificada (assíncrono)
    /// </summary>
    public async Task<MsiSqlConnection?> GetConnectionByUriRwAsync(string uri)
    {
        return await ConfiguracoesSys.GetConnectionByUriRwAsync(uri);
    }

    /// <summary>
    /// Obtém a string de conexão para a URI especificada
    /// </summary>
    public string? ConnectionByUri(in string uri)
    {
        return ConfiguracoesSys.ConnectionByUri(uri);
    }

    /// <summary>
    /// Cria um escopo de conexão para a URI especificada
    /// </summary>
    public ConnectionScope CreateConnectionScope(string uri, bool readOnly = true)
    {
        return ConfiguracoesSys.CreateConnectionScope(uri, readOnly);
    }

    /// <summary>
    /// Cria um escopo de conexão de leitura/escrita para a URI especificada
    /// </summary>
    public ConnectionScope CreateConnectionScopeRw(string uri, bool readOnly = false)
    {
        return ConfiguracoesSys.CreateConnectionScopeRw(uri, readOnly);
    }

    /// <summary>
    /// Executa uma ação usando uma conexão temporária
    /// </summary>
    public async Task<T> UseConnectionAsync<T>(string uri, Func<MsiSqlConnection, Task<T>> action, bool readOnly = true)
    {
        return await ConfiguracoesSys.UseConnectionAsync(uri, action, readOnly);
    }
}