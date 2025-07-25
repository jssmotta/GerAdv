namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAcao
{
    public DBAcao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAcao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Acao: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.Area)))
                m_FArea = Convert.ToInt32(getValue(DBAcaoDicInfo.Area));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBAcaoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBAcaoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.Justica)))
                m_FJustica = Convert.ToInt32(getValue(DBAcaoDicInfo.Justica));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBAcaoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBAcaoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAcaoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBAcaoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDescricao = getValue(DBAcaoDicInfo.Descricao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBAcaoDicInfo.GUID)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Acao: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Acao: {ex.Message}", ex);
        }
    }
}