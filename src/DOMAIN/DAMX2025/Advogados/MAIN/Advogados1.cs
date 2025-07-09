// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAdvogados : VSexo, ICadastrosAuditor, IAuditor
{
#region TableDefinition_Advogados
    [XmlIgnore]
    public string TabelaNome => "Advogados";

    public DBAdvogados()
    {
    }

#endregion
    public DBAdvogados(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBAdvogados(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBAdvogados(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Advogados
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCargo || pFldFEMailPro || pFldFCPF || pFldFNome || pFldFRG || pFldFCasa || pFldFNomeMae || pFldFEscritorio || pFldFEstagiario || pFldFOAB || pFldFNomeCompleto || pFldFEndereco || pFldFCidade || pFldFCEP || pFldFSexo || pFldFBairro || pFldFCTPSSerie || pFldFCTPS || pFldFFone || pFldFFax || pFldFComissao || pFldFDtInicio || pFldFDtFim || pFldFDtNasc || pFldFSalario || pFldFSecretaria || pFldFTextoProcuracao || pFldFEMail || pFldFEspecializacao || pFldFPasta || pFldFObservacao || pFldFContaBancaria || pFldFParcTop || pFldFClass || pFldFTop || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'advNome' está vazio!");
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
        if (pFldFCargo)
            clsW.Fields(DBAdvogadosDicInfo.Cargo, m_FCargo, ETiposCampos.FNumberNull);
        if (pFldFEMailPro)
            clsW.Fields(DBAdvogadosDicInfo.EMailPro, m_FEMailPro, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBAdvogadosDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFNome)
            clsW.Fields(DBAdvogadosDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBAdvogadosDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFCasa || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Casa, m_FCasa, ETiposCampos.FBoolean);
        if (pFldFNomeMae)
            clsW.Fields(DBAdvogadosDicInfo.NomeMae, m_FNomeMae, ETiposCampos.FString);
        if (pFldFEscritorio)
            clsW.Fields(DBAdvogadosDicInfo.Escritorio, m_FEscritorio, ETiposCampos.FNumberNull);
        if (pFldFEstagiario || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Estagiario, m_FEstagiario, ETiposCampos.FBoolean);
        if (pFldFOAB)
            clsW.Fields(DBAdvogadosDicInfo.OAB, m_FOAB, ETiposCampos.FString);
        if (pFldFNomeCompleto)
            clsW.Fields(DBAdvogadosDicInfo.NomeCompleto, m_FNomeCompleto, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBAdvogadosDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBAdvogadosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBAdvogadosDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFBairro)
            clsW.Fields(DBAdvogadosDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCTPSSerie)
            clsW.Fields(DBAdvogadosDicInfo.CTPSSerie, m_FCTPSSerie, ETiposCampos.FString);
        if (pFldFCTPS)
            clsW.Fields(DBAdvogadosDicInfo.CTPS, m_FCTPS, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBAdvogadosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBAdvogadosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFComissao)
            clsW.Fields(DBAdvogadosDicInfo.Comissao, m_FComissao, ETiposCampos.FNumberNull);
        if (pFldFDtInicio)
            clsW.Fields(DBAdvogadosDicInfo.DtInicio, m_FDtInicio, ETiposCampos.FDate);
        if (pFldFDtFim)
            clsW.Fields(DBAdvogadosDicInfo.DtFim, m_FDtFim, ETiposCampos.FDate);
        if (pFldFDtNasc)
            clsW.Fields(DBAdvogadosDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFSalario)
            clsW.Fields(DBAdvogadosDicInfo.Salario, m_FSalario, ETiposCampos.FDecimal);
        if (pFldFSecretaria)
            clsW.Fields(DBAdvogadosDicInfo.Secretaria, m_FSecretaria, ETiposCampos.FString);
        if (pFldFTextoProcuracao)
            clsW.Fields(DBAdvogadosDicInfo.TextoProcuracao, m_FTextoProcuracao, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBAdvogadosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFEspecializacao)
            clsW.Fields(DBAdvogadosDicInfo.Especializacao, m_FEspecializacao, ETiposCampos.FString);
        if (pFldFPasta)
            clsW.Fields(DBAdvogadosDicInfo.Pasta, m_FPasta, ETiposCampos.FString);
        if (pFldFObservacao)
            clsW.Fields(DBAdvogadosDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFContaBancaria)
            clsW.Fields(DBAdvogadosDicInfo.ContaBancaria, m_FContaBancaria, ETiposCampos.FString);
        if (pFldFParcTop || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.ParcTop, m_FParcTop, ETiposCampos.FBoolean);
        if (pFldFClass)
            clsW.Fields(DBAdvogadosDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFTop || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Top, m_FTop, ETiposCampos.FBoolean);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBAdvogadosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Advogados)
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
            clsW.Fields(DBAdvogadosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAdvogadosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAdvogadosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAdvogadosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAdvogadosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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