namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGruposAgendaOperadores
{
    public DBOperadorGruposAgendaOperadores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBOperadorGruposAgendaOperadores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do OperadorGruposAgendaOperadores: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBOperadorGruposAgendaOperadoresDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBOperadorGruposAgendaOperadoresDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBOperadorGruposAgendaOperadoresDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda)))
                m_FOperadorGruposAgenda = Convert.ToInt32(getValue(DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBOperadorGruposAgendaOperadoresDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGruposAgendaOperadoresDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBOperadorGruposAgendaOperadoresDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBOperadorGruposAgendaOperadoresDicInfo.GUID)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do OperadorGruposAgendaOperadores: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do OperadorGruposAgendaOperadores: {ex.Message}", ex);
        }
    }
}