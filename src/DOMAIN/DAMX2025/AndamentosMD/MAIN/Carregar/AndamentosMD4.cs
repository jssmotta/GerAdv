namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndamentosMD
{
    public DBAndamentosMD(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento]))
                m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAndamentosMD(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento]))
                m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AndamentosMD
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[AndamentosMD] (NOLOCK) WHERE [amdCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento]))
            m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;  } catch {}  try { m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;  } catch {}  try { m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; } catch { }

#else
        m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AndamentosMD
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
m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAndamentosMDDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento])) m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Andamento]))
            m_FAndamento = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.Andamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;  } catch {}  try { m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPathFull = dbRec[DBAndamentosMDDicInfo.PathFull]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;  } catch {}  try { m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty; } catch { }

#else
        m_FUNC = dbRec[DBAndamentosMDDicInfo.UNC]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAndamentosMDDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAndamentosMDDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAndamentosMDDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAndamentosMDDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAndamentosMDDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}