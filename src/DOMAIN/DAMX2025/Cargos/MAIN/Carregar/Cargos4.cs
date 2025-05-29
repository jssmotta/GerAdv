namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargos
{
    public DBCargos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBCargos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Cargos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [carCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Cargos
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
m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCargosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCargosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCargosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCargosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCargosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}