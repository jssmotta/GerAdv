namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTPeriodicidade
{
    public DBGUTPeriodicidade(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]))
                m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTPeriodicidade(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]))
                m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTPeriodicidade
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pcgCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]))
            m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTPeriodicidade
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
m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTPeriodicidadeDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias])) m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]))
            m_FIntervaloDias = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.IntervaloDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTPeriodicidadeDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTPeriodicidadeDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}