namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProSucumbencia
{
    public DBProSucumbencia(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]))
                m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProSucumbencia(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia]))
                m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]))
                m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProSucumbencia
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ProSucumbencia] (NOLOCK) WHERE [scbCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]))
            m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;  } catch {}  try { m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProSucumbencia
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
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia])) m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Instancia]))
            m_FInstancia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.Instancia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProSucumbenciaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia])) m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]))
            m_FTipoOrigemSucumbencia = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.TipoOrigemSucumbencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProSucumbenciaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;  } catch {}  try { m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPercentual = dbRec[DBProSucumbenciaDicInfo.Percentual]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProSucumbenciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProSucumbenciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProSucumbenciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProSucumbenciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProSucumbenciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}