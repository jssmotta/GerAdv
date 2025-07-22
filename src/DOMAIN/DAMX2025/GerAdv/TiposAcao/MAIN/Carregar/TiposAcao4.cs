namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTiposAcao
{
    public DBTiposAcao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTiposAcao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TiposAcao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [tacCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TiposAcao
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
m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTiposAcaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBTiposAcaoDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTiposAcaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTiposAcaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTiposAcaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTiposAcaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTiposAcaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTiposAcaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}