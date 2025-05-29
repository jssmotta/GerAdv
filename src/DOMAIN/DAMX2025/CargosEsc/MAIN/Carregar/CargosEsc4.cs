namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargosEsc
{
    public DBCargosEsc(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao]))
                m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual]))
                m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBCargosEsc(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao]))
                m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual]))
                m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_CargosEsc
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [cgeCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual]))
            m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao]))
            m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_CargosEsc
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual])) m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Percentual]))
            m_FPercentual = Convert.ToDecimal(dbRec[DBCargosEscDicInfo.Percentual]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosEscDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao])) m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Classificacao]))
            m_FClassificacao = Convert.ToInt32(dbRec[DBCargosEscDicInfo.Classificacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCargosEscDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosEscDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}