using MenphisSI.GerEntityTools.Entity;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace MenphisSI;
public static partial class Configuracoes
{
    private static readonly ConcurrentDictionary<string, string> _connectionCache = new ConcurrentDictionary<string, string>();
    private static readonly ConcurrentDictionary<string, string> _connectionRwCache = new ConcurrentDictionary<string, string>();
    private static readonly object _lockObject = new();

    public static string ConnectionString(string uri)
    {
        if (string.IsNullOrEmpty(uri))
        {
            throw new ArgumentNullException(nameof(uri));
        }

        // Tentar obter do cache primeiro
        if (_connectionCache.TryGetValue(uri, out var cachedConnection))
        {
            return cachedConnection;
        }

        // Se não estiver no cache, criar com lock para evitar múltiplas criações simultâneas
        lock (_lockObject)
        {
            // Verificar novamente dentro do lock (double-check locking pattern)
            if (_connectionCache.TryGetValue(uri, out cachedConnection))
            {
                return cachedConnection;
            }

            var dbRec = EntityApi.Read(uri);
            if (dbRec is null)
            {
                throw new InvalidEnumArgumentException("dbRec is null");
            }

            var connectionString = $"{PCmdReadOnly}Packet Size=4096;MultipleActiveResultSets=true;Enlist=false;encrypt=true;Data Source={dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=30;Persist Security Info=True;TrustServerCertificate=True;";

            // Adicionar ao cache
            _connectionCache[uri] = connectionString;

            return connectionString;
        }
    }

    public static string ConnectionStringRw(string uri)
    {
        if (string.IsNullOrEmpty(uri))
        {
            throw new ArgumentNullException(nameof(uri));
        }

        // Tentar obter do cache primeiro
        if (_connectionRwCache.TryGetValue(uri, out var cachedConnection))
        {
            return cachedConnection;
        }

        // Se não estiver no cache, criar com lock para evitar múltiplas criações simultâneas
        lock (_lockObject)
        {
            // Verificar novamente dentro do lock (double-check locking pattern)
            if (_connectionRwCache.TryGetValue(uri, out cachedConnection))
            {
                return cachedConnection;
            }

            var dbRec = EntityApi.Read(uri);
            if (dbRec is null)
            {
                throw new InvalidEnumArgumentException("dbRec is null");
            }

            var connectionString = $"Packet Size=4096;MultipleActiveResultSets=true;Enlist=false;encrypt=true;Data Source=tcp:{dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=30;Persist Security Info=True;TrustServerCertificate=True;";

            // Adicionar ao cache
            _connectionRwCache[uri] = connectionString;

            return connectionString;
        }
    }
}