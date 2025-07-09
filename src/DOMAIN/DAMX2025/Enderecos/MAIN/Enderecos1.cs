// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBEnderecos : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_Enderecos
    [XmlIgnore]
    public string TabelaNome => "Enderecos";

    public DBEnderecos()
    {
    }

#endregion
    public DBEnderecos(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBEnderecos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBEnderecos(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Enderecos
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFTopIndex || pFldFDescricao || pFldFContato || pFldFDtNasc || pFldFEndereco || pFldFBairro || pFldFPrivativo || pFldFAddContato || pFldFCEP || pFldFOAB || pFldFOBS || pFldFFone || pFldFFax || pFldFTratamento || pFldFCidade || pFldFSite || pFldFEMail || pFldFQuem || pFldFQuemIndicou || pFldFReportECBOnly || pFldFEtiqueta || pFldFAni || pFldFBold))
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
        if (this.FDescricao.IsEmpty())
        {
            throw new Exception("Campo 'endDescricao' está vazio!");
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
        if (pFldFTopIndex || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.TopIndex, m_FTopIndex, ETiposCampos.FBoolean);
        if (pFldFDescricao)
            clsW.Fields(DBEnderecosDicInfo.Descricao, m_FDescricao, ETiposCampos.FString);
        if (pFldFContato)
            clsW.Fields(DBEnderecosDicInfo.Contato, m_FContato, ETiposCampos.FString);
        if (pFldFDtNasc)
            clsW.Fields(DBEnderecosDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFEndereco)
            clsW.Fields(DBEnderecosDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBEnderecosDicInfo.Bairro, m_FBairro, ETiposCampos.FString);
        if (pFldFPrivativo || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.Privativo, m_FPrivativo, ETiposCampos.FBoolean);
        if (pFldFAddContato || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.AddContato, m_FAddContato, ETiposCampos.FBoolean);
        if (pFldFCEP)
            clsW.Fields(DBEnderecosDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFOAB)
            clsW.Fields(DBEnderecosDicInfo.OAB, m_FOAB, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBEnderecosDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBEnderecosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBEnderecosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFTratamento)
            clsW.Fields(DBEnderecosDicInfo.Tratamento, m_FTratamento, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBEnderecosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFSite)
            clsW.Fields(DBEnderecosDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBEnderecosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFQuem)
            clsW.Fields(DBEnderecosDicInfo.Quem, m_FQuem, ETiposCampos.FNumberNull);
        if (pFldFQuemIndicou)
            clsW.Fields(DBEnderecosDicInfo.QuemIndicou, m_FQuemIndicou, ETiposCampos.FString);
        if (pFldFReportECBOnly || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.ReportECBOnly, m_FReportECBOnly, ETiposCampos.FBoolean);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBEnderecosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Enderecos)
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
            clsW.Fields(DBEnderecosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBEnderecosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBEnderecosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBEnderecosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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