namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputEngine
{
    public DBProcessOutputEngine(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador]))
                m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem]))
                m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo]))
                m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]))
                m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID]))
                m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource]))
                m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);
        }
        catch
        {
        }

        try
        {
            m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProcessOutputEngine(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador]))
                m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem]))
                m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo]))
                m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]))
                m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID]))
                m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource]))
                m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);
        }
        catch
        {
        }

        try
        {
            m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProcessOutputEngine
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ProcessOutputEngine] (NOLOCK) WHERE [poeCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;  } catch {}  try { m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;  } catch {}  try { m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;  } catch {}  try { m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador]))
            m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource]))
            m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem]))
            m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo]))
            m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]))
            m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID]))
            m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProcessOutputEngine
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
m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProcessOutputEngineDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;  } catch {}  try { m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDatabase = dbRec[DBProcessOutputEngineDicInfo.Database]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTabela = dbRec[DBProcessOutputEngineDicInfo.Tabela]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;  } catch {}  try { m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCampo = dbRec[DBProcessOutputEngineDicInfo.Campo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;  } catch {}  try { m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FValor = dbRec[DBProcessOutputEngineDicInfo.Valor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;  } catch {}  try { m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOutput = dbRec[DBProcessOutputEngineDicInfo.Output]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador])) m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.Administrador]))
            m_FAdministrador = (bool)dbRec[DBProcessOutputEngineDicInfo.Administrador];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource])) m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.OutputSource]))
            m_FOutputSource = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.OutputSource]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem])) m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.DisabledItem]))
            m_FDisabledItem = (bool)dbRec[DBProcessOutputEngineDicInfo.DisabledItem];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo])) m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IDModulo]))
            m_FIDModulo = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.IDModulo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso])) m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso]))
            m_FIsOnlyProcesso = (bool)dbRec[DBProcessOutputEngineDicInfo.IsOnlyProcesso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID])) m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessOutputEngineDicInfo.MyID]))
            m_FMyID = Convert.ToInt32(dbRec[DBProcessOutputEngineDicInfo.MyID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessOutputEngineDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}