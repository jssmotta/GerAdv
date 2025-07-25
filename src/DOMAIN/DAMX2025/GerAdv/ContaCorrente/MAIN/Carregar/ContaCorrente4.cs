namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContaCorrente
{
    public DBContaCorrente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBContaCorrente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ContaCorrente: {ex.Message}", ex);
        }
    }

    private void InitFromRecord(Func<string, object?> getValue)
    {
        if (DBNull.Value.Equals(getValue(CampoCodigo)))
            return;
        ID = Convert.ToInt32(getValue(CampoCodigo));
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.CIAcordo)))
                m_FCIAcordo = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.CIAcordo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Contrato)))
                m_FContrato = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Contrato));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBContaCorrenteDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DataPgto)))
                m_FDataPgto = Convert.ToDateTime(getValue(DBContaCorrenteDicInfo.DataPgto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DebitoID)))
                m_FDebitoID = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.DebitoID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DistRegra)))
                m_FDistRegra = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.DistRegra));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Distribuir)))
                m_FDistribuir = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Distribuir));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBContaCorrenteDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBContaCorrenteDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.DtOriginal)))
                m_FDtOriginal = Convert.ToDateTime(getValue(DBContaCorrenteDicInfo.DtOriginal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Hide)))
                m_FHide = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Hide));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.IDContrato)))
                m_FIDContrato = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.IDContrato));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.IDHTrab)))
                m_FIDHTrab = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.IDHTrab));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.LC)))
                m_FLC = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.LC));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.LivroCaixaID)))
                m_FLivroCaixaID = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.LivroCaixaID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.NroParcelas)))
                m_FNroParcelas = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.NroParcelas));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Pago)))
                m_FPago = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Pago));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.ParcelaPrincipalID)))
                m_FParcelaPrincipalID = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.ParcelaPrincipalID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.ParcelaX)))
                m_FParcelaX = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.ParcelaX));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Quitado)))
                m_FQuitado = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Quitado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.QuitadoID)))
                m_FQuitadoID = Convert.ToInt32(getValue(DBContaCorrenteDicInfo.QuitadoID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Sucumbencia)))
                m_FSucumbencia = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Sucumbencia));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Valor)))
                m_FValor = Convert.ToDecimal(getValue(DBContaCorrenteDicInfo.Valor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.ValorPrincipal)))
                m_FValorPrincipal = Convert.ToDecimal(getValue(DBContaCorrenteDicInfo.ValorPrincipal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContaCorrenteDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBContaCorrenteDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBContaCorrenteDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHistorico = getValue(DBContaCorrenteDicInfo.Historico)?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ContaCorrente: {ex.Message}", ex);
        }
    }

    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ContaCorrente: {ex.Message}", ex);
        }
    }
}