namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresasCli
{
    public DBGruposEmpresasCli(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBGruposEmpresasCli(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do GruposEmpresasCli: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBGruposEmpresasCliDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBGruposEmpresasCliDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBGruposEmpresasCliDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.Grupo)))
                m_FGrupo = Convert.ToInt32(getValue(DBGruposEmpresasCliDicInfo.Grupo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.Oculto)))
                m_FOculto = Convert.ToBoolean(getValue(DBGruposEmpresasCliDicInfo.Oculto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBGruposEmpresasCliDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBGruposEmpresasCliDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBGruposEmpresasCliDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBGruposEmpresasCliDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do GruposEmpresasCli: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do GruposEmpresasCli: {ex.Message}", ex);
        }
    }
}