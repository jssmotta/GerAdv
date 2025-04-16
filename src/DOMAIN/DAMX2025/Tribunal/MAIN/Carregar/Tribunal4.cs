namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribunal
{
    public DBTribunal(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTribunal(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Tribunal
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Tribunal] (NOLOCK) WHERE [triCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; } catch { }

#else
        m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Tribunal
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
m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTribunalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBTribunalDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBTribunalDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBTribunalDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBTribunalDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSigla = dbRec[DBTribunalDicInfo.Sigla]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty; } catch { }

#else
        m_FWeb = dbRec[DBTribunalDicInfo.Web]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBTribunalDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTribunalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTribunalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTribunalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribunalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTribunalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}