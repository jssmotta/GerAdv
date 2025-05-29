namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAreasJustica
{
    public DBAreasJustica(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);
        }
        catch
        {
        }
    }

    public DBAreasJustica(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);
        }
        catch
        {
        }
    }

#region CarregarDados_AreasJustica
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [arjCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AreasJustica
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
if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreasJusticaDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAreasJusticaDicInfo.Justica]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}