namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteCliente
{
    public DBParteCliente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);
        }
        catch
        {
        }
    }

    public DBParteCliente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);
        }
        catch
        {
        }
    }

#region CarregarDados_ParteCliente
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
if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ParteCliente
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBParteClienteDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBParteClienteDicInfo.Processo]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}