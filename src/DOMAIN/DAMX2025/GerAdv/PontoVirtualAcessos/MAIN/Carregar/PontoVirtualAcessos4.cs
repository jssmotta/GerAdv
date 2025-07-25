namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtualAcessos
{
    public DBPontoVirtualAcessos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBPontoVirtualAcessos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do PontoVirtualAcessos: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBPontoVirtualAcessosDicInfo.DataHora)))
                m_FDataHora = Convert.ToDateTime(getValue(DBPontoVirtualAcessosDicInfo.DataHora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPontoVirtualAcessosDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBPontoVirtualAcessosDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBPontoVirtualAcessosDicInfo.Tipo)))
                m_FTipo = Convert.ToBoolean(getValue(DBPontoVirtualAcessosDicInfo.Tipo));
        }
        catch
        {
        }

        try
        {
            m_FOrigem = getValue(DBPontoVirtualAcessosDicInfo.Origem)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do PontoVirtualAcessos: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do PontoVirtualAcessos: {ex.Message}", ex);
        }
    }
}