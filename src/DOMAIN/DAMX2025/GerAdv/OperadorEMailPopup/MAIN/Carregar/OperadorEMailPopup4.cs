namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorEMailPopup
{
    public DBOperadorEMailPopup(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]))
                m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]))
                m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]))
                m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperadorEMailPopup(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]))
                m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]))
                m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]))
                m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OperadorEMailPopup
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [oepCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;  } catch {}  try { m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;  } catch {}  try { m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]))
            m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;  } catch {}  try { m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; } catch { }

#else
        m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]))
            m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]))
            m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OperadorEMailPopup
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
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBOperadorEMailPopupDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha = dbRec[DBOperadorEMailPopupDicInfo.Senha]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;  } catch {}  try { m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSMTP = dbRec[DBOperadorEMailPopupDicInfo.SMTP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;  } catch {}  try { m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPOP3 = dbRec[DBOperadorEMailPopupDicInfo.POP3]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao])) m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Autenticacao]))
            m_FAutenticacao = (bool)dbRec[DBOperadorEMailPopupDicInfo.Autenticacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBOperadorEMailPopupDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;  } catch {}  try { m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty; } catch { }

#else
        m_FUsuario = dbRec[DBOperadorEMailPopupDicInfo.Usuario]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp])) m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]))
            m_FPortaSmtp = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaSmtp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3])) m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]))
            m_FPortaPop3 = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.PortaPop3]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssinatura = dbRec[DBOperadorEMailPopupDicInfo.Assinatura]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSenha256 = dbRec[DBOperadorEMailPopupDicInfo.Senha256]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOperadorEMailPopupDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorEMailPopupDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorEMailPopupDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorEMailPopupDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorEMailPopupDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}