namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDivisaoTribunal
{
    public DBDivisaoTribunal(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBDivisaoTribunal(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do DivisaoTribunal: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Area)))
                m_FArea = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.Area));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Bold)))
                m_FBold = Convert.ToBoolean(getValue(DBDivisaoTribunalDicInfo.Bold));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBDivisaoTribunalDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBDivisaoTribunalDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Etiqueta)))
                m_FEtiqueta = Convert.ToBoolean(getValue(DBDivisaoTribunalDicInfo.Etiqueta));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Foro)))
                m_FForo = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.Foro));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Justica)))
                m_FJustica = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.Justica));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.NumCodigo)))
                m_FNumCodigo = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.NumCodigo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Tribunal)))
                m_FTribunal = Convert.ToInt32(getValue(DBDivisaoTribunalDicInfo.Tribunal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBDivisaoTribunalDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBDivisaoTribunalDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FAndar = getValue(DBDivisaoTribunalDicInfo.Andar)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = getValue(DBDivisaoTribunalDicInfo.CEP)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCodigoDiv = getValue(DBDivisaoTribunalDicInfo.CodigoDiv)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = getValue(DBDivisaoTribunalDicInfo.EMail)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = getValue(DBDivisaoTribunalDicInfo.Endereco)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = getValue(DBDivisaoTribunalDicInfo.Fax)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = getValue(DBDivisaoTribunalDicInfo.Fone)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBDivisaoTribunalDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeEspecial = getValue(DBDivisaoTribunalDicInfo.NomeEspecial)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = getValue(DBDivisaoTribunalDicInfo.Obs)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do DivisaoTribunal: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do DivisaoTribunal: {ex.Message}", ex);
        }
    }
}