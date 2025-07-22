namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContaCorrente
{
    public DBContaCorrente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo]))
                m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato]))
                m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto]))
                m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID]))
                m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra]))
                m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir]))
                m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal]))
                m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide]))
                m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato]))
                m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab]))
                m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC]))
                m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]))
                m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas]))
                m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago]))
                m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]))
                m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX]))
                m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado]))
                m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID]))
                m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia]))
                m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]))
                m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBContaCorrente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo]))
                m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato]))
                m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto]))
                m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID]))
                m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra]))
                m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir]))
                m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal]))
                m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide]))
                m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato]))
                m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab]))
                m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC]))
                m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]))
                m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas]))
                m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago]))
                m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]))
                m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX]))
                m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado]))
                m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID]))
                m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia]))
                m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]))
                m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ContaCorrente
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ctoCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo]))
            m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado]))
            m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato]))
            m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID]))
            m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID]))
            m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]))
            m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia]))
            m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra]))
            m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal]))
            m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX]))
            m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato]))
            m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago]))
            m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir]))
            m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC]))
            m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab]))
            m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas]))
            m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]))
            m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]))
            m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide]))
            m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto]))
            m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ContaCorrente
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
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo])) m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.CIAcordo]))
            m_FCIAcordo = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.CIAcordo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado])) m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Quitado]))
            m_FQuitado = (bool)dbRec[DBContaCorrenteDicInfo.Quitado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato])) m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDContrato]))
            m_FIDContrato = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID])) m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuitadoID]))
            m_FQuitadoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuitadoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID])) m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DebitoID]))
            m_FDebitoID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.DebitoID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID])) m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]))
            m_FLivroCaixaID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.LivroCaixaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia])) m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Sucumbencia]))
            m_FSucumbencia = (bool)dbRec[DBContaCorrenteDicInfo.Sucumbencia];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra])) m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DistRegra]))
            m_FDistRegra = (bool)dbRec[DBContaCorrenteDicInfo.DistRegra];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal])) m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtOriginal]))
            m_FDtOriginal = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtOriginal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX])) m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaX]))
            m_FParcelaX = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaX]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBContaCorrenteDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato])) m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Contrato]))
            m_FContrato = (bool)dbRec[DBContaCorrenteDicInfo.Contrato];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago])) m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Pago]))
            m_FPago = (bool)dbRec[DBContaCorrenteDicInfo.Pago];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir])) m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Distribuir]))
            m_FDistribuir = (bool)dbRec[DBContaCorrenteDicInfo.Distribuir];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC])) m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.LC]))
            m_FLC = (bool)dbRec[DBContaCorrenteDicInfo.LC];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab])) m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.IDHTrab]))
            m_FIDHTrab = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.IDHTrab]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas])) m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.NroParcelas]))
            m_FNroParcelas = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.NroParcelas]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal])) m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]))
            m_FValorPrincipal = Convert.ToDecimal(dbRec[DBContaCorrenteDicInfo.ValorPrincipal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID])) m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]))
            m_FParcelaPrincipalID = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.ParcelaPrincipalID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide])) m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Hide]))
            m_FHide = (bool)dbRec[DBContaCorrenteDicInfo.Hide];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto])) m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DataPgto]))
            m_FDataPgto = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DataPgto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContaCorrenteDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContaCorrenteDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContaCorrenteDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContaCorrenteDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContaCorrenteDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}