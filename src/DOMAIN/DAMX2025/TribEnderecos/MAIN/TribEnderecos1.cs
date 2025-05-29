// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBTribEnderecos : XCodeIdBase, ICadastros
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_TribEnderecos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBTribEnderecos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_TribEnderecos
    [XmlIgnore]
    public string TabelaNome => "TribEnderecos";

    public DBTribEnderecos()
    {
    }

#endregion
    public DBTribEnderecos(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBTribEnderecos(MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: TribEnderecos");
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
#region GravarDados_TribEnderecos
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFTribunal || pFldFCidade || pFldFEndereco || pFldFCEP || pFldFFone || pFldFFax || pFldFOBS))
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
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_TribEnderecos)
#endif
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (pFldFTribunal)
            clsW.Fields(DBTribEnderecosDicInfo.Tribunal, m_FTribunal, ETiposCampos.FNumberNull);
        if (pFldFCidade)
            clsW.Fields(DBTribEnderecosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFEndereco)
            clsW.Fields(DBTribEnderecosDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBTribEnderecosDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBTribEnderecosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBTribEnderecosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBTribEnderecosDicInfo.OBS, m_FOBS, ETiposCampos.FString);
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