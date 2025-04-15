namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBForo
{
    public DBForo(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBForoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico]))
                m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado]))
                m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBForo(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBForoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico]))
                m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado]))
                m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Foro
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Foro] (NOLOCK) WHERE [forCodigo] = @ThisIDToLoad", oCnn);
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
m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico]))
            m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado]))
            m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; } catch { }

#else
        m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBForoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Foro
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
m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBForoDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBForoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico])) m_FUnico = (bool)dbRec[DBForoDicInfo.Unico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Unico]))
            m_FUnico = (bool)dbRec[DBForoDicInfo.Unico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBForoDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBForoDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBForoDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBForoDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBForoDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBForoDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBForoDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBForoDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado])) m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.UnicoConfirmado]))
            m_FUnicoConfirmado = (bool)dbRec[DBForoDicInfo.UnicoConfirmado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty; } catch { }

#else
        m_FWeb = dbRec[DBForoDicInfo.Web]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBForoDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold])) m_FBold = (bool)dbRec[DBForoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBForoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBForoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBForoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBForoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBForoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBForoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBForoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBForoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}