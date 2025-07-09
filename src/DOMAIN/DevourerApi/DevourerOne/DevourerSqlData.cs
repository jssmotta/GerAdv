namespace MenphisSI;

public static partial class DevourerSqlData
{


    public static List<DBNomeID> ListarNomeID(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        return ReadLocalAsync().Result;
        async Task<List<DBNomeID>> ReadLocalAsync()
        {
            var result = new List<DBNomeID>(max); // Pr�-aloca para melhor performance
            await using var connection = Configuracoes.GetConnectionByUri(uri);

            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([.. parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(new DBNomeID(reader.GetInt32(0), reader.GetString(1)));
            }

            return result;
        }
    }

    public static bool ExecuteSql(string cSql, SqlConnection? oCnn)
    {

        using var cmd = oCnn.CreateCommand();
        cmd.CommandText = cSql.Replace(@"\r\n", " ");
        var oTrans = oCnn.BeginTransaction();
        cmd.Transaction = oTrans;
        cmd.CommandTimeout = 0;
        try
        {
            cmd.ExecuteNonQuery();
            oTrans.Commit();
            return true;
        }
        catch (Exception ex)

        {
            oTrans.Rollback();
            if (cSql.IndexOf("[WCfgSys]", StringComparison.Ordinal) != -1) return false;


#if (DEBUG)
#else
            if (cSql.ToUpper().IndexOf("SHADOWS", StringComparison.Ordinal) != -1 ||
                cSql.ToUpper().IndexOf("UltimosProcessos".ToUpper(), StringComparison.Ordinal) != -1)
                return false;

#endif
            return false;
        }
    }

    //public static void UpdateBoolFields(in string tabela, string campo, SqlConnection? oCnn)
    //{
    //    if (ConfigSys.ReadCfgSysX($"{nameof(UpdateBoolFields)}-{tabela}-{campo}", oCnn) == 2) return;

    //    try
    //    {
    //        ExecuteSql($"UPDATE {tabela} SET {campo}=0 WHERE {campo} IS NULL;", oCnn);
    //    }
    //    catch (Exception ex) { GeneralSystemErrorTraper.GetError(ex); }
    //    ConfigSys.WriteCfgSys($"{nameof(UpdateBoolFields)}-{tabela}-{campo}", 2, oCnn);
    //}
}