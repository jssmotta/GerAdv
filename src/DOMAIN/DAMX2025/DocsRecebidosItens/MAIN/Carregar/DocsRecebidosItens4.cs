namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocsRecebidosItens
{
    public DBDocsRecebidosItens(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido]))
                m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]))
                m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBDocsRecebidosItens(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido]))
                m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]))
                m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_DocsRecebidosItens
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [driCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido]))
            m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]))
            m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_DocsRecebidosItens
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
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBDocsRecebidosItensDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido])) m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Devolvido]))
            m_FDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.Devolvido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido])) m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido]))
            m_FSeraDevolvido = (bool)dbRec[DBDocsRecebidosItensDicInfo.SeraDevolvido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBDocsRecebidosItensDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold])) m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDocsRecebidosItensDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDocsRecebidosItensDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDocsRecebidosItensDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDocsRecebidosItensDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDocsRecebidosItensDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDocsRecebidosItensDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}