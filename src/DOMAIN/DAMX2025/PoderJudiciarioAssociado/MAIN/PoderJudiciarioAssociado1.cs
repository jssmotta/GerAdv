// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PoderJudiciarioAssociado)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBPoderJudiciarioAssociado();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_PoderJudiciarioAssociado
    [XmlIgnore]
    public string TabelaNome => "PoderJudiciarioAssociado";

    public DBPoderJudiciarioAssociado()
    {
    }

#endregion
    public DBPoderJudiciarioAssociado(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBPoderJudiciarioAssociado(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql))
        {
            if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
            {
                using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
                if (ds != null)
                    CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
            }
            else
            {
                throw new Exception("Erro de parâmetros sqlWhere: PoderJudiciarioAssociado");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#if (forWeb)
public int Update(SqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_PoderJudiciarioAssociado
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFJustica || pFldFJusticaNome || pFldFArea || pFldFAreaNome || pFldFTribunal || pFldFTribunalNome || pFldFForo || pFldFForoNome || pFldFCidade || pFldFSubDivisaoNome || pFldFCidadeNome || pFldFSubDivisao || pFldFTipo))
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
        if (pFldFJustica)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Justica, m_FJustica, ETiposCampos.FNumberNull);
        if (pFldFJusticaNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.JusticaNome, m_FJusticaNome, ETiposCampos.FString);
        if (pFldFArea)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Area, m_FArea, ETiposCampos.FNumberNull);
        if (pFldFAreaNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.AreaNome, m_FAreaNome, ETiposCampos.FString);
        if (pFldFTribunal)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Tribunal, m_FTribunal, ETiposCampos.FNumberNull);
        if (pFldFTribunalNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.TribunalNome, m_FTribunalNome, ETiposCampos.FString);
        if (pFldFForo)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Foro, m_FForo, ETiposCampos.FNumberNull);
        if (pFldFForoNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.ForoNome, m_FForoNome, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFSubDivisaoNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome, m_FSubDivisaoNome, ETiposCampos.FString);
        if (pFldFCidadeNome)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.CidadeNome, m_FCidadeNome, ETiposCampos.FString);
        if (pFldFSubDivisao)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.SubDivisao, m_FSubDivisao, ETiposCampos.FNumberNull);
        if (pFldFTipo)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Tipo, m_FTipo, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PoderJudiciarioAssociado)
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
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBPoderJudiciarioAssociadoDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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