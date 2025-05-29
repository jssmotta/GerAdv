namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFase
{
    public DBFase(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBFase(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Fase
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [fasCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Fase
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
m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBFaseDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBFaseDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBFaseDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFaseDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFaseDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFaseDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFaseDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFaseDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}