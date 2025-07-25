namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDepositos
{
    public DBProDepositos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBProDepositos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ProDepositos: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBProDepositosDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBProDepositosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBProDepositosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.Fase)))
                m_FFase = Convert.ToInt32(getValue(DBProDepositosDicInfo.Fase));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBProDepositosDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBProDepositosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBProDepositosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.TipoProDesposito)))
                m_FTipoProDesposito = Convert.ToInt32(getValue(DBProDepositosDicInfo.TipoProDesposito));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.Valor)))
                m_FValor = Convert.ToDecimal(getValue(DBProDepositosDicInfo.Valor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProDepositosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBProDepositosDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do ProDepositos: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ProDepositos: {ex.Message}", ex);
        }
    }
}