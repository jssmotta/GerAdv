namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetir
{
    public DBAgendaRepetir(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal]))
                m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo]))
                m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia]))
                m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1]))
                m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2]))
                m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3]))
                m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4]))
                m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem]))
                m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2]))
                m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo]))
                m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes]))
                m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal]))
                m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta]))
                m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta]))
                m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado]))
                m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda]))
                m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta]))
                m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca]))
                m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAgendaRepetir(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal]))
                m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia]))
                m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo]))
                m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia]))
                m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1]))
                m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2]))
                m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3]))
                m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4]))
                m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem]))
                m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2]))
                m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo]))
                m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes]))
                m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal]))
                m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta]))
                m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta]))
                m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado]))
                m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda]))
                m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta]))
                m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca]))
                m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaRepetir
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [rptCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal]))
            m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal]))
            m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia]))
            m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes]))
            m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem]))
            m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2]))
            m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;  } catch {}  try { m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo]))
            m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1]))
            m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2]))
            m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3]))
            m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4]))
            m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda]))
            m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta]))
            m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta]))
            m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta]))
            m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado]))
            m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo]))
            m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca]))
            m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaRepetir
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
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal])) m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DataFinal]))
            m_FDataFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DataFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal])) m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.HoraFinal]))
            m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.HoraFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal])) m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Pessoal]))
            m_FPessoal = (bool)dbRec[DBAgendaRepetirDicInfo.Pessoal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia])) m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Frequencia]))
            m_FFrequencia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Frequencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia])) m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Dia]))
            m_FDia = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Dia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes])) m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Mes]))
            m_FMes = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.Mes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem])) m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem]))
            m_FIDQuem = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2])) m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDQuem2]))
            m_FIDQuem2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDQuem2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;  } catch {}  try { m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMensagem = dbRec[DBAgendaRepetirDicInfo.Mensagem]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo])) m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.IDTipo]))
            m_FIDTipo = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.IDTipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1])) m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID1]))
            m_FID1 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID1]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2])) m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID2]))
            m_FID2 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID2]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3])) m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID3]))
            m_FID3 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4])) m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.ID4]))
            m_FID4 = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.ID4]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda])) m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Segunda]))
            m_FSegunda = (bool)dbRec[DBAgendaRepetirDicInfo.Segunda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta])) m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quarta]))
            m_FQuarta = (bool)dbRec[DBAgendaRepetirDicInfo.Quarta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta])) m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Quinta]))
            m_FQuinta = (bool)dbRec[DBAgendaRepetirDicInfo.Quinta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta])) m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sexta]))
            m_FSexta = (bool)dbRec[DBAgendaRepetirDicInfo.Sexta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado])) m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Sabado]))
            m_FSabado = (bool)dbRec[DBAgendaRepetirDicInfo.Sabado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo])) m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Domingo]))
            m_FDomingo = (bool)dbRec[DBAgendaRepetirDicInfo.Domingo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca])) m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Terca]))
            m_FTerca = (bool)dbRec[DBAgendaRepetirDicInfo.Terca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaRepetirDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaRepetirDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaRepetirDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaRepetirDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}