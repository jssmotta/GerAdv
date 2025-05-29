namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSetor
{
    public DBSetor(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBSetor(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Setor
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [setCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Setor
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
m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBSetorDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSetorDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSetorDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSetorDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSetorDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSetorDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}