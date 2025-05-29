namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNENotas
{
    public DBNENotas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso]))
                m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro]))
                m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida]))
                m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave]))
                m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria]))
                m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada]))
                m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBNENotas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso]))
                m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro]))
                m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida]))
                m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave]))
                m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria]))
                m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada]))
                m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_NENotas
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [nepCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso]))
            m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria]))
            m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro]))
            m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida]))
            m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada]))
            m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave]))
            m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;  } catch {}  try { m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_NENotas
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
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Apenso]))
            m_FApenso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Apenso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Precatoria]))
            m_FPrecatoria = Convert.ToInt32(dbRec[DBNENotasDicInfo.Precatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBNENotasDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro])) m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.MovPro]))
            m_FMovPro = (bool)dbRec[DBNENotasDicInfo.MovPro];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBNENotasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida])) m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.NotaExpedida]))
            m_FNotaExpedida = (bool)dbRec[DBNENotasDicInfo.NotaExpedida];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada])) m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Revisada]))
            m_FRevisada = (bool)dbRec[DBNENotasDicInfo.Revisada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBNENotasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave])) m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.PalavraChave]))
            m_FPalavraChave = Convert.ToInt32(dbRec[DBNENotasDicInfo.PalavraChave]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBNENotasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;  } catch {}  try { m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNotaPublicada = dbRec[DBNENotasDicInfo.NotaPublicada]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNENotasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNENotasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNENotasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNENotasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}