namespace MenphisSI;

public static partial class DevourerSqlData
{




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

    public static void UpdateBoolFields(in string tabela, string campo, SqlConnection? oCnn)
    {
        if (ConfigSys.ReadCfgSysX($"{nameof(UpdateBoolFields)}-{tabela}-{campo}", oCnn) == 2) return;

        try
        {
            ExecuteSql($"UPDATE {tabela} SET {campo}=0 WHERE {campo} IS NULL;", oCnn);
        }
        catch (Exception ex) { GeneralSystemErrorTraper.GetError(ex); }
        ConfigSys.WriteCfgSys($"{nameof(UpdateBoolFields)}-{tabela}-{campo}", 2, oCnn);
    }
}