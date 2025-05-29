namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividades
{
    public DBGUTAtividades(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido]))
                m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]))
                m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]))
                m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]))
                m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]))
                m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBGUTAtividades(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido]))
                m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]))
                m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]))
                m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]))
                m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]))
                m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_GUTAtividades
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [agtCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]))
            m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]))
            m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido]))
            m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]))
            m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]))
            m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GUTAtividades
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
m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBGUTAtividadesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBGUTAtividadesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo])) m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]))
            m_FGUTGrupo = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTGrupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade])) m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]))
            m_FGUTPeriodicidade = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.GUTPeriodicidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBGUTAtividadesDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido])) m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DataConcluido]))
            m_FDataConcluido = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DataConcluido]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar])) m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]))
            m_FDiasParaIniciar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.DiasParaIniciar]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar])) m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]))
            m_FMinutosParaRealizar = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.MinutosParaRealizar]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBGUTAtividadesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGUTAtividadesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGUTAtividadesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGUTAtividadesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGUTAtividadesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}