namespace MenphisSI.Domain.DBT;

 
public class ConfiguracoesDBT
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
        }
        catch (SqlException)
        { 
        }
        catch (Exception)
        {           
        }
        return resultTable;
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
             
            throw new Exception("Erro GetConnection " + ex.Message);
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

    
 
 
}

 
