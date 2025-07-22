// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_HorasTrab
    [XmlIgnore]
    public string TabelaNome => "HorasTrab";

    public DBHorasTrab()
    {
    }

#endregion
    public DBHorasTrab(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBHorasTrab(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: HorasTrab");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_HorasTrab
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFIDContatoCRM || pFldFHonorario || pFldFIDAgenda || pFldFData || pFldFCliente || pFldFStatus || pFldFProcesso || pFldFAdvogado || pFldFFuncionario || pFldFHrIni || pFldFHrFim || pFldFTempo || pFldFValor || pFldFOBS || pFldFAnexo || pFldFAnexoComp || pFldFAnexoUNC || pFldFServico))
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
        if (pFldFIDContatoCRM)
            clsW.Fields(DBHorasTrabDicInfo.IDContatoCRM, m_FIDContatoCRM, ETiposCampos.FNumberNull);
        if (pFldFHonorario || ID.IsEmptyIDNumber())
            clsW.Fields(DBHorasTrabDicInfo.Honorario, m_FHonorario, ETiposCampos.FBoolean);
        if (pFldFIDAgenda)
            clsW.Fields(DBHorasTrabDicInfo.IDAgenda, m_FIDAgenda, ETiposCampos.FNumberNull);
        if (pFldFData)
            clsW.Fields(DBHorasTrabDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFCliente)
            clsW.Fields(DBHorasTrabDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFStatus)
            clsW.Fields(DBHorasTrabDicInfo.Status, m_FStatus, ETiposCampos.FNumberNull);
        if (pFldFProcesso)
            clsW.Fields(DBHorasTrabDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFAdvogado)
            clsW.Fields(DBHorasTrabDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFFuncionario)
            clsW.Fields(DBHorasTrabDicInfo.Funcionario, m_FFuncionario, ETiposCampos.FNumberNull);
        if (pFldFHrIni)
            clsW.Fields(DBHorasTrabDicInfo.HrIni, m_FHrIni, ETiposCampos.FString);
        if (pFldFHrFim)
            clsW.Fields(DBHorasTrabDicInfo.HrFim, m_FHrFim, ETiposCampos.FString);
        if (pFldFTempo)
            clsW.Fields(DBHorasTrabDicInfo.Tempo, m_FTempo, ETiposCampos.FDecimal);
        if (pFldFValor)
            clsW.Fields(DBHorasTrabDicInfo.Valor, m_FValor, ETiposCampos.FDecimal);
        if (pFldFOBS)
            clsW.Fields(DBHorasTrabDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFAnexo)
            clsW.Fields(DBHorasTrabDicInfo.Anexo, m_FAnexo, ETiposCampos.FString);
        if (pFldFAnexoComp)
            clsW.Fields(DBHorasTrabDicInfo.AnexoComp, m_FAnexoComp, ETiposCampos.FString);
        if (pFldFAnexoUNC)
            clsW.Fields(DBHorasTrabDicInfo.AnexoUNC, m_FAnexoUNC, ETiposCampos.FString);
        if (pFldFServico)
            clsW.Fields(DBHorasTrabDicInfo.Servico, m_FServico, ETiposCampos.FNumberNull);
        if (pFldFGUID)
            clsW.Fields(DBHorasTrabDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_HorasTrab)
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
            clsW.Fields(DBHorasTrabDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBHorasTrabDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBHorasTrabDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBHorasTrabDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBHorasTrabDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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