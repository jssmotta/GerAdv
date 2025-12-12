namespace MenphisSI.Domain.DBT;

 
public class ConfiguracoesDBT
{
    public const string SQLNoCount = "SET STATISTICS IO OFF;SET NOCOUNT ON;set dateformat ymd;";
     
    public static string CmdSql(in string cSql) => $"{SQLNoCount}{cSql}";

    //public static bool ExecuteSqlCreate(string cSql, MsiSqlConnection? conn, SqlTransaction? trans = null)
    //{
    //    if (conn is null) return false;
    //    var commit = trans == null;

    //    using var cmd = conn.CreateCommand();
    //    cmd.CommandText = cSql;
    //    trans ??= conn.BeginTransaction();
    //    cmd.Transaction = trans;
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //        if (commit) trans.Commit();
    //        return true;
    //    }


    //    catch (Exception ex)
    //    {
    //        trans.Rollback();

    //        var err = ex.Message;
    //        return false;
    //    }
    //}
    public static DataTable? GetDataTable(SqlCommand command, CommandBehavior cmdBehavior, MsiSqlConnection? oCnn)
    {
        if (oCnn is null)
        {
            return new();
        }

        var resultTable = new DataTable();
        try
        {
            // Garantir que o comando seja descartado corretamente
            using (command)
            {
                using var dataReader = command.ExecuteReader(cmdBehavior);
                resultTable.Load(dataReader);
            }
            return resultTable;
        }
        catch (SqlException ex)
        {
            resultTable.Dispose();
            // Log do erro se necessário
            return new DataTable();
        }
        catch (Exception ex)
        {
            resultTable.Dispose();
            return new DataTable();
        }
    }   
     
    public static SqlConnection? GetConnection(string? cStrConn)
    {
        var oCnnSql = new SqlConnection { ConnectionString = $"{cStrConn};ApplicationIntent=ReadOnly;" };

        try
        {
            oCnnSql.Open();
        }
        catch (Exception ex)
        {
            oCnnSql.Dispose();
            throw new Exception("Erro GetConnection " + ex.Message);
        }

        return oCnnSql;
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

    [Serializable]
    public enum E_TipoSQLCommandTransaction
    {
        TipoSelect = 1,
        TipoUpdate = 2,
        TipoInsert = 3,
        TipoNone = 0
    }
}
