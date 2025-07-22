namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCidade
{
    public DBCidade(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital]))
                m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca]))
                m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top]))
                m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF]))
                m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBCidade(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital]))
                m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca]))
                m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top]))
                m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF]))
                m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Cidade
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [cidCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top]))
            m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca]))
            m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital]))
            m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF]))
            m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Cidade
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
m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDDD = dbRec[DBCidadeDicInfo.DDD]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top])) m_FTop = (bool)dbRec[DBCidadeDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Top]))
            m_FTop = (bool)dbRec[DBCidadeDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca])) m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Comarca]))
            m_FComarca = (bool)dbRec[DBCidadeDicInfo.Comarca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital])) m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Capital]))
            m_FCapital = (bool)dbRec[DBCidadeDicInfo.Capital];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBCidadeDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF])) m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.UF]))
            m_FUF = Convert.ToInt32(dbRec[DBCidadeDicInfo.UF]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSigla = dbRec[DBCidadeDicInfo.Sigla]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBCidadeDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBCidadeDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBCidadeDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto])) m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBCidadeDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBCidadeDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}