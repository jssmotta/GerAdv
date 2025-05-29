namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNECompromissos
{
    public DBNECompromissos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave]))
                m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar]))
                m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBNECompromissos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave]))
                m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar]))
                m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_NECompromissos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ncpCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave]))
            m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar]))
            m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_NECompromissos
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
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.PalavraChave]))
            m_FPalavraChave = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.PalavraChave]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar])) m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Provisionar]))
            m_FProvisionar = (bool)dbRec[DBNECompromissosDicInfo.Provisionar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoCompromisso = dbRec[DBNECompromissosDicInfo.TextoCompromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold])) m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBNECompromissosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNECompromissosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNECompromissosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNECompromissosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNECompromissosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}