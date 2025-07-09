// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBOponentes : VSexo, ICadastrosAuditor, IAuditor
{
#region TableDefinition_Oponentes
    [XmlIgnore]
    public string TabelaNome => "Oponentes";

    public DBOponentes()
    {
    }

#endregion
    public DBOponentes(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBOponentes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBOponentes(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Oponentes
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFEMPFuncao || pFldFCTPSNumero || pFldFSite || pFldFCTPSSerie || pFldFNome || pFldFAdv || pFldFEMPCliente || pFldFIDRep || pFldFPIS || pFldFContato || pFldFCNPJ || pFldFRG || pFldFJuridica || pFldFTipo || pFldFSexo || pFldFCPF || pFldFEndereco || pFldFFone || pFldFFax || pFldFCidade || pFldFBairro || pFldFCEP || pFldFInscEst || pFldFObservacao || pFldFEMail || pFldFClass || pFldFTop || pFldFEtiqueta || pFldFBold))
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
            throw new Exception("Campo 'opoNome' está vazio!");
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
        if (pFldFEMPFuncao)
            clsW.Fields(DBOponentesDicInfo.EMPFuncao, m_FEMPFuncao, ETiposCampos.FNumberNull);
        if (pFldFCTPSNumero)
            clsW.Fields(DBOponentesDicInfo.CTPSNumero, m_FCTPSNumero, ETiposCampos.FString);
        if (pFldFSite)
            clsW.Fields(DBOponentesDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFCTPSSerie)
            clsW.Fields(DBOponentesDicInfo.CTPSSerie, m_FCTPSSerie, ETiposCampos.FString);
        if (pFldFNome)
            clsW.Fields(DBOponentesDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFAdv)
            clsW.Fields(DBOponentesDicInfo.Adv, m_FAdv, ETiposCampos.FNumberNull);
        if (pFldFEMPCliente)
            clsW.Fields(DBOponentesDicInfo.EMPCliente, m_FEMPCliente, ETiposCampos.FNumberNull);
        if (pFldFIDRep)
            clsW.Fields(DBOponentesDicInfo.IDRep, m_FIDRep, ETiposCampos.FNumberNull);
        if (pFldFPIS)
            clsW.Fields(DBOponentesDicInfo.PIS, m_FPIS, ETiposCampos.FString);
        if (pFldFContato)
            clsW.Fields(DBOponentesDicInfo.Contato, m_FContato, ETiposCampos.FString);
        if (pFldFCNPJ)
            clsW.Fields(DBOponentesDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBOponentesDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFJuridica || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Juridica, m_FJuridica, ETiposCampos.FBoolean);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFCPF)
            clsW.Fields(DBOponentesDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBOponentesDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBOponentesDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBOponentesDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBOponentesDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFBairro)
            clsW.Fields(DBOponentesDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBOponentesDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFInscEst)
            clsW.Fields(DBOponentesDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFObservacao)
            clsW.Fields(DBOponentesDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBOponentesDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBOponentesDicInfo.Class, sex.m_FClass, ETiposCampos.FString);
        if (pFldFTop || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Top, m_FTop, ETiposCampos.FBoolean);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBOponentesDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Oponentes)
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
            clsW.Fields(DBOponentesDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBOponentesDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBOponentesDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBOponentesDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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