// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBModelosDocumentos : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ModelosDocumentos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBModelosDocumentos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ModelosDocumentos
    [XmlIgnore]
    public string TabelaNome => "ModelosDocumentos";

    public DBModelosDocumentos()
    {
    }

#endregion
    public DBModelosDocumentos(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBModelosDocumentos(in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBModelosDocumentos(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_ModelosDocumentos
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFRemuneracao || pFldFAssinatura || pFldFHeader || pFldFFooter || pFldFExtra1 || pFldFExtra2 || pFldFExtra3 || pFldFOutorgante || pFldFOutorgados || pFldFPoderes || pFldFObjeto || pFldFTitulo || pFldFTestemunhas || pFldFTipoModeloDocumento || pFldFCSS))
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
            throw new Exception("Campo 'mdcNome' está vazio!");
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
        if (pFldFNome)
            clsW.Fields(DBModelosDocumentosDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFRemuneracao)
            clsW.Fields(DBModelosDocumentosDicInfo.Remuneracao, m_FRemuneracao, ETiposCampos.FString);
        if (pFldFAssinatura)
            clsW.Fields(DBModelosDocumentosDicInfo.Assinatura, m_FAssinatura, ETiposCampos.FString);
        if (pFldFHeader)
            clsW.Fields(DBModelosDocumentosDicInfo.Header, m_FHeader, ETiposCampos.FString);
        if (pFldFFooter)
            clsW.Fields(DBModelosDocumentosDicInfo.Footer, m_FFooter, ETiposCampos.FString);
        if (pFldFExtra1)
            clsW.Fields(DBModelosDocumentosDicInfo.Extra1, m_FExtra1, ETiposCampos.FString);
        if (pFldFExtra2)
            clsW.Fields(DBModelosDocumentosDicInfo.Extra2, m_FExtra2, ETiposCampos.FString);
        if (pFldFExtra3)
            clsW.Fields(DBModelosDocumentosDicInfo.Extra3, m_FExtra3, ETiposCampos.FString);
        if (pFldFOutorgante)
            clsW.Fields(DBModelosDocumentosDicInfo.Outorgante, m_FOutorgante, ETiposCampos.FString);
        if (pFldFOutorgados)
            clsW.Fields(DBModelosDocumentosDicInfo.Outorgados, m_FOutorgados, ETiposCampos.FString);
        if (pFldFPoderes)
            clsW.Fields(DBModelosDocumentosDicInfo.Poderes, m_FPoderes, ETiposCampos.FString);
        if (pFldFObjeto)
            clsW.Fields(DBModelosDocumentosDicInfo.Objeto, m_FObjeto, ETiposCampos.FString);
        if (pFldFTitulo)
            clsW.Fields(DBModelosDocumentosDicInfo.Titulo, m_FTitulo, ETiposCampos.FString);
        if (pFldFTestemunhas)
            clsW.Fields(DBModelosDocumentosDicInfo.Testemunhas, m_FTestemunhas, ETiposCampos.FString);
        if (pFldFTipoModeloDocumento)
            clsW.Fields(DBModelosDocumentosDicInfo.TipoModeloDocumento, m_FTipoModeloDocumento, ETiposCampos.FNumberNull);
        if (pFldFCSS)
            clsW.Fields(DBModelosDocumentosDicInfo.CSS, m_FCSS, ETiposCampos.FString);
        if (pFldFGUID)
            clsW.Fields(DBModelosDocumentosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ModelosDocumentos)
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
            clsW.Fields(DBModelosDocumentosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBModelosDocumentosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBModelosDocumentosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBModelosDocumentosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBModelosDocumentosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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