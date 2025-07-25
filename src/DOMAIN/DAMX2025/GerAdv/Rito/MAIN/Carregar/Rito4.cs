namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRito
{
    public DBRito(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBRito(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Rito: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBRitoDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBRitoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBRitoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBRitoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBRitoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.Top)))
                m_FTop = Convert.ToBoolean(getValue(DBRitoDicInfo.Top));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBRitoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBRitoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDescricao = getValue(DBRitoDicInfo.Descricao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBRitoDicInfo.GUID)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Rito: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Rito: {ex.Message}", ex);
        }
    }
}