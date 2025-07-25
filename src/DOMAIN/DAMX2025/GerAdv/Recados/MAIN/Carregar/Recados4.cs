namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRecados
{
    public DBRecados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBRecados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Recados: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Agenda)))
                m_FAgenda = Convert.ToInt32(getValue(DBRecadosDicInfo.Agenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.AguardarRetorno)))
                m_FAguardarRetorno = Convert.ToBoolean(getValue(DBRecadosDicInfo.AguardarRetorno));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.AguardarRetornoOK)))
                m_FAguardarRetornoOK = Convert.ToBoolean(getValue(DBRecadosDicInfo.AguardarRetornoOK));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.AssuntoRecado)))
                m_FAssuntoRecado = Convert.ToInt32(getValue(DBRecadosDicInfo.AssuntoRecado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.BIU)))
                m_FBIU = Convert.ToBoolean(getValue(DBRecadosDicInfo.BIU));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBRecadosDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Concluido)))
                m_FConcluido = Convert.ToBoolean(getValue(DBRecadosDicInfo.Concluido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.ContatoCRM)))
                m_FContatoCRM = Convert.ToInt32(getValue(DBRecadosDicInfo.ContatoCRM));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBRecadosDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBRecadosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBRecadosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Emotion)))
                m_FEmotion = Convert.ToInt32(getValue(DBRecadosDicInfo.Emotion));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Historico)))
                m_FHistorico = Convert.ToInt32(getValue(DBRecadosDicInfo.Historico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Hora)))
                m_FHora = Convert.ToDateTime(getValue(DBRecadosDicInfo.Hora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Importante)))
                m_FImportante = Convert.ToBoolean(getValue(DBRecadosDicInfo.Importante));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.InternetID)))
                m_FInternetID = Convert.ToInt32(getValue(DBRecadosDicInfo.InternetID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.IsContatoCRM)))
                m_FIsContatoCRM = Convert.ToBoolean(getValue(DBRecadosDicInfo.IsContatoCRM));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Ligacoes)))
                m_FLigacoes = Convert.ToInt32(getValue(DBRecadosDicInfo.Ligacoes));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.MasterID)))
                m_FMasterID = Convert.ToInt32(getValue(DBRecadosDicInfo.MasterID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.NaoPublicavel)))
                m_FNaoPublicavel = Convert.ToBoolean(getValue(DBRecadosDicInfo.NaoPublicavel));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Natureza)))
                m_FNatureza = Convert.ToInt32(getValue(DBRecadosDicInfo.Natureza));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.ParaID)))
                m_FParaID = Convert.ToInt32(getValue(DBRecadosDicInfo.ParaID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Pessoal)))
                m_FPessoal = Convert.ToBoolean(getValue(DBRecadosDicInfo.Pessoal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBRecadosDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBRecadosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBRecadosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Retornar)))
                m_FRetornar = Convert.ToBoolean(getValue(DBRecadosDicInfo.Retornar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.RetornoData)))
                m_FRetornoData = Convert.ToDateTime(getValue(DBRecadosDicInfo.RetornoData));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Typed)))
                m_FTyped = Convert.ToBoolean(getValue(DBRecadosDicInfo.Typed));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Uploaded)))
                m_FUploaded = Convert.ToBoolean(getValue(DBRecadosDicInfo.Uploaded));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Urgente)))
                m_FUrgente = Convert.ToBoolean(getValue(DBRecadosDicInfo.Urgente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBRecadosDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRecadosDicInfo.Voltara)))
                m_FVoltara = Convert.ToBoolean(getValue(DBRecadosDicInfo.Voltara));
        }
        catch
        {
        }

        try
        {
            m_FAguardarRetornoPara = getValue(DBRecadosDicInfo.AguardarRetornoPara)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssunto = getValue(DBRecadosDicInfo.Assunto)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClienteNome = getValue(DBRecadosDicInfo.ClienteNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDe = getValue(DBRecadosDicInfo.De)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBRecadosDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FListaPara = getValue(DBRecadosDicInfo.ListaPara)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPara = getValue(DBRecadosDicInfo.Para)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRecado = getValue(DBRecadosDicInfo.Recado)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Recados: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Recados: {ex.Message}", ex);
        }
    }
}