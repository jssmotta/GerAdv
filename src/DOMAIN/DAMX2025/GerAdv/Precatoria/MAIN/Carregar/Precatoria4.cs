namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrecatoria
{
    public DBPrecatoria(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPrecatoria(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Precatoria: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBPrecatoriaDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBPrecatoriaDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBPrecatoriaDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.DtDist)))
                m_FDtDist = Convert.ToDateTime(getValue(DBPrecatoriaDicInfo.DtDist));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBPrecatoriaDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBPrecatoriaDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBPrecatoriaDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPrecatoriaDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBPrecatoriaDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDeprecado = getValue(DBPrecatoriaDicInfo.Deprecado)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDeprecante = getValue(DBPrecatoriaDicInfo.Deprecante)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBPrecatoriaDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = getValue(DBPrecatoriaDicInfo.OBS)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPrecatoria = getValue(DBPrecatoriaDicInfo.Precatoria)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Precatoria: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Precatoria: {ex.Message}", ex);
        }
    }
}