namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoRecurso
{
    public DBTipoRecurso(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTipoRecurso(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TipoRecurso
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [trcCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TipoRecurso
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
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoRecursoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoRecursoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoRecursoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoRecursoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoRecursoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoRecursoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}