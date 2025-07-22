namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhora
{
    public DBPenhora(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora]))
                m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus]))
                m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPenhora(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora]))
                m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus]))
                m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Penhora
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [phrCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora]))
            m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus]))
            m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Penhora
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
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPenhoraDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBPenhoraDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora])) m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DataPenhora]))
            m_FDataPenhora = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DataPenhora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus])) m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.PenhoraStatus]))
            m_FPenhoraStatus = Convert.ToInt32(dbRec[DBPenhoraDicInfo.PenhoraStatus]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBPenhoraDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPenhoraDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPenhoraDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}