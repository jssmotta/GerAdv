namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGrupos
{
    public DBOperadorGrupos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperadorGrupos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OperadorGrupos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [opgCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OperadorGrupos
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
m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorGruposDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGruposDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGruposDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGruposDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGruposDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}