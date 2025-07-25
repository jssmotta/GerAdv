namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlarmSMS
{
    public DBAlarmSMS(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAlarmSMS(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AlarmSMS: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Agenda)))
                m_FAgenda = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Agenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.AlertarDataHora)))
                m_FAlertarDataHora = Convert.ToDateTime(getValue(DBAlarmSMSDicInfo.AlertarDataHora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D1)))
                m_FD1 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D1));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D2)))
                m_FD2 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D3)))
                m_FD3 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D3));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D4)))
                m_FD4 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D4));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D5)))
                m_FD5 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D5));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D6)))
                m_FD6 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D6));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.D7)))
                m_FD7 = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.D7));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Desativar)))
                m_FDesativar = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.Desativar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Desktop)))
                m_FDesktop = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.Desktop));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBAlarmSMSDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBAlarmSMSDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Emocao)))
                m_FEmocao = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Emocao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.ExcetoDiasFelizes)))
                m_FExcetoDiasFelizes = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.ExcetoDiasFelizes));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Hora)))
                m_FHora = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Hora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Minuto)))
                m_FMinuto = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Minuto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Recado)))
                m_FRecado = Convert.ToInt32(getValue(DBAlarmSMSDicInfo.Recado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Today)))
                m_FToday = Convert.ToDateTime(getValue(DBAlarmSMSDicInfo.Today));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAlarmSMSDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBAlarmSMSDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDescricao = getValue(DBAlarmSMSDicInfo.Descricao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = getValue(DBAlarmSMSDicInfo.EMail)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBAlarmSMSDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGuidExo = getValue(DBAlarmSMSDicInfo.GuidExo)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do AlarmSMS: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AlarmSMS: {ex.Message}", ex);
        }
    }
}