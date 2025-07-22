namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTPeriodicidadeStatus
{
    public DBGUTPeriodicidadeStatus(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]))
                m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]))
                m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTPeriodicidadeStatus(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]))
                m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]))
                m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTPeriodicidadeStatus
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pgsCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]))
            m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]))
            m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTPeriodicidadeStatus
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
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]))
            m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.GUTAtividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado])) m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]))
            m_FDataRealizado = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DataRealizado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTPeriodicidadeStatusDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTPeriodicidadeStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTPeriodicidadeStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTPeriodicidadeStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}