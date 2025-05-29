namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteOponente
{
    public DBParteOponente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);
        }
        catch
        {
        }
    }

    public DBParteOponente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);
        }
        catch
        {
        }
    }

#region CarregarDados_ParteOponente
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ParteOponente
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteOponenteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteOponenteDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}