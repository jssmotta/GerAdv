// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgenda2Agenda : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Agenda2Agenda)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBAgenda2Agenda();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Agenda2Agenda
    [XmlIgnore]
    public string TabelaNome => "Agenda2Agenda";

    public DBAgenda2Agenda()
    {
    }

#endregion
    public DBAgenda2Agenda(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBAgenda2Agenda(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: Agenda2Agenda");
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
#region GravarDados_Agenda2Agenda
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFMaster || pFldFAgenda))
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

        if (pFldFMaster)
            clsW.Fields(DBAgenda2AgendaDicInfo.Master, m_FMaster, ETiposCampos.FNumberNull);
        if (pFldFAgenda)
            clsW.Fields(DBAgenda2AgendaDicInfo.Agenda, m_FAgenda, ETiposCampos.FNumberNull);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Agenda2Agenda)
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
            clsW.Fields(DBAgenda2AgendaDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAgenda2AgendaDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAgenda2AgendaDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAgenda2AgendaDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgenda2AgendaDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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