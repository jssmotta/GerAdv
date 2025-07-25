namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnquadramentoEmpresa
{
    public DBEnquadramentoEmpresa(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBEnquadramentoEmpresa(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do EnquadramentoEmpresa: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBEnquadramentoEmpresaDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBEnquadramentoEmpresaDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBEnquadramentoEmpresaDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBEnquadramentoEmpresaDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBEnquadramentoEmpresaDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBEnquadramentoEmpresaDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBEnquadramentoEmpresaDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBEnquadramentoEmpresaDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBEnquadramentoEmpresaDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBEnquadramentoEmpresaDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBEnquadramentoEmpresaDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBEnquadramentoEmpresaDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do EnquadramentoEmpresa: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do EnquadramentoEmpresa: {ex.Message}", ex);
        }
    }
}