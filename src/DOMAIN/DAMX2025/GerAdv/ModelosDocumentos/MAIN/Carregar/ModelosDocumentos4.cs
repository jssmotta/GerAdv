namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBModelosDocumentos
{
    public DBModelosDocumentos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]))
                m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBModelosDocumentos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]))
                m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ModelosDocumentos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [mdcCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;  } catch {}  try { m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;  } catch {}  try { m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;  } catch {}  try { m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;  } catch {}  try { m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;  } catch {}  try { m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]))
            m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ModelosDocumentos
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
m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBModelosDocumentosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRemuneracao = dbRec[DBModelosDocumentosDicInfo.Remuneracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssinatura = dbRec[DBModelosDocumentosDicInfo.Assinatura]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;  } catch {}  try { m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHeader = dbRec[DBModelosDocumentosDicInfo.Header]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;  } catch {}  try { m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFooter = dbRec[DBModelosDocumentosDicInfo.Footer]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra1 = dbRec[DBModelosDocumentosDicInfo.Extra1]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra2 = dbRec[DBModelosDocumentosDicInfo.Extra2]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtra3 = dbRec[DBModelosDocumentosDicInfo.Extra3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutorgante = dbRec[DBModelosDocumentosDicInfo.Outorgante]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutorgados = dbRec[DBModelosDocumentosDicInfo.Outorgados]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;  } catch {}  try { m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPoderes = dbRec[DBModelosDocumentosDicInfo.Poderes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBModelosDocumentosDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;  } catch {}  try { m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTitulo = dbRec[DBModelosDocumentosDicInfo.Titulo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;  } catch {}  try { m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTestemunhas = dbRec[DBModelosDocumentosDicInfo.Testemunhas]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento])) m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]))
            m_FTipoModeloDocumento = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.TipoModeloDocumento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCSS = dbRec[DBModelosDocumentosDicInfo.CSS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBModelosDocumentosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBModelosDocumentosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBModelosDocumentosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBModelosDocumentosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBModelosDocumentosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}