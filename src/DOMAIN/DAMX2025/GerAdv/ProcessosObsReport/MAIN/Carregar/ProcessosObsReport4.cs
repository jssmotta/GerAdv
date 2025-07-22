namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosObsReport
{
    public DBProcessosObsReport(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico]))
                m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProcessosObsReport(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico]))
                m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProcessosObsReport
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [prrCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico]))
            m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProcessosObsReport
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBProcessosObsReportDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Historico]))
            m_FHistorico = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.Historico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosObsReportDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosObsReportDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosObsReportDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessosObsReportDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}