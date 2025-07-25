namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaStatus
{
    public DBAgendaStatus(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAgendaStatus(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AgendaStatus: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.Agenda)))
                m_FAgenda = Convert.ToInt32(getValue(DBAgendaStatusDicInfo.Agenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.Completed)))
                m_FCompleted = Convert.ToInt32(getValue(DBAgendaStatusDicInfo.Completed));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBAgendaStatusDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBAgendaStatusDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBAgendaStatusDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBAgendaStatusDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaStatusDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBAgendaStatusDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do AgendaStatus: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AgendaStatus: {ex.Message}", ex);
        }
    }
}