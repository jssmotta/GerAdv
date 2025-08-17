using MenphisSI.Domain.DBT;

namespace MenphisSI.Connections;

[Serializable]
public static class DbConnectionFactoryExtensions
{
    public static MsiSqlConnection GetConnection(this ConfiguracoesDBT dbConfig, string connectionString)
    {
        return DbConnectionFactory.GetConnection(connectionString);
    }

    public static async Task<T> UseConnectionAsync<T>(this ConfiguracoesDBT dbConfig, string connectionString, Func<MsiSqlConnection, Task<T>> action)
    {
        using var scope = DbConnectionFactory.CreateScope(connectionString);
        return await action(scope.Connection);
    }
}
