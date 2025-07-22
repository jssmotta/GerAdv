namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoCompromisso
{
    public DBTipoCompromisso(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro]))
                m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTipoCompromisso(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro]))
                m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone]))
                m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TipoCompromisso
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [tipCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro]))
            m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TipoCompromisso
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
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone])) m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Icone]))
            m_FIcone = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.Icone]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTipoCompromissoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro])) m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Financeiro]))
            m_FFinanceiro = (bool)dbRec[DBTipoCompromissoDicInfo.Financeiro];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTipoCompromissoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoCompromissoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoCompromissoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoCompromissoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoCompromissoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoCompromissoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}