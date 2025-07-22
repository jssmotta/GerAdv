namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividadesMatriz
{
    public DBGUTAtividadesMatriz(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]))
                m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]))
                m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTAtividadesMatriz(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]))
                m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]))
                m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTAtividadesMatriz
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [amgCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]))
            m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]))
            m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTAtividadesMatriz
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
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz])) m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]))
            m_FGUTMatriz = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTMatriz]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade])) m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]))
            m_FGUTAtividade = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.GUTAtividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTAtividadesMatrizDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesMatrizDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesMatrizDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesMatrizDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTAtividadesMatrizDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}