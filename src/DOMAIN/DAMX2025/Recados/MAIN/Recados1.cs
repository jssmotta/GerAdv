// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBRecados : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_Recados
    [XmlIgnore]
    public string TabelaNome => "Recados";

    public DBRecados()
    {
    }

#endregion
    public DBRecados(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBRecados(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: Recados");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_Recados
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFClienteNome || pFldFDe || pFldFPara || pFldFAssunto || pFldFConcluido || pFldFProcesso || pFldFCliente || pFldFRecado || pFldFUrgente || pFldFImportante || pFldFHora || pFldFData || pFldFVoltara || pFldFPessoal || pFldFRetornar || pFldFRetornoData || pFldFEmotion || pFldFInternetID || pFldFUploaded || pFldFNatureza || pFldFBIU || pFldFAguardarRetorno || pFldFAguardarRetornoPara || pFldFAguardarRetornoOK || pFldFParaID || pFldFNaoPublicavel || pFldFIsContatoCRM || pFldFMasterID || pFldFListaPara || pFldFTyped || pFldFAssuntoRecado || pFldFHistorico || pFldFContatoCRM || pFldFLigacoes || pFldFAgenda))
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
        if (pFldFClienteNome)
            clsW.Fields(DBRecadosDicInfo.ClienteNome, m_FClienteNome, ETiposCampos.FString);
        if (pFldFDe)
            clsW.Fields(DBRecadosDicInfo.De, m_FDe, ETiposCampos.FString);
        if (pFldFPara)
            clsW.Fields(DBRecadosDicInfo.Para, m_FPara, ETiposCampos.FString);
        if (pFldFAssunto)
            clsW.Fields(DBRecadosDicInfo.Assunto, m_FAssunto, ETiposCampos.FString);
        if (pFldFConcluido || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Concluido, m_FConcluido, ETiposCampos.FBoolean);
        if (pFldFProcesso)
            clsW.Fields(DBRecadosDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBRecadosDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFRecado)
            clsW.Fields(DBRecadosDicInfo.Recado, m_FRecado, ETiposCampos.FString);
        if (pFldFUrgente || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Urgente, m_FUrgente, ETiposCampos.FBoolean);
        if (pFldFImportante || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Importante, m_FImportante, ETiposCampos.FBoolean);
        if (pFldFHora)
            clsW.Fields(DBRecadosDicInfo.Hora, m_FHora, ETiposCampos.FDate);
        if (pFldFData)
            clsW.Fields(DBRecadosDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFVoltara || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Voltara, m_FVoltara, ETiposCampos.FBoolean);
        if (pFldFPessoal || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Pessoal, m_FPessoal, ETiposCampos.FBoolean);
        if (pFldFRetornar || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Retornar, m_FRetornar, ETiposCampos.FBoolean);
        if (pFldFRetornoData)
            clsW.Fields(DBRecadosDicInfo.RetornoData, m_FRetornoData, ETiposCampos.FDate);
        if (pFldFEmotion)
            clsW.Fields(DBRecadosDicInfo.Emotion, m_FEmotion, ETiposCampos.FNumberNull);
        if (pFldFInternetID)
            clsW.Fields(DBRecadosDicInfo.InternetID, m_FInternetID, ETiposCampos.FNumberNull);
        if (pFldFUploaded || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Uploaded, m_FUploaded, ETiposCampos.FBoolean);
        if (pFldFNatureza)
            clsW.Fields(DBRecadosDicInfo.Natureza, m_FNatureza, ETiposCampos.FNumberNull);
        if (pFldFBIU || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.BIU, m_FBIU, ETiposCampos.FBoolean);
        if (pFldFAguardarRetorno || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.AguardarRetorno, m_FAguardarRetorno, ETiposCampos.FBoolean);
        if (pFldFAguardarRetornoPara)
            clsW.Fields(DBRecadosDicInfo.AguardarRetornoPara, m_FAguardarRetornoPara, ETiposCampos.FString);
        if (pFldFAguardarRetornoOK || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.AguardarRetornoOK, m_FAguardarRetornoOK, ETiposCampos.FBoolean);
        if (pFldFParaID)
            clsW.Fields(DBRecadosDicInfo.ParaID, m_FParaID, ETiposCampos.FNumberNull);
        if (pFldFNaoPublicavel || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.NaoPublicavel, m_FNaoPublicavel, ETiposCampos.FBoolean);
        if (pFldFIsContatoCRM || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.IsContatoCRM, m_FIsContatoCRM, ETiposCampos.FBoolean);
        if (pFldFMasterID)
            clsW.Fields(DBRecadosDicInfo.MasterID, m_FMasterID, ETiposCampos.FNumberNull);
        if (pFldFListaPara)
            clsW.Fields(DBRecadosDicInfo.ListaPara, m_FListaPara, ETiposCampos.FString);
        if (pFldFTyped || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Typed, m_FTyped, ETiposCampos.FBoolean);
        if (pFldFAssuntoRecado)
            clsW.Fields(DBRecadosDicInfo.AssuntoRecado, m_FAssuntoRecado, ETiposCampos.FNumberNull);
        if (pFldFHistorico)
            clsW.Fields(DBRecadosDicInfo.Historico, m_FHistorico, ETiposCampos.FNumberNull);
        if (pFldFContatoCRM)
            clsW.Fields(DBRecadosDicInfo.ContatoCRM, m_FContatoCRM, ETiposCampos.FNumberNull);
        if (pFldFLigacoes)
            clsW.Fields(DBRecadosDicInfo.Ligacoes, m_FLigacoes, ETiposCampos.FNumberNull);
        if (pFldFAgenda)
            clsW.Fields(DBRecadosDicInfo.Agenda, m_FAgenda, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBRecadosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Recados)
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
            clsW.Fields(DBRecadosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBRecadosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBRecadosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBRecadosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBRecadosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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