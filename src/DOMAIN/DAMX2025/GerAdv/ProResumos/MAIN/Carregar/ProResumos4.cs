namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProResumos
{
    public DBProResumos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo]))
                m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProResumos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo]))
                m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProResumos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [prsCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo]))
            m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProResumos
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
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProResumosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProResumosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FResumo = dbRec[DBProResumosDicInfo.Resumo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo])) m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.TipoResumo]))
            m_FTipoResumo = Convert.ToInt32(dbRec[DBProResumosDicInfo.TipoResumo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold])) m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProResumosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProResumosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProResumosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProResumosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProResumosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProResumosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}