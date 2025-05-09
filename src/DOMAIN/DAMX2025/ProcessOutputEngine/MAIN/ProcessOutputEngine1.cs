// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputEngine : XCodeIdBase, ICadastros
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ProcessOutputEngine)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBProcessOutputEngine();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ProcessOutputEngine
    [XmlIgnore]
    public string TabelaNome => "ProcessOutputEngine";

    public DBProcessOutputEngine()
    {
    }

#endregion
    public DBProcessOutputEngine(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBProcessOutputEngine(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
        else
        {
            using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[{PTabelaNome}] (NOLOCK) WHERE [{CampoNome}]  COLLATE SQL_Latin1_General_CP1_CI_AI  like @CampoNome", oCnn);
            cmd.Parameters.AddWithValue("@CampoNome", cNome?.trim() ?? string.Empty);
            using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    public DBProcessOutputEngine(in string? sqlWhere, SqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#if (forWeb)
public int Update(SqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_ProcessOutputEngine
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNome || pFldFDatabase || pFldFTabela || pFldFCampo || pFldFValor || pFldFOutput || pFldFAdministrador || pFldFOutputSource || pFldFDisabledItem || pFldFIDModulo || pFldFIsOnlyProcesso || pFldFMyID || pFldFGUID))
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
            throw new Exception("Campo 'poeNome' está vazio!");
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
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ProcessOutputEngine)
#endif
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFNome)
            clsW.Fields(DBProcessOutputEngineDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFDatabase)
            clsW.Fields(DBProcessOutputEngineDicInfo.Database, m_FDatabase, ETiposCampos.FString);
        if (pFldFTabela)
            clsW.Fields(DBProcessOutputEngineDicInfo.Tabela, m_FTabela, ETiposCampos.FString);
        if (pFldFCampo)
            clsW.Fields(DBProcessOutputEngineDicInfo.Campo, m_FCampo, ETiposCampos.FString);
        if (pFldFValor)
            clsW.Fields(DBProcessOutputEngineDicInfo.Valor, m_FValor, ETiposCampos.FString);
        if (pFldFOutput)
            clsW.Fields(DBProcessOutputEngineDicInfo.Output, m_FOutput, ETiposCampos.FString);
        if (pFldFAdministrador || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessOutputEngineDicInfo.Administrador, m_FAdministrador, ETiposCampos.FBoolean);
        if (pFldFOutputSource)
            clsW.Fields(DBProcessOutputEngineDicInfo.OutputSource, m_FOutputSource, ETiposCampos.FNumberNull);
        if (pFldFDisabledItem || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessOutputEngineDicInfo.DisabledItem, m_FDisabledItem, ETiposCampos.FBoolean);
        if (pFldFIDModulo)
            clsW.Fields(DBProcessOutputEngineDicInfo.IDModulo, m_FIDModulo, ETiposCampos.FNumberNull);
        if (pFldFIsOnlyProcesso || ID.IsEmptyIDNumber())
            clsW.Fields(DBProcessOutputEngineDicInfo.IsOnlyProcesso, m_FIsOnlyProcesso, ETiposCampos.FBoolean);
        if (pFldFMyID)
            clsW.Fields(DBProcessOutputEngineDicInfo.MyID, m_FMyID, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBProcessOutputEngineDicInfo.GUID, m_FGUID, ETiposCampos.FString);
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