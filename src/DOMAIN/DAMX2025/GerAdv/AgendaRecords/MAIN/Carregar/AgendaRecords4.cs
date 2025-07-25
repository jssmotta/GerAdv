namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRecords
{
    public DBAgendaRecords(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAgendaRecords(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AgendaRecords: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Agenda)))
                m_FAgenda = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.Agenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Aviso1)))
                m_FAviso1 = Convert.ToBoolean(getValue(DBAgendaRecordsDicInfo.Aviso1));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Aviso2)))
                m_FAviso2 = Convert.ToBoolean(getValue(DBAgendaRecordsDicInfo.Aviso2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Aviso3)))
                m_FAviso3 = Convert.ToBoolean(getValue(DBAgendaRecordsDicInfo.Aviso3));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.ClientesSocios)))
                m_FClientesSocios = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.ClientesSocios));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Colaborador)))
                m_FColaborador = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.Colaborador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.CrmAviso1)))
                m_FCrmAviso1 = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.CrmAviso1));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.CrmAviso2)))
                m_FCrmAviso2 = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.CrmAviso2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.CrmAviso3)))
                m_FCrmAviso3 = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.CrmAviso3));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.DataAviso1)))
                m_FDataAviso1 = Convert.ToDateTime(getValue(DBAgendaRecordsDicInfo.DataAviso1));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.DataAviso2)))
                m_FDataAviso2 = Convert.ToDateTime(getValue(DBAgendaRecordsDicInfo.DataAviso2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.DataAviso3)))
                m_FDataAviso3 = Convert.ToDateTime(getValue(DBAgendaRecordsDicInfo.DataAviso3));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Foro)))
                m_FForo = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.Foro));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Julgador)))
                m_FJulgador = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.Julgador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRecordsDicInfo.Perito)))
                m_FPerito = Convert.ToInt32(getValue(DBAgendaRecordsDicInfo.Perito));
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
            throw new Exception($"Erro ao carregar dados do AgendaRecords: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AgendaRecords: {ex.Message}", ex);
        }
    }
}