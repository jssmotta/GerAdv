namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPosicaoOutrasPartes
{
    public DBPosicaoOutrasPartes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPosicaoOutrasPartes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do PosicaoOutrasPartes: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBPosicaoOutrasPartesDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBPosicaoOutrasPartesDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBPosicaoOutrasPartesDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBPosicaoOutrasPartesDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBPosicaoOutrasPartesDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPosicaoOutrasPartesDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBPosicaoOutrasPartesDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FDescricao = getValue(DBPosicaoOutrasPartesDicInfo.Descricao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBPosicaoOutrasPartesDicInfo.GUID)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do PosicaoOutrasPartes: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do PosicaoOutrasPartes: {ex.Message}", ex);
        }
    }
}