namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusBiu
{
    public DBStatusBiu(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBStatusBiu(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do StatusBiu: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBStatusBiuDicInfo.Icone)))
                m_FIcone = Convert.ToInt32(getValue(DBStatusBiuDicInfo.Icone));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusBiuDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBStatusBiuDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBStatusBiuDicInfo.TipoStatusBiu)))
                m_FTipoStatusBiu = Convert.ToInt32(getValue(DBStatusBiuDicInfo.TipoStatusBiu));
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBStatusBiuDicInfo.Nome)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do StatusBiu: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do StatusBiu: {ex.Message}", ex);
        }
    }
}