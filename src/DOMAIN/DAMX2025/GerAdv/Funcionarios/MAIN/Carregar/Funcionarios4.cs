namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncionarios
{
    public DBFuncionarios(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBFuncionarios(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Funcionarios: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Ani)))
                m_FAni = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Ani));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Cargo)))
                m_FCargo = Convert.ToInt32(getValue(DBFuncionariosDicInfo.Cargo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBFuncionariosDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.CTPSDtEmissao)))
                m_FCTPSDtEmissao = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.CTPSDtEmissao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.DtNasc)))
                m_FDtNasc = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.DtNasc));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Etiqueta)))
                m_FEtiqueta = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Etiqueta));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Funcao)))
                m_FFuncao = Convert.ToInt32(getValue(DBFuncionariosDicInfo.Funcao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.LiberaAgenda)))
                m_FLiberaAgenda = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.LiberaAgenda));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Periodo_Fim)))
                m_FPeriodo_Fim = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.Periodo_Fim));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Periodo_Ini)))
                m_FPeriodo_Ini = Convert.ToDateTime(getValue(DBFuncionariosDicInfo.Periodo_Ini));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBFuncionariosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBFuncionariosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Salario)))
                m_FSalario = Convert.ToDecimal(getValue(DBFuncionariosDicInfo.Salario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Sexo)))
                m_FSexo = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Sexo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Tipo)))
                m_FTipo = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Tipo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBFuncionariosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBFuncionariosDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FBairro = getValue(DBFuncionariosDicInfo.Bairro)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = getValue(DBFuncionariosDicInfo.CEP)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClass = getValue(DBFuncionariosDicInfo.Class)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = getValue(DBFuncionariosDicInfo.Contato)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCPF = getValue(DBFuncionariosDicInfo.CPF)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = getValue(DBFuncionariosDicInfo.CTPSNumero)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = getValue(DBFuncionariosDicInfo.CTPSSerie)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = getValue(DBFuncionariosDicInfo.EMail)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailPro = getValue(DBFuncionariosDicInfo.EMailPro)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = getValue(DBFuncionariosDicInfo.Endereco)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = getValue(DBFuncionariosDicInfo.Fax)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = getValue(DBFuncionariosDicInfo.Fone)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBFuncionariosDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBFuncionariosDicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = getValue(DBFuncionariosDicInfo.Observacao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = getValue(DBFuncionariosDicInfo.Pasta)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = getValue(DBFuncionariosDicInfo.PIS)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRegistro = getValue(DBFuncionariosDicInfo.Registro)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = getValue(DBFuncionariosDicInfo.RG)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Funcionarios: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Funcionarios: {ex.Message}", ex);
        }
    }
}