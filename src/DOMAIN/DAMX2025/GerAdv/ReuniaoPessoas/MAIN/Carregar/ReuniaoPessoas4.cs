namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniaoPessoas
{
    public DBReuniaoPessoas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBReuniaoPessoas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ReuniaoPessoas: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBReuniaoPessoasDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBReuniaoPessoasDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.Operador)))
                m_FOperador = Convert.ToInt32(getValue(DBReuniaoPessoasDicInfo.Operador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBReuniaoPessoasDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBReuniaoPessoasDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.Reuniao)))
                m_FReuniao = Convert.ToInt32(getValue(DBReuniaoPessoasDicInfo.Reuniao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBReuniaoPessoasDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBReuniaoPessoasDicInfo.Visto));
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
            throw new Exception($"Erro ao carregar dados do ReuniaoPessoas: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ReuniaoPessoas: {ex.Message}", ex);
        }
    }
}