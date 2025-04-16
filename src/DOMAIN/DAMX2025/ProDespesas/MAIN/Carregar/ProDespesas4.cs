namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDespesas
{
    public DBProDespesas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido]))
                m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao]))
                m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID]))
                m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa]))
                m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado]))
                m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal]))
                m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProDespesas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido]))
                m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao]))
                m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID]))
                m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa]))
                m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado]))
                m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal]))
                m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProDespesas
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ProDespesas] (NOLOCK) WHERE [desCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID]))
            m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido]))
            m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal]))
            m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado]))
            m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao]))
            m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa]))
            m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProDespesas
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
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID])) m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LigacaoID]))
            m_FLigacaoID = Convert.ToInt32(dbRec[DBProDespesasDicInfo.LigacaoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido])) m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Corrigido]))
            m_FCorrigido = (bool)dbRec[DBProDespesasDicInfo.Corrigido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal])) m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.ValorOriginal]))
            m_FValorOriginal = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.ValorOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado])) m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Quitado]))
            m_FQuitado = Convert.ToInt32(dbRec[DBProDespesasDicInfo.Quitado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao])) m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DataCorrecao]))
            m_FDataCorrecao = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DataCorrecao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProDespesasDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBProDespesasDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBProDespesasDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa])) m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.LivroCaixa]))
            m_FLivroCaixa = (bool)dbRec[DBProDespesasDicInfo.LivroCaixa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProDespesasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProDespesasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProDespesasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDespesasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProDespesasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}