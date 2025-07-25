namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRelatorio
{
    public DBAgendaRelatorio(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAgendaRelatorio(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AgendaRelatorio: {ex.Message}", ex);
        }
    }

    private void InitFromRecord(Func<string, object?> getValue)
    {
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRelatorioDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBAgendaRelatorioDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaRelatorioDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBAgendaRelatorioDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            m_FBoxAudiencia = getValue(DBAgendaRelatorioDicInfo.BoxAudiencia)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FBoxAudienciaMobile = getValue(DBAgendaRelatorioDicInfo.BoxAudienciaMobile)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeAdvogado = getValue(DBAgendaRelatorioDicInfo.NomeAdvogado)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeArea = getValue(DBAgendaRelatorioDicInfo.NomeArea)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeForo = getValue(DBAgendaRelatorioDicInfo.NomeForo)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeJustica = getValue(DBAgendaRelatorioDicInfo.NomeJustica)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaNome = getValue(DBAgendaRelatorioDicInfo.ParaNome)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaPessoas = getValue(DBAgendaRelatorioDicInfo.ParaPessoas)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do AgendaRelatorio: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AgendaRelatorio: {ex.Message}", ex);
        }
    }
}