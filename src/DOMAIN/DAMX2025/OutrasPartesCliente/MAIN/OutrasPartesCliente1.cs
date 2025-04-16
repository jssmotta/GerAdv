// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBOutrasPartesCliente : VSexo, ICadastrosAuditor, IAuditor, IListagemCidade
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_OutrasPartesCliente)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBOutrasPartesCliente();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_OutrasPartesCliente
    [XmlIgnore]
    public string TabelaNome => "OutrasPartesCliente";

    public DBOutrasPartesCliente()
    {
    }

#endregion
    public DBOutrasPartesCliente(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBOutrasPartesCliente(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBOutrasPartesCliente(in string? sqlWhere, SqlConnection? oCnn)
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
#region GravarDados_OutrasPartesCliente
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFTerceirizado || pFldFClientePrincipal || pFldFTipo || pFldFSexo || pFldFDtNasc || pFldFCPF || pFldFRG || pFldFCNPJ || pFldFInscEst || pFldFNomeFantasia || pFldFEndereco || pFldFCidade || pFldFCEP || pFldFBairro || pFldFFone || pFldFFax || pFldFEMail || pFldFSite || pFldFClass || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'opcNome' está vazio!");
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
            clsW.Fields(DBOutrasPartesClienteDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFTerceirizado || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Terceirizado, m_FTerceirizado, ETiposCampos.FBoolean);
        if (pFldFClientePrincipal)
            clsW.Fields(DBOutrasPartesClienteDicInfo.ClientePrincipal, m_FClientePrincipal, ETiposCampos.FNumberNull);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFDtNasc)
            clsW.Fields(DBOutrasPartesClienteDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFCPF)
            clsW.Fields(DBOutrasPartesClienteDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBOutrasPartesClienteDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFCNPJ)
            clsW.Fields(DBOutrasPartesClienteDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFInscEst)
            clsW.Fields(DBOutrasPartesClienteDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFNomeFantasia)
            clsW.Fields(DBOutrasPartesClienteDicInfo.NomeFantasia, m_FNomeFantasia, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBOutrasPartesClienteDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBOutrasPartesClienteDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFSite)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBOutrasPartesClienteDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBOutrasPartesClienteDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_OutrasPartesCliente)
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
            clsW.Fields(DBOutrasPartesClienteDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBOutrasPartesClienteDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBOutrasPartesClienteDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBOutrasPartesClienteDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBOutrasPartesClienteDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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