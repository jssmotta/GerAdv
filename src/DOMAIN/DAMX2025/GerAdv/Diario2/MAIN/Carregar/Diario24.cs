namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDiario2
{
    public DBDiario2(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBDiario2(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Diario2: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBDiario2DicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBDiario2DicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBDiario2DicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBDiario2DicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBDiario2DicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Hora)))
                m_FHora = Convert.ToDateTime(getValue(DBDiario2DicInfo.Hora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBDiario2DicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBDiario2DicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBDiario2DicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDiario2DicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBDiario2DicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBDiario2DicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = getValue(DBDiario2DicInfo.Nome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOcorrencia = getValue(DBDiario2DicInfo.Ocorrencia)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do Diario2: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do Diario2: {ex.Message}", ex);
        }
    }
}