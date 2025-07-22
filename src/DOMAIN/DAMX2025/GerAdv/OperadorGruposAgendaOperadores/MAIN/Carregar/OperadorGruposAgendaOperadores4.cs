namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGruposAgendaOperadores
{
    public DBOperadorGruposAgendaOperadores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]))
                m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperadorGruposAgendaOperadores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]))
                m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OperadorGruposAgendaOperadores
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ogpCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]))
            m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OperadorGruposAgendaOperadores
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
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda])) m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]))
            m_FOperadorGruposAgenda = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorGruposAgendaOperadoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposAgendaOperadoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}