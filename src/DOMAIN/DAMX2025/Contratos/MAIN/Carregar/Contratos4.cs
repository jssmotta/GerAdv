namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContratos
{
    public DBContratos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso]))
                m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato]))
                m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio]))
                m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino]))
                m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro]))
                m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio]))
                m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio]))
                m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso]))
                m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca]))
                m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria]))
                m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel]))
                m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBContratos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso]))
                m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato]))
                m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio]))
                m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino]))
                m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro]))
                m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio]))
                m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio]))
                m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso]))
                m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca]))
                m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria]))
                m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel]))
                m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Contratos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [cttCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio]))
            m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino]))
            m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio]))
            m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio]))
            m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria]))
            m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca]))
            m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;  } catch {}  try { m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;  } catch {}  try { m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; } catch { }

#else
        m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel]))
            m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;  } catch {}  try { m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato]))
            m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro]))
            m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso]))
            m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso]))
            m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;  } catch {}  try { m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Contratos
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
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContratosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContratosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBContratosDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBContratosDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBContratosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio])) m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataInicio]))
            m_FDataInicio = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataInicio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino])) m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DataTermino]))
            m_FDataTermino = Convert.ToDateTime(dbRec[DBContratosDicInfo.DataTermino]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio])) m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.OcultarRelatorio]))
            m_FOcultarRelatorio = (bool)dbRec[DBContratosDicInfo.OcultarRelatorio];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio])) m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.PercEscritorio]))
            m_FPercEscritorio = Convert.ToDecimal(dbRec[DBContratosDicInfo.PercEscritorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria])) m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorConsultoria]))
            m_FValorConsultoria = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorConsultoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca])) m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.TipoCobranca]))
            m_FTipoCobranca = Convert.ToInt32(dbRec[DBContratosDicInfo.TipoCobranca]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;  } catch {}  try { m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProtestar = dbRec[DBContratosDicInfo.Protestar]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;  } catch {}  try { m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty; } catch { }

#else
        m_FJuros = dbRec[DBContratosDicInfo.Juros]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel])) m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ValorRealizavel]))
            m_FValorRealizavel = Convert.ToDecimal(dbRec[DBContratosDicInfo.ValorRealizavel]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;  } catch {}  try { m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDOCUMENTO = dbRec[DBContratosDicInfo.DOCUMENTO]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail1 = dbRec[DBContratosDicInfo.EMail1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail2 = dbRec[DBContratosDicInfo.EMail2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail3 = dbRec[DBContratosDicInfo.EMail3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa1 = dbRec[DBContratosDicInfo.Pessoa1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa2 = dbRec[DBContratosDicInfo.Pessoa2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoa3 = dbRec[DBContratosDicInfo.Pessoa3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBContratosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato])) m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.ClienteContrato]))
            m_FClienteContrato = Convert.ToInt32(dbRec[DBContratosDicInfo.ClienteContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro])) m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.IdExtrangeiro]))
            m_FIdExtrangeiro = Convert.ToInt32(dbRec[DBContratosDicInfo.IdExtrangeiro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FChaveContrato = dbRec[DBContratosDicInfo.ChaveContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso])) m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Avulso]))
            m_FAvulso = (bool)dbRec[DBContratosDicInfo.Avulso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso])) m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Suspenso]))
            m_FSuspenso = (bool)dbRec[DBContratosDicInfo.Suspenso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;  } catch {}  try { m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMulta = dbRec[DBContratosDicInfo.Multa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold])) m_FBold = (bool)dbRec[DBContratosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBContratosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContratosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContratosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContratosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContratosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContratosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}