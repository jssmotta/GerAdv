// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtualAcessos : XCodeIdBase, ICadastros
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PontoVirtualAcessos)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBPontoVirtualAcessos();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_PontoVirtualAcessos
    [XmlIgnore]
    public string TabelaNome => "PontoVirtualAcessos";

    public DBPontoVirtualAcessos()
    {
    }

#endregion
    public DBPontoVirtualAcessos(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    // REF. 250325
    public DBPontoVirtualAcessos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: PontoVirtualAcessos");
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
#region GravarDados_PontoVirtualAcessos
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFOperador || pFldFDataHora || pFldFTipo || pFldFOrigem))
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
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_PontoVirtualAcessos)
#endif
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (pFldFOperador)
            clsW.Fields(DBPontoVirtualAcessosDicInfo.Operador, m_FOperador, ETiposCampos.FNumberNull);
        if (pFldFDataHora)
            clsW.Fields(DBPontoVirtualAcessosDicInfo.DataHora, m_FDataHora, ETiposCampos.FDate);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBPontoVirtualAcessosDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFOrigem)
            clsW.Fields(DBPontoVirtualAcessosDicInfo.Origem, m_FOrigem, ETiposCampos.FString);
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