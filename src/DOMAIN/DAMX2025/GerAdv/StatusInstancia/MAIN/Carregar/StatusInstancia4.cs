namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusInstancia
{
    public DBStatusInstancia(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBStatusInstancia(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do StatusInstancia: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBStatusInstanciaDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBStatusInstanciaDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBStatusInstanciaDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBStatusInstanciaDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBStatusInstanciaDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusInstanciaDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBStatusInstanciaDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBStatusInstanciaDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBStatusInstanciaDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do StatusInstancia: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do StatusInstancia: {ex.Message}", ex);
        }
    }
}