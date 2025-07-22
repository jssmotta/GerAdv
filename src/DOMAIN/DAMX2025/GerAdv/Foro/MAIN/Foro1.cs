// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBForo : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_Foro
    [XmlIgnore]
    public string TabelaNome => "Foro";

    public DBForo()
    {
    }

#endregion
    public DBForo(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBForo(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBForo(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Foro
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFEMail || pFldFNome || pFldFUnico || pFldFCidade || pFldFSite || pFldFEndereco || pFldFBairro || pFldFFone || pFldFFax || pFldFCEP || pFldFOBS || pFldFUnicoConfirmado || pFldFWeb || pFldFEtiqueta || pFldFBold))
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
            throw new Exception("Campo 'forNome' está vazio!");
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

        if (pFldFEMail)
            clsW.Fields(DBForoDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFNome)
            clsW.Fields(DBForoDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFUnico || ID.IsEmptyIDNumber())
            clsW.Fields(DBForoDicInfo.Unico, m_FUnico, ETiposCampos.FBoolean);
        if (pFldFCidade)
            clsW.Fields(DBForoDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFSite)
            clsW.Fields(DBForoDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBForoDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBForoDicInfo.Bairro, m_FBairro, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBForoDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBForoDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBForoDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBForoDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFUnicoConfirmado || ID.IsEmptyIDNumber())
            clsW.Fields(DBForoDicInfo.UnicoConfirmado, m_FUnicoConfirmado, ETiposCampos.FBoolean);
        if (pFldFWeb)
            clsW.Fields(DBForoDicInfo.Web, m_FWeb, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBForoDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBForoDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_Foro)
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
            clsW.Fields(DBForoDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBForoDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBForoDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBForoDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBForoDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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