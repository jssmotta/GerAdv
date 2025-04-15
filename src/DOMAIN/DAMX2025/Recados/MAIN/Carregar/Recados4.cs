namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRecados
{
    public DBRecados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno]))
                m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK]))
                m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado]))
                m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU]))
                m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion]))
                m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico]))
                m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID]))
                m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM]))
                m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes]))
                m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID]))
                m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza]))
                m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID]))
                m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal]))
                m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar]))
                m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData]))
                m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed]))
                m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded]))
                m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara]))
                m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];
        }
        catch
        {
        }

        try
        {
            m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBRecados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno]))
                m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK]))
                m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado]))
                m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU]))
                m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion]))
                m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico]))
                m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID]))
                m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM]))
                m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes]))
                m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID]))
                m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel]))
                m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza]))
                m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID]))
                m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal]))
                m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar]))
                m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData]))
                m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed]))
                m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded]))
                m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente]))
                m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara]))
                m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];
        }
        catch
        {
        }

        try
        {
            m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Recados
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Recados] (NOLOCK) WHERE [recCodigo] = @ThisIDToLoad", oCnn);
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
m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;  } catch {}  try { m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;  } catch {}  try { m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara]))
            m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal]))
            m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar]))
            m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData]))
            m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion]))
            m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID]))
            m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded]))
            m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza]))
            m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU]))
            m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno]))
            m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK]))
            m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID]))
            m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM]))
            m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID]))
            m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed]))
            m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado]))
            m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico]))
            m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes]))
            m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Recados
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
m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FClienteNome = dbRec[DBRecadosDicInfo.ClienteNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;  } catch {}  try { m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDe = dbRec[DBRecadosDicInfo.De]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPara = dbRec[DBRecadosDicInfo.Para]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssunto = dbRec[DBRecadosDicInfo.Assunto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBRecadosDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBRecadosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBRecadosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;  } catch {}  try { m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRecado = dbRec[DBRecadosDicInfo.Recado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente])) m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Urgente]))
            m_FUrgente = (bool)dbRec[DBRecadosDicInfo.Urgente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante])) m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBRecadosDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara])) m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Voltara]))
            m_FVoltara = (bool)dbRec[DBRecadosDicInfo.Voltara];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Pessoal]))
            m_FPessoal = (bool)dbRec[DBRecadosDicInfo.Pessoal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar])) m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Retornar]))
            m_FRetornar = (bool)dbRec[DBRecadosDicInfo.Retornar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData])) m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.RetornoData]))
            m_FRetornoData = Convert.ToDateTime(dbRec[DBRecadosDicInfo.RetornoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion])) m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Emotion]))
            m_FEmotion = Convert.ToInt32(dbRec[DBRecadosDicInfo.Emotion]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID])) m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.InternetID]))
            m_FInternetID = Convert.ToInt32(dbRec[DBRecadosDicInfo.InternetID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded])) m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Uploaded]))
            m_FUploaded = (bool)dbRec[DBRecadosDicInfo.Uploaded];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza])) m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Natureza]))
            m_FNatureza = Convert.ToInt32(dbRec[DBRecadosDicInfo.Natureza]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU])) m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.BIU]))
            m_FBIU = (bool)dbRec[DBRecadosDicInfo.BIU];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno])) m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetorno]))
            m_FAguardarRetorno = (bool)dbRec[DBRecadosDicInfo.AguardarRetorno];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAguardarRetornoPara = dbRec[DBRecadosDicInfo.AguardarRetornoPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK])) m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AguardarRetornoOK]))
            m_FAguardarRetornoOK = (bool)dbRec[DBRecadosDicInfo.AguardarRetornoOK];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID])) m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ParaID]))
            m_FParaID = Convert.ToInt32(dbRec[DBRecadosDicInfo.ParaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel])) m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.NaoPublicavel]))
            m_FNaoPublicavel = (bool)dbRec[DBRecadosDicInfo.NaoPublicavel];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM])) m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.IsContatoCRM]))
            m_FIsContatoCRM = (bool)dbRec[DBRecadosDicInfo.IsContatoCRM];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID])) m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.MasterID]))
            m_FMasterID = Convert.ToInt32(dbRec[DBRecadosDicInfo.MasterID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;  } catch {}  try { m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty; } catch { }

#else
        m_FListaPara = dbRec[DBRecadosDicInfo.ListaPara]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed])) m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Typed]))
            m_FTyped = (bool)dbRec[DBRecadosDicInfo.Typed];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado])) m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.AssuntoRecado]))
            m_FAssuntoRecado = Convert.ToInt32(dbRec[DBRecadosDicInfo.AssuntoRecado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico])) m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Historico]))
            m_FHistorico = Convert.ToInt32(dbRec[DBRecadosDicInfo.Historico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBRecadosDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes])) m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Ligacoes]))
            m_FLigacoes = Convert.ToInt32(dbRec[DBRecadosDicInfo.Ligacoes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBRecadosDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRecadosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRecadosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRecadosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRecadosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRecadosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}