// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRecords : XCodeIdBase, ICadastros
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_AgendaRecords)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBAgendaRecords();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_AgendaRecords
    [XmlIgnore]
    public string TabelaNome => "AgendaRecords";

    public DBAgendaRecords()
    {
    }

#endregion
    public DBAgendaRecords(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBAgendaRecords(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: AgendaRecords");
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
#region GravarDados_AgendaRecords
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFAgenda || pFldFJulgador || pFldFClientesSocios || pFldFPerito || pFldFColaborador || pFldFForo || pFldFAviso1 || pFldFAviso2 || pFldFAviso3 || pFldFCrmAviso1 || pFldFCrmAviso2 || pFldFCrmAviso3 || pFldFDataAviso1 || pFldFDataAviso2 || pFldFDataAviso3))
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
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_AgendaRecords)
#endif
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (pFldFAgenda)
            clsW.Fields(DBAgendaRecordsDicInfo.Agenda, m_FAgenda, ETiposCampos.FNumberNull);
        if (pFldFJulgador)
            clsW.Fields(DBAgendaRecordsDicInfo.Julgador, m_FJulgador, ETiposCampos.FNumberNull);
        if (pFldFClientesSocios)
            clsW.Fields(DBAgendaRecordsDicInfo.ClientesSocios, m_FClientesSocios, ETiposCampos.FNumberNull);
        if (pFldFPerito)
            clsW.Fields(DBAgendaRecordsDicInfo.Perito, m_FPerito, ETiposCampos.FNumberNull);
        if (pFldFColaborador)
            clsW.Fields(DBAgendaRecordsDicInfo.Colaborador, m_FColaborador, ETiposCampos.FNumberNull);
        if (pFldFForo)
            clsW.Fields(DBAgendaRecordsDicInfo.Foro, m_FForo, ETiposCampos.FNumberNull);
        if (pFldFAviso1 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRecordsDicInfo.Aviso1, m_FAviso1, ETiposCampos.FBoolean);
        if (pFldFAviso2 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRecordsDicInfo.Aviso2, m_FAviso2, ETiposCampos.FBoolean);
        if (pFldFAviso3 || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRecordsDicInfo.Aviso3, m_FAviso3, ETiposCampos.FBoolean);
        if (pFldFCrmAviso1)
            clsW.Fields(DBAgendaRecordsDicInfo.CrmAviso1, m_FCrmAviso1, ETiposCampos.FNumberNull);
        if (pFldFCrmAviso2)
            clsW.Fields(DBAgendaRecordsDicInfo.CrmAviso2, m_FCrmAviso2, ETiposCampos.FNumberNull);
        if (pFldFCrmAviso3)
            clsW.Fields(DBAgendaRecordsDicInfo.CrmAviso3, m_FCrmAviso3, ETiposCampos.FNumberNull);
        if (pFldFDataAviso1)
            clsW.Fields(DBAgendaRecordsDicInfo.DataAviso1, m_FDataAviso1, ETiposCampos.FDate);
        if (pFldFDataAviso2)
            clsW.Fields(DBAgendaRecordsDicInfo.DataAviso2, m_FDataAviso2, ETiposCampos.FDate);
        if (pFldFDataAviso3)
            clsW.Fields(DBAgendaRecordsDicInfo.DataAviso3, m_FDataAviso3, ETiposCampos.FDate);
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