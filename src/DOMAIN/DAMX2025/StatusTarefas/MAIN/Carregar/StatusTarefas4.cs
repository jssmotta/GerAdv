namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusTarefas
{
    public DBStatusTarefas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBStatusTarefas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_StatusTarefas
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [sttCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_StatusTarefas
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
m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusTarefasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusTarefasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusTarefasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusTarefasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusTarefasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusTarefasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}