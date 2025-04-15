namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso2
{
    public DBApenso2(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado]))
                m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBApenso2(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado]))
                m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_Apenso2
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Apenso2] (NOLOCK) WHERE [ap2Codigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado]))
            m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Apenso2
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
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBApenso2DicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado])) m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Apensado]))
            m_FApensado = Convert.ToInt32(dbRec[DBApenso2DicInfo.Apensado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBApenso2DicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBApenso2DicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto])) m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBApenso2DicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBApenso2DicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}