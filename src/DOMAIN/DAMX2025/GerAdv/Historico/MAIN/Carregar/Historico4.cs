namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHistorico
{
    public DBHistorico(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado]))
                m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso]))
                m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID]))
                m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase]))
                m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso]))
                m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem]))
                m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda]))
                m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria]))
                m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido]))
                m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD]))
                m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento]))
                m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBHistorico(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado]))
                m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso]))
                m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID]))
                m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase]))
                m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso]))
                m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem]))
                m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda]))
                m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria]))
                m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido]))
                m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD]))
                m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento]))
                m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Historico
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [hisCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID]))
            m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem]))
            m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria]))
            m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso]))
            m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso]))
            m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase]))
            m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado]))
            m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda]))
            m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD]))
            m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido]))
            m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento]))
            m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Historico
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
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID])) m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.ExtraID]))
            m_FExtraID = Convert.ToInt32(dbRec[DBHistoricoDicInfo.ExtraID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FExtraGUID = dbRec[DBHistoricoDicInfo.ExtraGUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem])) m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.LiminarOrigem]))
            m_FLiminarOrigem = Convert.ToInt32(dbRec[DBHistoricoDicInfo.LiminarOrigem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBHistoricoDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria])) m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Precatoria]))
            m_FPrecatoria = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Precatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso])) m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Apenso]))
            m_FApenso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Apenso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso])) m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.IDInstProcesso]))
            m_FIDInstProcesso = Convert.ToInt32(dbRec[DBHistoricoDicInfo.IDInstProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Fase]))
            m_FFase = Convert.ToInt32(dbRec[DBHistoricoDicInfo.Fase]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBHistoricoDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado])) m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Agendado]))
            m_FAgendado = (bool)dbRec[DBHistoricoDicInfo.Agendado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBHistoricoDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda])) m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.MesmaAgenda]))
            m_FMesmaAgenda = (bool)dbRec[DBHistoricoDicInfo.MesmaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD])) m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.SAD]))
            m_FSAD = Convert.ToInt32(dbRec[DBHistoricoDicInfo.SAD]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido])) m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Resumido]))
            m_FResumido = (bool)dbRec[DBHistoricoDicInfo.Resumido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento])) m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.StatusAndamento]))
            m_FStatusAndamento = Convert.ToInt32(dbRec[DBHistoricoDicInfo.StatusAndamento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top])) m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBHistoricoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBHistoricoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBHistoricoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBHistoricoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBHistoricoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBHistoricoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}