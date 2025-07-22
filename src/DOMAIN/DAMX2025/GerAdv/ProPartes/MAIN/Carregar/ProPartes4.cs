namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProPartes
{
    public DBProPartes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte]))
                m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);
        }
        catch
        {
        }
    }

    public DBProPartes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte]))
                m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);
        }
        catch
        {
        }
    }

#region CarregarDados_ProPartes
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [oppCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte]))
            m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProPartes
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte])) m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Parte]))
            m_FParte = Convert.ToInt32(dbRec[DBProPartesDicInfo.Parte]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProPartesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProPartesDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}