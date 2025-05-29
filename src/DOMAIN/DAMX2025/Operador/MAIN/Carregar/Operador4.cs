#define fastAndSecureCode
namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperador
{
    public DBOperador(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod]))
                m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID]))
                m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador]))
                m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset]))
                m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado]))
                m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido]))
                m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo]))
                m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro]))
                m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master]))
                m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine]))
                m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao]))
                m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId]))
                m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]))
                m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp]))
                m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista]))
                m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff]))
                m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOperador(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod]))
                m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID]))
                m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador]))
                m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset]))
                m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado]))
                m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido]))
                m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo]))
                m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro]))
                m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master]))
                m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine]))
                m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao]))
                m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId]))
                m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]))
                m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp]))
                m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista]))
                m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff]))
                m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Operador
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [operCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
            try
            {
                ID = Convert.ToInt32(dbRec[CampoCodigo]);
            }
            catch
            {
            }
        }

#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista]))
                m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master]))
                m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;  } catch {}  try { m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;  } catch {}  try { m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID]))
                m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod]))
                m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido]))
                m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao]))
                m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador]))
                m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff]))
                m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;  } catch {}  try { m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine]))
                m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp]))
                m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId]))
                m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro]))
                m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo]))
                m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado]))
                m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset]))
                m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]))
                m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];
        }
        catch
        {
        }
    // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; 
// #endif
// 
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Operador
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
            try
            {
                ID = Convert.ToInt32(dbRec[CampoCodigo]);
            }
            catch
            {
            }
        }

#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FEMail = dbRec[DBOperadorDicInfo.EMail]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FPasta = dbRec[DBOperadorDicInfo.Pasta]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista]))
                m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Telefonista])) m_FTelefonista = (bool)dbRec[DBOperadorDicInfo.Telefonista]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master]))
                m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Master])) m_FMaster = (bool)dbRec[DBOperadorDicInfo.Master]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FNome = dbRec[DBOperadorDicInfo.Nome]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;  } catch {}  try { m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FNick = dbRec[DBOperadorDicInfo.Nick]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;  } catch {}  try { m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FRamal = dbRec[DBOperadorDicInfo.Ramal]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID]))
                m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadID])) m_FCadID = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadID]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod]))
                m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.CadCod])) m_FCadCod = Convert.ToInt32(dbRec[DBOperadorDicInfo.CadCod]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido]))
                m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Excluido])) m_FExcluido = (bool)dbRec[DBOperadorDicInfo.Excluido]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao]))
                m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Situacao])) m_FSituacao = (bool)dbRec[DBOperadorDicInfo.Situacao]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador]))
                m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Computador])) m_FComputador = Convert.ToInt32(dbRec[DBOperadorDicInfo.Computador]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FMinhaDescricao = dbRec[DBOperadorDicInfo.MinhaDescricao]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff]))
                m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.UltimoLogoff])) m_FUltimoLogoff = Convert.ToDateTime(dbRec[DBOperadorDicInfo.UltimoLogoff]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FEMailNet = dbRec[DBOperadorDicInfo.EMailNet]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;  } catch {}  try { m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FOnlineIP = dbRec[DBOperadorDicInfo.OnlineIP]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine]))
                m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.OnLine])) m_FOnLine = (bool)dbRec[DBOperadorDicInfo.OnLine]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp]))
                m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SysOp])) m_FSysOp = (bool)dbRec[DBOperadorDicInfo.SysOp]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId]))
                m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.StatusId])) m_FStatusId = Convert.ToInt32(dbRec[DBOperadorDicInfo.StatusId]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FStatusMessage = dbRec[DBOperadorDicInfo.StatusMessage]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro]))
                m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.IsFinanceiro])) m_FIsFinanceiro = (bool)dbRec[DBOperadorDicInfo.IsFinanceiro]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOperadorDicInfo.Top];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Top])) m_FTop = (bool)dbRec[DBOperadorDicInfo.Top]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOperadorDicInfo.Sexo]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico]))
                m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Basico])) m_FBasico = (bool)dbRec[DBOperadorDicInfo.Basico]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo]))
                m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Externo])) m_FExterno = (bool)dbRec[DBOperadorDicInfo.Externo]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSenha256 = dbRec[DBOperadorDicInfo.Senha256]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado]))
                m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado];
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.EMailConfirmado])) m_FEMailConfirmado = (bool)dbRec[DBOperadorDicInfo.EMailConfirmado]; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset]))
                m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DataLimiteReset])) m_FDataLimiteReset = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DataLimiteReset]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteSenha256 = dbRec[DBOperadorDicInfo.SuporteSenha256]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge]))
                m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteMaxAge])) m_FSuporteMaxAge = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteMaxAge]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteNomeSolicitante = dbRec[DBOperadorDicInfo.SuporteNomeSolicitante]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]))
                m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso])) m_FSuporteUltimoAcesso = Convert.ToDateTime(dbRec[DBOperadorDicInfo.SuporteUltimoAcesso]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;  } catch {}  try { m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FSuporteIpUltimoAcesso = dbRec[DBOperadorDicInfo.SuporteIpUltimoAcesso]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 203
        // m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        // 
#else
// m_FGUID = dbRec[DBOperadorDicInfo.GUID]?.ToString() ?? string.Empty; 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemCad]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtCad]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 3
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorDicInfo.QuemAtu]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 7
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorDicInfo.DtAtu]); 
// #endif
// 
#endif
        // #if (NofastCodeLoadToDebug)
        // region JMen - nType = 2
        // if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];  } catch {}  try { 
        // #else
        // 
#if (fastAndSecureCode)
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto];
        }
        catch
        {
        }
    // 
#else
// if (!DBNull.Value.Equals(dbRec[DBOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorDicInfo.Visto]; 
// #endif
// 
#endif
    ///RELATION_READ///
    }
#endregion
}