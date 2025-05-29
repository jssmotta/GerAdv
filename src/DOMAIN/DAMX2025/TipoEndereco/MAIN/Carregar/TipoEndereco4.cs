namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoEndereco
{
    public DBTipoEndereco(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTipoEndereco(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TipoEndereco
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [tipCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TipoEndereco
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
m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoEnderecoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoEnderecoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoEnderecoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}