namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso2
{
    public DBApenso2(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBApenso2(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Apenso2: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.Apensado)))
                m_FApensado = Convert.ToInt32(getValue(DBApenso2DicInfo.Apensado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBApenso2DicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBApenso2DicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBApenso2DicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBApenso2DicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBApenso2DicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBApenso2DicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBApenso2DicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do Apenso2: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Apenso2: {ex.Message}", ex);
        }
    }
}