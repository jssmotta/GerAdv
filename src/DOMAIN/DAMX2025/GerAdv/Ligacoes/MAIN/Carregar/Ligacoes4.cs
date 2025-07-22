namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLigacoes
{
    public DBLigacoes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]))
                m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular]))
                m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada]))
                m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion]))
                m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular]))
                m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal]))
                m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada]))
                m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante]))
                m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen]))
                m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista]))
                m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso]))
                m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBLigacoes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]))
                m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular]))
                m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada]))
                m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion]))
                m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular]))
                m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal]))
                m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada]))
                m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante]))
                m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen]))
                m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista]))
                m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso]))
                m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Ligacoes
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ligCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]))
            m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular]))
            m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada]))
            m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista]))
            m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso]))
            m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante]))
            m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal]))
            m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular]))
            m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada]))
            m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen]))
            m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion]))
            m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Ligacoes
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
m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBLigacoesDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]))
            m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBLigacoesDicInfo.AgeClienteAvisado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular])) m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Celular]))
            m_FCelular = (bool)dbRec[DBLigacoesDicInfo.Celular];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBLigacoesDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada])) m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DataRealizada]))
            m_FDataRealizada = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DataRealizada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista])) m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Telefonista]))
            m_FTelefonista = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Telefonista]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso])) m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.UltimoAviso]))
            m_FUltimoAviso = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.UltimoAviso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBLigacoesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante])) m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Solicitante]))
            m_FSolicitante = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Solicitante]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPara = dbRec[DBLigacoesDicInfo.Para]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBLigacoesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal])) m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Ramal]))
            m_FRamal = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Ramal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular])) m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Particular]))
            m_FParticular = (bool)dbRec[DBLigacoesDicInfo.Particular];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada])) m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Realizada]))
            m_FRealizada = (bool)dbRec[DBLigacoesDicInfo.Realizada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBLigacoesDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBLigacoesDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLigarPara = dbRec[DBLigacoesDicInfo.LigarPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen])) m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.StartScreen]))
            m_FStartScreen = (bool)dbRec[DBLigacoesDicInfo.StartScreen];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Emotion]))
            m_FEmotion = Convert.ToInt32(dbRec[DBLigacoesDicInfo.Emotion]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold])) m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBLigacoesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBLigacoesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLigacoesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLigacoesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLigacoesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLigacoesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}