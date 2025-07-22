namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRecords
{
    public DBAgendaRecords(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1]))
                m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2]))
                m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3]))
                m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]))
                m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador]))
                m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]))
                m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]))
                m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]))
                m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1]))
                m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2]))
                m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3]))
                m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador]))
                m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito]))
                m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);
        }
        catch
        {
        }
    }

    public DBAgendaRecords(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1]))
                m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2]))
                m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3]))
                m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]))
                m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador]))
                m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]))
                m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]))
                m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]))
                m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1]))
                m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2]))
                m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3]))
                m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador]))
                m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito]))
                m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaRecords
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ragCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador]))
            m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]))
            m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito]))
            m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador]))
            m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1]))
            m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2]))
            m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3]))
            m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]))
            m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]))
            m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]))
            m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1]))
            m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2]))
            m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3]))
            m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaRecords
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Julgador]))
            m_FJulgador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Julgador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios])) m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]))
            m_FClientesSocios = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.ClientesSocios]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito])) m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Perito]))
            m_FPerito = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Perito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador])) m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Colaborador]))
            m_FColaborador = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Colaborador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1])) m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso1]))
            m_FAviso1 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso1];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2])) m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso2]))
            m_FAviso2 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3])) m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.Aviso3]))
            m_FAviso3 = (bool)dbRec[DBAgendaRecordsDicInfo.Aviso3];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1])) m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]))
            m_FCrmAviso1 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2])) m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]))
            m_FCrmAviso2 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3])) m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]))
            m_FCrmAviso3 = Convert.ToInt32(dbRec[DBAgendaRecordsDicInfo.CrmAviso3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1])) m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso1]))
            m_FDataAviso1 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2])) m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso2]))
            m_FDataAviso2 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3])) m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRecordsDicInfo.DataAviso3]))
            m_FDataAviso3 = Convert.ToDateTime(dbRec[DBAgendaRecordsDicInfo.DataAviso3]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}