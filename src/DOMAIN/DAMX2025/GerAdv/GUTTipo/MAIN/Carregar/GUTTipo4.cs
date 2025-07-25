namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTTipo
{
    public DBGUTTipo(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBGUTTipo(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do GUTTipo: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBGUTTipoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBGUTTipoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.Ordem)))
                m_FOrdem = Convert.ToInt32(getValue(DBGUTTipoDicInfo.Ordem));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBGUTTipoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBGUTTipoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGUTTipoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBGUTTipoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBGUTTipoDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBGUTTipoDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do GUTTipo: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do GUTTipo: {ex.Message}", ex);
        }
    }
}