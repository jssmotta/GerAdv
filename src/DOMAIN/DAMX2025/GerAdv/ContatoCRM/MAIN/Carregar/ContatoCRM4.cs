namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRM
{
    public DBContatoCRM(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]))
                m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar]))
                m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou]))
                m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]))
                m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao]))
                m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo]))
                m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]))
                m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial]))
                m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou]))
                m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]))
                m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar]))
                m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]))
                m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar]))
                m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou]))
                m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo]))
                m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]))
                m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBContatoCRM(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]))
                m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar]))
                m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou]))
                m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]))
                m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao]))
                m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo]))
                m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]))
                m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial]))
                m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou]))
                m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]))
                m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar]))
                m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]))
                m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar]))
                m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou]))
                m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo]))
                m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]))
                m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ContatoCRM
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ctcCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]))
            m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]))
            m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar]))
            m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar]))
            m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]))
            m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou]))
            m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou]))
            m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou]))
            m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]))
            m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo]))
            m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial]))
            m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]))
            m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo]))
            m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]))
            m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao]))
            m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar]))
            m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ContatoCRM
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
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado])) m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]))
            m_FAgeClienteAvisado = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.AgeClienteAvisado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento])) m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]))
            m_FDocsViaRecebimento = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.DocsViaRecebimento]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBContatoCRMDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar])) m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Notificar]))
            m_FNotificar = (bool)dbRec[DBContatoCRMDicInfo.Notificar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar])) m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Ocultar]))
            m_FOcultar = (bool)dbRec[DBContatoCRMDicInfo.Ocultar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBContatoCRMDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos])) m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.IsDocsRecebidos]))
            m_FIsDocsRecebidos = (bool)dbRec[DBContatoCRMDicInfo.IsDocsRecebidos];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou])) m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemNotificou]))
            m_FQuemNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou])) m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DataNotificou]))
            m_FDataNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DataNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou])) m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraNotificou]))
            m_FHoraNotificou = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou])) m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]))
            m_FObjetoNotificou = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.ObjetoNotificou]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoaContato = dbRec[DBContatoCRMDicInfo.PessoaContato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo])) m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Tempo]))
            m_FTempo = Convert.ToDecimal(dbRec[DBContatoCRMDicInfo.Tempo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial])) m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraInicial]))
            m_FHoraInicial = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante])) m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBContatoCRMDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBContatoCRMDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada])) m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada]))
            m_FGerarHoraTrabalhada = (bool)dbRec[DBContatoCRMDicInfo.GerarHoraTrabalhada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo])) m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.ExibirNoTopo]))
            m_FExibirNoTopo = (bool)dbRec[DBContatoCRMDicInfo.ExibirNoTopo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM])) m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]))
            m_FTipoContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.TipoContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBContatoCRMDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao])) m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Emocao]))
            m_FEmocao = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.Emocao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar])) m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Continuar]))
            m_FContinuar = (bool)dbRec[DBContatoCRMDicInfo.Continuar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBContatoCRMDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContatoCRMDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}