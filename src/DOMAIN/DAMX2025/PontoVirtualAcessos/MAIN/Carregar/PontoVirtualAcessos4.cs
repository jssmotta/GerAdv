namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtualAcessos
{
    public DBPontoVirtualAcessos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]))
                m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPontoVirtualAcessos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]))
                m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PontoVirtualAcessos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pvaCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]))
            m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;  } catch {}  try { m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PontoVirtualAcessos
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
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualAcessosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]))
            m_FDataHora = Convert.ToDateTime(dbRec[DBPontoVirtualAcessosDicInfo.DataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualAcessosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBPontoVirtualAcessosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;  } catch {}  try { m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOrigem = dbRec[DBPontoVirtualAcessosDicInfo.Origem]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}