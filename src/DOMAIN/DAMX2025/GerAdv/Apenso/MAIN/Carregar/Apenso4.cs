namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso
{
    public DBApenso(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist]))
                m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa]))
                m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBApenso(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist]))
                m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa]))
                m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Apenso
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [apeCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;  } catch {}  try { m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;  } catch {}  try { m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist]))
            m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa]))
            m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Apenso
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
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBApensoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;  } catch {}  try { m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FApenso = dbRec[DBApensoDicInfo.Apenso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;  } catch {}  try { m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAcao = dbRec[DBApensoDicInfo.Acao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtDist]))
            m_FDtDist = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtDist]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBApensoDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa])) m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.ValorCausa]))
            m_FValorCausa = Convert.ToDecimal(dbRec[DBApensoDicInfo.ValorCausa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBApensoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBApensoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApensoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBApensoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}