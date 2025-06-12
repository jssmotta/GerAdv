// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAlarmSMS : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_AlarmSMS)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBAlarmSMS();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_AlarmSMS
    [XmlIgnore]
    public string TabelaNome => "AlarmSMS";

    public DBAlarmSMS()
    {
    }

#endregion
    public DBAlarmSMS(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBAlarmSMS(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBAlarmSMS(in string? sqlWhere, MsiSqlConnection? oCnn)
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
#region GravarDados_AlarmSMS
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFDescricao || pFldFHora || pFldFMinuto || pFldFD1 || pFldFD2 || pFldFD3 || pFldFD4 || pFldFD5 || pFldFD6 || pFldFD7 || pFldFEMail || pFldFDesativar || pFldFToday || pFldFExcetoDiasFelizes || pFldFDesktop || pFldFAlertarDataHora || pFldFOperador || pFldFAgenda || pFldFRecado || pFldFEmocao))
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
        if (this.FDescricao.IsEmpty())
        {
            throw new Exception("Campo 'alrDescricao' está vazio!");
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
        if (pFldFDescricao)
            clsW.Fields(DBAlarmSMSDicInfo.Descricao, m_FDescricao, ETiposCampos.FString);
        if (pFldFHora)
            clsW.Fields(DBAlarmSMSDicInfo.Hora, m_FHora, ETiposCampos.FNumberNull);
        if (pFldFMinuto)
            clsW.Fields(DBAlarmSMSDicInfo.Minuto, m_FMinuto, ETiposCampos.FNumberNull);
        if (pFldFD1 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D1, m_FD1, ETiposCampos.FBoolean);
        if (pFldFD2 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D2, m_FD2, ETiposCampos.FBoolean);
        if (pFldFD3 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D3, m_FD3, ETiposCampos.FBoolean);
        if (pFldFD4 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D4, m_FD4, ETiposCampos.FBoolean);
        if (pFldFD5 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D5, m_FD5, ETiposCampos.FBoolean);
        if (pFldFD6 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D6, m_FD6, ETiposCampos.FBoolean);
        if (pFldFD7 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.D7, m_FD7, ETiposCampos.FBoolean);
        if (pFldFEMail)
            clsW.Fields(DBAlarmSMSDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFDesativar || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.Desativar, m_FDesativar, ETiposCampos.FBoolean);
        if (pFldFToday)
            clsW.Fields(DBAlarmSMSDicInfo.Today, m_FToday, ETiposCampos.FDate);
        if (pFldFExcetoDiasFelizes || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.ExcetoDiasFelizes, m_FExcetoDiasFelizes, ETiposCampos.FBoolean);
        if (pFldFDesktop || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.Desktop, m_FDesktop, ETiposCampos.FBoolean);
        if (pFldFAlertarDataHora)
            clsW.Fields(DBAlarmSMSDicInfo.AlertarDataHora, m_FAlertarDataHora, ETiposCampos.FDate);
        if (pFldFOperador)
            clsW.Fields(DBAlarmSMSDicInfo.Operador, m_FOperador, ETiposCampos.FNumberNull);
        if (pFldFGuidExo)
            clsW.Fields(DBAlarmSMSDicInfo.GuidExo, m_FGuidExo, ETiposCampos.FString);
        if (pFldFAgenda)
            clsW.Fields(DBAlarmSMSDicInfo.Agenda, m_FAgenda, ETiposCampos.FNumberNull);
        if (pFldFRecado)
            clsW.Fields(DBAlarmSMSDicInfo.Recado, m_FRecado, ETiposCampos.FNumberNull);
        if (pFldFEmocao)
            clsW.Fields(DBAlarmSMSDicInfo.Emocao, m_FEmocao, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBAlarmSMSDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_AlarmSMS)
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
            clsW.Fields(DBAlarmSMSDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAlarmSMSDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAlarmSMSDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAlarmSMSDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAlarmSMSDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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