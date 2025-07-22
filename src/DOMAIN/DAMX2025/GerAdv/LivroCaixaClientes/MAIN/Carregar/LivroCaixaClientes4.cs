namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixaClientes
{
    public DBLivroCaixaClientes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado]))
                m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]))
                m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBLivroCaixaClientes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado]))
                m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]))
                m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_LivroCaixaClientes
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [lccCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]))
            m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado]))
            m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_LivroCaixaClientes
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
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa])) m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]))
            m_FLivroCaixa = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.LivroCaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado])) m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Lancado]))
            m_FLancado = (bool)dbRec[DBLivroCaixaClientesDicInfo.Lancado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLivroCaixaClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}