// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBProcessos : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Processos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBProcessos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Processos
    [XmlIgnore]
    public string TabelaNome => "Processos";

    public DBProcessos()
    {
    }

#endregion
    public DBProcessos(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBProcessos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBProcessos(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_Processos
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFAdvParc || pFldFAJGPedidoNegado || pFldFAJGCliente || pFldFAJGPedidoNegadoOPO || pFldFNotificarPOE || pFldFValorProvisionado || pFldFAJGOponente || pFldFValorCacheCalculo || pFldFAJGPedidoOPO || pFldFValorCacheCalculoProv || pFldFConsiderarParado || pFldFValorCalculado || pFldFAJGConcedidoOPO || pFldFCobranca || pFldFDataEntrada || pFldFPenhora || pFldFAJGPedido || pFldFTipoBaixa || pFldFClassRisco || pFldFIsApenso || pFldFValorCausaInicial || pFldFAJGConcedido || pFldFObsBCX || pFldFValorCausaDefinitivo || pFldFPercProbExito || pFldFMNA || pFldFPercExito || pFldFNroExtra || pFldFAdvOpo || pFldFExtra || pFldFJustica || pFldFAdvogado || pFldFNroCaixa || pFldFPreposto || pFldFCliente || pFldFOponente || pFldFArea || pFldFCidade || pFldFSituacao || pFldFIDSituacao || pFldFValor || pFldFRito || pFldFFato || pFldFNroPasta || pFldFAtividade || pFldFCaixaMorto || pFldFBaixado || pFldFDtBaixa || pFldFMotivoBaixa || pFldFOBS || pFldFPrinted || pFldFZKey || pFldFZKeyQuem || pFldFZKeyQuando || pFldFResumo || pFldFNaoImprimir || pFldFEletronico || pFldFNroContrato || pFldFPercProbExitoJustificativa || pFldFHonorarioValor || pFldFHonorarioPercentual || pFldFHonorarioSucumbencia || pFldFFaseAuditoria || pFldFValorCondenacao || pFldFValorCondenacaoCalculado || pFldFValorCondenacaoProvisorio))
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
        if (pFldFAdvParc)
            clsW.Fields(DBProcessosDicInfo.AdvParc, m_FAdvParc, ETiposCampos.FNumberNull);
        if (pFldFAJGPedidoNegado || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGPedidoNegado, m_FAJGPedidoNegado, ETiposCampos.FBoolean);
        if (pFldFAJGCliente || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGCliente, m_FAJGCliente, ETiposCampos.FBoolean);
        if (pFldFAJGPedidoNegadoOPO || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGPedidoNegadoOPO, m_FAJGPedidoNegadoOPO, ETiposCampos.FBoolean);
        if (pFldFNotificarPOE || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.NotificarPOE, m_FNotificarPOE, ETiposCampos.FBoolean);
        if (pFldFValorProvisionado)
            clsW.Fields(DBProcessosDicInfo.ValorProvisionado, m_FValorProvisionado, ETiposCampos.FDecimal);
        if (pFldFAJGOponente || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGOponente, m_FAJGOponente, ETiposCampos.FBoolean);
        if (pFldFValorCacheCalculo)
            clsW.Fields(DBProcessosDicInfo.ValorCacheCalculo, m_FValorCacheCalculo, ETiposCampos.FDecimal);
        if (pFldFAJGPedidoOPO || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGPedidoOPO, m_FAJGPedidoOPO, ETiposCampos.FBoolean);
        if (pFldFValorCacheCalculoProv)
            clsW.Fields(DBProcessosDicInfo.ValorCacheCalculoProv, m_FValorCacheCalculoProv, ETiposCampos.FDecimal);
        if (pFldFConsiderarParado || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.ConsiderarParado, m_FConsiderarParado, ETiposCampos.FBoolean);
        if (pFldFValorCalculado || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.ValorCalculado, m_FValorCalculado, ETiposCampos.FBoolean);
        if (pFldFAJGConcedidoOPO || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGConcedidoOPO, m_FAJGConcedidoOPO, ETiposCampos.FBoolean);
        if (pFldFCobranca || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Cobranca, m_FCobranca, ETiposCampos.FBoolean);
        if (pFldFDataEntrada)
            clsW.Fields(DBProcessosDicInfo.DataEntrada, m_FDataEntrada, ETiposCampos.FDate);
        if (pFldFPenhora || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Penhora, m_FPenhora, ETiposCampos.FBoolean);
        if (pFldFAJGPedido || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGPedido, m_FAJGPedido, ETiposCampos.FBoolean);
        if (pFldFTipoBaixa)
            clsW.Fields(DBProcessosDicInfo.TipoBaixa, m_FTipoBaixa, ETiposCampos.FNumberNull);
        if (pFldFClassRisco)
            clsW.Fields(DBProcessosDicInfo.ClassRisco, m_FClassRisco, ETiposCampos.FNumberNull);
        if (pFldFIsApenso || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.IsApenso, m_FIsApenso, ETiposCampos.FBoolean);
        if (pFldFValorCausaInicial)
            clsW.Fields(DBProcessosDicInfo.ValorCausaInicial, m_FValorCausaInicial, ETiposCampos.FDecimal);
        if (pFldFAJGConcedido || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.AJGConcedido, m_FAJGConcedido, ETiposCampos.FBoolean);
        if (pFldFObsBCX)
            clsW.Fields(DBProcessosDicInfo.ObsBCX, m_FObsBCX, ETiposCampos.FString);
        if (pFldFValorCausaDefinitivo)
            clsW.Fields(DBProcessosDicInfo.ValorCausaDefinitivo, m_FValorCausaDefinitivo, ETiposCampos.FDecimal);
        if (pFldFPercProbExito)
            clsW.Fields(DBProcessosDicInfo.PercProbExito, m_FPercProbExito, ETiposCampos.FDecimal);
        if (pFldFMNA || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.MNA, m_FMNA, ETiposCampos.FBoolean);
        if (pFldFPercExito)
            clsW.Fields(DBProcessosDicInfo.PercExito, m_FPercExito, ETiposCampos.FDecimal);
        if (pFldFNroExtra)
            clsW.Fields(DBProcessosDicInfo.NroExtra, m_FNroExtra, ETiposCampos.FString);
        if (pFldFAdvOpo)
            clsW.Fields(DBProcessosDicInfo.AdvOpo, m_FAdvOpo, ETiposCampos.FNumberNull);
        if (pFldFExtra || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Extra, m_FExtra, ETiposCampos.FBoolean);
        if (pFldFJustica)
            clsW.Fields(DBProcessosDicInfo.Justica, m_FJustica, ETiposCampos.FNumberNull);
        if (pFldFAdvogado)
            clsW.Fields(DBProcessosDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFNroCaixa)
            clsW.Fields(DBProcessosDicInfo.NroCaixa, m_FNroCaixa, ETiposCampos.FString);
        if (pFldFPreposto)
            clsW.Fields(DBProcessosDicInfo.Preposto, m_FPreposto, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBProcessosDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFOponente)
            clsW.Fields(DBProcessosDicInfo.Oponente, m_FOponente, ETiposCampos.FNumberNull);
        if (pFldFArea)
            clsW.Fields(DBProcessosDicInfo.Area, m_FArea, ETiposCampos.FNumberNull);
        if (pFldFCidade)
            clsW.Fields(DBProcessosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFSituacao)
            clsW.Fields(DBProcessosDicInfo.Situacao, m_FSituacao, ETiposCampos.FNumberNull);
        if (pFldFIDSituacao || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.IDSituacao, m_FIDSituacao, ETiposCampos.FBoolean);
        if (pFldFValor)
            clsW.Fields(DBProcessosDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFRito)
            clsW.Fields(DBProcessosDicInfo.Rito, m_FRito, ETiposCampos.FNumberNull);
        if (pFldFFato)
            clsW.Fields(DBProcessosDicInfo.Fato, m_FFato, ETiposCampos.FString);
        if (pFldFNroPasta)
            clsW.Fields(DBProcessosDicInfo.NroPasta, m_FNroPasta, ETiposCampos.FString);
        if (pFldFAtividade)
            clsW.Fields(DBProcessosDicInfo.Atividade, m_FAtividade, ETiposCampos.FNumberNull);
        if (pFldFCaixaMorto)
            clsW.Fields(DBProcessosDicInfo.CaixaMorto, m_FCaixaMorto, ETiposCampos.FString);
        if (pFldFBaixado || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Baixado, m_FBaixado, ETiposCampos.FBoolean);
        if (pFldFDtBaixa)
            clsW.Fields(DBProcessosDicInfo.DtBaixa, m_FDtBaixa, ETiposCampos.FDate);
        if (pFldFMotivoBaixa)
            clsW.Fields(DBProcessosDicInfo.MotivoBaixa, m_FMotivoBaixa, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBProcessosDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFPrinted || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Printed, m_FPrinted, ETiposCampos.FBoolean);
        if (pFldFZKey)
            clsW.Fields(DBProcessosDicInfo.ZKey, m_FZKey, ETiposCampos.FString);
        if (pFldFZKeyQuem)
            clsW.Fields(DBProcessosDicInfo.ZKeyQuem, m_FZKeyQuem, ETiposCampos.FNumberNull);
        if (pFldFZKeyQuando)
            clsW.Fields(DBProcessosDicInfo.ZKeyQuando, m_FZKeyQuando, ETiposCampos.FDate);
        if (pFldFResumo)
            clsW.Fields(DBProcessosDicInfo.Resumo, m_FResumo, ETiposCampos.FString);
        if (pFldFNaoImprimir || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.NaoImprimir, m_FNaoImprimir, ETiposCampos.FBoolean);
        if (pFldFEletronico || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Eletronico, m_FEletronico, ETiposCampos.FBoolean);
        if (pFldFNroContrato)
            clsW.Fields(DBProcessosDicInfo.NroContrato, m_FNroContrato, ETiposCampos.FString);
        if (pFldFPercProbExitoJustificativa)
            clsW.Fields(DBProcessosDicInfo.PercProbExitoJustificativa, m_FPercProbExitoJustificativa, ETiposCampos.FString);
        if (pFldFHonorarioValor)
            clsW.Fields(DBProcessosDicInfo.HonorarioValor, m_FHonorarioValor, ETiposCampos.FDecimal);
        if (pFldFHonorarioPercentual)
            clsW.Fields(DBProcessosDicInfo.HonorarioPercentual, m_FHonorarioPercentual, ETiposCampos.FDecimal);
        if (pFldFHonorarioSucumbencia)
            clsW.Fields(DBProcessosDicInfo.HonorarioSucumbencia, m_FHonorarioSucumbencia, ETiposCampos.FDecimal);
        if (pFldFFaseAuditoria)
            clsW.Fields(DBProcessosDicInfo.FaseAuditoria, m_FFaseAuditoria, ETiposCampos.FNumberNull);
        if (pFldFValorCondenacao)
            clsW.Fields(DBProcessosDicInfo.ValorCondenacao, m_FValorCondenacao, ETiposCampos.FDecimal);
        if (pFldFValorCondenacaoCalculado)
            clsW.Fields(DBProcessosDicInfo.ValorCondenacaoCalculado, m_FValorCondenacaoCalculado, ETiposCampos.FDecimal);
        if (pFldFValorCondenacaoProvisorio)
            clsW.Fields(DBProcessosDicInfo.ValorCondenacaoProvisorio, m_FValorCondenacaoProvisorio, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBProcessosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Processos)
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
            clsW.Fields(DBProcessosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBProcessosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBProcessosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBProcessosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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