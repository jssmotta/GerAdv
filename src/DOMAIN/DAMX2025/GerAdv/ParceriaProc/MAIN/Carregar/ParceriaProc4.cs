namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParceriaProc
{
    public DBParceriaProc(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBParceriaProc(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ParceriaProc
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [parCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ParceriaProc
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
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBParceriaProcDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBParceriaProcDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBParceriaProcDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParceriaProcDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBParceriaProcDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}