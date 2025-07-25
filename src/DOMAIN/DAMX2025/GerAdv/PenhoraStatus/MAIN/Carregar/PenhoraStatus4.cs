namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhoraStatus
{
    public DBPenhoraStatus(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPenhoraStatus(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do PenhoraStatus: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPenhoraStatusDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBPenhoraStatusDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPenhoraStatusDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBPenhoraStatusDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPenhoraStatusDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBPenhoraStatusDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPenhoraStatusDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBPenhoraStatusDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPenhoraStatusDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBPenhoraStatusDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBPenhoraStatusDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBPenhoraStatusDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do PenhoraStatus: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do PenhoraStatus: {ex.Message}", ex);
        }
    }
}