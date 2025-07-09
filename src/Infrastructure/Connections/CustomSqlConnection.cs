namespace Microsoft.Data.SqlClient;

public class MsiSqlConnection : IDisposable
{
    private SqlConnection? _SqlConnection;
    private string? _ConnectionString;    

    public string UseDbo { get; set; } = "dbo";

    public ConnectionState State => _SqlConnection?.State ?? ConnectionState.Closed;
    public MsiSqlConnection(string connectionString)
    {
        _ConnectionString = connectionString;
        _SqlConnection = new SqlConnection()
        {
            ConnectionString = _ConnectionString
        };
    }

    public MsiSqlConnection()
    {
    }
    public string ConnectionString
    {
        get => _ConnectionString ?? string.Empty;
        set => _ConnectionString = value;
    }

    public void Open()
    {
        _SqlConnection ??= new SqlConnection(_ConnectionString);
        _SqlConnection.Open();
    }

    public void Close()
    {
        _SqlConnection?.Close();
    }

    public SqlCommand CreateCommand()
    {
        return _SqlConnection?.CreateCommand() ?? throw new Exception("Null Connection CreateCommand");
    }
    public SqlTransaction BeginTransaction()
    {
        return _SqlConnection?.BeginTransaction() ?? throw new Exception("Null Connection BeginTransaction");
    }
    public void Dispose()
    {
        _SqlConnection?.Dispose();
    }
    public void ChangeDatabase(string databaseName)
    {
        _SqlConnection?.ChangeDatabase(databaseName);
    }

    public async Task OpenAsync(CancellationToken cancellationToken = default)
    {
        if (_SqlConnection == null) _SqlConnection = new SqlConnection(_ConnectionString);
        await _SqlConnection.OpenAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task CloseAsync()
    {
        if (_SqlConnection != null)
            await _SqlConnection.CloseAsync();
    }

    public async Task DisposeAsync()
    {
        if (_SqlConnection != null)
            await _SqlConnection.DisposeAsync();
    }

    public SqlConnection InnerConnection => _SqlConnection ?? throw new Exception("InnerConnection null");

    public DataTable GetSchema(string collectionName)
    {
        if (_SqlConnection == null)
            throw new Exception("Null Connection GetSchema");

        return _SqlConnection.GetSchema(collectionName);
    }

    public DataTable GetSchema(string collectionName, string[] restrictionValues)
    {
        if (_SqlConnection == null)
            throw new Exception("Null Connection GetSchema");
        return _SqlConnection.GetSchema(collectionName, restrictionValues);
    }

    public DataTable GetSchema()
    {
        if (_SqlConnection == null)
            throw new Exception("Null Connection GetSchema");
        return _SqlConnection.GetSchema();
    }

}
