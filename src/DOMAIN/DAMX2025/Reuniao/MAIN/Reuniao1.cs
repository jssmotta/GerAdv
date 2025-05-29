// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBReuniao : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Reuniao)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBReuniao();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Reuniao
    [XmlIgnore]
    public string TabelaNome => "Reuniao";

    public DBReuniao()
    {
    }

#endregion
    public DBReuniao(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBReuniao(MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql))
        {
            if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
            {
                using var ds = ConfiguracoesDBT.GetDataTable(fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
                if (ds != null)
                    CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
            }
            else
            {
                throw new Exception("Erro de parâmetros sqlWhere: Reuniao");
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
public int Update(MsiSqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_Reuniao
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCliente || pFldFIDAgenda || pFldFData || pFldFPauta || pFldFATA || pFldFHoraInicial || pFldFHoraFinal || pFldFExterna || pFldFHoraSaida || pFldFHoraRetorno || pFldFPrincipaisDecisoes || pFldFBold))
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
        if (pFldFCliente)
            clsW.Fields(DBReuniaoDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFIDAgenda)
            clsW.Fields(DBReuniaoDicInfo.IDAgenda, m_FIDAgenda, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBReuniaoDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFPauta)
            clsW.Fields(DBReuniaoDicInfo.Pauta, m_FPauta, ETiposCampos.FString);
        if (pFldFATA)
            clsW.Fields(DBReuniaoDicInfo.ATA, m_FATA, ETiposCampos.FString);
        if (pFldFHoraInicial)
            clsW.Fields(DBReuniaoDicInfo.HoraInicial, m_FHoraInicial, ETiposCampos.FDate);
        if (pFldFHoraFinal)
            clsW.Fields(DBReuniaoDicInfo.HoraFinal, m_FHoraFinal, ETiposCampos.FDate);
        if (pFldFExterna || ID.IsEmptyIDNumber())
            clsW.Fields(DBReuniaoDicInfo.Externa, m_FExterna, ETiposCampos.FBoolean);
        if (pFldFHoraSaida)
            clsW.Fields(DBReuniaoDicInfo.HoraSaida, m_FHoraSaida, ETiposCampos.FDate);
        if (pFldFHoraRetorno)
            clsW.Fields(DBReuniaoDicInfo.HoraRetorno, m_FHoraRetorno, ETiposCampos.FDate);
        if (pFldFPrincipaisDecisoes)
            clsW.Fields(DBReuniaoDicInfo.PrincipaisDecisoes, m_FPrincipaisDecisoes, ETiposCampos.FString);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBReuniaoDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBReuniaoDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Reuniao)
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
            clsW.Fields(DBReuniaoDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBReuniaoDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBReuniaoDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBReuniaoDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBReuniaoDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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