using System.Diagnostics;

namespace MenphisSI.Infrastructure.Connections;


public class ConfiguracoesDBT
{
    public const string SQLNoCount = "SET STATISTICS IO OFF;SET NOCOUNT ON;set dateformat ymd;";
     
    public static string CmdSql(in string cSql) => $"{SQLNoCount}{cSql}";

   
    public static DataTable? GetDataTable(SqlCommand command, CommandBehavior cmdBehavior, SqlConnection? oCnn)
    {
        if (oCnn is null)
        {
            return new();
        }

        var source = new TaskCompletionSource<DataTable>();
        using var resultTable = new DataTable(command.CommandText);
        try
        {
            using var dataReader = command.ExecuteReader(cmdBehavior);

            resultTable.Load(dataReader);
            source.SetResult(resultTable);
            //dataReader?.Close();
        }
        catch (SqlException ex)
        { 
        }
        catch (Exception ex)
        {
           // Ignore
        }

        return resultTable;

    }
   
   
 
    public static DataTable? GetDataTable(in string? cSql, in CommandBehavior cmdBehavior, SqlConnection? oCnn)
    {
        

        if (oCnn is null) throw new Exception("Conexão nula GetDataTable");
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn, null);
        var resultTable = new DataTable(command.CommandText);

        try
        {
            var source = new TaskCompletionSource<DataTable>();
            using var dataReader = command.ExecuteReader(cmdBehavior);
            resultTable.Load(dataReader);
            source.SetResult(resultTable);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro GetDataTable " + ex.Message);
        }

        return resultTable;
    }

   
   
    public static DataTable? GetDataTable2(string cSql, SqlConnection? oCnn)
    {
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn, null);
        using var resultTable = new DataTable(command.CommandText);

        try
        {
            var source = new TaskCompletionSource<DataTable>();
            using var dataReader = command.ExecuteReader(CommandBehavior.Default);
            resultTable.Load(dataReader);
            source.SetResult(resultTable);
        }

        catch (Exception ex)
        {
            return ex.Message.ToUpper().Contains("SHADOWS")
                ? new()
                : throw new Exception($"Get Data Table: {ex.Message}.<br />{cSql}");
        }

        return resultTable;
    }

    public static async Task<DataTable?> GetDataTable2Async(string cSql, SqlConnection? oCnn)
    {
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn, null);
        var resultTable = new DataTable(command.CommandText);

        try
        {
            using var dataReader = await command.ExecuteReaderAsync(CommandBehavior.Default);
            resultTable.Load(dataReader);
        }
        catch (Exception ex)
        {
            return ex.Message.ToUpper().Contains("SHADOWS")
                ? new()
                : throw new Exception($"Get Data Table: {ex.Message}.<br />{cSql}");
        }

        return resultTable;
    } 
    public static SqlConnection? GetConnection(string? cStrConn)
    {

        var oCnnSql = new SqlConnection { ConnectionString = $"{cStrConn};ApplicationIntent=ReadOnly;MultipleActiveResultSets=true;" };

        try
        {
            oCnnSql.Open();
        }
        catch
        {
             return null;
        }

        return oCnnSql;
    }
  
    [Serializable]
    public enum E_TipoSQLCommandTransaction
    {
        TipoSelect = 1,
        TipoUpdate = 2,
        TipoInsert = 3,
        TipoNone = 0
    }

    public static SqlDataAdapter GetDataAdapter(in string sqlSelect, SqlConnection conn, SqlTransaction? trans,
        E_TipoSQLCommandTransaction tipoTransSelect)
    {
        var sqlAd = new SqlDataAdapter($"{SQLNoCount}{sqlSelect}", conn);
        if (trans == null) return sqlAd;
        switch (tipoTransSelect)
        {
            case E_TipoSQLCommandTransaction.TipoSelect:
                sqlAd.SelectCommand.Transaction = trans;
                break;
            case E_TipoSQLCommandTransaction.TipoUpdate:
                sqlAd.UpdateCommand.Transaction = trans;
                break;
            case E_TipoSQLCommandTransaction.TipoInsert:
                sqlAd.InsertCommand.Transaction = trans;
                break;
        }

        return sqlAd;
    }
   
    public static bool ExecuteSql(string? cSql, SqlConnection? conn, SqlTransaction? trans = null)
    {
        if (conn is null || cSql is null) return false;

        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"{SQLNoCount}{cSql}";
        trans ??= conn.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            return true;
        }
        catch  
        {
            trans.Rollback(); 
            
            return false;
        }
    }

     
    public static bool ExecuteSqlCreate(string cSql, SqlConnection? conn, SqlTransaction? trans = null)
    {
        if (conn is null) return false;

        using var cmd = conn.CreateCommand();
        cmd.CommandText = cSql;
        trans ??= conn.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            return true;
        }

 
        catch (Exception ex)
        {
            trans.Rollback();

            var err = ex.Message;
            return false;
        }
    }
     
     
}

 
