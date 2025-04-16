namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRegimeTributacao
{
    public DBRegimeTributacao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBRegimeTributacao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_RegimeTributacao
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[RegimeTributacao] (NOLOCK) WHERE [rdtCodigo] = @ThisIDToLoad", oCnn);
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
// region JMen - nType = 203
m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_RegimeTributacao
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
// region JMen - nType = 203
m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBRegimeTributacaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRegimeTributacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRegimeTributacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRegimeTributacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRegimeTributacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRegimeTributacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}