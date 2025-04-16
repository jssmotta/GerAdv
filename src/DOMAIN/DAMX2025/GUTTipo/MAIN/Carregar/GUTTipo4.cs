namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTTipo
{
    public DBGUTTipo(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem]))
                m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTTipo(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem]))
                m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTTipo
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[GUTTipo] (NOLOCK) WHERE [gttCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem]))
            m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTTipo
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
m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTTipoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem])) m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Ordem]))
            m_FOrdem = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.Ordem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTTipoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTTipoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTTipoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTTipoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTTipoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}