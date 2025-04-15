namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaSemana
{
    public DBAgendaSemana(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaSemanaDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaSemanaDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaSemanaDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaSemanaDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAgendaSemanaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeCliente = dbRec[DBAgendaSemanaDicInfo.NomeCliente]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaNome = dbRec[DBAgendaSemanaDicInfo.ParaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTipo = dbRec[DBAgendaSemanaDicInfo.Tipo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAgendaSemana(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaSemanaDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.HoraFinal]))
                m_FHoraFinal = Convert.ToDateTime(dbRec[DBAgendaSemanaDicInfo.HoraFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaSemanaDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaSemanaDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaSemanaDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaSemanaDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaSemanaDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAgendaSemanaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeCliente = dbRec[DBAgendaSemanaDicInfo.NomeCliente]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaNome = dbRec[DBAgendaSemanaDicInfo.ParaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTipo = dbRec[DBAgendaSemanaDicInfo.Tipo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaSemana
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[PTabelaNome] (NOLOCK) WHERE [CampoCodigo] = @ThisIDToLoad", oCnn);
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
m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;  } catch {}  try { m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxData"]))
            m_FData = Convert.ToDateTime(dbRec["xxxData"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxFuncionario"]))
            m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxAdvogado"]))
            m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxHora"]))
            m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxConcluido"]))
            m_FConcluido = (bool)dbRec["xxxConcluido"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxLiberado"]))
            m_FLiberado = (bool)dbRec["xxxLiberado"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxImportante"]))
            m_FImportante = (bool)dbRec["xxxImportante"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"]))
            m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxCliente"]))
            m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;  } catch {}  try { m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaSemana
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
m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;  } catch {}  try { m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParaNome = dbRec["xxxParaNome"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxData"])) m_FData = Convert.ToDateTime(dbRec["xxxData"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxData"]))
            m_FData = Convert.ToDateTime(dbRec["xxxData"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxFuncionario"])) m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxFuncionario"]))
            m_FFuncionario = Convert.ToInt32(dbRec["xxxFuncionario"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxAdvogado"])) m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxAdvogado"]))
            m_FAdvogado = Convert.ToInt32(dbRec["xxxAdvogado"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxHora"])) m_FHora = Convert.ToDateTime(dbRec["xxxHora"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxHora"]))
            m_FHora = Convert.ToDateTime(dbRec["xxxHora"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"])) m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxTipoCompromisso"]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec["xxxTipoCompromisso"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec["xxxCompromisso"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxConcluido"])) m_FConcluido = (bool)dbRec["xxxConcluido"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxConcluido"]))
            m_FConcluido = (bool)dbRec["xxxConcluido"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxLiberado"])) m_FLiberado = (bool)dbRec["xxxLiberado"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxLiberado"]))
            m_FLiberado = (bool)dbRec["xxxLiberado"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"];  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxImportante"])) m_FImportante = (bool)dbRec["xxxImportante"]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxImportante"]))
            m_FImportante = (bool)dbRec["xxxImportante"];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"])) m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxHoraFinal"]))
            m_FHoraFinal = Convert.ToDateTime(dbRec["xxxHoraFinal"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec["xxxNome"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["xxxCliente"])) m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["xxxCliente"]))
            m_FCliente = Convert.ToInt32(dbRec["xxxCliente"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeCliente = dbRec["xxxNomeCliente"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;  } catch {}  try { m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTipo = dbRec["xxxTipo"]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}