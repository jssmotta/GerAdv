namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargosEscClass
{
    public DBCargosEscClass(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBCargosEscClass(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_CargosEscClass
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [cecCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_CargosEscClass
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
m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosEscClassDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCargosEscClassDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosEscClassDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosEscClassDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosEscClassDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosEscClassDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}