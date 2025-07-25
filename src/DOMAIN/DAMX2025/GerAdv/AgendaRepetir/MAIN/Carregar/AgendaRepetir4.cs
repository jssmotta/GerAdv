namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetir
{
    public DBAgendaRepetir(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAgendaRepetir(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AgendaRepetir: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Advogado)))
                m_FAdvogado = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Advogado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.DataFinal)))
                m_FDataFinal = Convert.ToDateTime(getValue(DBAgendaRepetirDicInfo.DataFinal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Dia)))
                m_FDia = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Dia));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Domingo)))
                m_FDomingo = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Domingo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBAgendaRepetirDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBAgendaRepetirDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Frequencia)))
                m_FFrequencia = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Frequencia));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Funcionario)))
                m_FFuncionario = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Funcionario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Hora)))
                m_FHora = Convert.ToDateTime(getValue(DBAgendaRepetirDicInfo.Hora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.HoraFinal)))
                m_FHoraFinal = Convert.ToDateTime(getValue(DBAgendaRepetirDicInfo.HoraFinal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.ID1)))
                m_FID1 = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.ID1));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.ID2)))
                m_FID2 = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.ID2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.ID3)))
                m_FID3 = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.ID3));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.ID4)))
                m_FID4 = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.ID4));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.IDQuem)))
                m_FIDQuem = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.IDQuem));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.IDQuem2)))
                m_FIDQuem2 = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.IDQuem2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.IDTipo)))
                m_FIDTipo = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.IDTipo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Mes)))
                m_FMes = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Mes));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Pessoal)))
                m_FPessoal = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Pessoal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Quarta)))
                m_FQuarta = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Quarta));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBAgendaRepetirDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Quinta)))
                m_FQuinta = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Quinta));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Sabado)))
                m_FSabado = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Sabado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Segunda)))
                m_FSegunda = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Segunda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Sexta)))
                m_FSexta = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Sexta));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Terca)))
                m_FTerca = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Terca));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRepetirDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBAgendaRepetirDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FMensagem = getValue(DBAgendaRepetirDicInfo.Mensagem)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do AgendaRepetir: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AgendaRepetir: {ex.Message}", ex);
        }
    }
}