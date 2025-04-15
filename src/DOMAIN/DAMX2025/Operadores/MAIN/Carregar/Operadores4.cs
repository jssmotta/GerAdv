namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadores
{
    public DBOperadores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado]))
                m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha]))
                m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo]))
                m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID]))
                m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado]))
                m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo]))
                m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperadores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado]))
                m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha]))
                m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo]))
                m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID]))
                m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado]))
                m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo]))
                m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Operadores
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Operadores] (NOLOCK) WHERE [operCodigo] = @ThisIDToLoad", oCnn);
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado]))
            m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID]))
            m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo]))
            m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo]))
            m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado]))
            m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha]))
            m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge]))
            m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Operadores
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado])) m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Enviado]))
            m_FEnviado = (bool)dbRec[DBOperadoresDicInfo.Enviado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa])) m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBOperadoresDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID])) m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaID]))
            m_FCasaID = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo])) m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.CasaCodigo]))
            m_FCasaCodigo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.CasaCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo])) m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.IsNovo]))
            m_FIsNovo = (bool)dbRec[DBOperadoresDicInfo.IsNovo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBOperadoresDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOperadoresDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha = dbRec[DBOperadoresDicInfo.Senha]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado])) m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Ativado]))
            m_FAtivado = (bool)dbRec[DBOperadoresDicInfo.Ativado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha])) m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.AtualizarSenha]))
            m_FAtualizarSenha = (bool)dbRec[DBOperadoresDicInfo.AtualizarSenha];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha256 = dbRec[DBOperadoresDicInfo.Senha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSuporteSenha256 = dbRec[DBOperadoresDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.SuporteMaxAge]))
            m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.SuporteMaxAge]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}