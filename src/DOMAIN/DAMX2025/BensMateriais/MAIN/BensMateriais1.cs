// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBBensMateriais : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_BensMateriais)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBBensMateriais();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_BensMateriais
    [XmlIgnore]
    public string TabelaNome => "BensMateriais";

    public DBBensMateriais()
    {
    }

#endregion
    public DBBensMateriais(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBBensMateriais(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBBensMateriais(in string? sqlWhere, SqlConnection? oCnn)
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
#region GravarDados_BensMateriais
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFBensClassificacao || pFldFDataCompra || pFldFDataFimDaGarantia || pFldFNFNRO || pFldFFornecedor || pFldFValorBem || pFldFNroSerieProduto || pFldFComprador || pFldFCidade || pFldFGarantiaLoja || pFldFDataTerminoDaGarantiaDaLoja || pFldFObservacoes || pFldFNomeVendedor || pFldFBold))
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
            throw new Exception("Campo 'bmtNome' está vazio!");
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
            clsW.Fields(DBBensMateriaisDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFBensClassificacao)
            clsW.Fields(DBBensMateriaisDicInfo.BensClassificacao, m_FBensClassificacao, ETiposCampos.FNumberNull);
        if (pFldFDataCompra)
            clsW.Fields(DBBensMateriaisDicInfo.DataCompra, m_FDataCompra, ETiposCampos.FDate);
        if (pFldFDataFimDaGarantia)
            clsW.Fields(DBBensMateriaisDicInfo.DataFimDaGarantia, m_FDataFimDaGarantia, ETiposCampos.FDate);
        if (pFldFNFNRO)
            clsW.Fields(DBBensMateriaisDicInfo.NFNRO, m_FNFNRO, ETiposCampos.FString);
        if (pFldFFornecedor)
            clsW.Fields(DBBensMateriaisDicInfo.Fornecedor, m_FFornecedor, ETiposCampos.FNumberNull);
        if (pFldFValorBem)
            clsW.Fields(DBBensMateriaisDicInfo.ValorBem, m_FValorBem, ETiposCampos.FDecimal);
        if (pFldFNroSerieProduto)
            clsW.Fields(DBBensMateriaisDicInfo.NroSerieProduto, m_FNroSerieProduto, ETiposCampos.FString);
        if (pFldFComprador)
            clsW.Fields(DBBensMateriaisDicInfo.Comprador, m_FComprador, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBBensMateriaisDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFGarantiaLoja || ID.IsEmptyIDNumber())
            clsW.Fields(DBBensMateriaisDicInfo.GarantiaLoja, m_FGarantiaLoja, ETiposCampos.FBoolean);
        if (pFldFDataTerminoDaGarantiaDaLoja)
            clsW.Fields(DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja, m_FDataTerminoDaGarantiaDaLoja, ETiposCampos.FDate);
        if (pFldFObservacoes)
            clsW.Fields(DBBensMateriaisDicInfo.Observacoes, m_FObservacoes, ETiposCampos.FString);
        if (pFldFNomeVendedor)
            clsW.Fields(DBBensMateriaisDicInfo.NomeVendedor, m_FNomeVendedor, ETiposCampos.FString);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBBensMateriaisDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBBensMateriaisDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_BensMateriais)
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
            clsW.Fields(DBBensMateriaisDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBBensMateriaisDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBBensMateriaisDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBBensMateriaisDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBBensMateriaisDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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