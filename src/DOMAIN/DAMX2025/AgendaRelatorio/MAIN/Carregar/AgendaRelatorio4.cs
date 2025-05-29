namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRelatorio
{
    public DBAgendaRelatorio(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRelatorioDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaRelatorioDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRelatorioDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRelatorioDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            m_FBoxAudiencia = dbRec[DBAgendaRelatorioDicInfo.BoxAudiencia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FBoxAudienciaMobile = dbRec[DBAgendaRelatorioDicInfo.BoxAudienciaMobile]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeAdvogado = dbRec[DBAgendaRelatorioDicInfo.NomeAdvogado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeArea = dbRec[DBAgendaRelatorioDicInfo.NomeArea]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeForo = dbRec[DBAgendaRelatorioDicInfo.NomeForo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeJustica = dbRec[DBAgendaRelatorioDicInfo.NomeJustica]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaNome = dbRec[DBAgendaRelatorioDicInfo.ParaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaPessoas = dbRec[DBAgendaRelatorioDicInfo.ParaPessoas]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAgendaRelatorio(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRelatorioDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaRelatorioDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaRelatorioDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaRelatorioDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            m_FBoxAudiencia = dbRec[DBAgendaRelatorioDicInfo.BoxAudiencia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FBoxAudienciaMobile = dbRec[DBAgendaRelatorioDicInfo.BoxAudienciaMobile]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeAdvogado = dbRec[DBAgendaRelatorioDicInfo.NomeAdvogado]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeArea = dbRec[DBAgendaRelatorioDicInfo.NomeArea]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeForo = dbRec[DBAgendaRelatorioDicInfo.NomeForo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeJustica = dbRec[DBAgendaRelatorioDicInfo.NomeJustica]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaNome = dbRec[DBAgendaRelatorioDicInfo.ParaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParaPessoas = dbRec[DBAgendaRelatorioDicInfo.ParaPessoas]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaRelatorio
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [CampoCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["vqaData"]))
            m_FData = Convert.ToDateTime(dbRec["vqaData"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["vqaProcesso"]))
            m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);
#endif
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
// region JMen - nType = 203
m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;  } catch {}  try { m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;  } catch {}  try { m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;  } catch {}  try { m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaRelatorio
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
        // Não tem campo código no DEVOURER
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["vqaData"])) m_FData = Convert.ToDateTime(dbRec["vqaData"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["vqaData"]))
            m_FData = Convert.ToDateTime(dbRec["vqaData"]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec["vqaProcesso"])) m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec["vqaProcesso"]))
            m_FProcesso = Convert.ToInt32(dbRec["vqaProcesso"]);
#endif
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
// region JMen - nType = 203
m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;  } catch {}  try { m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParaPessoas = dbRec["xxxParaPessoas"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;  } catch {}  try { m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBoxAudiencia = dbRec["xxxBoxAudiencia"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;  } catch {}  try { m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBoxAudienciaMobile = dbRec["xxxBoxAudienciaMobile"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeAdvogado = dbRec["xxxNomeAdvogado"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeForo = dbRec["xxxNomeForo"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeJustica = dbRec["xxxNomeJustica"]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeArea = dbRec["xxxNomeArea"]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}