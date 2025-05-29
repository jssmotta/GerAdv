namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputRequest
{
    public DBProcessOutputRequest(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]))
                m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]))
                m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProcessOutputRequest(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]))
                m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]))
                m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProcessOutputRequest
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [porCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]))
            m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]))
            m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProcessOutputRequest
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
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine])) m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]))
            m_FProcessOutputEngine = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.ProcessOutputEngine]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo])) m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]))
            m_FUltimoIdTabelaExo = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.UltimoIdTabelaExo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessOutputRequestDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessOutputRequestDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessOutputRequestDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputRequestDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessOutputRequestDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}