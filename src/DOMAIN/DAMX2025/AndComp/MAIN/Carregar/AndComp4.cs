namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndComp
{
    public DBAndComp(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento]))
                m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso]))
                m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);
        }
        catch
        {
        }
    }

    public DBAndComp(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento]))
                m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso]))
                m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);
        }
        catch
        {
        }
    }

#region CarregarDados_AndComp
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[AndComp] (NOLOCK) WHERE [acpCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento]))
            m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso]))
            m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AndComp
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
if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Andamento]))
            m_FAndamento = Convert.ToInt32(dbRec[DBAndCompDicInfo.Andamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso])) m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndCompDicInfo.Compromisso]))
            m_FCompromisso = Convert.ToInt32(dbRec[DBAndCompDicInfo.Compromisso]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}