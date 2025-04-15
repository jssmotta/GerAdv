namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBInstancia
{
    public DBInstancia(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao]))
                m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca]))
                m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao]))
                m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso]))
                m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador]))
                m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente]))
                m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida]))
                m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada]))
                m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial]))
                m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente]))
                m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal]))
                m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado]))
                m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao]))
                m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso]))
                m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando]))
                m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem]))
                m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);
        }
        catch
        {
        }

        try
        {
            m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBInstancia(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao]))
                m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca]))
                m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao]))
                m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso]))
                m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador]))
                m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente]))
                m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida]))
                m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada]))
                m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial]))
                m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente]))
                m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal]))
                m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado]))
                m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao]))
                m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso]))
                m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando]))
                m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem]))
                m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);
        }
        catch
        {
        }

        try
        {
            m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Instancia
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Instancia] (NOLOCK) WHERE [insCodigo] = @ThisIDToLoad", oCnn);
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
m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;  } catch {}  try { m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado]))
            m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente]))
            m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso]))
            m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida]))
            m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada]))
            m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial]))
            m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;  } catch {}  try { m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao]))
            m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente]))
            m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca]))
            m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao]))
            m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal]))
            m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao]))
            m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso]))
            m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem]))
            m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando]))
            m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;  } catch {}  try { m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador]))
            m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Instancia
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
m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;  } catch {}  try { m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLiminarPedida = dbRec[DBInstanciaDicInfo.LiminarPedida]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBInstanciaDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado])) m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.StatusResultado]))
            m_FStatusResultado = Convert.ToInt32(dbRec[DBInstanciaDicInfo.StatusResultado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente])) m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarPendente]))
            m_FLiminarPendente = (bool)dbRec[DBInstanciaDicInfo.LiminarPendente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso])) m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.InterpusemosRecurso]))
            m_FInterpusemosRecurso = (bool)dbRec[DBInstanciaDicInfo.InterpusemosRecurso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida])) m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarConcedida]))
            m_FLiminarConcedida = (bool)dbRec[DBInstanciaDicInfo.LiminarConcedida];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada])) m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarNegada]))
            m_FLiminarNegada = (bool)dbRec[DBInstanciaDicInfo.LiminarNegada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial])) m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarParcial]))
            m_FLiminarParcial = (bool)dbRec[DBInstanciaDicInfo.LiminarParcial];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;  } catch {}  try { m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty; } catch { }

#else
        m_FLiminarResultado = dbRec[DBInstanciaDicInfo.LiminarResultado]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroProcesso = dbRec[DBInstanciaDicInfo.NroProcesso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao])) m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Divisao]))
            m_FDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Divisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente])) m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.LiminarCliente]))
            m_FLiminarCliente = (bool)dbRec[DBInstanciaDicInfo.LiminarCliente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca])) m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Comarca]))
            m_FComarca = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Comarca]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.SubDivisao]))
            m_FSubDivisao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.SubDivisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal])) m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Principal]))
            m_FPrincipal = (bool)dbRec[DBInstanciaDicInfo.Principal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao])) m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Acao]))
            m_FAcao = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Acao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso])) m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.TipoRecurso]))
            m_FTipoRecurso = Convert.ToInt32(dbRec[DBInstanciaDicInfo.TipoRecurso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKey = dbRec[DBInstanciaDicInfo.ZKey]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuem]))
            m_FZKeyQuem = Convert.ToInt32(dbRec[DBInstanciaDicInfo.ZKeyQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.ZKeyQuando]))
            m_FZKeyQuando = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.ZKeyQuando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroAntigo = dbRec[DBInstanciaDicInfo.NroAntigo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;  } catch {}  try { m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAccessCode = dbRec[DBInstanciaDicInfo.AccessCode]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador])) m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Julgador]))
            m_FJulgador = Convert.ToInt32(dbRec[DBInstanciaDicInfo.Julgador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKeyIA = dbRec[DBInstanciaDicInfo.ZKeyIA]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBInstanciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBInstanciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBInstanciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBInstanciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}