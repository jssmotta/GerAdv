namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTPeriodicidade
{
    public DBGUTPeriodicidade(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBGUTPeriodicidade(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do GUTPeriodicidade: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBGUTPeriodicidadeDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBGUTPeriodicidadeDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.IntervaloDias)))
                m_FIntervaloDias = Convert.ToInt32(getValue(DBGUTPeriodicidadeDicInfo.IntervaloDias));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBGUTPeriodicidadeDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBGUTPeriodicidadeDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTPeriodicidadeDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBGUTPeriodicidadeDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBGUTPeriodicidadeDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBGUTPeriodicidadeDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do GUTPeriodicidade: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do GUTPeriodicidade: {ex.Message}", ex);
        }
    }
}