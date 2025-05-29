namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusBiu
{
    public DBStatusBiu(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]))
                m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBStatusBiu(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]))
                m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_StatusBiu
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [stbCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]))
            m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_StatusBiu
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
m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusBiuDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu])) m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]))
            m_FTipoStatusBiu = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.TipoStatusBiu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusBiuDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBStatusBiuDicInfo.Icone]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}