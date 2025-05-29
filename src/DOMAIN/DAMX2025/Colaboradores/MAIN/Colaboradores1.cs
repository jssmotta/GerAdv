// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBColaboradores : VSexo, ICadastrosAuditor, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Colaboradores)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBColaboradores();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Colaboradores
    [XmlIgnore]
    public string TabelaNome => "Colaboradores";

    public DBColaboradores()
    {
    }

#endregion
    public DBColaboradores(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBColaboradores(in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBColaboradores(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_Colaboradores
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCargo || pFldFCliente || pFldFSexo || pFldFNome || pFldFCPF || pFldFRG || pFldFDtNasc || pFldFIdade || pFldFEndereco || pFldFBairro || pFldFCEP || pFldFCidade || pFldFFone || pFldFObservacao || pFldFEMail || pFldFCNH || pFldFClass || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'colNome' está vazio!");
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

        if (pFldFCargo)
            clsW.Fields(DBColaboradoresDicInfo.Cargo, m_FCargo, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBColaboradoresDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBColaboradoresDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFNome)
            clsW.Fields(DBColaboradoresDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBColaboradoresDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBColaboradoresDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFDtNasc)
            clsW.Fields(DBColaboradoresDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFIdade)
            clsW.Fields(DBColaboradoresDicInfo.Idade, m_FIdade, ETiposCampos.FNumberNull);
        if (pFldFEndereco)
            clsW.Fields(DBColaboradoresDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBColaboradoresDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBColaboradoresDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBColaboradoresDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFFone)
            clsW.Fields(DBColaboradoresDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFObservacao)
            clsW.Fields(DBColaboradoresDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBColaboradoresDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFCNH)
            clsW.Fields(DBColaboradoresDicInfo.CNH, m_FCNH, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBColaboradoresDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBColaboradoresDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBColaboradoresDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBColaboradoresDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Colaboradores)
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
            clsW.Fields(DBColaboradoresDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBColaboradoresDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBColaboradoresDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBColaboradoresDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBColaboradoresDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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