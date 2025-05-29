namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProProcuradores
{
    public DBProProcuradores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao]))
                m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento]))
                m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProProcuradores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao]))
                m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento]))
                m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProProcuradores
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [papCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento]))
            m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao]))
            m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProProcuradores
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
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProProcuradoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento])) m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Substabelecimento]))
            m_FSubstabelecimento = (bool)dbRec[DBProProcuradoresDicInfo.Substabelecimento];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao])) m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Procuracao]))
            m_FProcuracao = (bool)dbRec[DBProProcuradoresDicInfo.Procuracao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProProcuradoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProProcuradoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProProcuradoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProProcuradoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProProcuradoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProProcuradoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}