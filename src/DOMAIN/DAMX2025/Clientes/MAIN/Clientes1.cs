// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBClientes : VSexo, ICadastrosAuditor, IAuditor
{
#region TableDefinition_Clientes
    [XmlIgnore]
    public string TabelaNome => "Clientes";

    public DBClientes()
    {
    }

#endregion
    public DBClientes(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBClientes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBClientes(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Clientes
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFEmpresa || pFldFIcone || pFldFNomeMae || pFldFRGDataExp || pFldFInativo || pFldFQuemIndicou || pFldFSendEMail || pFldFNome || pFldFAdv || pFldFIDRep || pFldFJuridica || pFldFNomeFantasia || pFldFClass || pFldFTipo || pFldFDtNasc || pFldFInscEst || pFldFQualificacao || pFldFSexo || pFldFIdade || pFldFCNPJ || pFldFCPF || pFldFRG || pFldFTipoCaptacao || pFldFObservacao || pFldFEndereco || pFldFBairro || pFldFCidade || pFldFCEP || pFldFFax || pFldFFone || pFldFData || pFldFHomePage || pFldFEMail || pFldFObito || pFldFNomePai || pFldFRGOExpeditor || pFldFRegimeTributacao || pFldFEnquadramentoEmpresa || pFldFReportECBOnly || pFldFProBono || pFldFCNH || pFldFPessoaContato || pFldFEtiqueta || pFldFAni || pFldFBold))
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

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFEmpresa)
            clsW.Fields(DBClientesDicInfo.Empresa, m_FEmpresa, ETiposCampos.FNumberNull);
        if (pFldFIcone)
            clsW.Fields(DBClientesDicInfo.Icone, m_FIcone, ETiposCampos.FString);
        if (pFldFNomeMae)
            clsW.Fields(DBClientesDicInfo.NomeMae, m_FNomeMae, ETiposCampos.FString);
        if (pFldFRGDataExp)
            clsW.Fields(DBClientesDicInfo.RGDataExp, m_FRGDataExp, ETiposCampos.FDate);
        if (pFldFInativo || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Inativo, m_FInativo, ETiposCampos.FBoolean);
        if (pFldFQuemIndicou)
            clsW.Fields(DBClientesDicInfo.QuemIndicou, m_FQuemIndicou, ETiposCampos.FString);
        if (pFldFSendEMail || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.SendEMail, m_FSendEMail, ETiposCampos.FBoolean);
        if (pFldFNome)
            clsW.Fields(DBClientesDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFAdv)
            clsW.Fields(DBClientesDicInfo.Adv, m_FAdv, ETiposCampos.FNumberNull);
        if (pFldFIDRep)
            clsW.Fields(DBClientesDicInfo.IDRep, m_FIDRep, ETiposCampos.FNumberNull);
        if (pFldFJuridica || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Juridica, m_FJuridica, ETiposCampos.FBoolean);
        if (pFldFNomeFantasia)
            clsW.Fields(DBClientesDicInfo.NomeFantasia, m_FNomeFantasia, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBClientesDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFDtNasc)
            clsW.Fields(DBClientesDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFInscEst)
            clsW.Fields(DBClientesDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFQualificacao)
            clsW.Fields(DBClientesDicInfo.Qualificacao, m_FQualificacao, ETiposCampos.FString);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFIdade)
            clsW.Fields(DBClientesDicInfo.Idade, m_FIdade, ETiposCampos.FNumberNull);
        if (pFldFCNPJ)
            clsW.Fields(DBClientesDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBClientesDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBClientesDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFTipoCaptacao || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.TipoCaptacao, m_FTipoCaptacao, ETiposCampos.FBoolean);
        if (pFldFObservacao)
            clsW.Fields(DBClientesDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBClientesDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBClientesDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBClientesDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBClientesDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBClientesDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBClientesDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFData)
            clsW.Fields(DBClientesDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFHomePage)
            clsW.Fields(DBClientesDicInfo.HomePage, m_FHomePage, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBClientesDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFObito || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Obito, m_FObito, ETiposCampos.FBoolean);
        if (pFldFNomePai)
            clsW.Fields(DBClientesDicInfo.NomePai, m_FNomePai, ETiposCampos.FString);
        if (pFldFRGOExpeditor)
            clsW.Fields(DBClientesDicInfo.RGOExpeditor, m_FRGOExpeditor, ETiposCampos.FString);
        if (pFldFRegimeTributacao)
            clsW.Fields(DBClientesDicInfo.RegimeTributacao, m_FRegimeTributacao, ETiposCampos.FNumberNull);
        if (pFldFEnquadramentoEmpresa)
            clsW.Fields(DBClientesDicInfo.EnquadramentoEmpresa, m_FEnquadramentoEmpresa, ETiposCampos.FNumberNull);
        if (pFldFReportECBOnly || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.ReportECBOnly, m_FReportECBOnly, ETiposCampos.FBoolean);
        if (pFldFProBono || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.ProBono, m_FProBono, ETiposCampos.FBoolean);
        if (pFldFCNH)
            clsW.Fields(DBClientesDicInfo.CNH, m_FCNH, ETiposCampos.FString);
        if (pFldFPessoaContato)
            clsW.Fields(DBClientesDicInfo.PessoaContato, m_FPessoaContato, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBClientesDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Clientes)
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
            clsW.Fields(DBClientesDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBClientesDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBClientesDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBClientesDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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