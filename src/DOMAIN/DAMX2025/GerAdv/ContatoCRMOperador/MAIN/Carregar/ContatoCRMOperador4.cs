namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMOperador
{
    public DBContatoCRMOperador(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBContatoCRMOperador(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ContatoCRMOperador: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.CargoEsc)))
                m_FCargoEsc = Convert.ToInt32(getValue(DBContatoCRMOperadorDicInfo.CargoEsc));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.ContatoCRM)))
                m_FContatoCRM = Convert.ToInt32(getValue(DBContatoCRMOperadorDicInfo.ContatoCRM));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBContatoCRMOperadorDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBContatoCRMOperadorDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBContatoCRMOperadorDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBContatoCRMOperadorDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBContatoCRMOperadorDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBContatoCRMOperadorDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBContatoCRMOperadorDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do ContatoCRMOperador: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ContatoCRMOperador: {ex.Message}", ex);
        }
    }
}