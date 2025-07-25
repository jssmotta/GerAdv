namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTerceiros
{
    public DBTerceiros(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBTerceiros(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Terceiros: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBTerceirosDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBTerceirosDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBTerceirosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBTerceirosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBTerceirosDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBTerceirosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBTerceirosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Sexo)))
                m_FSexo = Convert.ToBoolean(getValue(DBTerceirosDicInfo.Sexo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Situacao)))
                m_FSituacao = Convert.ToInt32(getValue(DBTerceirosDicInfo.Situacao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBTerceirosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBTerceirosDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FBairro = getValue(DBTerceirosDicInfo.Bairro)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = getValue(DBTerceirosDicInfo.CEP)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClass = getValue(DBTerceirosDicInfo.Class)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = getValue(DBTerceirosDicInfo.EMail)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = getValue(DBTerceirosDicInfo.Endereco)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = getValue(DBTerceirosDicInfo.Fax)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = getValue(DBTerceirosDicInfo.Fone)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBTerceirosDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBTerceirosDicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = getValue(DBTerceirosDicInfo.OBS)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FVaraForoComarca = getValue(DBTerceirosDicInfo.VaraForoComarca)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Terceiros: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Terceiros: {ex.Message}", ex);
        }
    }
}