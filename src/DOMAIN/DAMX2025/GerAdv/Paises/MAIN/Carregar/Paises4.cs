namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPaises
{
    public DBPaises(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPaises(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Paises: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPaisesDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBPaisesDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPaisesDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBPaisesDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPaisesDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBPaisesDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPaisesDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBPaisesDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPaisesDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBPaisesDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBPaisesDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBPaisesDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Paises: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Paises: {ex.Message}", ex);
        }
    }
}