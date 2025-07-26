using System.Diagnostics;

namespace MenphisSI.DB;

 
public partial class ConfiguracoesDBT
{
    public const string SQLNoCount = "SET STATISTICS IO OFF;SET NOCOUNT ON;set dateformat ymd;";
     
    public static string CmdSql(in string cSql) => $"{SQLNoCount}{cSql}";

   
    public static DataTable? GetDataTable(SqlCommand command, CommandBehavior cmdBehavior, MsiSqlConnection? oCnn)
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
            GeneralSystemErrorTraper.GetError(ex, stackTrace: true);
        }

        return resultTable;

    }
    public static DataTable GetDataTable(string cSql, MsiSqlConnection? oCnn)
     =>
          GetDataTable3(cSql, oCnn) ?? throw new Exception(cSql);
    public static DataTable? GetDataTable3(string cSql, MsiSqlConnection? oCnn)
    {
      
        if (oCnn is null) throw new Exception("Conexão fechada DataTable.");

        var trans = oCnn.BeginTransaction();
        using var command = new SqlCommand($"{DevourerConsts.SQLNoCount}{cSql}", oCnn?.InnerConnection, trans);
        
        try
        {
            var table = new DataTable();
            using var da = new SqlDataAdapter(command);
            da.Fill(table);
            trans.Commit();
            return table;
        }
        catch (Exception ex)
        {
            trans.Rollback();
            if (Debugger.IsAttached)
                throw new Exception($"{cSql} - {ex.Message}");
            throw new Exception(ex.Message);
            
        } 
    }

 
    public static DataTable? GetDataTable(in string? cSql, in CommandBehavior cmdBehavior, MsiSqlConnection? oCnn)
    {
        

        if (oCnn is null) throw new Exception("Conexão nula GetDataTable");
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn?.InnerConnection, null);
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

   
   
    public static DataTable? GetDataTable2(string cSql, MsiSqlConnection? oCnn)
    {
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn?.InnerConnection, null);
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
            return ex.Message.ContemUpper("SHADOWS")
                ? new()
                : throw new Exception($"Get Data Table: {ex.Message}.<br />{cSql}");
        }

        return resultTable;
    }

    public static async Task<DataTable?> GetDataTable2Async(string cSql, List<SqlParameter> parametros, MsiSqlConnection? oCnn)
    {
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn?.InnerConnection, null) { CommandTimeout = 30};
        foreach (var param in parametros)
        {
            if (!command.Parameters.Contains(param.ParameterName))
            {
                var newParam = new SqlParameter(param.ParameterName, param.Value)
                {
                    SqlDbType = param.SqlDbType,
                    Direction = param.Direction,
                    Size = param.Size,
                    Precision = param.Precision,
                    Scale = param.Scale
                };
                command.Parameters.Add(newParam);
            }
        }
        var resultTable = new DataTable(command.CommandText);

        try
        {
            using var dataReader = await command.ExecuteReaderAsync(CommandBehavior.Default);
            resultTable.Load(dataReader);
        }
        catch (Exception ex)
        {
            return ex.Message.ContemUpper("SHADOWS")
                ? new()
                : throw new Exception($"Get Data Table: {ex.Message}.<br />{cSql}");
        }

        return resultTable;
    }


    public static async Task<DataTable?> GetDataTable2Async(string cSql, MsiSqlConnection? oCnn)
    {
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn?.InnerConnection, null);
        var resultTable = new DataTable(command.CommandText);

        try
        {
            using var dataReader = await command.ExecuteReaderAsync(CommandBehavior.Default);
            resultTable.Load(dataReader);
        }
        catch (Exception ex)
        {
            return ex.Message.ContemUpper("SHADOWS")
                ? new()
                : throw new Exception($"Get Data Table: {ex.Message}.<br />{cSql}");
        }

        return resultTable;
    } 
    public static MsiSqlConnection? GetConnection(string? cStrConn)
    {

        var oCnnSql = new MsiSqlConnection { ConnectionString = $"{cStrConn};ApplicationIntent=ReadOnly;MultipleActiveResultSets=true;" };

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

    public static SqlDataAdapter GetDataAdapter(in string sqlSelect, MsiSqlConnection conn, SqlTransaction? trans,
        E_TipoSQLCommandTransaction tipoTransSelect)
    {
        var sqlAd = new SqlDataAdapter($"{SQLNoCount}{sqlSelect}", conn?.InnerConnection);
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
   
    public static bool ExecuteSql(string? cSql, MsiSqlConnection? conn, SqlTransaction? trans = null)
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

     
    public static bool ExecuteSqlCreate(string cSql, MsiSqlConnection? conn, SqlTransaction? trans = null)
    {
        if (conn is null) return false;
        var commit = trans == null;

        using var cmd = conn.CreateCommand();
        cmd.CommandText = cSql;
        trans ??= conn.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            cmd.ExecuteNonQuery();
            if (commit) trans.Commit();
            return true;
        }

 
        catch (Exception ex)
        {
            trans.Rollback();

            var err = ex.Message;
            return false;
        }
    }

    public static string DeleteCommand(MsiSqlConnection? oCnn, in bool lTop1 = false)
        => $"DELETE {(lTop1 ? " TOP (1) " : "")}";
 
    
    public static bool CreatePmk(in string tabela, string campoCodigo, MsiSqlConnection? oCnn)
    {
        if (oCnn is null) return false;
        if (ConfigSys.ReadCfgSysX($"{nameof(CreatePmk)}-{tabela}-{campoCodigo}", oCnn) == 2) return true;

        ConfigSys.WriteCfgSys($"{nameof(CreatePmk)}-{tabela}-{campoCodigo}", 2, oCnn);

        // http://www.c-sharpcorner.com/article/dba-skills-for-developers/
        //http://stackoverflow.com/questions/13258297/a-script-to-test-existence-of-primary-keys
        //http://www.sqlservercentral.com/Forums/Topic1267073-392-1.aspx
        var sbSql = new StringBuilder("IF NOT EXISTS (SELECT t.table_schema, t.table_name ");
        sbSql.Append(" FROM INFORMATION_SCHEMA.TABLES t ");
        sbSql.Append(" join INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc");
        sbSql.Append(" ON t.TABLE_NAME = tc.TABLE_NAME AND t.table_schema = tc.table_schema ");
        sbSql.Append(
            $" WHERE tc.constraint_type = 'PRIMARY KEY' AND t.TABLE_NAME='{tabela}' ) ALTER TABLE {tabela} ADD PRIMARY KEY ({campoCodigo})");
        return ExecuteSql(sbSql.ToString(), oCnn, null);
    }

    internal static async Task<string> GetScalarAsync(string cSql, SqlConnection oCnn)
    {
        if (oCnn is null)
            throw new ArgumentNullException(nameof(oCnn), "A conexão não pode ser nula.");

        if (string.IsNullOrWhiteSpace(cSql))
            throw new ArgumentException("O comando SQL não pode ser nulo ou vazio.", nameof(cSql));

        using var cmd = new SqlCommand($"{SQLNoCount}{cSql}", oCnn);
        try
        {
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? string.Empty; // Retorna o valor como string ou vazio se for nulo
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao executar GetScalarAsync: {ex.Message}. SQL: {cSql}", ex);
        }
    }

    public static bool ExecuteDelete(string? cSql, MsiSqlConnection? conn, SqlTransaction? trans = null)
    {
        if (conn is null || cSql is null) return false;

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
        catch (SqlException ex)
        {
            trans.Rollback();

            if (ex.Number == 547)
            {
                throw new Exception($"Este registro não pode ser excluído, pois está vinculado a outros registros.");
            }
            throw new Exception($"Erro ao executar Delete: {ex.Message}.");
        }
        catch
        {
            trans.Rollback();
        }

        return false;
    }

    public static DataTable? GetDataTable(List<SqlParameter> parameters, in string? cSql, in CommandBehavior cmdBehavior, MsiSqlConnection? oCnn)
    {
        if (oCnn is null) throw new Exception("Conexão nula GetDataTable");
        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn?.InnerConnection, null);

        foreach (var param in parameters)
        {
            if (!command.Parameters.Contains(param.ParameterName))
            {
                var newParam = new SqlParameter(param.ParameterName, param.Value)
                {
                    SqlDbType = param.SqlDbType,
                    Direction = param.Direction,
                    Size = param.Size,
                    Precision = param.Precision,
                    Scale = param.Scale
                };
                command.Parameters.Add(newParam);
            }
        }

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

    public static int GetFieldId(in string cWhere, in string campoRetorno, in string cTabela, in MsiSqlConnection? oCnn)
    {
        using var cmd = new SqlCommand(cmdText: $"Select TOP 1 {campoRetorno} From {cTabela.dbo(oCnn)} Where {cWhere}",
            connection: oCnn?.InnerConnection);
        return int.TryParse(cmd.ExecuteScalar().ToString(), out var retId) ? retId : 0;
    }

    public static string GetField(in string cWhere, in string campoRetorno, in string cTabela, in MsiSqlConnection? oCnn)
    {
        using var cmd = new SqlCommand(cmdText: $"Select TOP 1 {campoRetorno} From {cTabela.dbo(oCnn)} Where {cWhere}",
            connection: oCnn?.InnerConnection);
        return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
    }

}


