using MenphisSI.Connections;
using MenphisSI.GerEntityTools.Services;

namespace MenphisSI;

/// <summary>
/// Interface para abstrair operações de conexão, facilitando testes unitários
/// </summary>
public interface IConnectionService
{
    /// <summary>
    /// Serviço de entidades para obter informações de conexão
    /// </summary>
    IEntityService EntityService { get; }
 

    /// <summary>
    /// Obtém uma conexão somente leitura do pool para a URI especificada (assíncrono)
    /// </summary>
    Task<MsiSqlConnection> GetConnectionByUriAsync(string uri);

 

    /// <summary>
    /// Obtém uma conexão de leitura/escrita do pool para a URI especificada (assíncrono)
    /// </summary>
    Task<MsiSqlConnection> GetConnectionByUriRwAsync(string uri);
 

    /// <summary>
    /// Cria um escopo de conexão para a URI especificada
    /// </summary>
    ConnectionScope CreateConnectionScope(string uri, bool readOnly = true);

    /// <summary>
    /// Cria um escopo de conexão de leitura/escrita para a URI especificada
    /// </summary>
    ConnectionScope CreateConnectionScopeRw(string uri, bool readOnly = false);

    /// <summary>
    /// Executa uma ação usando uma conexão temporária
    /// </summary>
    Task<T> UseConnectionAsync<T>(string uri, Func<MsiSqlConnection, Task<T>> action, bool readOnly = true);
}