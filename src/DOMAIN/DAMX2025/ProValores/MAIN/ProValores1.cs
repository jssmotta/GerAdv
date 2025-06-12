// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBProValores : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ProValores)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBProValores();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ProValores
    [XmlIgnore]
    public string TabelaNome => "ProValores";

    public DBProValores()
    {
    }

#endregion
    public DBProValores(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBProValores(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        // Tracking: 250605-3
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql))
        {
            if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
            {
                using var ds = ConfiguracoesDBT.GetDataTable(parameters, fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
                if (ds != null)
                    CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
            }
            else
            {
                throw new Exception("Erro de parâmetros sqlWhere: ProValores");
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
public int Update(MsiSqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_ProValores
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFProcesso || pFldFTipoValorProcesso || pFldFIndice || pFldFIgnorar || pFldFData || pFldFValorOriginal || pFldFPercMulta || pFldFValorMulta || pFldFPercJuros || pFldFValorOriginalCorrigidoIndice || pFldFValorMultaCorrigido || pFldFValorJurosCorrigido || pFldFValorFinal || pFldFDataUltimaCorrecao))
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
        if (pFldFProcesso)
            clsW.Fields(DBProValoresDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFTipoValorProcesso)
            clsW.Fields(DBProValoresDicInfo.TipoValorProcesso, m_FTipoValorProcesso, ETiposCampos.FNumberNull);
        if (pFldFIndice)
            clsW.Fields(DBProValoresDicInfo.Indice, m_FIndice, ETiposCampos.FString);
        if (pFldFIgnorar || ID.IsEmptyIDNumber())
            clsW.Fields(DBProValoresDicInfo.Ignorar, m_FIgnorar, ETiposCampos.FBoolean);
        if (pFldFData)
            clsW.Fields(DBProValoresDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFValorOriginal)
            clsW.Fields(DBProValoresDicInfo.ValorOriginal, m_FValorOriginal, ETiposCampos.FDecimal);
        if (pFldFPercMulta)
            clsW.Fields(DBProValoresDicInfo.PercMulta, m_FPercMulta, ETiposCampos.FDecimal);
        if (pFldFValorMulta)
            clsW.Fields(DBProValoresDicInfo.ValorMulta, m_FValorMulta, ETiposCampos.FDecimal);
        if (pFldFPercJuros)
            clsW.Fields(DBProValoresDicInfo.PercJuros, m_FPercJuros, ETiposCampos.FDecimal);
        if (pFldFValorOriginalCorrigidoIndice)
            clsW.Fields(DBProValoresDicInfo.ValorOriginalCorrigidoIndice, m_FValorOriginalCorrigidoIndice, ETiposCampos.FDecimal);
        if (pFldFValorMultaCorrigido)
            clsW.Fields(DBProValoresDicInfo.ValorMultaCorrigido, m_FValorMultaCorrigido, ETiposCampos.FDecimal);
        if (pFldFValorJurosCorrigido)
            clsW.Fields(DBProValoresDicInfo.ValorJurosCorrigido, m_FValorJurosCorrigido, ETiposCampos.FDecimal);
        if (pFldFValorFinal)
            clsW.Fields(DBProValoresDicInfo.ValorFinal, m_FValorFinal, ETiposCampos.FDecimal);
        if (pFldFDataUltimaCorrecao)
            clsW.Fields(DBProValoresDicInfo.DataUltimaCorrecao, m_FDataUltimaCorrecao, ETiposCampos.FDate);
        if (pFldFGUID)
            clsW.Fields(DBProValoresDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ProValores)
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
            clsW.Fields(DBProValoresDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBProValoresDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBProValoresDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBProValoresDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBProValoresDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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