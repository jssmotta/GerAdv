namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensMateriais
{
    public DBBensMateriais(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao]))
                m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra]))
                m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]))
                m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]))
                m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor]))
                m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja]))
                m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem]))
                m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBBensMateriais(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao]))
                m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra]))
                m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]))
                m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]))
                m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor]))
                m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja]))
                m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem]))
                m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_BensMateriais
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [bmtCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao]))
            m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra]))
            m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]))
            m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;  } catch {}  try { m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor]))
            m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem]))
            m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;  } catch {}  try { m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; } catch { }

#else
        m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja]))
            m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]))
            m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_BensMateriais
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
m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBBensMateriaisDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao])) m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.BensClassificacao]))
            m_FBensClassificacao = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.BensClassificacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra])) m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataCompra]))
            m_FDataCompra = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataCompra]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia])) m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]))
            m_FDataFimDaGarantia = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataFimDaGarantia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;  } catch {}  try { m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNFNRO = dbRec[DBBensMateriaisDicInfo.NFNRO]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor])) m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Fornecedor]))
            m_FFornecedor = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Fornecedor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem])) m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.ValorBem]))
            m_FValorBem = Convert.ToDecimal(dbRec[DBBensMateriaisDicInfo.ValorBem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroSerieProduto = dbRec[DBBensMateriaisDicInfo.NroSerieProduto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;  } catch {}  try { m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty; } catch { }

#else
        m_FComprador = dbRec[DBBensMateriaisDicInfo.Comprador]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja])) m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.GarantiaLoja]))
            m_FGarantiaLoja = (bool)dbRec[DBBensMateriaisDicInfo.GarantiaLoja];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja])) m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]))
            m_FDataTerminoDaGarantiaDaLoja = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBBensMateriaisDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeVendedor = dbRec[DBBensMateriaisDicInfo.NomeVendedor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBBensMateriaisDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBBensMateriaisDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBBensMateriaisDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBBensMateriaisDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensMateriaisDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBBensMateriaisDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}