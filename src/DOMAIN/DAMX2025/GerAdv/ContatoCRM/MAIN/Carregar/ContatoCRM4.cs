namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRM
{
    public DBContatoCRM(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBContatoCRM(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ContatoCRM: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.AgeClienteAvisado)))
                m_FAgeClienteAvisado = Convert.ToInt32(getValue(DBContatoCRMDicInfo.AgeClienteAvisado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBContatoCRMDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Continuar)))
                m_FContinuar = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Continuar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.DataNotificou)))
                m_FDataNotificou = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.DataNotificou));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.DocsViaRecebimento)))
                m_FDocsViaRecebimento = Convert.ToInt32(getValue(DBContatoCRMDicInfo.DocsViaRecebimento));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Emocao)))
                m_FEmocao = Convert.ToInt32(getValue(DBContatoCRMDicInfo.Emocao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.ExibirNoTopo)))
                m_FExibirNoTopo = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.ExibirNoTopo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.GerarHoraTrabalhada)))
                m_FGerarHoraTrabalhada = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.GerarHoraTrabalhada));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.HoraFinal)))
                m_FHoraFinal = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.HoraFinal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.HoraInicial)))
                m_FHoraInicial = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.HoraInicial));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.HoraNotificou)))
                m_FHoraNotificou = Convert.ToDateTime(getValue(DBContatoCRMDicInfo.HoraNotificou));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Importante)))
                m_FImportante = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Importante));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.IsDocsRecebidos)))
                m_FIsDocsRecebidos = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.IsDocsRecebidos));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.NaoPublicavel)))
                m_FNaoPublicavel = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.NaoPublicavel));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Notificar)))
                m_FNotificar = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Notificar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.ObjetoNotificou)))
                m_FObjetoNotificou = Convert.ToInt32(getValue(DBContatoCRMDicInfo.ObjetoNotificou));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Ocultar)))
                m_FOcultar = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Ocultar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBContatoCRMDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBContatoCRMDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBContatoCRMDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBContatoCRMDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.QuemNotificou)))
                m_FQuemNotificou = Convert.ToInt32(getValue(DBContatoCRMDicInfo.QuemNotificou));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Tempo)))
                m_FTempo = Convert.ToDecimal(getValue(DBContatoCRMDicInfo.Tempo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.TipoContatoCRM)))
                m_FTipoContatoCRM = Convert.ToInt32(getValue(DBContatoCRMDicInfo.TipoContatoCRM));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Urgente)))
                m_FUrgente = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Urgente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBContatoCRMDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FAssunto = getValue(DBContatoCRMDicInfo.Assunto)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = getValue(DBContatoCRMDicInfo.Contato)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBContatoCRMDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoaContato = getValue(DBContatoCRMDicInfo.PessoaContato)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do ContatoCRM: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ContatoCRM: {ex.Message}", ex);
        }
    }
}