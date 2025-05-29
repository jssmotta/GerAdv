namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniao
{
    public DBReuniao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa]))
                m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial]))
                m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno]))
                m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida]))
                m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBReuniao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa]))
                m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial]))
                m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno]))
                m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida]))
                m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Reuniao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [renCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;  } catch {}  try { m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; } catch { }

#else
        m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial]))
            m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa]))
            m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida]))
            m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno]))
            m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Reuniao
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
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBReuniaoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBReuniaoDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPauta = dbRec[DBReuniaoDicInfo.Pauta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;  } catch {}  try { m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty; } catch { }

#else
        m_FATA = dbRec[DBReuniaoDicInfo.ATA]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraInicial]))
            m_FHoraInicial = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa])) m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Externa]))
            m_FExterna = (bool)dbRec[DBReuniaoDicInfo.Externa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida])) m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraSaida]))
            m_FHoraSaida = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraSaida]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno])) m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.HoraRetorno]))
            m_FHoraRetorno = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.HoraRetorno]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;  } catch {}  try { m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPrincipaisDecisoes = dbRec[DBReuniaoDicInfo.PrincipaisDecisoes]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBReuniaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBReuniaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBReuniaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}