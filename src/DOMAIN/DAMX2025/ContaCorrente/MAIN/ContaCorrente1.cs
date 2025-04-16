// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBContaCorrente : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ContaCorrente)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBContaCorrente();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ContaCorrente
    [XmlIgnore]
    public string TabelaNome => "ContaCorrente";

    public DBContaCorrente()
    {
    }

#endregion
    public DBContaCorrente(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBContaCorrente(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: ContaCorrente");
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
#region GravarDados_ContaCorrente
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCIAcordo || pFldFQuitado || pFldFIDContrato || pFldFQuitadoID || pFldFDebitoID || pFldFLivroCaixaID || pFldFSucumbencia || pFldFDistRegra || pFldFDtOriginal || pFldFProcesso || pFldFParcelaX || pFldFValor || pFldFData || pFldFCliente || pFldFHistorico || pFldFContrato || pFldFPago || pFldFDistribuir || pFldFLC || pFldFIDHTrab || pFldFNroParcelas || pFldFValorPrincipal || pFldFParcelaPrincipalID || pFldFHide || pFldFDataPgto))
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
        if (pFldFCIAcordo)
            clsW.Fields(DBContaCorrenteDicInfo.CIAcordo, m_FCIAcordo, ETiposCampos.FNumberNull);
        if (pFldFQuitado || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Quitado, m_FQuitado, ETiposCampos.FBoolean);
        if (pFldFIDContrato)
            clsW.Fields(DBContaCorrenteDicInfo.IDContrato, m_FIDContrato, ETiposCampos.FNumberNull);
        if (pFldFQuitadoID)
            clsW.Fields(DBContaCorrenteDicInfo.QuitadoID, m_FQuitadoID, ETiposCampos.FNumberNull);
        if (pFldFDebitoID)
            clsW.Fields(DBContaCorrenteDicInfo.DebitoID, m_FDebitoID, ETiposCampos.FNumberNull);
        if (pFldFLivroCaixaID)
            clsW.Fields(DBContaCorrenteDicInfo.LivroCaixaID, m_FLivroCaixaID, ETiposCampos.FNumberNull);
        if (pFldFSucumbencia || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Sucumbencia, m_FSucumbencia, ETiposCampos.FBoolean);
        if (pFldFDistRegra || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.DistRegra, m_FDistRegra, ETiposCampos.FBoolean);
        if (pFldFDtOriginal)
            clsW.Fields(DBContaCorrenteDicInfo.DtOriginal, m_FDtOriginal, ETiposCampos.FDate);
        if (pFldFProcesso)
            clsW.Fields(DBContaCorrenteDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFParcelaX)
            clsW.Fields(DBContaCorrenteDicInfo.ParcelaX, m_FParcelaX, ETiposCampos.FNumberNull);
        if (pFldFValor)
            clsW.Fields(DBContaCorrenteDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFData)
            clsW.Fields(DBContaCorrenteDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFCliente)
            clsW.Fields(DBContaCorrenteDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFHistorico)
            clsW.Fields(DBContaCorrenteDicInfo.Historico, m_FHistorico, ETiposCampos.FString);
        if (pFldFContrato || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Contrato, m_FContrato, ETiposCampos.FBoolean);
        if (pFldFPago || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Pago, m_FPago, ETiposCampos.FBoolean);
        if (pFldFDistribuir || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Distribuir, m_FDistribuir, ETiposCampos.FBoolean);
        if (pFldFLC || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.LC, m_FLC, ETiposCampos.FBoolean);
        if (pFldFIDHTrab)
            clsW.Fields(DBContaCorrenteDicInfo.IDHTrab, m_FIDHTrab, ETiposCampos.FNumberNull);
        if (pFldFNroParcelas)
            clsW.Fields(DBContaCorrenteDicInfo.NroParcelas, m_FNroParcelas, ETiposCampos.FNumberNull);
        if (pFldFValorPrincipal)
            clsW.Fields(DBContaCorrenteDicInfo.ValorPrincipal, m_FValorPrincipal, ETiposCampos.FDecimal);
        if (pFldFParcelaPrincipalID)
            clsW.Fields(DBContaCorrenteDicInfo.ParcelaPrincipalID, m_FParcelaPrincipalID, ETiposCampos.FNumberNull);
        if (pFldFHide || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Hide, m_FHide, ETiposCampos.FBoolean);
        if (pFldFDataPgto)
            clsW.Fields(DBContaCorrenteDicInfo.DataPgto, m_FDataPgto, ETiposCampos.FDate);
        if (pFldFGUID)
            clsW.Fields(DBContaCorrenteDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ContaCorrente)
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
            clsW.Fields(DBContaCorrenteDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBContaCorrenteDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBContaCorrenteDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBContaCorrenteDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBContaCorrenteDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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