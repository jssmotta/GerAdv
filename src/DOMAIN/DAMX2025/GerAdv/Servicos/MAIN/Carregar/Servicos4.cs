namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBServicos
{
    public DBServicos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBServicos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Servicos: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.Basico)))
                m_FBasico = Convert.ToBoolean(getValue(DBServicosDicInfo.Basico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.Cobrar)))
                m_FCobrar = Convert.ToBoolean(getValue(DBServicosDicInfo.Cobrar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBServicosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBServicosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBServicosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBServicosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBServicosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBServicosDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDescricao = getValue(DBServicosDicInfo.Descricao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBServicosDicInfo.GUID)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Servicos: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Servicos: {ex.Message}", ex);
        }
    }
}