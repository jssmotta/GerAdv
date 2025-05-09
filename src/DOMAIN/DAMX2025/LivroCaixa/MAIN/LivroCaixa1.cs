// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixa : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_LivroCaixa)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBLivroCaixa();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_LivroCaixa
    [XmlIgnore]
    public string TabelaNome => "LivroCaixa";

    public DBLivroCaixa()
    {
    }

#endregion
    public DBLivroCaixa(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBLivroCaixa(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: LivroCaixa");
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
#region GravarDados_LivroCaixa
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFIDDes || pFldFPessoal || pFldFAjuste || pFldFIDHon || pFldFIDHonParc || pFldFIDHonSuc || pFldFData || pFldFProcesso || pFldFValor || pFldFTipo || pFldFHistorico || pFldFPrevisto || pFldFGrupo))
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

        if (pFldFIDDes)
            clsW.Fields(DBLivroCaixaDicInfo.IDDes, m_FIDDes, ETiposCampos.FNumberNull);
        if (pFldFPessoal)
            clsW.Fields(DBLivroCaixaDicInfo.Pessoal, m_FPessoal, ETiposCampos.FNumberNull);
        if (pFldFAjuste || ID.IsEmptyIDNumber())
            clsW.Fields(DBLivroCaixaDicInfo.Ajuste, m_FAjuste, ETiposCampos.FBoolean);
        if (pFldFIDHon)
            clsW.Fields(DBLivroCaixaDicInfo.IDHon, m_FIDHon, ETiposCampos.FNumberNull);
        if (pFldFIDHonParc)
            clsW.Fields(DBLivroCaixaDicInfo.IDHonParc, m_FIDHonParc, ETiposCampos.FNumberNull);
        if (pFldFIDHonSuc || ID.IsEmptyIDNumber())
            clsW.Fields(DBLivroCaixaDicInfo.IDHonSuc, m_FIDHonSuc, ETiposCampos.FBoolean);
        if (pFldFData)
            clsW.Fields(DBLivroCaixaDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFProcesso)
            clsW.Fields(DBLivroCaixaDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFValor)
            clsW.Fields(DBLivroCaixaDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBLivroCaixaDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFHistorico)
            clsW.Fields(DBLivroCaixaDicInfo.Historico, m_FHistorico, ETiposCampos.FString);
        if (pFldFPrevisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBLivroCaixaDicInfo.Previsto, m_FPrevisto, ETiposCampos.FBoolean);
        if (pFldFGrupo)
            clsW.Fields(DBLivroCaixaDicInfo.Grupo, m_FGrupo, ETiposCampos.FNumberNull);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_LivroCaixa)
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
            clsW.Fields(DBLivroCaixaDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBLivroCaixaDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBLivroCaixaDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBLivroCaixaDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBLivroCaixaDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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