namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertasEnviados
{
    public DBAlertasEnviados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta]))
                m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]))
                m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado]))
                m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];
        }
        catch
        {
        }
    }

    public DBAlertasEnviados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta]))
                m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]))
                m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado]))
                m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];
        }
        catch
        {
        }
    }

#region CarregarDados_AlertasEnviados
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [aloCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta]))
            m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]))
            m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado]))
            m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AlertasEnviados
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
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta])) m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Alerta]))
            m_FAlerta = Convert.ToInt32(dbRec[DBAlertasEnviadosDicInfo.Alerta]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado])) m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]))
            m_FDataAlertado = Convert.ToDateTime(dbRec[DBAlertasEnviadosDicInfo.DataAlertado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado])) m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasEnviadosDicInfo.Visualizado]))
            m_FVisualizado = (bool)dbRec[DBAlertasEnviadosDicInfo.Visualizado];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}