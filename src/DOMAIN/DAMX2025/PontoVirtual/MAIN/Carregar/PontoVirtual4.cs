namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtual
{
    public DBPontoVirtual(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada]))
                m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida]))
                m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPontoVirtual(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada]))
                m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida]))
                m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PontoVirtual
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pvtCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada]))
            m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida]))
            m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;  } catch {}  try { m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; } catch { }

#else
        m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PontoVirtual
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada])) m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraEntrada]))
            m_FHoraEntrada = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraEntrada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.HoraSaida]))
            m_FHoraSaida = Convert.ToDateTime(dbRec[DBPontoVirtualDicInfo.HoraSaida]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPontoVirtualDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBPontoVirtualDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;  } catch {}  try { m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty; } catch { }

#else
        m_FKey = dbRec[DBPontoVirtualDicInfo.Key]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}