namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertas
{
    public DBAlertas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte]))
                m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAlertas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte]))
                m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Alertas
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Alertas] (NOLOCK) WHERE [altCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte]))
            m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Alertas
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
m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAlertasDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAlertasDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBAlertasDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte])) m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DataAte]))
            m_FDataAte = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DataAte]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAlertasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAlertasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAlertasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAlertasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}