namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDepositos
{
    public DBProDepositos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase]))
                m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito]))
                m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBProDepositos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase]))
                m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito]))
                m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_ProDepositos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pdsCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase]))
            m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito]))
            m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProDepositos
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
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase])) m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Fase]))
            m_FFase = Convert.ToInt32(dbRec[DBProDepositosDicInfo.Fase]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProDepositosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito])) m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.TipoProDesposito]))
            m_FTipoProDesposito = Convert.ToInt32(dbRec[DBProDepositosDicInfo.TipoProDesposito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProDepositosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProDepositosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProDepositosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProDepositosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}