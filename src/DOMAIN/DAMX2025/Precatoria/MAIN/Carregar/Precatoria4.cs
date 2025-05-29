namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrecatoria
{
    public DBPrecatoria(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist]))
                m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPrecatoria(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist]))
                m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Precatoria
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [preCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist]))
            m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;  } catch {}  try { m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;  } catch {}  try { m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;  } catch {}  try { m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Precatoria
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist])) m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtDist]))
            m_FDtDist = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtDist]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;  } catch {}  try { m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPrecatoria = dbRec[DBPrecatoriaDicInfo.Precatoria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;  } catch {}  try { m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDeprecante = dbRec[DBPrecatoriaDicInfo.Deprecante]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;  } catch {}  try { m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDeprecado = dbRec[DBPrecatoriaDicInfo.Deprecado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBPrecatoriaDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPrecatoriaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPrecatoriaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPrecatoriaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPrecatoriaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrecatoriaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPrecatoriaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}