namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRamal
{
    public DBRamal(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBRamal(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Ramal
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Ramal] (NOLOCK) WHERE [ramCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Ramal
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
m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBRamalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBRamalDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRamalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRamalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRamalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRamalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}