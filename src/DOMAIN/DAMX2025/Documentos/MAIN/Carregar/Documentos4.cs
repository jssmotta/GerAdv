namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocumentos
{
    public DBDocumentos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBDocumentos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Documentos
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Documentos] (NOLOCK) WHERE [docCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Documentos
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
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBDocumentosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBDocumentosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDocumentosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDocumentosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocumentosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDocumentosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}