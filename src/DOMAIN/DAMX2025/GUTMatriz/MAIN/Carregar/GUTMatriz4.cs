namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTMatriz
{
    public DBGUTMatriz(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo]))
                m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor]))
                m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTMatriz(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo]))
                m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor]))
                m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTMatriz
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [gutCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo]))
            m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor]))
            m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTMatriz
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
m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBGUTMatrizDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo])) m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.GUTTipo]))
            m_FGUTTipo = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.GUTTipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor])) m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTMatrizDicInfo.Valor]))
            m_FValor = Convert.ToInt32(dbRec[DBGUTMatrizDicInfo.Valor]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}