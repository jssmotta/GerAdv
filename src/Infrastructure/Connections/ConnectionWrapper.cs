namespace MenphisSI.Connections;

// Wrapper class to track LastUsed timestamp
public class ConnectionWrapper
{
    public MsiSqlConnection Connection { get; }
    public DateTime LastUsed { get; set; }

    public ConnectionWrapper(MsiSqlConnection connection)
    {
        Connection = connection;
        LastUsed = DateTime.Now;
    }
}
