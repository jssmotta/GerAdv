// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBOperadorEMailPopup : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_OperadorEMailPopup
    [XmlIgnore]
    public string TabelaNome => "OperadorEMailPopup";

    public DBOperadorEMailPopup()
    {
    }

#endregion
    public DBOperadorEMailPopup(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBOperadorEMailPopup(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        // Tracking: 250605-0
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql) && !string.IsNullOrEmpty(cNome))
        {
            if (cNome is null)
            {
                return;
            }

            sqlWhere = cNome;
        }

        if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
        {
            using var ds = ConfiguracoesDBT.GetDataTable(parameters, fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
        else
        {
            using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [{CampoNome}]  COLLATE SQL_Latin1_General_CP1_CI_AI  like @CampoNome", oCnn?.InnerConnection);
            cmd.Parameters.AddWithValue("@CampoNome", cNome?.trim() ?? string.Empty);
            using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    public DBOperadorEMailPopup(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_OperadorEMailPopup
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFOperador || pFldFNome || pFldFSenha || pFldFSMTP || pFldFPOP3 || pFldFAutenticacao || pFldFDescricao || pFldFUsuario || pFldFPortaSmtp || pFldFPortaPop3 || pFldFAssinatura || pFldFSenha256))
                return 0;
        if (oCnn is null)
#if (DEBUG)
			        {
				        PTabelaNome.PopupBox("oCnn is null - Update()");
#else
            return 0;
#endif
#if (DEBUG)
			         }
#endif
        if (this.FNome.IsEmpty())
        {
            throw new Exception("Campo 'oepNome' está vazio!");
        }

        var clsW = new DBToolWTable32(PTabelaNome, CampoCodigo, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
        }
        else
        {
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFOperador)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Operador, m_FOperador, ETiposCampos.FNumberNull);
        if (pFldFNome)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFSenha)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Senha, m_FSenha, ETiposCampos.FString);
        if (pFldFSMTP)
            clsW.Fields(DBOperadorEMailPopupDicInfo.SMTP, m_FSMTP, ETiposCampos.FString);
        if (pFldFPOP3)
            clsW.Fields(DBOperadorEMailPopupDicInfo.POP3, m_FPOP3, ETiposCampos.FString);
        if (pFldFAutenticacao || ID.IsEmptyIDNumber())
            clsW.Fields(DBOperadorEMailPopupDicInfo.Autenticacao, m_FAutenticacao, ETiposCampos.FBoolean);
        if (pFldFDescricao)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Descricao, m_FDescricao, ETiposCampos.FString);
        if (pFldFUsuario)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Usuario, m_FUsuario, ETiposCampos.FString);
        if (pFldFPortaSmtp)
            clsW.Fields(DBOperadorEMailPopupDicInfo.PortaSmtp, m_FPortaSmtp, ETiposCampos.FNumberNull);
        if (pFldFPortaPop3)
            clsW.Fields(DBOperadorEMailPopupDicInfo.PortaPop3, m_FPortaPop3, ETiposCampos.FNumberNull);
        if (pFldFAssinatura)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Assinatura, m_FAssinatura, ETiposCampos.FString);
        if (pFldFSenha256)
            clsW.Fields(DBOperadorEMailPopupDicInfo.Senha256, m_FSenha256, ETiposCampos.FString);
        if (pFldFGUID)
            clsW.Fields(DBOperadorEMailPopupDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_OperadorEMailPopup)
        if (clsW.HasUpdates)
        {
            HasChanges = true;
        }
        else if (ID != 0)
        {
            return 0;
        }

#endif
        if (m_AuditorQuem == 0)
            AuditorQuem = 1;
        if (pFldFQuemCad)
            clsW.Fields(DBOperadorEMailPopupDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBOperadorEMailPopupDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBOperadorEMailPopupDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBOperadorEMailPopupDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBOperadorEMailPopupDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
        if (insertId != 0)
            return GravaNewId();
        var cRet = clsW.RecUpdate(oCnn);
        if (!clsW.Insert)
            return Error;
        if (!cRet.Equals("OK"))
            return Error;
        ID = clsW.GetCodigo();
        if (CampoCodigo.IsEmpty())
        {
        }
        else if (ID == 0)
        {
            Error = -2;
            ErrorDescription = "900xh100 - O registro não pode ser incluído, tente mais tarde.";
#if (!IgnoreExploreMSIDb)
            DevourerOne.ExplodeErrorWindows(clsW.Table, clsW.LastError, ErrorDescription, cRet);
#endif
        }

        int GravaNewId()
        {
            ID = insertId;
            clsW.Fields(CampoCodigo, insertId, ETiposCampos.FNumber);
            cRet = clsW.RecUpdate(oCnn, true);
            if (cRet.Equals("OK"))
                return 0;
            ErrorDescription = "Erro de inclusão insertiva de Id!";
            return -3;
        }

        return Error;
    }
#endregion // 001

}