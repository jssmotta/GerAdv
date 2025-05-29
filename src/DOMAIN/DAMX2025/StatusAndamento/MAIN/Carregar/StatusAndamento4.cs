namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusAndamento
{
    public DBStatusAndamento(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBStatusAndamento(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_StatusAndamento
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [sanCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_StatusAndamento
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
m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusAndamentoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.Icone]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBStatusAndamentoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusAndamentoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusAndamentoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusAndamentoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusAndamentoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusAndamentoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}