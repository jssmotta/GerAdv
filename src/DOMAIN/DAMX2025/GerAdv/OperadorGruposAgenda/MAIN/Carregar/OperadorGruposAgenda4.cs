namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGruposAgenda
{
    public DBOperadorGruposAgenda(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperadorGruposAgenda(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OperadorGruposAgenda
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [groCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;  } catch {}  try { m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OperadorGruposAgenda
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
m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;  } catch {}  try { m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSQLWhere = dbRec[DBOperadorGruposAgendaDicInfo.SQLWhere]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorGruposAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorGruposAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}