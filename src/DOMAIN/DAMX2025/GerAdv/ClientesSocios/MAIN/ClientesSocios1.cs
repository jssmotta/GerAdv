// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBClientesSocios : VSexo, ICadastrosAuditor, IAuditor
{
#region TableDefinition_ClientesSocios
    [XmlIgnore]
    public string TabelaNome => "ClientesSocios";

    public DBClientesSocios()
    {
    }

#endregion
    public DBClientesSocios(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBClientesSocios(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBClientesSocios(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_ClientesSocios
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFSomenteRepresentante || pFldFIdade || pFldFIsRepresentanteLegal || pFldFQualificacao || pFldFSexo || pFldFDtNasc || pFldFNome || pFldFSite || pFldFRepresentanteLegal || pFldFCliente || pFldFEndereco || pFldFBairro || pFldFCEP || pFldFCidade || pFldFRG || pFldFCPF || pFldFFone || pFldFParticipacao || pFldFCargo || pFldFEMail || pFldFObs || pFldFCNH || pFldFDataContrato || pFldFCNPJ || pFldFInscEst || pFldFSocioEmpresaAdminNome || pFldFEnderecoSocio || pFldFBairroSocio || pFldFCEPSocio || pFldFCidadeSocio || pFldFRGDataExp || pFldFSocioEmpresaAdminSomente || pFldFTipo || pFldFFax || pFldFClass || pFldFEtiqueta || pFldFAni || pFldFBold))
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
            throw new Exception("Campo 'cscNome' está vazio!");
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
        if (pFldFSomenteRepresentante || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.SomenteRepresentante, m_FSomenteRepresentante, ETiposCampos.FBoolean);
        if (pFldFIdade)
            clsW.Fields(DBClientesSociosDicInfo.Idade, m_FIdade, ETiposCampos.FNumberNull);
        if (pFldFIsRepresentanteLegal || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.IsRepresentanteLegal, m_FIsRepresentanteLegal, ETiposCampos.FBoolean);
        if (pFldFQualificacao)
            clsW.Fields(DBClientesSociosDicInfo.Qualificacao, m_FQualificacao, ETiposCampos.FString);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFDtNasc)
            clsW.Fields(DBClientesSociosDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFNome)
            clsW.Fields(DBClientesSociosDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFSite)
            clsW.Fields(DBClientesSociosDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFRepresentanteLegal)
            clsW.Fields(DBClientesSociosDicInfo.RepresentanteLegal, m_FRepresentanteLegal, ETiposCampos.FString);
        if (pFldFCliente)
            clsW.Fields(DBClientesSociosDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFEndereco)
            clsW.Fields(DBClientesSociosDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBClientesSociosDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBClientesSociosDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBClientesSociosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFRG)
            clsW.Fields(DBClientesSociosDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBClientesSociosDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBClientesSociosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFParticipacao)
            clsW.Fields(DBClientesSociosDicInfo.Participacao, m_FParticipacao, ETiposCampos.FString);
        if (pFldFCargo)
            clsW.Fields(DBClientesSociosDicInfo.Cargo, m_FCargo, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBClientesSociosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFObs)
            clsW.Fields(DBClientesSociosDicInfo.Obs, m_FObs, ETiposCampos.FString);
        if (pFldFCNH)
            clsW.Fields(DBClientesSociosDicInfo.CNH, m_FCNH, ETiposCampos.FString);
        if (pFldFDataContrato)
            clsW.Fields(DBClientesSociosDicInfo.DataContrato, m_FDataContrato, ETiposCampos.FDate);
        if (pFldFCNPJ)
            clsW.Fields(DBClientesSociosDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFInscEst)
            clsW.Fields(DBClientesSociosDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFSocioEmpresaAdminNome)
            clsW.Fields(DBClientesSociosDicInfo.SocioEmpresaAdminNome, m_FSocioEmpresaAdminNome, ETiposCampos.FString);
        if (pFldFEnderecoSocio)
            clsW.Fields(DBClientesSociosDicInfo.EnderecoSocio, m_FEnderecoSocio, ETiposCampos.FString);
        if (pFldFBairroSocio)
            clsW.Fields(DBClientesSociosDicInfo.BairroSocio, m_FBairroSocio, ETiposCampos.FString);
        if (pFldFCEPSocio)
            clsW.Fields(DBClientesSociosDicInfo.CEPSocio, m_FCEPSocio, ETiposCampos.FString);
        if (pFldFCidadeSocio)
            clsW.Fields(DBClientesSociosDicInfo.CidadeSocio, m_FCidadeSocio, ETiposCampos.FNumberNull);
        if (pFldFRGDataExp)
            clsW.Fields(DBClientesSociosDicInfo.RGDataExp, m_FRGDataExp, ETiposCampos.FDate);
        if (pFldFSocioEmpresaAdminSomente || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.SocioEmpresaAdminSomente, m_FSocioEmpresaAdminSomente, ETiposCampos.FBoolean);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFFax)
            clsW.Fields(DBClientesSociosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBClientesSociosDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBClientesSociosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_ClientesSocios)
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
            clsW.Fields(DBClientesSociosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBClientesSociosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBClientesSociosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBClientesSociosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBClientesSociosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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