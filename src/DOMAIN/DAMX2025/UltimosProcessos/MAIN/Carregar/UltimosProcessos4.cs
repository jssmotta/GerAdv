namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUltimosProcessos
{
    public DBUltimosProcessos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando]))
                m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem]))
                m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);
        }
        catch
        {
        }
    }

    public DBUltimosProcessos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando]))
                m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem]))
                m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);
        }
        catch
        {
        }
    }

#region CarregarDados_UltimosProcessos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ultCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando]))
            m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem]))
            m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_UltimosProcessos
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
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando])) m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quando]))
            m_FQuando = Convert.ToDateTime(dbRec[DBUltimosProcessosDicInfo.Quando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUltimosProcessosDicInfo.Quem]))
            m_FQuem = Convert.ToInt32(dbRec[DBUltimosProcessosDicInfo.Quem]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}