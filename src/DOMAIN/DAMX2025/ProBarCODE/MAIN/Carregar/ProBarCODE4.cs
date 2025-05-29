namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProBarCODE
{
    public DBProBarCODE(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProBarCODE(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProBarCODE
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;  } catch {}  try { m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProBarCODE
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;  } catch {}  try { m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBarCODE = dbRec[DBProBarCODEDicInfo.BarCODE]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProBarCODEDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProBarCODEDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProBarCODEDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProBarCODEDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}