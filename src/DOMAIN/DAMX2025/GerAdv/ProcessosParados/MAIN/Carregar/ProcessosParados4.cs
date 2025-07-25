namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosParados
{
    public DBProcessosParados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBProcessosParados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ProcessosParados: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.Ano)))
                m_FAno = Convert.ToInt32(getValue(DBProcessosParadosDicInfo.Ano));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.DataHistorico)))
                m_FDataHistorico = Convert.ToDateTime(getValue(DBProcessosParadosDicInfo.DataHistorico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.DataHora)))
                m_FDataHora = Convert.ToDateTime(getValue(DBProcessosParadosDicInfo.DataHora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.DataNENotas)))
                m_FDataNENotas = Convert.ToDateTime(getValue(DBProcessosParadosDicInfo.DataNENotas));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBProcessosParadosDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBProcessosParadosDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosParadosDicInfo.Semana)))
                m_FSemana = Convert.ToInt32(getValue(DBProcessosParadosDicInfo.Semana));
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
            throw new Exception($"Erro ao carregar dados do ProcessosParados: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ProcessosParados: {ex.Message}", ex);
        }
    }
}