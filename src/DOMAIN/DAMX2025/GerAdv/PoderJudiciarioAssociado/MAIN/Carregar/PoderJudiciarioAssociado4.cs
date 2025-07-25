namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado
{
    public DBPoderJudiciarioAssociado(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPoderJudiciarioAssociado(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do PoderJudiciarioAssociado: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Area)))
                m_FArea = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Area));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBPoderJudiciarioAssociadoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBPoderJudiciarioAssociadoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Foro)))
                m_FForo = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Foro));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Justica)))
                m_FJustica = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Justica));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.SubDivisao)))
                m_FSubDivisao = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.SubDivisao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Tipo)))
                m_FTipo = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Tipo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Tribunal)))
                m_FTribunal = Convert.ToInt32(getValue(DBPoderJudiciarioAssociadoDicInfo.Tribunal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPoderJudiciarioAssociadoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBPoderJudiciarioAssociadoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FAreaNome = getValue(DBPoderJudiciarioAssociadoDicInfo.AreaNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCidadeNome = getValue(DBPoderJudiciarioAssociadoDicInfo.CidadeNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FForoNome = getValue(DBPoderJudiciarioAssociadoDicInfo.ForoNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBPoderJudiciarioAssociadoDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FJusticaNome = getValue(DBPoderJudiciarioAssociadoDicInfo.JusticaNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSubDivisaoNome = getValue(DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTribunalNome = getValue(DBPoderJudiciarioAssociadoDicInfo.TribunalNome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do PoderJudiciarioAssociado: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do PoderJudiciarioAssociado: {ex.Message}", ex);
        }
    }
}