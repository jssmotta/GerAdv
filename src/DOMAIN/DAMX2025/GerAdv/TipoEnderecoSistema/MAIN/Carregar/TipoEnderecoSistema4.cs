namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoEnderecoSistema
{
    public DBTipoEnderecoSistema(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTipoEnderecoSistema(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TipoEnderecoSistema
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [tesCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TipoEnderecoSistema
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
m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTipoEnderecoSistemaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoEnderecoSistemaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoEnderecoSistemaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoEnderecoSistemaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoEnderecoSistemaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}