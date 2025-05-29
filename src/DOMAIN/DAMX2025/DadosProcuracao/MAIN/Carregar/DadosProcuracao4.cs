namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDadosProcuracao
{
    public DBDadosProcuracao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBDadosProcuracao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_DadosProcuracao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [prcCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;  } catch {}  try { m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;  } catch {}  try { m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;  } catch {}  try { m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;  } catch {}  try { m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_DadosProcuracao
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
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;  } catch {}  try { m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEstadoCivil = dbRec[DBDadosProcuracaoDicInfo.EstadoCivil]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;  } catch {}  try { m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNacionalidade = dbRec[DBDadosProcuracaoDicInfo.Nacionalidade]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;  } catch {}  try { m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProfissao = dbRec[DBDadosProcuracaoDicInfo.Profissao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPS = dbRec[DBDadosProcuracaoDicInfo.CTPS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;  } catch {}  try { m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPisPasep = dbRec[DBDadosProcuracaoDicInfo.PisPasep]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRemuneracao = dbRec[DBDadosProcuracaoDicInfo.Remuneracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObjeto = dbRec[DBDadosProcuracaoDicInfo.Objeto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDadosProcuracaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDadosProcuracaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDadosProcuracaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDadosProcuracaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDadosProcuracaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}