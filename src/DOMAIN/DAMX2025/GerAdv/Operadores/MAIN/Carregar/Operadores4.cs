namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadores
{
    public DBOperadores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBOperadores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Operadores: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Ativado)))
                m_FAtivado = Convert.ToBoolean(getValue(DBOperadoresDicInfo.Ativado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.AtualizarSenha)))
                m_FAtualizarSenha = Convert.ToBoolean(getValue(DBOperadoresDicInfo.AtualizarSenha));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Casa)))
                m_FCasa = Convert.ToBoolean(getValue(DBOperadoresDicInfo.Casa));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.CasaCodigo)))
                m_FCasaCodigo = Convert.ToInt32(getValue(DBOperadoresDicInfo.CasaCodigo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.CasaID)))
                m_FCasaID = Convert.ToInt32(getValue(DBOperadoresDicInfo.CasaID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBOperadoresDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBOperadoresDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBOperadoresDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Enviado)))
                m_FEnviado = Convert.ToBoolean(getValue(DBOperadoresDicInfo.Enviado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Grupo)))
                m_FGrupo = Convert.ToInt32(getValue(DBOperadoresDicInfo.Grupo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.IsNovo)))
                m_FIsNovo = Convert.ToBoolean(getValue(DBOperadoresDicInfo.IsNovo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBOperadoresDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBOperadoresDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.SuporteMaxAge)))
                m_FSuporteMaxAge = Convert.ToDateTime(getValue(DBOperadoresDicInfo.SuporteMaxAge));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadoresDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBOperadoresDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FEMail = getValue(DBOperadoresDicInfo.EMail)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBOperadoresDicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha = getValue(DBOperadoresDicInfo.Senha)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = getValue(DBOperadoresDicInfo.Senha256)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteSenha256 = getValue(DBOperadoresDicInfo.SuporteSenha256)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Operadores: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Operadores: {ex.Message}", ex);
        }
    }
}