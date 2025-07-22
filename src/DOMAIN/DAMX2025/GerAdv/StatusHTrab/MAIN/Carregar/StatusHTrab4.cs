namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusHTrab
{
    public DBStatusHTrab(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID]))
                m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBStatusHTrab(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID]))
                m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_StatusHTrab
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [shtCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 203
m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID]))
            m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_StatusHTrab
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
// region JMen - nType = 203
m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBStatusHTrabDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID])) m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusHTrabDicInfo.ResID]))
            m_FResID = Convert.ToInt32(dbRec[DBStatusHTrabDicInfo.ResID]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}