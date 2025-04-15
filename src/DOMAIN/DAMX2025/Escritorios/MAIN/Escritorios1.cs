// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBEscritorios : VAuditor, ICadastros, IAuditor, IListagemCidade
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Escritorios)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBEscritorios();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_Escritorios
    [XmlIgnore]
    public string TabelaNome => "Escritorios";

    public DBEscritorios()
    {
    }

#endregion
    public DBEscritorios(in int nCodigo, SqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
    public DBEscritorios(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
    public DBEscritorios(in string? sqlWhere, SqlConnection? oCnn)
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
#region GravarDados_Escritorios
#if (forWeb)
                private int UpdateX(SqlConnection? oCnn, int insertId = 0)
#else
    public int Update(SqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCNPJ || pFldFCasa || pFldFParceria || pFldFNome || pFldFOAB || pFldFEndereco || pFldFCidade || pFldFBairro || pFldFCEP || pFldFFone || pFldFFax || pFldFSite || pFldFEMail || pFldFOBS || pFldFAdvResponsavel || pFldFSecretaria || pFldFInscEst || pFldFCorrespondente || pFldFTop || pFldFEtiqueta || pFldFBold))
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
            throw new Exception("Campo 'escNome' está vazio!");
        }

        var clsW = new DBToolWTable32(PTabelaNome, CampoCodigo, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
            if (insertId == 0)
            {
            }
            else
            {
            }
        }
        else
        {
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFCNPJ)
            clsW.Fields(DBEscritoriosDicInfo.CNPJ, m_FCNPJ, ETiposCampos.FString);
        if (pFldFCasa || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Casa, m_FCasa, ETiposCampos.FBoolean);
        if (pFldFParceria || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Parceria, m_FParceria, ETiposCampos.FBoolean);
        if (pFldFNome)
            clsW.Fields(DBEscritoriosDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFOAB)
            clsW.Fields(DBEscritoriosDicInfo.OAB, m_FOAB, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBEscritoriosDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBEscritoriosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFBairro)
            clsW.Fields(DBEscritoriosDicInfo.Bairro, m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBEscritoriosDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBEscritoriosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBEscritoriosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFSite)
            clsW.Fields(DBEscritoriosDicInfo.Site, m_FSite, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBEscritoriosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFOBS)
            clsW.Fields(DBEscritoriosDicInfo.OBS, m_FOBS, ETiposCampos.FString);
        if (pFldFAdvResponsavel)
            clsW.Fields(DBEscritoriosDicInfo.AdvResponsavel, m_FAdvResponsavel, ETiposCampos.FString);
        if (pFldFSecretaria)
            clsW.Fields(DBEscritoriosDicInfo.Secretaria, m_FSecretaria, ETiposCampos.FString);
        if (pFldFInscEst)
            clsW.Fields(DBEscritoriosDicInfo.InscEst, m_FInscEst, ETiposCampos.FString);
        if (pFldFCorrespondente || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Correspondente, m_FCorrespondente, ETiposCampos.FBoolean);
        if (pFldFTop || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Top, m_FTop, ETiposCampos.FBoolean);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBEscritoriosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_Escritorios)
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
            clsW.Fields(DBEscritoriosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBEscritoriosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBEscritoriosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBEscritoriosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBEscritoriosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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