namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProCDA
{
    public DBProCDA(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProCDA(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProCDA
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pcdCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProCDA
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
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProCDADicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProCDADicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroInterno = dbRec[DBProCDADicInfo.NroInterno]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold])) m_FBold = (bool)dbRec[DBProCDADicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProCDADicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProCDADicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProCDADicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProCDADicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto])) m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProCDADicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProCDADicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}