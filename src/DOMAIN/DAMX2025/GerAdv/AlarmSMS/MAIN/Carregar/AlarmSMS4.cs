namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlarmSMS
{
    public DBAlarmSMS(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]))
                m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1]))
                m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2]))
                m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3]))
                m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4]))
                m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5]))
                m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6]))
                m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7]))
                m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar]))
                m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop]))
                m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao]))
                m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]))
                m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora]))
                m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto]))
                m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado]))
                m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today]))
                m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAlarmSMS(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]))
                m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1]))
                m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2]))
                m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3]))
                m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4]))
                m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5]))
                m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6]))
                m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7]))
                m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar]))
                m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop]))
                m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao]))
                m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]))
                m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora]))
                m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto]))
                m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado]))
                m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today]))
                m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AlarmSMS
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [alrCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora]))
            m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto]))
            m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1]))
            m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2]))
            m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3]))
            m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4]))
            m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5]))
            m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6]))
            m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7]))
            m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar]))
            m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today]))
            m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]))
            m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop]))
            m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]))
            m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;  } catch {}  try { m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado]))
            m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao]))
            m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AlarmSMS
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
m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAlarmSMSDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora])) m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Hora]))
            m_FHora = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto])) m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Minuto]))
            m_FMinuto = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Minuto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1])) m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D1]))
            m_FD1 = (bool)dbRec[DBAlarmSMSDicInfo.D1];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2])) m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D2]))
            m_FD2 = (bool)dbRec[DBAlarmSMSDicInfo.D2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3])) m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D3]))
            m_FD3 = (bool)dbRec[DBAlarmSMSDicInfo.D3];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4])) m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D4]))
            m_FD4 = (bool)dbRec[DBAlarmSMSDicInfo.D4];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5])) m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D5]))
            m_FD5 = (bool)dbRec[DBAlarmSMSDicInfo.D5];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6])) m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D6]))
            m_FD6 = (bool)dbRec[DBAlarmSMSDicInfo.D6];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7])) m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.D7]))
            m_FD7 = (bool)dbRec[DBAlarmSMSDicInfo.D7];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBAlarmSMSDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar])) m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desativar]))
            m_FDesativar = (bool)dbRec[DBAlarmSMSDicInfo.Desativar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today])) m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Today]))
            m_FToday = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.Today]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes])) m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes]))
            m_FExcetoDiasFelizes = (bool)dbRec[DBAlarmSMSDicInfo.ExcetoDiasFelizes];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop])) m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Desktop]))
            m_FDesktop = (bool)dbRec[DBAlarmSMSDicInfo.Desktop];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora])) m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]))
            m_FAlertarDataHora = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.AlertarDataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;  } catch {}  try { m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGuidExo = dbRec[DBAlarmSMSDicInfo.GuidExo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado])) m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Recado]))
            m_FRecado = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Recado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Emocao]))
            m_FEmocao = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.Emocao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAlarmSMSDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAlarmSMSDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAlarmSMSDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlarmSMSDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAlarmSMSDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}