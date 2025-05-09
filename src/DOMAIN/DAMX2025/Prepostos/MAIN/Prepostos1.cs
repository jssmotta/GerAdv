// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBPrepostos : VSexo, ICadastrosAuditor, IAuditor, IListagemCidade
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Prepostos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBPrepostos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Prepostos
    [XmlIgnore]
    public string TabelaNome => "Prepostos";

    public DBPrepostos()
    {
    }

#endregion
    public DBPrepostos(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBPrepostos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
        else
        {
            using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[{PTabelaNome}] (NOLOCK) WHERE [{CampoNome}]  COLLATE SQL_Latin1_General_CP1_CI_AI  like @CampoNome", oCnn);
            cmd.Parameters.AddWithValue("@CampoNome", cNome?.trim() ?? string.Empty);
            using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    public DBPrepostos(in string? sqlWhere, SqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#if (forWeb)
public int Update(SqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_Prepostos
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFFuncao || pFldFSetor || pFldFDtNasc || pFldFQualificacao || pFldFSexo || pFldFIdade || pFldFCPF || pFldFRG || pFldFPeriodo_Ini || pFldFPeriodo_Fim || pFldFRegistro || pFldFCTPSNumero || pFldFCTPSSerie || pFldFCTPSDtEmissao || pFldFPIS || pFldFSalario || pFldFLiberaAgenda || pFldFObservacao || pFldFEndereco || pFldFBairro || pFldFCidade || pFldFCEP || pFldFFone || pFldFFax || pFldFEMail || pFldFPai || pFldFMae || pFldFClass || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'preNome' está vazio!");
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
        if (pFldFNome)
            clsW.Fields(DBPrepostosDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFFuncao)
            clsW.Fields(DBPrepostosDicInfo.Funcao, m_FFuncao, ETiposCampos.FNumberNull);
        if (pFldFSetor)
            clsW.Fields(DBPrepostosDicInfo.Setor, m_FSetor, ETiposCampos.FNumberNull);
        if (pFldFDtNasc)
            clsW.Fields(DBPrepostosDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFQualificacao)
            clsW.Fields(DBPrepostosDicInfo.Qualificacao, m_FQualificacao, ETiposCampos.FString);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFIdade)
            clsW.Fields(DBPrepostosDicInfo.Idade, m_FIdade, ETiposCampos.FNumberNull);
        if (pFldFCPF)
            clsW.Fields(DBPrepostosDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBPrepostosDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFPeriodo_Ini)
            clsW.Fields(DBPrepostosDicInfo.Periodo_Ini, m_FPeriodo_Ini, ETiposCampos.FDate);
        if (pFldFPeriodo_Fim)
            clsW.Fields(DBPrepostosDicInfo.Periodo_Fim, m_FPeriodo_Fim, ETiposCampos.FDate);
        if (pFldFRegistro)
            clsW.Fields(DBPrepostosDicInfo.Registro, m_FRegistro, ETiposCampos.FString);
        if (pFldFCTPSNumero)
            clsW.Fields(DBPrepostosDicInfo.CTPSNumero, m_FCTPSNumero, ETiposCampos.FString);
        if (pFldFCTPSSerie)
            clsW.Fields(DBPrepostosDicInfo.CTPSSerie, m_FCTPSSerie, ETiposCampos.FString);
        if (pFldFCTPSDtEmissao)
            clsW.Fields(DBPrepostosDicInfo.CTPSDtEmissao, m_FCTPSDtEmissao, ETiposCampos.FDate);
        if (pFldFPIS)
            clsW.Fields(DBPrepostosDicInfo.PIS, m_FPIS, ETiposCampos.FString);
        if (pFldFSalario)
            clsW.Fields(DBPrepostosDicInfo.Salario, m_FSalario, ETiposCampos.FDecimal);
        if (pFldFLiberaAgenda || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.LiberaAgenda, m_FLiberaAgenda, ETiposCampos.FBoolean);
        if (pFldFObservacao)
            clsW.Fields(DBPrepostosDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBPrepostosDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBPrepostosDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBPrepostosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBPrepostosDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBPrepostosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBPrepostosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBPrepostosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFPai)
            clsW.Fields(DBPrepostosDicInfo.Pai, m_FPai, ETiposCampos.FString);
        if (pFldFMae)
            clsW.Fields(DBPrepostosDicInfo.Mae, m_FMae, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBPrepostosDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBPrepostosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Prepostos)
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
            clsW.Fields(DBPrepostosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBPrepostosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBPrepostosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBPrepostosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBPrepostosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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