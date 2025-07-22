namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAcao
{
    public DBAcao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAcao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Acao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [acaCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Acao
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
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAcaoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAcaoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAcaoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAcaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAcaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAcaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAcaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}