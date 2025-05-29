namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncao
{
    public DBFuncao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBFuncao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Funcao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [funCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Funcao
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
m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBFuncaoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFuncaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}