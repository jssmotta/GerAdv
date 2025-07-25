namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProCDA
{
    public DBProCDA(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBProCDA(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ProCDA: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBProCDADicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBProCDADicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBProCDADicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBProCDADicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBProCDADicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBProCDADicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProCDADicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBProCDADicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBProCDADicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBProCDADicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroInterno = getValue(DBProCDADicInfo.NroInterno)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do ProCDA: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ProCDA: {ex.Message}", ex);
        }
    }
}