namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab
{
    public DBHorasTrab(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario]))
                m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM]))
                m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico]))
                m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status]))
                m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo]))
                m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBHorasTrab(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario]))
                m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM]))
                m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico]))
                m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status]))
                m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo]))
                m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_HorasTrab
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[HorasTrab] (NOLOCK) WHERE [htbCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM]))
            m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario]))
            m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status]))
            m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;  } catch {}  try { m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;  } catch {}  try { m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo]))
            m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico]))
            m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_HorasTrab
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
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM])) m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDContatoCRM]))
            m_FIDContatoCRM = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario])) m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Honorario]))
            m_FHonorario = (bool)dbRec[DBHorasTrabDicInfo.Honorario];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status])) m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Status]))
            m_FStatus = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Status]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;  } catch {}  try { m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHrIni = dbRec[DBHorasTrabDicInfo.HrIni]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;  } catch {}  try { m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHrFim = dbRec[DBHorasTrabDicInfo.HrFim]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Tempo]))
            m_FTempo = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Tempo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBHorasTrabDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBHorasTrabDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexo = dbRec[DBHorasTrabDicInfo.Anexo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexoComp = dbRec[DBHorasTrabDicInfo.AnexoComp]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;  } catch {}  try { m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAnexoUNC = dbRec[DBHorasTrabDicInfo.AnexoUNC]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico])) m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Servico]))
            m_FServico = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.Servico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHorasTrabDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHorasTrabDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHorasTrabDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHorasTrabDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHorasTrabDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}