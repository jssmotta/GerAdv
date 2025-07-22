namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProValores
{
    public DBProValores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]))
                m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar]))
                m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros]))
                m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta]))
                m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso]))
                m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal]))
                m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]))
                m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta]))
                m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]))
                m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal]))
                m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]))
                m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProValores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]))
                m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar]))
                m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros]))
                m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta]))
                m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso]))
                m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal]))
                m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]))
                m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta]))
                m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]))
                m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal]))
                m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]))
                m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProValores
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [prvCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso]))
            m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;  } catch {}  try { m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar]))
            m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal]))
            m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta]))
            m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta]))
            m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros]))
            m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]))
            m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]))
            m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]))
            m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal]))
            m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]))
            m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProValores
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
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso])) m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.TipoValorProcesso]))
            m_FTipoValorProcesso = Convert.ToInt32(dbRec[DBProValoresDicInfo.TipoValorProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;  } catch {}  try { m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIndice = dbRec[DBProValoresDicInfo.Indice]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar])) m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Ignorar]))
            m_FIgnorar = (bool)dbRec[DBProValoresDicInfo.Ignorar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProValoresDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginal]))
            m_FValorOriginal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta])) m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercMulta]))
            m_FPercMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercMulta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta])) m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMulta]))
            m_FValorMulta = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMulta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros])) m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.PercJuros]))
            m_FPercJuros = Convert.ToDecimal(dbRec[DBProValoresDicInfo.PercJuros]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice])) m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]))
            m_FValorOriginalCorrigidoIndice = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorOriginalCorrigidoIndice]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido])) m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]))
            m_FValorMultaCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorMultaCorrigido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido])) m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]))
            m_FValorJurosCorrigido = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorJurosCorrigido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal])) m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.ValorFinal]))
            m_FValorFinal = Convert.ToDecimal(dbRec[DBProValoresDicInfo.ValorFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao])) m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]))
            m_FDataUltimaCorrecao = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DataUltimaCorrecao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProValoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProValoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProValoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProValoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProValoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}