namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNENotas
{
    public DBNENotas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBNENotas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do NENotas: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Apenso)))
                m_FApenso = Convert.ToInt32(getValue(DBNENotasDicInfo.Apenso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBNENotasDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBNENotasDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBNENotasDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Instancia)))
                m_FInstancia = Convert.ToInt32(getValue(DBNENotasDicInfo.Instancia));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.MovPro)))
                m_FMovPro = Convert.ToBoolean(getValue(DBNENotasDicInfo.MovPro));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.NotaExpedida)))
                m_FNotaExpedida = Convert.ToBoolean(getValue(DBNENotasDicInfo.NotaExpedida));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.PalavraChave)))
                m_FPalavraChave = Convert.ToInt32(getValue(DBNENotasDicInfo.PalavraChave));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Precatoria)))
                m_FPrecatoria = Convert.ToInt32(getValue(DBNENotasDicInfo.Precatoria));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBNENotasDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBNENotasDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBNENotasDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Revisada)))
                m_FRevisada = Convert.ToBoolean(getValue(DBNENotasDicInfo.Revisada));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBNENotasDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBNENotasDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBNENotasDicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNotaPublicada = getValue(DBNENotasDicInfo.NotaPublicada)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do NENotas: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do NENotas: {ex.Message}", ex);
        }
    }
}