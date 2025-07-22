// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBDivisaoTribunal : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_DivisaoTribunal
    [XmlIgnore]
    public string TabelaNome => "DivisaoTribunal";

    public DBDivisaoTribunal()
    {
    }

#endregion
    public DBDivisaoTribunal(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBDivisaoTribunal(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: DivisaoTribunal");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_DivisaoTribunal
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFNumCodigo || pFldFJustica || pFldFNomeEspecial || pFldFArea || pFldFCidade || pFldFForo || pFldFTribunal || pFldFCodigoDiv || pFldFEndereco || pFldFFone || pFldFFax || pFldFCEP || pFldFObs || pFldFEMail || pFldFAndar || pFldFEtiqueta || pFldFBold))
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
        if (pFldFNumCodigo)
            clsW.Fields(DBDivisaoTribunalDicInfo.NumCodigo, m_FNumCodigo, ETiposCampos.FNumberNull);
        if (pFldFJustica)
            clsW.Fields(DBDivisaoTribunalDicInfo.Justica, m_FJustica, ETiposCampos.FNumberNull);
        if (pFldFNomeEspecial)
            clsW.Fields(DBDivisaoTribunalDicInfo.NomeEspecial, m_FNomeEspecial, ETiposCampos.FString);
        if (pFldFArea)
            clsW.Fields(DBDivisaoTribunalDicInfo.Area, m_FArea, ETiposCampos.FNumberNull);
        if (pFldFCidade)
            clsW.Fields(DBDivisaoTribunalDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFForo)
            clsW.Fields(DBDivisaoTribunalDicInfo.Foro, m_FForo, ETiposCampos.FNumberNull);
        if (pFldFTribunal)
            clsW.Fields(DBDivisaoTribunalDicInfo.Tribunal, m_FTribunal, ETiposCampos.FNumberNull);
        if (pFldFCodigoDiv)
            clsW.Fields(DBDivisaoTribunalDicInfo.CodigoDiv, m_FCodigoDiv, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBDivisaoTribunalDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBDivisaoTribunalDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBDivisaoTribunalDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBDivisaoTribunalDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFObs)
            clsW.Fields(DBDivisaoTribunalDicInfo.Obs, m_FObs, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBDivisaoTribunalDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFAndar)
            clsW.Fields(DBDivisaoTribunalDicInfo.Andar, m_FAndar, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBDivisaoTribunalDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBDivisaoTribunalDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBDivisaoTribunalDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_DivisaoTribunal)
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
            clsW.Fields(DBDivisaoTribunalDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBDivisaoTribunalDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBDivisaoTribunalDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBDivisaoTribunalDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBDivisaoTribunalDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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