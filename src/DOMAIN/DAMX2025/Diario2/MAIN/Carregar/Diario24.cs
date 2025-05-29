namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDiario2
{
    public DBDiario2(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBDiario2(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Diario2
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [diaCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;  } catch {}  try { m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Diario2
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBDiario2DicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBDiario2DicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBDiario2DicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;  } catch {}  try { m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOcorrencia = dbRec[DBDiario2DicInfo.Ocorrencia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBDiario2DicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold])) m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDiario2DicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDiario2DicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDiario2DicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDiario2DicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDiario2DicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDiario2DicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}