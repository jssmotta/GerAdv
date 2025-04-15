namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAnexamentoRegistros
{
    public DBAnexamentoRegistros(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]))
                m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]))
                m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAnexamentoRegistros(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]))
                m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]))
                m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AnexamentoRegistros
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[AnexamentoRegistros] (NOLOCK) WHERE [axrCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]))
            m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]))
            m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AnexamentoRegistros
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
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUIDReg = dbRec[DBAnexamentoRegistrosDicInfo.GUIDReg]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg])) m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]))
            m_FCodigoReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.CodigoReg]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg])) m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]))
            m_FIDReg = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.IDReg]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAnexamentoRegistrosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAnexamentoRegistrosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAnexamentoRegistrosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAnexamentoRegistrosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAnexamentoRegistrosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}