namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteClienteOutras
{
    public DBParteClienteOutras(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]))
                m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBParteClienteOutras(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]))
                m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_ParteClienteOutras
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pcoCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]))
            m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ParteClienteOutras
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
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada])) m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada]))
            m_FPrimeiraReclamada = (bool)dbRec[DBParteClienteOutrasDicInfo.PrimeiraReclamada];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBParteClienteOutrasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBParteClienteOutrasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteOutrasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBParteClienteOutrasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}