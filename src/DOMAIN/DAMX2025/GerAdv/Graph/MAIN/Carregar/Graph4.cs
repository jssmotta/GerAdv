namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGraph
{
    public DBGraph(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem]))
                m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId]))
                m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGraph(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem]))
                m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId]))
                m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Graph
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [gphCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId]))
            m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 1000
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem]))
            m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Graph
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
m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTabela = dbRec[DBGraphDicInfo.Tabela]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId])) m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.TabelaId]))
            m_FTabelaId = Convert.ToInt32(dbRec[DBGraphDicInfo.TabelaId]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 1000
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem])) m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Imagem]))
            m_FImagem = dbRec[DBGraphDicInfo.Imagem] as byte[] ?? [0];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGraphDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGraphDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGraphDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGraphDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGraphDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}