namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSMSAlice
{
    public DBSMSAlice(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail]))
                m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBSMSAlice(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail]))
                m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_SMSAlice
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [smaCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail]))
            m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_SMSAlice
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
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBSMSAliceDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail])) m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.TipoEMail]))
            m_FTipoEMail = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.TipoEMail]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSMSAliceDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSMSAliceDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSMSAliceDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSMSAliceDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSMSAliceDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}