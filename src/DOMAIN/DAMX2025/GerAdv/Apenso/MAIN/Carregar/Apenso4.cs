namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso
{
    public DBApenso(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBApenso(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Apenso: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBApensoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBApensoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.DtDist)))
                m_FDtDist = Convert.ToDateTime(getValue(DBApensoDicInfo.DtDist));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBApensoDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBApensoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBApensoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.ValorCausa)))
                m_FValorCausa = Convert.ToDecimal(getValue(DBApensoDicInfo.ValorCausa));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApensoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBApensoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FAcao = getValue(DBApensoDicInfo.Acao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FApenso = getValue(DBApensoDicInfo.Apenso)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = getValue(DBApensoDicInfo.OBS)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Apenso: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Apenso: {ex.Message}", ex);
        }
    }
}