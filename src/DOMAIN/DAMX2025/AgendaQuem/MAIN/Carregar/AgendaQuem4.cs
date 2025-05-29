namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaQuem
{
    public DBAgendaQuem(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);
        }
        catch
        {
        }
    }

    public DBAgendaQuem(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda]))
                m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaQuem
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [agqCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaQuem
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
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda])) m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.IDAgenda]))
            m_FIDAgenda = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.IDAgenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaQuemDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaQuemDicInfo.Preposto]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}