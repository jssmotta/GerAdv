// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBInstancia : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Instancia)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBInstancia();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Instancia
    [XmlIgnore]
    public string TabelaNome => "Instancia";

    public DBInstancia()
    {
    }

#endregion
    public DBInstancia(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBInstancia(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBInstancia(in string? sqlWhere, SqlConnection? oCnn)
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
#region GravarDados_Instancia
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFLiminarPedida || pFldFObjeto || pFldFStatusResultado || pFldFLiminarPendente || pFldFInterpusemosRecurso || pFldFLiminarConcedida || pFldFLiminarNegada || pFldFProcesso || pFldFData || pFldFLiminarParcial || pFldFLiminarResultado || pFldFNroProcesso || pFldFDivisao || pFldFLiminarCliente || pFldFComarca || pFldFSubDivisao || pFldFPrincipal || pFldFAcao || pFldFForo || pFldFTipoRecurso || pFldFZKey || pFldFZKeyQuem || pFldFZKeyQuando || pFldFNroAntigo || pFldFAccessCode || pFldFJulgador || pFldFZKeyIA))
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
        if (pFldFLiminarPedida)
            clsW.Fields(DBInstanciaDicInfo.LiminarPedida, m_FLiminarPedida, ETiposCampos.FString);
        if (pFldFObjeto)
            clsW.Fields(DBInstanciaDicInfo.Objeto, m_FObjeto, ETiposCampos.FString);
        if (pFldFStatusResultado)
            clsW.Fields(DBInstanciaDicInfo.StatusResultado, m_FStatusResultado, ETiposCampos.FNumberNull);
        if (pFldFLiminarPendente || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.LiminarPendente, m_FLiminarPendente, ETiposCampos.FBoolean);
        if (pFldFInterpusemosRecurso || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.InterpusemosRecurso, m_FInterpusemosRecurso, ETiposCampos.FBoolean);
        if (pFldFLiminarConcedida || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.LiminarConcedida, m_FLiminarConcedida, ETiposCampos.FBoolean);
        if (pFldFLiminarNegada || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.LiminarNegada, m_FLiminarNegada, ETiposCampos.FBoolean);
        if (pFldFProcesso)
            clsW.Fields(DBInstanciaDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBInstanciaDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFLiminarParcial || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.LiminarParcial, m_FLiminarParcial, ETiposCampos.FBoolean);
        if (pFldFLiminarResultado)
            clsW.Fields(DBInstanciaDicInfo.LiminarResultado, m_FLiminarResultado, ETiposCampos.FString);
        if (pFldFNroProcesso)
            clsW.Fields(DBInstanciaDicInfo.NroProcesso, m_FNroProcesso, ETiposCampos.FString);
        if (pFldFDivisao)
            clsW.Fields(DBInstanciaDicInfo.Divisao, m_FDivisao, ETiposCampos.FNumberNull);
        if (pFldFLiminarCliente || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.LiminarCliente, m_FLiminarCliente, ETiposCampos.FBoolean);
        if (pFldFComarca)
            clsW.Fields(DBInstanciaDicInfo.Comarca, m_FComarca, ETiposCampos.FNumberNull);
        if (pFldFSubDivisao)
            clsW.Fields(DBInstanciaDicInfo.SubDivisao, m_FSubDivisao, ETiposCampos.FNumberNull);
        if (pFldFPrincipal || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.Principal, m_FPrincipal, ETiposCampos.FBoolean);
        if (pFldFAcao)
            clsW.Fields(DBInstanciaDicInfo.Acao, m_FAcao, ETiposCampos.FNumberNull);
        if (pFldFForo)
            clsW.Fields(DBInstanciaDicInfo.Foro, m_FForo, ETiposCampos.FNumberNull);
        if (pFldFTipoRecurso)
            clsW.Fields(DBInstanciaDicInfo.TipoRecurso, m_FTipoRecurso, ETiposCampos.FNumberNull);
        if (pFldFZKey)
            clsW.Fields(DBInstanciaDicInfo.ZKey, m_FZKey, ETiposCampos.FString);
        if (pFldFZKeyQuem)
            clsW.Fields(DBInstanciaDicInfo.ZKeyQuem, m_FZKeyQuem, ETiposCampos.FNumberNull);
        if (pFldFZKeyQuando)
            clsW.Fields(DBInstanciaDicInfo.ZKeyQuando, m_FZKeyQuando, ETiposCampos.FDate);
        if (pFldFNroAntigo)
            clsW.Fields(DBInstanciaDicInfo.NroAntigo, m_FNroAntigo, ETiposCampos.FString);
        if (pFldFAccessCode)
            clsW.Fields(DBInstanciaDicInfo.AccessCode, m_FAccessCode, ETiposCampos.FString);
        if (pFldFJulgador)
            clsW.Fields(DBInstanciaDicInfo.Julgador, m_FJulgador, ETiposCampos.FNumberNull);
        if (pFldFZKeyIA)
            clsW.Fields(DBInstanciaDicInfo.ZKeyIA, m_FZKeyIA, ETiposCampos.FString);
        if (pFldFGUID)
            clsW.Fields(DBInstanciaDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Instancia)
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
            clsW.Fields(DBInstanciaDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBInstanciaDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBInstanciaDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBInstanciaDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBInstanciaDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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