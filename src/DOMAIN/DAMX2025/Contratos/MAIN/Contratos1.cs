// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBContratos : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Contratos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBContratos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Contratos
    [XmlIgnore]
    public string TabelaNome => "Contratos";

    public DBContratos()
    {
    }

#endregion
    public DBContratos(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBContratos(MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql))
        {
            if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
            {
                using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
                if (ds != null)
                    CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
            }
            else
            {
                throw new Exception("Erro de parâmetros sqlWhere: Contratos");
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
#region GravarDados_Contratos
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFProcesso || pFldFCliente || pFldFAdvogado || pFldFDia || pFldFValor || pFldFDataInicio || pFldFDataTermino || pFldFOcultarRelatorio || pFldFPercEscritorio || pFldFValorConsultoria || pFldFTipoCobranca || pFldFProtestar || pFldFJuros || pFldFValorRealizavel || pFldFDOCUMENTO || pFldFEMail1 || pFldFEMail2 || pFldFEMail3 || pFldFPessoa1 || pFldFPessoa2 || pFldFPessoa3 || pFldFOBS || pFldFClienteContrato || pFldFIdExtrangeiro || pFldFChaveContrato || pFldFAvulso || pFldFSuspenso || pFldFMulta || pFldFBold))
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
            clsW.Fields(DBContratosDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBContratosDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFAdvogado)
            clsW.Fields(DBContratosDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFDia)
            clsW.Fields(DBContratosDicInfo.Dia, m_FDia, ETiposCampos.FNumberNull);
        if (pFldFValor)
            clsW.Fields(DBContratosDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFDataInicio)
            clsW.Fields(DBContratosDicInfo.DataInicio, m_FDataInicio, ETiposCampos.FDate);
        if (pFldFDataTermino)
            clsW.Fields(DBContratosDicInfo.DataTermino, m_FDataTermino, ETiposCampos.FDate);
        if (pFldFOcultarRelatorio || ID.IsEmptyIDNumber())
            clsW.Fields(DBContratosDicInfo.OcultarRelatorio, m_FOcultarRelatorio, ETiposCampos.FBoolean);
        if (pFldFPercEscritorio)
            clsW.Fields(DBContratosDicInfo.PercEscritorio, m_FPercEscritorio, ETiposCampos.FDecimal);
        if (pFldFValorConsultoria)
            clsW.Fields(DBContratosDicInfo.ValorConsultoria, m_FValorConsultoria, ETiposCampos.FDecimal);
        if (pFldFTipoCobranca)
            clsW.Fields(DBContratosDicInfo.TipoCobranca, m_FTipoCobranca, ETiposCampos.FNumber);
        if (pFldFProtestar)
            clsW.Fields(DBContratosDicInfo.Protestar, m_FProtestar, ETiposCampos.FString);
        if (pFldFJuros)
            clsW.Fields(DBContratosDicInfo.Juros, m_FJuros, ETiposCampos.FString);
        if (pFldFValorRealizavel)
            clsW.Fields(DBContratosDicInfo.ValorRealizavel, m_FValorRealizavel, ETiposCampos.FDecimal);
        if (pFldFDOCUMENTO)
            clsW.Fields(DBContratosDicInfo.DOCUMENTO, m_FDOCUMENTO, ETiposCampos.FString);
        if (pFldFEMail1)
            clsW.Fields(DBContratosDicInfo.EMail1, m_FEMail1, ETiposCampos.FString);
        if (pFldFEMail2)
            clsW.Fields(DBContratosDicInfo.EMail2, m_FEMail2, ETiposCampos.FString);
        if (pFldFEMail3)
            clsW.Fields(DBContratosDicInfo.EMail3, m_FEMail3, ETiposCampos.FString);
        if (pFldFPessoa1)
            clsW.Fields(DBContratosDicInfo.Pessoa1, m_FPessoa1, ETiposCampos.FString);
        if (pFldFPessoa2)
            clsW.Fields(DBContratosDicInfo.Pessoa2, m_FPessoa2, ETiposCampos.FString);
        if (pFldFPessoa3)
            clsW.Fields(DBContratosDicInfo.Pessoa3, m_FPessoa3, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBContratosDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFClienteContrato)
            clsW.Fields(DBContratosDicInfo.ClienteContrato, m_FClienteContrato, ETiposCampos.FNumberNull);
        if (pFldFIdExtrangeiro)
            clsW.Fields(DBContratosDicInfo.IdExtrangeiro, m_FIdExtrangeiro, ETiposCampos.FNumberNull);
        if (pFldFChaveContrato)
            clsW.Fields(DBContratosDicInfo.ChaveContrato, m_FChaveContrato, ETiposCampos.FString);
        if (pFldFAvulso || ID.IsEmptyIDNumber())
            clsW.Fields(DBContratosDicInfo.Avulso, m_FAvulso, ETiposCampos.FBoolean);
        if (pFldFSuspenso || ID.IsEmptyIDNumber())
            clsW.Fields(DBContratosDicInfo.Suspenso, m_FSuspenso, ETiposCampos.FBoolean);
        if (pFldFMulta)
            clsW.Fields(DBContratosDicInfo.Multa, m_FMulta, ETiposCampos.FString);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBContratosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBContratosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Contratos)
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
            clsW.Fields(DBContratosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBContratosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBContratosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBContratosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBContratosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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