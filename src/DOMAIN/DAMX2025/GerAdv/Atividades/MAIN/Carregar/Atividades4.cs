namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAtividades
{
    public DBAtividades(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAtividades(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Atividades
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [atvCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Atividades
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
m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAtividadesDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAtividadesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAtividadesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAtividadesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAtividadesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}