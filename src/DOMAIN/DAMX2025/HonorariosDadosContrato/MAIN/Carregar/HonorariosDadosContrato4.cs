namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato
{
    public DBHonorariosDadosContrato(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]))
                m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo]))
                m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]))
                m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]))
                m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel]))
                m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBHonorariosDadosContrato(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]))
                m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo]))
                m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]))
                m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]))
                m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel]))
                m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_HonorariosDadosContrato
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[HonorariosDadosContrato] (NOLOCK) WHERE [hdcCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo]))
            m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel]))
            m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]))
            m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]))
            m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]))
            m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_HonorariosDadosContrato
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
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo])) m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Fixo]))
            m_FFixo = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Fixo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel])) m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Variavel]))
            m_FVariavel = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Variavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso])) m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]))
            m_FPercSucesso = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.PercSucesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FArquivoContrato = dbRec[DBHonorariosDadosContratoDicInfo.ArquivoContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoContrato = dbRec[DBHonorariosDadosContratoDicInfo.TextoContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo])) m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]))
            m_FValorFixo = Convert.ToDecimal(dbRec[DBHonorariosDadosContratoDicInfo.ValorFixo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBHonorariosDadosContratoDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]))
            m_FDataContrato = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DataContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHonorariosDadosContratoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHonorariosDadosContratoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHonorariosDadosContratoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHonorariosDadosContratoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHonorariosDadosContratoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}