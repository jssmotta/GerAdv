namespace MenphisSI.Connections;

public class ConnectionScope : IDisposable
{
    public MsiSqlConnection Connection { get; }

    public ConnectionScope(MsiSqlConnection connection)
    {
        Connection = connection;
    }

    public void Dispose()
    {
        DbConnectionFactory.ReturnConnection(Connection);
    }
}
