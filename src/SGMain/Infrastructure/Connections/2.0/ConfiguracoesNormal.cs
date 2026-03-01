//using MenphisSI.GerEntityTools.Services;
//using System.ComponentModel;
//using System.Collections.Concurrent;

//namespace MenphisSI;
//public static partial class ConfiguracoesSys
//{
//    private static readonly ConcurrentDictionary<string, string> _connectionCache = new ConcurrentDictionary<string, string>();
//    private static readonly ConcurrentDictionary<string, string> _connectionRwCache = new ConcurrentDictionary<string, string>();
//    private static readonly object _lockObject = new();

//    /// <summary>
//    /// Instância do EntityService para uso interno - configurada via DI
//    /// </summary>
//    internal static IEntityService? EntityServiceInstance { get; set; }

//    public static string ConnectionStringAsync(string uri)
//    {
//        if (string.IsNullOrEmpty(uri))
//        {
//            throw new ArgumentNullException(nameof(uri));
//        }

//        if (EntityServiceInstance == null)
//        {
//            throw new InvalidOperationException("EntityService não foi inicializado. Configure via ConnectionService ou IServiceCollection.");
//        }

//        // Tentar obter do cache primeiro
//        if (_connectionCache.TryGetValue(uri, out var cachedConnection))
//        {
//            return cachedConnection;
//        }

//        // Se não estiver no cache, criar com lock para evitar múltiplas criações simultâneas
//        lock (_lockObject)
//        {
//            // Verificar novamente dentro do lock (double-check locking pattern)
//            if (_connectionCache.TryGetValue(uri, out cachedConnection))
//            {
//                return cachedConnection;
//            }

//            var dbRec = EntityServiceInstance.ReadAsync(uri).GetAwaiter().GetResult();
//            if (dbRec is null)
//            {
//                throw new InvalidEnumArgumentException("dbRec is null");
//            }

//            var connectionString =
//                dbRec.UserID == "SPI" 
//                ?
//                   $"{PCmdReadOnly}Server=np:\\\\.\\pipe\\sql\\query;Database={dbRec.InitialCatalog};Integrated Security=True;Packet Size=4096;MultipleActiveResultSets=true;encrypt=true;Max Pool Size=100;Pooling=true;Connect Timeout=90;TrustServerCertificate=False;MultipleActiveResultSets=true;Enlist=false;Application Name=GerAdv"

//                :                
//                   $"{PCmdReadOnly}{PStringExtraPerformance}Packet Size=4096;MultipleActiveResultSets=true;Enlist=false;encrypt=true;Data Source={dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=90;Persist Security Info=False;TrustServerCertificate=False;Application Name=GerAdv";

//            // Adicionar ao cache
//            _connectionCache[uri] = connectionString;

//            return connectionString;
//        }
//    }

//    public static string ConnectionStringRwAsync(string uri)
//    {
//        if (string.IsNullOrEmpty(uri))
//        {
//            throw new ArgumentNullException(nameof(uri));
//        }

//        if (EntityServiceInstance == null)
//        {
//            throw new InvalidOperationException("EntityService não foi inicializado. Configure via ConnectionService ou IServiceCollection.");
//        }

//        // Tentar obter do cache primeiro
//        if (_connectionRwCache.TryGetValue(uri, out var cachedConnection))
//        {
//            return cachedConnection;
//        }

//        // Se não estiver no cache, criar com lock para evitar múltiplas criações simultâneas
//        lock (_lockObject)
//        {
//            // Verificar novamente dentro do lock (double-check locking pattern)
//            if (_connectionRwCache.TryGetValue(uri, out cachedConnection))
//            {
//                return cachedConnection;
//            }

//            var dbRec = EntityServiceInstance.ReadAsync(uri).GetAwaiter().GetResult();
//            if (dbRec is null)
//            {
//                throw new InvalidEnumArgumentException("dbRec is null");
//            }

//            var connectionString =

//                 dbRec.UserID == "SPI"
//                ?
//                   $"Server=np:\\\\.\\pipe\\sql\\query;Database={dbRec.InitialCatalog};Integrated Security=True;Packet Size=4096;MultipleActiveResultSets=true;encrypt=true;Max Pool Size=100;Pooling=true;Connect Timeout=90;TrustServerCertificate=False;MultipleActiveResultSets=true;Enlist=false;Application Name=GerAdv"

//                :
//                $"{PStringExtraPerformance}Packet Size=4096;MultipleActiveResultSets=true;Enlist=false;encrypt=true;Data Source=tcp:{dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=90;Persist Security Info=False;TrustServerCertificate=False;;Application Name=GerAdv";

//            // Adicionar ao cache
//            _connectionRwCache[uri] = connectionString;

//            return connectionString;
//        }
//    }
//}