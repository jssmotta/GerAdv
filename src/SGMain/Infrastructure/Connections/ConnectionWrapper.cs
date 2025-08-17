namespace MenphisSI.Connections;

// Wrapper class to track LastUsed timestamp
public class ConnectionWrapper
{
    public MsiSqlConnection? Connection { get; }
    public DateTime LastUsed { get; set; }

    public ConnectionWrapper(MsiSqlConnection? connection)
    {
        if (connection == null)
            throw new ArgumentNullException(nameof(connection), "Connection cannot be null");
        Connection = connection;
        LastUsed = DateTime.Now;
    }
}
