namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetirDias
{
    public DBAgendaRepetirDias(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);
        }
        catch
        {
        }
    }

    public DBAgendaRepetirDias(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaRepetirDias
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [rpdCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaRepetirDias
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDiasDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDiasDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDiasDicInfo.Hora]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}