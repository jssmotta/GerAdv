namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGrupo
{
    public DBOperadorGrupo(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBOperadorGrupo(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do OperadorGrupo: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBOperadorGrupoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBOperadorGrupoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.Grupo)))
                m_FGrupo = Convert.ToInt32(getValue(DBOperadorGrupoDicInfo.Grupo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.Inativo)))
                m_FInativo = Convert.ToBoolean(getValue(DBOperadorGrupoDicInfo.Inativo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBOperadorGrupoDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBOperadorGrupoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBOperadorGrupoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBOperadorGrupoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBOperadorGrupoDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do OperadorGrupo: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do OperadorGrupo: {ex.Message}", ex);
        }
    }
}