namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBServicos
{
    public DBServicos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar]))
                m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBServicos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar]))
                m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Servicos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [serCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar]))
            m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico]))
            m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Servicos
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar])) m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Cobrar]))
            m_FCobrar = (bool)dbRec[DBServicosDicInfo.Cobrar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBServicosDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico])) m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Basico]))
            m_FBasico = (bool)dbRec[DBServicosDicInfo.Basico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBServicosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBServicosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBServicosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBServicosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBServicosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}