namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProObservacoes
{
    public DBProObservacoes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProObservacoes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProObservacoes
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ProObservacoes] (NOLOCK) WHERE [pobCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProObservacoes
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
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProObservacoesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBProObservacoesDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProObservacoesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProObservacoesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProObservacoesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProObservacoesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProObservacoesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}