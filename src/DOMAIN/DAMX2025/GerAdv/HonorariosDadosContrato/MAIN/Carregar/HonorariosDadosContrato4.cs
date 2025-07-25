namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato
{
    public DBHonorariosDadosContrato(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBHonorariosDadosContrato(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do HonorariosDadosContrato: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBHonorariosDadosContratoDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.DataContrato)))
                m_FDataContrato = Convert.ToDateTime(getValue(DBHonorariosDadosContratoDicInfo.DataContrato));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBHonorariosDadosContratoDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBHonorariosDadosContratoDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.Fixo)))
                m_FFixo = Convert.ToBoolean(getValue(DBHonorariosDadosContratoDicInfo.Fixo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.PercSucesso)))
                m_FPercSucesso = Convert.ToDecimal(getValue(DBHonorariosDadosContratoDicInfo.PercSucesso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBHonorariosDadosContratoDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBHonorariosDadosContratoDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBHonorariosDadosContratoDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.ValorFixo)))
                m_FValorFixo = Convert.ToDecimal(getValue(DBHonorariosDadosContratoDicInfo.ValorFixo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.Variavel)))
                m_FVariavel = Convert.ToBoolean(getValue(DBHonorariosDadosContratoDicInfo.Variavel));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBHonorariosDadosContratoDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBHonorariosDadosContratoDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FArquivoContrato = getValue(DBHonorariosDadosContratoDicInfo.ArquivoContrato)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBHonorariosDadosContratoDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = getValue(DBHonorariosDadosContratoDicInfo.Observacao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTextoContrato = getValue(DBHonorariosDadosContratoDicInfo.TextoContrato)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do HonorariosDadosContrato: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do HonorariosDadosContrato: {ex.Message}", ex);
        }
    }
}