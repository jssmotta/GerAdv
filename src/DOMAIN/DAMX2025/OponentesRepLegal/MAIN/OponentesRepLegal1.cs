// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBOponentesRepLegal : VSexo, ICadastrosAuditor, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_OponentesRepLegal)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBOponentesRepLegal();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_OponentesRepLegal
    [XmlIgnore]
    public string TabelaNome => "OponentesRepLegal";

    public DBOponentesRepLegal()
    {
    }

#endregion
    public DBOponentesRepLegal(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBOponentesRepLegal(in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBOponentesRepLegal(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_OponentesRepLegal
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFFone || pFldFOponente || pFldFSexo || pFldFCPF || pFldFRG || pFldFEndereco || pFldFBairro || pFldFCEP || pFldFCidade || pFldFFax || pFldFEMail || pFldFSite || pFldFObservacao || pFldFBold))
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
            throw new Exception("Campo 'oprNome' está vazio!");
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

        if (pFldFNome)
            clsW.Fields(DBOponentesRepLegalDicInfo.Nome, sex.m_FNome, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBOponentesRepLegalDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFOponente)
            clsW.Fields(DBOponentesRepLegalDicInfo.Oponente, m_FOponente, ETiposCampos.FNumberNull);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesRepLegalDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFCPF)
            clsW.Fields(DBOponentesRepLegalDicInfo.CPF, sex.m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBOponentesRepLegalDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBOponentesRepLegalDicInfo.Endereco, sex.m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBOponentesRepLegalDicInfo.Bairro, sex.m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBOponentesRepLegalDicInfo.CEP, sex.m_FCEP, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBOponentesRepLegalDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFFax)
            clsW.Fields(DBOponentesRepLegalDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBOponentesRepLegalDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFSite)
            clsW.Fields(DBOponentesRepLegalDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFObservacao)
            clsW.Fields(DBOponentesRepLegalDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesRepLegalDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_OponentesRepLegal)
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
            clsW.Fields(DBOponentesRepLegalDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBOponentesRepLegalDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBOponentesRepLegalDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBOponentesRepLegalDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBOponentesRepLegalDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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