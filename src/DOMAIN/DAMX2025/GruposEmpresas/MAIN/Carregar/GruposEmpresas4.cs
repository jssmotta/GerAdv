namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresas
{
    public DBGruposEmpresas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]))
                m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGruposEmpresas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]))
                m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GruposEmpresas
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[GruposEmpresas] (NOLOCK) WHERE [grpCodigo] = @ThisIDToLoad", oCnn);
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
m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]))
            m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GruposEmpresas
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
m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBGruposEmpresasDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBGruposEmpresasDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBGruposEmpresasDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacoes = dbRec[DBGruposEmpresasDicInfo.Observacoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIcone = dbRec[DBGruposEmpresasDicInfo.Icone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada])) m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DespesaUnificada]))
            m_FDespesaUnificada = (bool)dbRec[DBGruposEmpresasDicInfo.DespesaUnificada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGruposEmpresasDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGruposEmpresasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}