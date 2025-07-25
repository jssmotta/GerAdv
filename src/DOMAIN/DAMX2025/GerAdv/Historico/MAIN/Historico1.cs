// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBHistorico : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_Historico
    [XmlIgnore]
    public string TabelaNome => "Historico";

    public DBHistorico()
    {
    }

#endregion
    // REF. 250325
    public DBHistorico(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: Historico");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_Historico
    internal int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFExtraID || pFldFIDNE || pFldFExtraGUID || pFldFLiminarOrigem || pFldFNaoPublicavel || pFldFProcesso || pFldFPrecatoria || pFldFApenso || pFldFIDInstProcesso || pFldFFase || pFldFData || pFldFObservacao || pFldFAgendado || pFldFConcluido || pFldFMesmaAgenda || pFldFSAD || pFldFResumido || pFldFStatusAndamento || pFldFTop))
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
        if (pFldFExtraID)
            clsW.Fields(DBHistoricoDicInfo.ExtraID, m_FExtraID, ETiposCampos.FNumberNull);
        if (pFldFIDNE)
            clsW.Fields(DBHistoricoDicInfo.IDNE, m_FIDNE, ETiposCampos.FNumberNull);
        if (pFldFExtraGUID)
            clsW.Fields(DBHistoricoDicInfo.ExtraGUID, m_FExtraGUID, ETiposCampos.FString);
        if (pFldFLiminarOrigem)
            clsW.Fields(DBHistoricoDicInfo.LiminarOrigem, m_FLiminarOrigem, ETiposCampos.FNumberNull);
        if (pFldFNaoPublicavel || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.NaoPublicavel, m_FNaoPublicavel, ETiposCampos.FBoolean);
        if (pFldFProcesso)
            clsW.Fields(DBHistoricoDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFPrecatoria)
            clsW.Fields(DBHistoricoDicInfo.Precatoria, m_FPrecatoria, ETiposCampos.FNumberNull);
        if (pFldFApenso)
            clsW.Fields(DBHistoricoDicInfo.Apenso, m_FApenso, ETiposCampos.FNumberNull);
        if (pFldFIDInstProcesso)
            clsW.Fields(DBHistoricoDicInfo.IDInstProcesso, m_FIDInstProcesso, ETiposCampos.FNumberNull);
        if (pFldFFase)
            clsW.Fields(DBHistoricoDicInfo.Fase, m_FFase, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBHistoricoDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFObservacao)
            clsW.Fields(DBHistoricoDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFAgendado || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.Agendado, m_FAgendado, ETiposCampos.FBoolean);
        if (pFldFConcluido || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.Concluido, m_FConcluido, ETiposCampos.FBoolean);
        if (pFldFMesmaAgenda || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.MesmaAgenda, m_FMesmaAgenda, ETiposCampos.FBoolean);
        if (pFldFSAD)
            clsW.Fields(DBHistoricoDicInfo.SAD, m_FSAD, ETiposCampos.FNumberNull);
        if (pFldFResumido || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.Resumido, m_FResumido, ETiposCampos.FBoolean);
        if (pFldFStatusAndamento)
            clsW.Fields(DBHistoricoDicInfo.StatusAndamento, m_FStatusAndamento, ETiposCampos.FNumberNull);
        if (pFldFTop || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.Top, m_FTop, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBHistoricoDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_Historico)
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
            clsW.Fields(DBHistoricoDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBHistoricoDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBHistoricoDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBHistoricoDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBHistoricoDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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