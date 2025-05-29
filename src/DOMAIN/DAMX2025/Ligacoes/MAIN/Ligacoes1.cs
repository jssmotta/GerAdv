// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBLigacoes : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Ligacoes)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBLigacoes();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Ligacoes
    [XmlIgnore]
    public string TabelaNome => "Ligacoes";

    public DBLigacoes()
    {
    }

#endregion
    public DBLigacoes(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBLigacoes(in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
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
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
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
    public DBLigacoes(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_Ligacoes
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFAssunto || pFldFAgeClienteAvisado || pFldFCelular || pFldFCliente || pFldFContato || pFldFDataRealizada || pFldFQuemID || pFldFTelefonista || pFldFUltimoAviso || pFldFHoraFinal || pFldFNome || pFldFQuemCodigo || pFldFSolicitante || pFldFPara || pFldFFone || pFldFRamal || pFldFParticular || pFldFRealizada || pFldFStatus || pFldFData || pFldFHora || pFldFUrgente || pFldFLigarPara || pFldFProcesso || pFldFStartScreen || pFldFEmotion || pFldFBold))
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
        if (this.FNome.IsEmpty())
        {
            throw new Exception("Campo 'ligNome' está vazio!");
        }

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
        if (pFldFAssunto)
            clsW.Fields(DBLigacoesDicInfo.Assunto, m_FAssunto, ETiposCampos.FString);
        if (pFldFAgeClienteAvisado)
            clsW.Fields(DBLigacoesDicInfo.AgeClienteAvisado, m_FAgeClienteAvisado, ETiposCampos.FNumberNull);
        if (pFldFCelular || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Celular, m_FCelular, ETiposCampos.FBoolean);
        if (pFldFCliente)
            clsW.Fields(DBLigacoesDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFContato)
            clsW.Fields(DBLigacoesDicInfo.Contato, m_FContato, ETiposCampos.FString);
        if (pFldFDataRealizada)
            clsW.Fields(DBLigacoesDicInfo.DataRealizada, m_FDataRealizada, ETiposCampos.FDate);
        if (pFldFQuemID)
            clsW.Fields(DBLigacoesDicInfo.QuemID, m_FQuemID, ETiposCampos.FNumberNull);
        if (pFldFTelefonista)
            clsW.Fields(DBLigacoesDicInfo.Telefonista, m_FTelefonista, ETiposCampos.FNumberNull);
        if (pFldFUltimoAviso)
            clsW.Fields(DBLigacoesDicInfo.UltimoAviso, m_FUltimoAviso, ETiposCampos.FDate);
        if (pFldFHoraFinal)
            clsW.Fields(DBLigacoesDicInfo.HoraFinal, m_FHoraFinal, ETiposCampos.FDate);
        if (pFldFNome)
            clsW.Fields(DBLigacoesDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFQuemCodigo)
            clsW.Fields(DBLigacoesDicInfo.QuemCodigo, m_FQuemCodigo, ETiposCampos.FNumberNull);
        if (pFldFSolicitante)
            clsW.Fields(DBLigacoesDicInfo.Solicitante, m_FSolicitante, ETiposCampos.FNumberNull);
        if (pFldFPara)
            clsW.Fields(DBLigacoesDicInfo.Para, m_FPara, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBLigacoesDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFRamal)
            clsW.Fields(DBLigacoesDicInfo.Ramal, m_FRamal, ETiposCampos.FNumberNull);
        if (pFldFParticular || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Particular, m_FParticular, ETiposCampos.FBoolean);
        if (pFldFRealizada || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Realizada, m_FRealizada, ETiposCampos.FBoolean);
        if (pFldFStatus)
            clsW.Fields(DBLigacoesDicInfo.Status, m_FStatus, ETiposCampos.FString);
        if (pFldFData)
            clsW.Fields(DBLigacoesDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFHora)
            clsW.Fields(DBLigacoesDicInfo.Hora, m_FHora, ETiposCampos.FDate);
        if (pFldFUrgente || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Urgente, m_FUrgente, ETiposCampos.FBoolean);
        if (pFldFLigarPara)
            clsW.Fields(DBLigacoesDicInfo.LigarPara, m_FLigarPara, ETiposCampos.FString);
        if (pFldFProcesso)
            clsW.Fields(DBLigacoesDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFStartScreen || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.StartScreen, m_FStartScreen, ETiposCampos.FBoolean);
        if (pFldFEmotion)
            clsW.Fields(DBLigacoesDicInfo.Emotion, m_FEmotion, ETiposCampos.FNumberNull);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBLigacoesDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Ligacoes)
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
            clsW.Fields(DBLigacoesDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBLigacoesDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBLigacoesDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBLigacoesDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBLigacoesDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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