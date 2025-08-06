namespace MenphisSI;

public class DatabaseConnectionException : Exception
{
    public DatabaseConnectionException(string message = "Falha de conexão") : base(message) { }
    public DatabaseConnectionException(string message, Exception innerException)
        : base(message, innerException) { }
}
