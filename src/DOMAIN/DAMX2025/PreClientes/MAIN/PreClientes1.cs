// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBPreClientes : VSexo, ICadastrosAuditor, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PreClientes)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBPreClientes();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_PreClientes
    [XmlIgnore]
    public string TabelaNome => "PreClientes";

    public DBPreClientes()
    {
    }

#endregion
    public DBPreClientes(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBPreClientes(in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
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
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
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
    public DBPreClientes(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#if (forWeb)
public int Update(MsiSqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_PreClientes
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFInativo || pFldFQuemIndicou || pFldFNome || pFldFAdv || pFldFIDRep || pFldFJuridica || pFldFNomeFantasia || pFldFClass || pFldFTipo || pFldFDtNasc || pFldFInscEst || pFldFQualificacao || pFldFSexo || pFldFIdade || pFldFCNPJ || pFldFCPF || pFldFRG || pFldFTipoCaptacao || pFldFObservacao || pFldFEndereco || pFldFBairro || pFldFCidade || pFldFCEP || pFldFFax || pFldFFone || pFldFData || pFldFHomePage || pFldFEMail || pFldFAssistido || pFldFAssRG || pFldFAssCPF || pFldFAssEndereco || pFldFCNH || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'cliNome' está vazio!");
        }

        var clsW = new DBToolWTable32(PTabelaNome, CampoCodigo, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
            if (insertId == 0)
            {
            }
            else
            {
            }
        }
        else
        {
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (pFldFInativo || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Inativo, m_FInativo, ETiposCampos.FBoolean);
        if (pFldFQuemIndicou)
            clsW.Fields(DBPreClientesDicInfo.QuemIndicou, m_FQuemIndicou, ETiposCampos.FString);
        if (pFldFNome)
            clsW.Fields(DBPreClientesDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFAdv)
            clsW.Fields(DBPreClientesDicInfo.Adv, m_FAdv, ETiposCampos.FNumberNull);
        if (pFldFIDRep)
            clsW.Fields(DBPreClientesDicInfo.IDRep, m_FIDRep, ETiposCampos.FNumberNull);
        if (pFldFJuridica || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Juridica, m_FJuridica, ETiposCampos.FBoolean);
        if (pFldFNomeFantasia)
            clsW.Fields(DBPreClientesDicInfo.NomeFantasia, m_FNomeFantasia, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBPreClientesDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFDtNasc)
            clsW.Fields(DBPreClientesDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFInscEst)
            clsW.Fields(DBPreClientesDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFQualificacao)
            clsW.Fields(DBPreClientesDicInfo.Qualificacao, m_FQualificacao, ETiposCampos.FString);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFIdade)
            clsW.Fields(DBPreClientesDicInfo.Idade, m_FIdade, ETiposCampos.FNumberNull);
        if (pFldFCNPJ)
            clsW.Fields(DBPreClientesDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBPreClientesDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBPreClientesDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFTipoCaptacao || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.TipoCaptacao, m_FTipoCaptacao, ETiposCampos.FBoolean);
        if (pFldFObservacao)
            clsW.Fields(DBPreClientesDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBPreClientesDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBPreClientesDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBPreClientesDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBPreClientesDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBPreClientesDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBPreClientesDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFData)
            clsW.Fields(DBPreClientesDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFHomePage)
            clsW.Fields(DBPreClientesDicInfo.HomePage, m_FHomePage, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBPreClientesDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFAssistido)
            clsW.Fields(DBPreClientesDicInfo.Assistido, m_FAssistido, ETiposCampos.FString);
        if (pFldFAssRG)
            clsW.Fields(DBPreClientesDicInfo.AssRG, m_FAssRG, ETiposCampos.FString);
        if (pFldFAssCPF)
            clsW.Fields(DBPreClientesDicInfo.AssCPF, m_FAssCPF, ETiposCampos.FString);
        if (pFldFAssEndereco)
            clsW.Fields(DBPreClientesDicInfo.AssEndereco, m_FAssEndereco, ETiposCampos.FString);
        if (pFldFCNH)
            clsW.Fields(DBPreClientesDicInfo.CNH, m_FCNH, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PreClientes)
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
            clsW.Fields(DBPreClientesDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBPreClientesDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBPreClientesDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBPreClientesDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBPreClientesDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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