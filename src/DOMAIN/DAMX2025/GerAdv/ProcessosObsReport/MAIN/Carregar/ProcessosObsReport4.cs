namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosObsReport
{
    public DBProcessosObsReport(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBProcessosObsReport(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ProcessosObsReport: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBProcessosObsReportDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBProcessosObsReportDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBProcessosObsReportDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.Historico)))
                m_FHistorico = Convert.ToInt32(getValue(DBProcessosObsReportDicInfo.Historico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBProcessosObsReportDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBProcessosObsReportDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBProcessosObsReportDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosObsReportDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBProcessosObsReportDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FObservacao = getValue(DBProcessosObsReportDicInfo.Observacao)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do ProcessosObsReport: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ProcessosObsReport: {ex.Message}", ex);
        }
    }
}