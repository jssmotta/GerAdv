// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgendaFinanceiro : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_AgendaFinanceiro
    [XmlIgnore]
    public string TabelaNome => "AgendaFinanceiro";

    public DBAgendaFinanceiro()
    {
    }

#endregion
    // REF. 250325
    public DBAgendaFinanceiro(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: AgendaFinanceiro");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_AgendaFinanceiro
    internal int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFIDCOB || pFldFIDNE || pFldFPrazoProvisionado || pFldFCidade || pFldFOculto || pFldFCartaPrecatoria || pFldFRepetirDias || pFldFHrFinal || pFldFRepetir || pFldFAdvogado || pFldFEventoGerador || pFldFEventoData || pFldFFuncionario || pFldFData || pFldFEventoPrazo || pFldFHora || pFldFCompromisso || pFldFTipoCompromisso || pFldFCliente || pFldFDDias || pFldFDias || pFldFLiberado || pFldFImportante || pFldFConcluido || pFldFArea || pFldFJustica || pFldFProcesso || pFldFIDHistorico || pFldFIDInsProcesso || pFldFUsuario || pFldFPreposto || pFldFQuemID || pFldFQuemCodigo || pFldFStatus || pFldFValor || pFldFCompromissoHTML || pFldFDecisao || pFldFRevisar || pFldFRevisarP2 || pFldFSempre || pFldFPrazoDias || pFldFProtocoloIntegrado || pFldFDataInicioPrazo || pFldFUsuarioCiente))
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
        if (pFldFIDCOB)
            clsW.Fields(DBAgendaFinanceiroDicInfo.IDCOB, m_FIDCOB, ETiposCampos.FNumberNull);
        if (pFldFIDNE)
            clsW.Fields(DBAgendaFinanceiroDicInfo.IDNE, m_FIDNE, ETiposCampos.FNumberNull);
        if (pFldFPrazoProvisionado)
            clsW.Fields(DBAgendaFinanceiroDicInfo.PrazoProvisionado, m_FPrazoProvisionado, ETiposCampos.FNumberNull);
        if (pFldFCidade)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFOculto)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Oculto, m_FOculto, ETiposCampos.FNumberNull);
        if (pFldFCartaPrecatoria)
            clsW.Fields(DBAgendaFinanceiroDicInfo.CartaPrecatoria, m_FCartaPrecatoria, ETiposCampos.FNumberNull);
        if (pFldFRepetirDias)
            clsW.Fields(DBAgendaFinanceiroDicInfo.RepetirDias, m_FRepetirDias, ETiposCampos.FNumberNull);
        if (pFldFHrFinal)
            clsW.Fields(DBAgendaFinanceiroDicInfo.HrFinal, m_FHrFinal, ETiposCampos.FDate);
        if (pFldFRepetir)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Repetir, m_FRepetir, ETiposCampos.FNumberNull);
        if (pFldFAdvogado)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFEventoGerador)
            clsW.Fields(DBAgendaFinanceiroDicInfo.EventoGerador, m_FEventoGerador, ETiposCampos.FNumberNull);
        if (pFldFEventoData)
            clsW.Fields(DBAgendaFinanceiroDicInfo.EventoData, m_FEventoData, ETiposCampos.FDate);
        if (pFldFFuncionario)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Funcionario, m_FFuncionario, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFEventoPrazo)
            clsW.Fields(DBAgendaFinanceiroDicInfo.EventoPrazo, m_FEventoPrazo, ETiposCampos.FNumberNull);
        if (pFldFHora)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Hora, m_FHora, ETiposCampos.FDate);
        if (pFldFCompromisso)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Compromisso, m_FCompromisso, ETiposCampos.FString);
        if (pFldFTipoCompromisso)
            clsW.Fields(DBAgendaFinanceiroDicInfo.TipoCompromisso, m_FTipoCompromisso, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFDDias)
            clsW.Fields(DBAgendaFinanceiroDicInfo.DDias, m_FDDias, ETiposCampos.FDate);
        if (pFldFDias)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Dias, m_FDias, ETiposCampos.FNumberNull);
        if (pFldFLiberado || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.Liberado, m_FLiberado, ETiposCampos.FBoolean);
        if (pFldFImportante || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.Importante, m_FImportante, ETiposCampos.FBoolean);
        if (pFldFConcluido || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.Concluido, m_FConcluido, ETiposCampos.FBoolean);
        if (pFldFArea)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Area, m_FArea, ETiposCampos.FNumberNull);
        if (pFldFJustica)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Justica, m_FJustica, ETiposCampos.FNumberNull);
        if (pFldFProcesso)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFIDHistorico)
            clsW.Fields(DBAgendaFinanceiroDicInfo.IDHistorico, m_FIDHistorico, ETiposCampos.FNumberNull);
        if (pFldFIDInsProcesso)
            clsW.Fields(DBAgendaFinanceiroDicInfo.IDInsProcesso, m_FIDInsProcesso, ETiposCampos.FNumberNull);
        if (pFldFUsuario)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Usuario, m_FUsuario, ETiposCampos.FNumberNull);
        if (pFldFPreposto)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Preposto, m_FPreposto, ETiposCampos.FNumberNull);
        if (pFldFQuemID)
            clsW.Fields(DBAgendaFinanceiroDicInfo.QuemID, m_FQuemID, ETiposCampos.FNumberNull);
        if (pFldFQuemCodigo)
            clsW.Fields(DBAgendaFinanceiroDicInfo.QuemCodigo, m_FQuemCodigo, ETiposCampos.FNumberNull);
        if (pFldFStatus)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Status, m_FStatus, ETiposCampos.FString);
        if (pFldFValor)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFCompromissoHTML)
            clsW.Fields(DBAgendaFinanceiroDicInfo.CompromissoHTML, m_FCompromissoHTML, ETiposCampos.FString);
        if (pFldFDecisao)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Decisao, m_FDecisao, ETiposCampos.FString);
        if (pFldFRevisar || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.Revisar, m_FRevisar, ETiposCampos.FBoolean);
        if (pFldFRevisarP2 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.RevisarP2, m_FRevisarP2, ETiposCampos.FBoolean);
        if (pFldFSempre)
            clsW.Fields(DBAgendaFinanceiroDicInfo.Sempre, m_FSempre, ETiposCampos.FNumberNull);
        if (pFldFPrazoDias)
            clsW.Fields(DBAgendaFinanceiroDicInfo.PrazoDias, m_FPrazoDias, ETiposCampos.FNumberNull);
        if (pFldFProtocoloIntegrado)
            clsW.Fields(DBAgendaFinanceiroDicInfo.ProtocoloIntegrado, m_FProtocoloIntegrado, ETiposCampos.FNumberNull);
        if (pFldFDataInicioPrazo)
            clsW.Fields(DBAgendaFinanceiroDicInfo.DataInicioPrazo, m_FDataInicioPrazo, ETiposCampos.FDate);
        if (pFldFUsuarioCiente || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.UsuarioCiente, m_FUsuarioCiente, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBAgendaFinanceiroDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_AgendaFinanceiro)
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
            clsW.Fields(DBAgendaFinanceiroDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAgendaFinanceiroDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAgendaFinanceiroDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAgendaFinanceiroDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaFinanceiroDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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
            throw new Exception($"{clsW.Table} {clsW.LastError}, {ErrorDescription}, {cRet}");
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