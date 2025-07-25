namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteOponente
{
    public DBParteOponente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBParteOponente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do ParteOponente: {ex.Message}", ex);
        }
    }

    private void InitFromRecord(Func<string, object?> getValue)
    {
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(getValue(DBParteOponenteDicInfo.Oponente)))
                m_FOponente = Convert.ToInt32(getValue(DBParteOponenteDicInfo.Oponente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBParteOponenteDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBParteOponenteDicInfo.Processo));
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
            throw new Exception($"Erro ao carregar dados do ParteOponente: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do ParteOponente: {ex.Message}", ex);
        }
    }
}