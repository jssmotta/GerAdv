namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab
{
    public DBHorasTrab(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBHorasTrab(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do HorasTrab: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Advogado)))
                m_FAdvogado = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Advogado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBHorasTrabDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBHorasTrabDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBHorasTrabDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Funcionario)))
                m_FFuncionario = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Funcionario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Honorario)))
                m_FHonorario = Convert.ToBoolean(getValue(DBHorasTrabDicInfo.Honorario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.IDAgenda)))
                m_FIDAgenda = Convert.ToInt32(getValue(DBHorasTrabDicInfo.IDAgenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.IDContatoCRM)))
                m_FIDContatoCRM = Convert.ToInt32(getValue(DBHorasTrabDicInfo.IDContatoCRM));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBHorasTrabDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBHorasTrabDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Servico)))
                m_FServico = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Servico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Status)))
                m_FStatus = Convert.ToInt32(getValue(DBHorasTrabDicInfo.Status));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Tempo)))
                m_FTempo = Convert.ToDecimal(getValue(DBHorasTrabDicInfo.Tempo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Valor)))
                m_FValor = Convert.ToDecimal(getValue(DBHorasTrabDicInfo.Valor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHorasTrabDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBHorasTrabDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FAnexo = getValue(DBHorasTrabDicInfo.Anexo)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoComp = getValue(DBHorasTrabDicInfo.AnexoComp)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoUNC = getValue(DBHorasTrabDicInfo.AnexoUNC)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBHorasTrabDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrFim = getValue(DBHorasTrabDicInfo.HrFim)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrIni = getValue(DBHorasTrabDicInfo.HrIni)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = getValue(DBHorasTrabDicInfo.OBS)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do HorasTrab: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do HorasTrab: {ex.Message}", ex);
        }
    }
}