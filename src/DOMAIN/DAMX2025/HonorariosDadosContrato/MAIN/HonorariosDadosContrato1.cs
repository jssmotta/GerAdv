// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_HonorariosDadosContrato)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBHonorariosDadosContrato();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_HonorariosDadosContrato
    [XmlIgnore]
    public string TabelaNome => "HonorariosDadosContrato";

    public DBHonorariosDadosContrato()
    {
    }

#endregion
    public DBHonorariosDadosContrato(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBHonorariosDadosContrato(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: HonorariosDadosContrato");
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
#region GravarDados_HonorariosDadosContrato
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCliente || pFldFFixo || pFldFVariavel || pFldFPercSucesso || pFldFProcesso || pFldFArquivoContrato || pFldFTextoContrato || pFldFValorFixo || pFldFObservacao || pFldFDataContrato))
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
        if (pFldFCliente)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFFixo || ID.IsEmptyIDNumber())
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Fixo, m_FFixo, ETiposCampos.FBoolean);
        if (pFldFVariavel || ID.IsEmptyIDNumber())
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Variavel, m_FVariavel, ETiposCampos.FBoolean);
        if (pFldFPercSucesso)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.PercSucesso, m_FPercSucesso, ETiposCampos.FDecimal);
        if (pFldFProcesso)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFArquivoContrato)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.ArquivoContrato, m_FArquivoContrato, ETiposCampos.FString);
        if (pFldFTextoContrato)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.TextoContrato, m_FTextoContrato, ETiposCampos.FString);
        if (pFldFValorFixo)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.ValorFixo, m_FValorFixo, ETiposCampos.FDecimal);
        if (pFldFObservacao)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFDataContrato)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.DataContrato, m_FDataContrato, ETiposCampos.FDate);
        if (pFldFGUID)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_HonorariosDadosContrato)
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
            clsW.Fields(DBHonorariosDadosContratoDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBHonorariosDadosContratoDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBHonorariosDadosContratoDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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