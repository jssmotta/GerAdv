// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRM : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ContatoCRM)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBContatoCRM();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ContatoCRM
    [XmlIgnore]
    public string TabelaNome => "ContatoCRM";

    public DBContatoCRM()
    {
    }

#endregion
    public DBContatoCRM(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBContatoCRM(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: ContatoCRM");
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
#region GravarDados_ContatoCRM
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFAgeClienteAvisado || pFldFDocsViaRecebimento || pFldFNaoPublicavel || pFldFNotificar || pFldFOcultar || pFldFAssunto || pFldFIsDocsRecebidos || pFldFQuemNotificou || pFldFDataNotificou || pFldFOperador || pFldFCliente || pFldFHoraNotificou || pFldFObjetoNotificou || pFldFPessoaContato || pFldFData || pFldFTempo || pFldFHoraInicial || pFldFHoraFinal || pFldFProcesso || pFldFImportante || pFldFUrgente || pFldFGerarHoraTrabalhada || pFldFExibirNoTopo || pFldFTipoContatoCRM || pFldFContato || pFldFEmocao || pFldFContinuar || pFldFBold))
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
        if (pFldFAgeClienteAvisado)
            clsW.Fields(DBContatoCRMDicInfo.AgeClienteAvisado, m_FAgeClienteAvisado, ETiposCampos.FNumberNull);
        if (pFldFDocsViaRecebimento)
            clsW.Fields(DBContatoCRMDicInfo.DocsViaRecebimento, m_FDocsViaRecebimento, ETiposCampos.FNumberNull);
        if (pFldFNaoPublicavel || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.NaoPublicavel, m_FNaoPublicavel, ETiposCampos.FBoolean);
        if (pFldFNotificar || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Notificar, m_FNotificar, ETiposCampos.FBoolean);
        if (pFldFOcultar || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Ocultar, m_FOcultar, ETiposCampos.FBoolean);
        if (pFldFAssunto)
            clsW.Fields(DBContatoCRMDicInfo.Assunto, m_FAssunto, ETiposCampos.FString);
        if (pFldFIsDocsRecebidos || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.IsDocsRecebidos, m_FIsDocsRecebidos, ETiposCampos.FBoolean);
        if (pFldFQuemNotificou)
            clsW.Fields(DBContatoCRMDicInfo.QuemNotificou, m_FQuemNotificou, ETiposCampos.FNumberNull);
        if (pFldFDataNotificou)
            clsW.Fields(DBContatoCRMDicInfo.DataNotificou, m_FDataNotificou, ETiposCampos.FDate);
        if (pFldFOperador)
            clsW.Fields(DBContatoCRMDicInfo.Operador, m_FOperador, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBContatoCRMDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFHoraNotificou)
            clsW.Fields(DBContatoCRMDicInfo.HoraNotificou, m_FHoraNotificou, ETiposCampos.FDate);
        if (pFldFObjetoNotificou)
            clsW.Fields(DBContatoCRMDicInfo.ObjetoNotificou, m_FObjetoNotificou, ETiposCampos.FNumberNull);
        if (pFldFPessoaContato)
            clsW.Fields(DBContatoCRMDicInfo.PessoaContato, m_FPessoaContato, ETiposCampos.FString);
        if (pFldFData)
            clsW.Fields(DBContatoCRMDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFTempo)
            clsW.Fields(DBContatoCRMDicInfo.Tempo, m_FTempo, ETiposCampos.FDecimal);
        if (pFldFHoraInicial)
            clsW.Fields(DBContatoCRMDicInfo.HoraInicial, m_FHoraInicial, ETiposCampos.FDate);
        if (pFldFHoraFinal)
            clsW.Fields(DBContatoCRMDicInfo.HoraFinal, m_FHoraFinal, ETiposCampos.FDate);
        if (pFldFProcesso)
            clsW.Fields(DBContatoCRMDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFImportante || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Importante, m_FImportante, ETiposCampos.FBoolean);
        if (pFldFUrgente || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Urgente, m_FUrgente, ETiposCampos.FBoolean);
        if (pFldFGerarHoraTrabalhada || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.GerarHoraTrabalhada, m_FGerarHoraTrabalhada, ETiposCampos.FBoolean);
        if (pFldFExibirNoTopo || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.ExibirNoTopo, m_FExibirNoTopo, ETiposCampos.FBoolean);
        if (pFldFTipoContatoCRM)
            clsW.Fields(DBContatoCRMDicInfo.TipoContatoCRM, m_FTipoContatoCRM, ETiposCampos.FNumberNull);
        if (pFldFContato)
            clsW.Fields(DBContatoCRMDicInfo.Contato, m_FContato, ETiposCampos.FString);
        if (pFldFEmocao)
            clsW.Fields(DBContatoCRMDicInfo.Emocao, m_FEmocao, ETiposCampos.FNumberNull);
        if (pFldFContinuar || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Continuar, m_FContinuar, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBContatoCRMDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ContatoCRM)
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
            clsW.Fields(DBContatoCRMDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBContatoCRMDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBContatoCRMDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBContatoCRMDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBContatoCRMDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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