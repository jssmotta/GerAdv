// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgenda : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Agenda)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBAgenda();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Agenda
    [XmlIgnore]
    public string TabelaNome => "Agenda";

    public DBAgenda()
    {
    }

#endregion
    public DBAgenda(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBAgenda(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: Agenda");
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
#region GravarDados_Agenda
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFIDCOB || pFldFClienteAvisado || pFldFRevisarP2 || pFldFIDNE || pFldFCidade || pFldFOculto || pFldFCartaPrecatoria || pFldFRevisar || pFldFHrFinal || pFldFAdvogado || pFldFEventoGerador || pFldFEventoData || pFldFFuncionario || pFldFData || pFldFEventoPrazo || pFldFHora || pFldFCompromisso || pFldFTipoCompromisso || pFldFCliente || pFldFLiberado || pFldFImportante || pFldFConcluido || pFldFArea || pFldFJustica || pFldFProcesso || pFldFIDHistorico || pFldFIDInsProcesso || pFldFUsuario || pFldFPreposto || pFldFQuemID || pFldFQuemCodigo || pFldFStatus || pFldFValor || pFldFDecisao || pFldFSempre || pFldFPrazoDias || pFldFProtocoloIntegrado || pFldFDataInicioPrazo || pFldFUsuarioCiente))
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
            clsW.Fields(DBAgendaDicInfo.IDCOB, m_FIDCOB, ETiposCampos.FNumberNull);
        if (pFldFClienteAvisado || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.ClienteAvisado, m_FClienteAvisado, ETiposCampos.FBoolean);
        if (pFldFRevisarP2 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.RevisarP2, m_FRevisarP2, ETiposCampos.FBoolean);
        if (pFldFIDNE)
            clsW.Fields(DBAgendaDicInfo.IDNE, m_FIDNE, ETiposCampos.FNumberNull);
        if (pFldFCidade)
            clsW.Fields(DBAgendaDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFOculto)
            clsW.Fields(DBAgendaDicInfo.Oculto, m_FOculto, ETiposCampos.FNumberNull);
        if (pFldFCartaPrecatoria)
            clsW.Fields(DBAgendaDicInfo.CartaPrecatoria, m_FCartaPrecatoria, ETiposCampos.FNumberNull);
        if (pFldFRevisar || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.Revisar, m_FRevisar, ETiposCampos.FBoolean);
        if (pFldFHrFinal)
            clsW.Fields(DBAgendaDicInfo.HrFinal, m_FHrFinal, ETiposCampos.FDate);
        if (pFldFAdvogado)
            clsW.Fields(DBAgendaDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFEventoGerador)
            clsW.Fields(DBAgendaDicInfo.EventoGerador, m_FEventoGerador, ETiposCampos.FNumberNull);
        if (pFldFEventoData)
            clsW.Fields(DBAgendaDicInfo.EventoData, m_FEventoData, ETiposCampos.FDate);
        if (pFldFFuncionario)
            clsW.Fields(DBAgendaDicInfo.Funcionario, m_FFuncionario, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBAgendaDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFEventoPrazo)
            clsW.Fields(DBAgendaDicInfo.EventoPrazo, m_FEventoPrazo, ETiposCampos.FNumberNull);
        if (pFldFHora)
            clsW.Fields(DBAgendaDicInfo.Hora, m_FHora, ETiposCampos.FDate);
        if (pFldFCompromisso)
            clsW.Fields(DBAgendaDicInfo.Compromisso, m_FCompromisso, ETiposCampos.FString);
        if (pFldFTipoCompromisso)
            clsW.Fields(DBAgendaDicInfo.TipoCompromisso, m_FTipoCompromisso, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBAgendaDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFLiberado || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.Liberado, m_FLiberado, ETiposCampos.FBoolean);
        if (pFldFImportante || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.Importante, m_FImportante, ETiposCampos.FBoolean);
        if (pFldFConcluido || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.Concluido, m_FConcluido, ETiposCampos.FBoolean);
        if (pFldFArea)
            clsW.Fields(DBAgendaDicInfo.Area, m_FArea, ETiposCampos.FNumberNull);
        if (pFldFJustica)
            clsW.Fields(DBAgendaDicInfo.Justica, m_FJustica, ETiposCampos.FNumberNull);
        if (pFldFProcesso)
            clsW.Fields(DBAgendaDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFIDHistorico)
            clsW.Fields(DBAgendaDicInfo.IDHistorico, m_FIDHistorico, ETiposCampos.FNumberNull);
        if (pFldFIDInsProcesso)
            clsW.Fields(DBAgendaDicInfo.IDInsProcesso, m_FIDInsProcesso, ETiposCampos.FNumberNull);
        if (pFldFUsuario)
            clsW.Fields(DBAgendaDicInfo.Usuario, m_FUsuario, ETiposCampos.FNumberNull);
        if (pFldFPreposto)
            clsW.Fields(DBAgendaDicInfo.Preposto, m_FPreposto, ETiposCampos.FNumberNull);
        if (pFldFQuemID)
            clsW.Fields(DBAgendaDicInfo.QuemID, m_FQuemID, ETiposCampos.FNumberNull);
        if (pFldFQuemCodigo)
            clsW.Fields(DBAgendaDicInfo.QuemCodigo, m_FQuemCodigo, ETiposCampos.FNumberNull);
        if (pFldFStatus)
            clsW.Fields(DBAgendaDicInfo.Status, m_FStatus, ETiposCampos.FString);
        if (pFldFValor)
            clsW.Fields(DBAgendaDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFDecisao)
            clsW.Fields(DBAgendaDicInfo.Decisao, m_FDecisao, ETiposCampos.FString);
        if (pFldFSempre)
            clsW.Fields(DBAgendaDicInfo.Sempre, m_FSempre, ETiposCampos.FNumberNull);
        if (pFldFPrazoDias)
            clsW.Fields(DBAgendaDicInfo.PrazoDias, m_FPrazoDias, ETiposCampos.FNumberNull);
        if (pFldFProtocoloIntegrado)
            clsW.Fields(DBAgendaDicInfo.ProtocoloIntegrado, m_FProtocoloIntegrado, ETiposCampos.FNumberNull);
        if (pFldFDataInicioPrazo)
            clsW.Fields(DBAgendaDicInfo.DataInicioPrazo, m_FDataInicioPrazo, ETiposCampos.FDate);
        if (pFldFUsuarioCiente || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.UsuarioCiente, m_FUsuarioCiente, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBAgendaDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Agenda)
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
            clsW.Fields(DBAgendaDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAgendaDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAgendaDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAgendaDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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