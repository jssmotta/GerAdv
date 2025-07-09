namespace MenphisSI.Connections;

public class ConnectionScope : IDisposable
{
    public MsiSqlConnection Connection { get; }

    internal ConnectionScope(MsiSqlConnection connection)
    {
        Connection = connection;
    }

    public void Dispose()
    {
        DbConnectionFactory.ReturnConnection(Connection);
    }
}
