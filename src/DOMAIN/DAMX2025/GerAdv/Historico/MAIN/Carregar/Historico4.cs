namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHistorico
{
    public DBHistorico(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBHistorico(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Historico: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Agendado)))
                m_FAgendado = Convert.ToBoolean(getValue(DBHistoricoDicInfo.Agendado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Apenso)))
                m_FApenso = Convert.ToInt32(getValue(DBHistoricoDicInfo.Apenso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Concluido)))
                m_FConcluido = Convert.ToBoolean(getValue(DBHistoricoDicInfo.Concluido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBHistoricoDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBHistoricoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBHistoricoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.ExtraID)))
                m_FExtraID = Convert.ToInt32(getValue(DBHistoricoDicInfo.ExtraID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Fase)))
                m_FFase = Convert.ToInt32(getValue(DBHistoricoDicInfo.Fase));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.IDInstProcesso)))
                m_FIDInstProcesso = Convert.ToInt32(getValue(DBHistoricoDicInfo.IDInstProcesso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.IDNE)))
                m_FIDNE = Convert.ToInt32(getValue(DBHistoricoDicInfo.IDNE));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.LiminarOrigem)))
                m_FLiminarOrigem = Convert.ToInt32(getValue(DBHistoricoDicInfo.LiminarOrigem));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.MesmaAgenda)))
                m_FMesmaAgenda = Convert.ToBoolean(getValue(DBHistoricoDicInfo.MesmaAgenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.NaoPublicavel)))
                m_FNaoPublicavel = Convert.ToBoolean(getValue(DBHistoricoDicInfo.NaoPublicavel));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Precatoria)))
                m_FPrecatoria = Convert.ToInt32(getValue(DBHistoricoDicInfo.Precatoria));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBHistoricoDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBHistoricoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBHistoricoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Resumido)))
                m_FResumido = Convert.ToBoolean(getValue(DBHistoricoDicInfo.Resumido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.SAD)))
                m_FSAD = Convert.ToInt32(getValue(DBHistoricoDicInfo.SAD));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.StatusAndamento)))
                m_FStatusAndamento = Convert.ToInt32(getValue(DBHistoricoDicInfo.StatusAndamento));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Top)))
                m_FTop = Convert.ToBoolean(getValue(DBHistoricoDicInfo.Top));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHistoricoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBHistoricoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FExtraGUID = getValue(DBHistoricoDicInfo.ExtraGUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBHistoricoDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = getValue(DBHistoricoDicInfo.Observacao)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Historico: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Historico: {ex.Message}", ex);
        }
    }
}